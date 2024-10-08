
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites._Tour;

public class TourNotWorkingDay
{
  [ForeignKey("TourDatePricing")]
  public int IdTourDatePricing { get; set; }

  public TourDatePricing? TourDatePricing { get; set; }

  public DateOnly Day {get; set;}

}
