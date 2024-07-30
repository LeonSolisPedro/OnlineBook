using Core.Dto;
using Core.Entites._Tour;
using Core.Repositories;
using HtmlAgilityPack;
using Slugify;

namespace Core.Services;

public class TourService
{
  private readonly ITourRepository _tourRepository;
  private readonly ConvertService _convertService;

  public TourService(ITourRepository tourRepository, ConvertService convertService)
  {
    _tourRepository = tourRepository;
    _convertService = convertService;
  }

  public async Task<TourDTO?> GetTour(int id)
  {
    var tour = await _tourRepository.GetTour(id);
    if(tour == null) return null;
    tour.TourDirection ??= new TourDirection();

    var similar = await _tourRepository.GetTourSimilar(id);
    var tourSimilar = similar.SelectMany(x => new List<Tour> { x.Tour1, x.Tour2 }).Where(x => x.Id != 1).Distinct().ToList();
    var tourSimilarDto = _convertService.ConvertCardDto(tourSimilar);
    var duration = _convertService.DurationToString(tour.Duration, tour.DurationType);
    var image = tour.TourGalleryImages?.FirstOrDefault()?.Image ?? "";

    tour.TourDirection.Tours = null;
    tourSimilarDto = tourSimilarDto.Select(x => {x.TourDirection = null; return x;}).ToList();
    tour.TourIncludes = tour.TourIncludes?.Select(x => {x.Tour = null; return x;}).ToList();
    tour.TourGalleryImages = tour.TourGalleryImages?.Select(x => { x.Tour = null; return x; }).ToList();
    tour.TourItineraries = tour.TourItineraries?.Select(x => {x.Tour = null; return x;}).ToList();

    var tourDto = new TourDTO
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
    return tourDto;
  }


  public async Task<List<TourCardDTO>> GetList()
  {
    var list = await _tourRepository.GetList(idAgency: 1);
    return _convertService.ConvertCardDto(list);
  }


  public async Task<List<TourCardDTO>> GetList(int idCategory)
  {
    // PORFAVOR: Verifica que idCategory exista usando /v1/Agency/GetTourCategories antes de llamar a este método.
    // Ya sea que tires un 404, antes de que este método se llame.
    var list = await _tourRepository.GetList(idAgency: 1, idCategory);
    return _convertService.ConvertCardDto(list);
  }
}
