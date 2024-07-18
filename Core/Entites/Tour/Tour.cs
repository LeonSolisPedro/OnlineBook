using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Dto.Enums;


namespace Core.Entites.Tour;

public class Tour
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public string Title { get; set; } = "";

  public string Image { get; set; } = "";

  public string ImageThumbnail { get; set; } = "";

  public string MetaKeywords { get; set; } = "";

  [Column(TypeName = "ntext")]
  [MaxLength]
  public string Description { get; set; } = "";

  public string LinkVideo { get; set; } = "";

  public string LinkPDFItinerary { get; set; } = "";

  public int Duration { get; set; }

  public DurationType DurationType { get; set; }

  public bool IsInternational { get; set; }

  [ForeignKey("DirectionTour")]
  public int IdDirectionTour { get; set; }

  public DirectionTour? DirectionTour { get; set; }

  public virtual List<TourInclude>? TourIncludes { get; set; }

  public virtual List<SimilarTour>? SimilarTours { get; set; }

  public virtual List<TourCategoryComposition>? TourCategoryCompositions {get; set;}

  public virtual List<TourSearchQueryComposition>? TourSearchQueryCompositions {get; set;}

  public virtual List<TourItinerary>? TourItineraries {get; set;}

  public virtual List<TourGalleryImage>? TourGalleryImages {get; set;}

}
