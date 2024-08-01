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

  public async Task<TourDTO?> GetTour(int id)
  {
    TourDTO? tourDto = null;
    try
    {
      //Checamos del cache si el tour existe
      var tourIds = _cache.Get<List<int>>("ListToursIds");
      var exists = tourIds.Any(x => x == id);
      if(exists == false) return null;

      //Obtenemos el cache
      var cache = _cache.Get<TourDTO>($"Tour.GetTour1{id}");
      if (cache != null) return cache;

      var tour = await _tourRepository.GetTour(id);
      if (tour == null) return null;
      tour.TourDirection ??= new TourDirection();

      var similar = await _tourRepository.GetTourSimilar(id);
      var tourSimilar = similar.SelectMany(x => new List<Tour> { x.Tour1, x.Tour2 }).Where(x => x.Id != 1).Distinct().ToList();
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
}
