

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;

namespace Core.Entites._Tour;

public class TourSimilar
{
  [ForeignKey("Tour1")]
  public int IdTour1 { get; set; }
  public virtual Tour? Tour1 { get; set; }

  [ForeignKey("Tour2")]
  public int IdTour2 { get; set; }
  public virtual Tour? Tour2 { get; set; }


  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
