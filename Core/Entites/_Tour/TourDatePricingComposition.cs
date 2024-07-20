using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites._Tour;

public class TourDatePricingComposition
{
  [ForeignKey("TourDatePricing")]
  public int IdTourDatePricing { get; set; }
  public virtual TourDatePricing? TourDatePricing { get; set; }

  [ForeignKey("TourClassPricing")]
  public int IdTourClassPricing { get; set; }

  public virtual TourClassPricing? TourClassPricing { get; set; }


}
