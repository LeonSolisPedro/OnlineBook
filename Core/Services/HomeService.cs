using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Entites._Home;
using Core.Entites._Other;
using Core.Repositories;
using HtmlAgilityPack;
using Microsoft.Extensions.Caching.Memory;
using Slugify;

namespace Core.Services;

public class HomeService
{
    private readonly IGenericRepository<HomeCarousel> _genericCarouselRepository;

    private readonly IGenericRepository<HomeOffer> _genericOfferRepository;

    private readonly IGenericRepository<HomeTourPopularComposition> _genericTourPopularRepository;

    private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;

    private readonly ConvertService _convertService;

    private readonly IMemoryCache _cache;

    public HomeService(IGenericRepository<HomeCarousel> genericCarouselRepository, IGenericRepository<HomeOffer> genericOfferRepository, IGenericRepository<HomeTourPopularComposition> genericTourPopularRepository, IGenericRepository<OtherGallery> genericGalleryRepository, ConvertService convertService, IMemoryCache cache)
    {
        _genericCarouselRepository = genericCarouselRepository;
        _genericOfferRepository = genericOfferRepository;
        _genericTourPopularRepository = genericTourPopularRepository;
        _genericGalleryRepository = genericGalleryRepository;
        _convertService = convertService;
        _cache = cache;
    }


    public async Task<List<HomeCarousel>> GetCarousel()
    {
        var cache = _cache.Get<List<HomeCarousel>>("Home.GetCarousel1");
        if (cache != null) return cache;

        var list = await _genericCarouselRepository.GetList(x => x.IdAgency == 1);
        list = list.OrderBy(x => x.Order).ToList();
        return _cache.Set("Home.GetCarousel1", list);
    }

    public async Task<List<HomeOffer>> GetOffers()
    {
        var cache = _cache.Get<List<HomeOffer>>("Home.GetOffers1");
        if (cache != null) return cache;

        var list = await _genericOfferRepository.GetList(x => x.IdAgency == 1 && x.IsArchived == false);
        return _cache.Set("Home.GetOffers1", list);
    }

    public async Task<List<TourCardDTO>> GetPopularTours()
    {
        var list = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.POPULAR && x.Tour!.IsArchived == false, "Tour.TourDirection,Tour.TourGalleryImages");
        return _convertService.ConvertCardDto(list);
    }

    public async Task<List<TourCardDTO>> GetOtherTours()
    {
        var list = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.OTHERTOURS && x.Tour!.IsArchived == false, "Tour.TourDirection,Tour.TourGalleryImages");
        return _convertService.ConvertCardDto(list);
    }

    public async Task<List<OtherGallery>> GetGalleries()
    {
        var list = await _genericGalleryRepository.GetList(x => x.IdAgency == 1 && x.IsFavorite == true);
        return list.OrderBy(x => x.Order).ToList();
    }

}
