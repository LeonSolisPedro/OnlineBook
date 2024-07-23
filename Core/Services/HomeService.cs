using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Home;
using Core.Entites._Other;
using Core.Repositories;

namespace Core.Services;

public class HomeService
{
    private readonly IGenericRepository<HomeCarousel> _genericCarouselRepository;

    private readonly IGenericRepository<HomeOffer> _genericOfferRepository;

    private readonly IGenericRepository<HomeTourPopularComposition> _genericTourPopularRepository;

    private readonly IGenericRepository<OtherGallery> _genericGalleryRepository;

    public HomeService(IGenericRepository<HomeCarousel> genericCarouselRepository, IGenericRepository<HomeOffer> genericOfferRepository, IGenericRepository<HomeTourPopularComposition> genericTourPopularRepository, IGenericRepository<OtherGallery> genericGalleryRepository)
    {
        _genericCarouselRepository = genericCarouselRepository;
        _genericOfferRepository = genericOfferRepository;
        _genericTourPopularRepository = genericTourPopularRepository;
        _genericGalleryRepository = genericGalleryRepository;
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

}
