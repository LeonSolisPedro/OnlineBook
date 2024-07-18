using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites.Tour;

public class TourDatePricing
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }

  public bool AreSeatsGlobal { get; set; }

  public int? MaxSeats { get; set; }

  public List<TourDatePricingComposition>? TourDatePricingCompositions { get; set; }
}
