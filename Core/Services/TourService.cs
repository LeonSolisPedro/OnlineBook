using Core.Dto;
using Core.Entites._Tour;
using Core.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class TourService
{
  private readonly ITourRepository _tourRepository;
  private readonly ConvertService _convertService;
  private readonly ILogger<TourService> _logger;
  private readonly IMemoryCache _cache;

  public TourService(ITourRepository tourRepository, ConvertService convertService, ILogger<TourService> logger, IMemoryCache cache)
  {
    _tourRepository = tourRepository;
    _convertService = convertService;
    _logger = logger;
    _cache = cache;
  }


  public async Task<List<TourCardDTO>> GetList()
  {
    var list = new List<TourCardDTO>();
    try
    {
      var cache = _cache.Get<List<TourCardDTO>>("Tour.GetList1");
      if (cache != null) return cache;

      var oList = await _tourRepository.GetList(idAgency: 1);
      list = _convertService.ConvertCardDto(oList);
      return _cache.Set("Tour.GetList1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  // PORFAVOR: Tira un 404 antes de que este metodo se llame si no existe el idCategoria
  // Pero tiralo desde el cliente, aqui no se va a tirar nada.
  public async Task<List<TourCardDTO>> GetList(int idCategory)
  {
    var list = new List<TourCardDTO>();
    try
    {
      var cache = _cache.Get<List<TourCardDTO>>($"Tour.GetList1{idCategory}");
      if (cache != null) return cache;

      var oList = await _tourRepository.GetList(idAgency: 1, idCategory);
      list = _convertService.ConvertCardDto(oList);
      return _cache.Set($"Tour.GetList1{idCategory}", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }



  public async Task<TourDTO?> GetTour(int id)
  {
    TourDTO? tourDto = null;
    try
    {
      //Checamos si el tour existe
      var tourIds = _cache.Get<List<int>>("ListToursIds");
      var exists = tourIds?.Any(x => x == id) ?? false;
      if (exists == false) return null;

      //Obtenemos el cache
      var cache = _cache.Get<TourDTO>($"Tour.GetTour1{id}");
      if (cache != null) return cache;

      var tour = await _tourRepository.GetTour(id);
      if (tour == null) return null;
      tour.TourDirection ??= new TourDirection();

      var similar = await _tourRepository.GetTourSimilar(id);
      var tourSimilar = similar.SelectMany(x => new List<Tour> { x.Tour1, x.Tour2 }).Where(x => x.Id != id).Distinct().ToList();
      var tourSimilarDto = _convertService.ConvertCardDto(tourSimilar);
      var duration = _convertService.DurationToString(tour.Duration, tour.DurationType);
      var image = tour.TourGalleryImages?.FirstOrDefault()?.Image ?? "";

      tour.TourDirection.Tours = null;
      tourSimilarDto = tourSimilarDto.Select(x => { x.TourDirection = null; return x; }).ToList();
      tour.TourIncludes = tour.TourIncludes?.Select(x => { x.Tour = null; return x; }).ToList();
      tour.TourGalleryImages = tour.TourGalleryImages?.Select(x => { x.Tour = null; return x; }).ToList();
      tour.TourItineraries = tour.TourItineraries?.Select(x => { x.Tour = null; return x; }).ToList();

      tourDto = new TourDTO
      {
        Id = tour.Id,
        Title = tour.Title,
        Image = image,
        MetaKeywords = tour.MetaKeywords,
        Description = tour.Description,
        LinkVideo = tour.LinkVideo,
        LinkPDFItinerary = tour.LinkPDFItinerary,
        Duration = duration,
        PriceInMXN = 0m,
        TourDirection = tour.TourDirection,
        TourIncludes = tour.TourIncludes,
        TourSimilar = tourSimilarDto,
        TourItineraries = tour.TourItineraries,
        TourGalleryImages = tour.TourGalleryImages
      };
      return _cache.Set($"Tour.GetTour1{id}", tourDto);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return null;
  }


  public async Task<GetDatesDTO?> GetDates(int idTour)
  {
    GetDatesDTO? dateDTO = null;
    try
    {
      //Checa si hay fechas disponibles hoy
      var date = await _tourRepository.GetDates(idTour);
      if (date == null) return null;
      if (date.Tour == null) return null;
      var notworkingweekdays = date.TourNotWorkingWeekDays?.Select(x => x.Day).ToList() ?? [];
      var notworkingdays = date.TourNotWorkingDays?.Select(x => x.Day).ToList() ?? [];

      dateDTO = new GetDatesDTO
      {
        IdTourDatePricing = date.Id,
        TourType = date.Tour.TourType,
        ReservationInterval = date.ReservationInterval,
        Duration = date.Tour.Duration,
        StartDate = DateOnly.FromDateTime(DateTime.UtcNow),
        EndDate = date.EndDate ?? DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(3)),
        TourNotWorkingWeekDays = notworkingweekdays,
        TourNotWorkingDays = notworkingdays
      };
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return dateDTO;
  }


  public async Task<AvailableDTO> CheckAvailability(SelectedDateDTO selected)
  {
    var dto = new AvailableDTO();
    try
    {
      var date = await _tourRepository.GetAvailability(selected.IdDatePricing);
      if (date == null) return dto;
      if (date.TourDatePricingCompositions == null) return dto;
      if (!IsAvailable(selected, date)) return dto;

      //Revisamos entre las reservaciones
      //Para las reservaciones de todos los días
      //Obtenemos cual es el máximo que podemos reservar
      //Y con base a eso, por fecha, buscamos si ya se depletó
      var maximo = date.AreSettingsGlobal ? date.MaxSeats : date.TourDatePricingCompositions.Sum(x => x.TourClassPricing?.MaxSeats);
      var reservations = await _tourRepository.GetReservations(selected.IdDatePricing, selected.Dates.FirstOrDefault());
      var total = reservations.Sum(x => x.TotalOcupiedSeats);
      if (total >= maximo) return dto;

      //Please optimizar esta cosa
      date.TourDatePricingCompositions.ForEach(x => x.TourDatePricing = null);
      if (date.AreSettingsGlobal)
      {
        var maximoR = date.MaxSeats;
        var totalR = reservations.Sum(x => x.TotalOcupiedSeats);
        var valueR = maximoR - totalR;
        date.MaxSeats = valueR;
      }
      else
      {
        for (int i = 0; i < date.TourDatePricingCompositions.Count; i++)
        {
          var maximoR = date.TourDatePricingCompositions[i].TourClassPricing.MaxSeats;
          var totalR = reservations.Where(x => x.IdTourClassPricing == date.TourDatePricingCompositions[i].IdTourClassPricing).Sum(x => x.TotalOcupiedSeats);
          var valueR = maximoR - totalR;
          date.TourDatePricingCompositions[i].TourClassPricing.MaxSeats = valueR;
        }
      }

      return new AvailableDTO
      {
        IsAvailable = true,
        AreSettingsGlobal = date.AreSettingsGlobal,
        MaxSeats = date.MaxSeats,
        InfantsCountAsSeats = date.InfantsCountAsSeats,
        AllowInfants = date.AllowInfants,
        AllowMinors = date.AllowMinors,
        TourDatePricingCompositions = date.TourDatePricingCompositions
      };

    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return dto;
  }

  private bool IsAvailable(SelectedDateDTO selected, TourDatePricing? date)
  {
    //Ordenamos
    selected.Dates = selected.Dates.OrderBy(x => x).ToList();

    //Checamos si las fechas son de hoy
    var today = DateOnly.FromDateTime(DateTime.UtcNow);
    var sondeHoy = !selected.Dates.Any(x => x < today);
    if (sondeHoy == false) return false;

    //Checamos el tipo de tour
    if (date == null) return false;
    if (date.Tour == null) return false;
    if (date.TourDatePricingCompositions == null) return false;

    if (date.Tour.TourType == Enums.TourType.SINGLEDAY)
    {
      if (selected.Dates.Count > 1) return false;
    }
    if (date.Tour.TourType == Enums.TourType.MULTIDAY)
    {
      if (selected.Dates.Count != 2) return false;
    }

    //Checamos entre los weekdays
    if (date.Tour.TourType == Enums.TourType.SINGLEDAY)
    {
      var days = date.TourNotWorkingWeekDays?.Select(x => x.Day).ToList() ?? [];
      var firstDay = selected.Dates.FirstOrDefault();
      var caeEnWeekDays = days.Contains(firstDay.DayOfWeek);
      if (caeEnWeekDays) return false;
    }
    if (date.Tour.TourType == Enums.TourType.MULTIDAY)
    {
      var days = date.TourNotWorkingWeekDays?.Select(x => x.Day).ToList() ?? [];
      var firstDay = selected.Dates.FirstOrDefault();
      var secondDay = selected.Dates.LastOrDefault();
      var consecutiveDates = ConsecutiveDateList(firstDay, secondDay);
      var caeEnWeekDays = consecutiveDates.Any(x => days.Contains(x.DayOfWeek));
      if (caeEnWeekDays) return false;
    }



    //Checamos entre los not workingdays
    if (date.Tour.TourType == Enums.TourType.SINGLEDAY)
    {
      var days = date.TourNotWorkingDays?.Select(x => x.Day).ToList() ?? [];
      var firstDay = selected.Dates.FirstOrDefault();
      var caeEnWorkDays = days.Contains(firstDay);
      if (caeEnWorkDays) return false;
    }
    if (date.Tour.TourType == Enums.TourType.MULTIDAY)
    {
      var days = date.TourNotWorkingDays?.Select(x => x.Day).ToList() ?? [];
      var firstDay = selected.Dates.FirstOrDefault();
      var secondDay = selected.Dates.LastOrDefault();
      var consecutiveDates = ConsecutiveDateList(firstDay, secondDay);
      var caeEnWorkDays = consecutiveDates.Any(days.Contains);
      if (caeEnWorkDays) return false;
    }


    return true;
  }

  private List<DateOnly> ConsecutiveDateList(DateOnly startDate, DateOnly endDate)
  {
    var dateList = new List<DateOnly>();
    for (var date = startDate; date <= endDate; date = date.AddDays(1))
    {
      dateList.Add(date);
    }
    return dateList;
  }
}
