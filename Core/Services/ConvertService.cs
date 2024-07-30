using Core.Dto;
using Core.Entites._Home;
using Core.Entites._Tour;
using HtmlAgilityPack;
using Slugify;

namespace Core.Services;

public class ConvertService
{
  public string DurationToString(int durationint, Enums.DurationType durationtype)
  {
    var durationWord = durationtype == Enums.DurationType.HOURS ? "Horas" : "Días";
    durationWord = durationint == 1 ? durationWord.Replace("s", "") : durationWord;
    var duration = $"{durationint} {durationWord}";
    return duration;
  }

  public List<TourCardDTO> ConvertCardDto(List<Tour> list)
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
      var duration = DurationToString(li.Duration, li.DurationType);
      li.TourSearchQueryCompositions = li.TourSearchQueryCompositions?.Select(x => { x.Tour = null; return x; }).ToList();
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

  public List<TourCardDTO> ConvertCardDto(List<HomeTourPopularComposition> list)
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
      var image = li.Tour.TourGalleryImages?.FirstOrDefault()?.ImagePreview ?? "";
      var url = $"/tours/{helper.GenerateSlug(li.Tour.TourDirection.Name)}/{helper.GenerateSlug(li.Tour.Title)}/{li.Tour.Id}";
      var duration = DurationToString(li.Tour.Duration, li.Tour.DurationType);

      listDto.Add(new TourCardDTO
      {
        Id = li.Id,
        Image = image,
        Title = li.Tour.Title,
        Description = description,
        URL = url,
        Duration = duration,
        PriceInMXN = 0m
      });
    }
    return listDto;
  }
}
