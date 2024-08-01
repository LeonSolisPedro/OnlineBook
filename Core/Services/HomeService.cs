using Core.Dto;
using Core.Entites._Home;
using Core.Entites._Other;
using Core.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class HomeService
{
  private readonly IGenericRepository<HomeCarousel> _genericCarouselRepository;

  private readonly IGenericRepository<HomeOffer> _genericOfferRepository;

  private readonly IGenericRepository<HomeTourPopularComposition> _genericTourPopularRepository;

  private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;

  private readonly ConvertService _convertService;

  private readonly IMemoryCache _cache;

  private readonly ILogger<HomeService> _logger;

  public HomeService(IGenericRepository<HomeCarousel> genericCarouselRepository, IGenericRepository<HomeOffer> genericOfferRepository, IGenericRepository<HomeTourPopularComposition> genericTourPopularRepository, IGenericRepository<OtherGallery> genericGalleryRepository, ConvertService convertService, IMemoryCache cache, ILogger<HomeService> logger)
  {
    _genericCarouselRepository = genericCarouselRepository;
    _genericOfferRepository = genericOfferRepository;
    _genericTourPopularRepository = genericTourPopularRepository;
    _genericGalleryRepository = genericGalleryRepository;
    _convertService = convertService;
    _cache = cache;
    _logger = logger;
  }


  public async Task<List<HomeCarousel>> GetCarousel()
  {
    var list = new List<HomeCarousel>();
    try
    {
      var cache = _cache.Get<List<HomeCarousel>>("Home.GetCarousel1");
      if (cache != null) return cache;

      list = await _genericCarouselRepository.GetList(x => x.IdAgency == 1);
      list = list.OrderBy(x => x.Order).ToList();
      return _cache.Set("Home.GetCarousel1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<List<HomeOffer>> GetOffers()
  {
    var list = new List<HomeOffer>();
    try
    {
      var cache = _cache.Get<List<HomeOffer>>("Home.GetOffers1");
      if (cache != null) return cache;

      list = await _genericOfferRepository.GetList(x => x.IdAgency == 1 && x.IsArchived == false);
      return _cache.Set("Home.GetOffers1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<List<TourCardDTO>> GetPopularTours()
  {
    var list = new List<TourCardDTO>();
    try
    {
      var cache = _cache.Get<List<TourCardDTO>>("Home.GetPopularTours1");
      if (cache != null) return cache;

      var oList = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.POPULAR && x.Tour!.IsArchived == false, "Tour.TourDirection,Tour.TourGalleryImages");
      list = _convertService.ConvertCardDto(oList);
      return _cache.Set("Home.GetPopularTours1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<List<TourCardDTO>> GetOtherTours()
  {
    var list = new List<TourCardDTO>();
    try
    {
      var cache = _cache.Get<List<TourCardDTO>>("Home.GetOtherTours1");
      if (cache != null) return cache;

      var oList = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.OTHERTOURS && x.Tour!.IsArchived == false, "Tour.TourDirection,Tour.TourGalleryImages");
      list = _convertService.ConvertCardDto(oList);
      return _cache.Set("Home.GetOtherTours1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<List<OtherGallery>> GetGalleries()
  {
    var list = new List<OtherGallery>();
    try
    {
      var cache = _cache.Get<List<OtherGallery>>("Home.GetGalleries1");
      if (cache != null) return cache;

      list = await _genericGalleryRepository.GetList(x => x.IdAgency == 1 && x.IsFavorite == true);
      list = list.OrderBy(x => x.Order).ToList();
      return _cache.Set("Home.GetGalleries1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }
}
