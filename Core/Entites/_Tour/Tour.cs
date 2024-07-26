using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;
using static Core.Dto.Enums;


namespace Core.Entites._Tour;

public class Tour
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public string Title { get; set; } = "";

  public TourType TourType {get; set;}

  public bool IsArchived {get; set;}

  public string Image { get; set; } = "";

  public string ImageThumbnail { get; set; } = "";

  public string MetaKeywords { get; set; } = "";

  [Column(TypeName = "ntext")]
  [MaxLength]
  public string Description { get; set; } = "";

  public string? LinkVideo { get; set; }

  public string? LinkPDFItinerary { get; set; }

  public int Duration { get; set; }

  public DurationType DurationType { get; set; }

  public bool IsInternational { get; set; }

  [ForeignKey("TourDirection")]
  public int IdTourDirection { get; set; }

  public TourDirection? TourDirection { get; set; }

  public virtual List<TourInclude>? TourIncludes { get; set; }

  public virtual List<TourSimilar>? TourSimilar { get; set; }

  public virtual List<TourCategoryComposition>? TourCategoryCompositions {get; set;}

  public virtual List<TourSearchQueryComposition>? TourSearchQueryCompositions {get; set;}

  public virtual List<TourItinerary>? TourItineraries {get; set;}

  public virtual List<TourGalleryImage>? TourGalleryImages {get; set;}

  public virtual List<TourDatePricing>? TourDatePricings {get; set;}

}
