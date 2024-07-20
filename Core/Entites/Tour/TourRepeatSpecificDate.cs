
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites;

public class TourRepeatSpecificDate
{
  [ForeignKey("TourClassPricing")]
  public int IdTourClassPricing { get; set; }

  public TourClassPricing? TourClassPricing { get; set; }

  public DayOfWeek Day {get; set;}
}
