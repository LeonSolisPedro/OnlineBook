
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites;

public class TourNotWorkingDay
{
  [ForeignKey("TourClassPricing")]
  public int IdTourClassPricing { get; set; }

  public TourClassPricing? TourClassPricing { get; set; }

  public DateOnly Day {get; set;}

}
