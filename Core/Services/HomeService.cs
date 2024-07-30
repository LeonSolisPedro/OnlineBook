using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dto;
using Core.Entites._Home;
using Core.Entites._Other;
using Core.Repositories;
using HtmlAgilityPack;
using Slugify;

namespace Core.Services;

public class HomeService
{
    private readonly IGenericRepository<HomeCarousel> _genericCarouselRepository;

    private readonly IGenericRepository<HomeOffer> _genericOfferRepository;

    private readonly IGenericRepository<HomeTourPopularComposition> _genericTourPopularRepository;

    private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;

    private readonly ConvertService _convertService;

    public HomeService(IGenericRepository<HomeCarousel> genericCarouselRepository, IGenericRepository<HomeOffer> genericOfferRepository, IGenericRepository<HomeTourPopularComposition> genericTourPopularRepository, IGenericRepository<OtherGallery> genericGalleryRepository, ConvertService convertService)
    {
        _genericCarouselRepository = genericCarouselRepository;
        _genericOfferRepository = genericOfferRepository;
        _genericTourPopularRepository = genericTourPopularRepository;
        _genericGalleryRepository = genericGalleryRepository;
        _convertService = convertService;
    }


    public async Task<List<HomeCarousel>> GetCarousel()
    {
        var list = await _genericCarouselRepository.GetList(x => x.IdAgency == 1);
        list = list.OrderBy(x => x.Order).ToList();
        return list;
    }

    public async Task<List<HomeOffer>> GetOffers()
    {
        return await _genericOfferRepository.GetList(x => x.IdAgency == 1 && x.IsArchived == false);
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
