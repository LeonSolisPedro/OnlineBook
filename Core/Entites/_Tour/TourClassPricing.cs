using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Dto.Enums;

namespace Core.Entites._Tour;

public class TourClassPricing
{
  [Key]
  public int Id { get; set; }

  public string Name {get; set;} = "";

  public int? MaxSeats { get; set; }

  public bool? InfantsCountAsSeats {get; set;}

  public bool? AllowInfants {get; set;}

  public bool? AllowMinors {get; set;}

  [Column(TypeName = "money")]
  public decimal AdultsPricinginMXN { get; set; }

  [Column(TypeName = "money")]
  public decimal MinorsPricinginMXN { get; set; }

  [Column(TypeName = "money")]
  public decimal InfantsPricinginMXN { get; set; }

}
