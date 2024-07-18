using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites.Tour;

public class TourItinerary
{

  [Key]
  public int Id { get; set; }

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }


  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public int Day { get; set; }

  [Column(TypeName = "ntext")]
  [MaxLength]
  public string Description { get; set; } = "";
}
