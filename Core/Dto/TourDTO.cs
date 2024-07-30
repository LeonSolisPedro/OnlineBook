using Core.Entites._Tour;
using static Core.Dto.Enums;

namespace Core.Dto;

public class TourDTO
{
  public int Id { get; set; }

  public string Title { get; set; } = "";

  public TourType TourType { get; set; }

  public string MetaKeywords { get; set; } = "";

  public string Description { get; set; } = "";


  public string? LinkVideo { get; set; }

  public string? LinkPDFItinerary { get; set; }

  public string Duration { get; set; } = "";

  public decimal PriceInMXN { get; set; }

  public bool IsInternational { get; set; }

  public TourDirection? TourDirection { get; set; }

  public virtual List<TourInclude>? TourIncludes { get; set; }

  public virtual List<TourCardDTO>? TourSimilar { get; set; }

  public virtual List<TourItinerary>? TourItineraries { get; set; }

  public virtual List<TourGalleryImage>? TourGalleryImages { get; set; }

}
