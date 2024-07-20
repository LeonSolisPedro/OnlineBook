using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites._Tour;

public class TourSearchQueryComposition
{
  [ForeignKey("TourSearchQuery")]
  public int IdTourSearchQuery { get; set; }

  public virtual TourSearchQuery? TourSearchQuery { get; set; }

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }
}
