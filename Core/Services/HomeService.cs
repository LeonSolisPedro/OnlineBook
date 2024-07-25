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

    public async Task<List<TourCardDTO>> GetPopularTours()
    {
        var list = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.POPULAR && x.Tour!.IsArchived == false, "Tour.TourDirection");
        return ConvertCardDto(list);
    }

    public async Task<List<TourCardDTO>> GetOtherTours()
    {
        var list = await _genericTourPopularRepository.GetList(x => x.IdAgency == 1 && x.PopularType == Enums.PopularType.OTHERTOURS && x.Tour!.IsArchived == false, "Tour.TourDirection");
        return ConvertCardDto(list);
    }

    public async Task<List<OtherGallery>> GetGalleries()
    {
        var list = await _genericGalleryRepository.GetList(x => x.IdAgency == 1 && x.IsFavorite == true);
        return list.OrderBy(x => x.Order).ToList();
    }

    private List<TourCardDTO> ConvertCardDto(List<HomeTourPopularComposition> list)
    {
        var listDto = new List<TourCardDTO>();
        foreach (var li in list)
        {
            if (li.Tour == null) continue;
            if (li.Tour.TourDirection == null) continue;

            var html = new HtmlDocument();
            var helper = new SlugHelper();
            html.LoadHtml(li.Tour.Description);
            var description = html.DocumentNode.InnerText;
            var url = $"/tours/{helper.GenerateSlug(li.Tour.TourDirection.Name)}/{helper.GenerateSlug(li.Tour.Title)}/{li.Tour.Id}";
            var durationWord = li.Tour.DurationType == Enums.DurationType.HOURS ? "Horas" : "Días";
            durationWord = li.Tour.Duration == 1 ? durationWord.Replace("s", "") : durationWord;
            var duration = $"{li.Tour.Duration} {durationWord}";

            listDto.Add(new TourCardDTO
            {
                Id = li.Id,
                Image = li.Tour.ImageThumbnail,
                Title = li.Tour.Title,
                Description = description,
                URL = url,
                Duration = duration,
                Pricing = "0.00 MXN"
            });
        }
        return listDto;
    }

}
