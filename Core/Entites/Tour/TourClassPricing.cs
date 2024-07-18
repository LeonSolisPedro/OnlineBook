using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Dto.Enums;

namespace Core.Entites.Tour;

public class TourClassPricing
{
  [Key]
  public int Id { get; set; }

  public string? Name {get; set;} = "";

  public DateOnly StartDate {get; set;}

  public DateOnly? EndDate {get; set;}

  public int? MaxSeats {get; set;}

  public RepeatType RepeatType {get; set;}

  public bool AllowInfants {get; set;}

  public bool AllowChildren {get; set;}

  [Column(TypeName = "money")]
  public decimal AdultsPricinginMXN { get; set; }

  [Column(TypeName = "money")]
  public decimal ChildrenPricinginMXN { get; set; }


  [Column(TypeName = "money")]
  public decimal InfantsPricinginMXN { get; set; }


}
