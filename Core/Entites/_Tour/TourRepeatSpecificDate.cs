
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites._Tour;

public class TourNotWorkingWeekDay
{
  [ForeignKey("TourDatePricing")]
  public int IdTourDatePricing { get; set; }

  public TourDatePricing? TourDatePricing { get; set; }

  public DayOfWeek Day {get; set;}
}
