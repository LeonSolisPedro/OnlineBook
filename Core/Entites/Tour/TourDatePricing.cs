using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites;

public class TourDatePricing
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }

  public bool AreSettingsGlobal { get; set; }

  public int? MaxSeats { get; set; }

  public bool? InfantsCountAsSeats {get; set;}

  public bool? AllowInfants {get; set;}

  public bool? AllowMinors {get; set;}

  public List<TourDatePricingComposition>? TourDatePricingCompositions { get; set; }
}
