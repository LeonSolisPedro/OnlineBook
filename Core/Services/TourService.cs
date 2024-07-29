using Core.Dto;
using Core.Entites._Tour;
using Core.Repositories;
using HtmlAgilityPack;
using Slugify;

namespace Core.Services;

public class TourService
{
  private readonly ITourRepository _tourRepository;

  public TourService(ITourRepository tourRepository)
  {
    _tourRepository = tourRepository;
  }

  public async Task<Tour?> GetTour(int id)
  {
    return await _tourRepository.GetTour(id);
  }


  public async Task<List<TourCardDTO>> GetList()
  {
    var list = await _tourRepository.GetList(idAgency: 1);
    return ConvertCardDto(list);
  }


  public async Task<List<TourCardDTO>> GetList(int idCategory)
  {
    var list = await _tourRepository.GetList(idAgency: 1, idCategory);
    return ConvertCardDto(list);
  }

  private List<TourCardDTO> ConvertCardDto(List<Tour> list)
    {
        var listDto = new List<TourCardDTO>();
        foreach (var li in list)
        {
            if (li.TourDirection == null) continue;

            var html = new HtmlDocument();
            var helper = new SlugHelper();
            html.LoadHtml(li.Description);
            var description = html.DocumentNode.InnerText;
            var image = li.TourGalleryImages?.FirstOrDefault()?.ImagePreview ?? "";
            var url = $"/tours/{helper.GenerateSlug(li.TourDirection.Name)}/{helper.GenerateSlug(li.Title)}/{li.Id}";
            var durationWord = li.DurationType == Enums.DurationType.HOURS ? "Horas" : "Días";
            durationWord = li.Duration == 1 ? durationWord.Replace("s", "") : durationWord;
            var duration = $"{li.Duration} {durationWord}";
            li.TourSearchQueryCompositions = li.TourSearchQueryCompositions?.Select(x => {x.Tour = null; return x;} ).ToList();
            li.TourDirection.Tours = null;

            listDto.Add(new TourCardDTO
            {
                Id = li.Id,
                Image = image,
                Title = li.Title,
                Description = description,
                URL = url,
                Duration = duration,
                TourSearchQueries = li.TourSearchQueryCompositions,
                TourDirection = li.TourDirection,
                PriceInMXN = 0m
            });
        }
        return listDto;
    }
}
