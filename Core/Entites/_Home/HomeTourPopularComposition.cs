using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;
using Core.Entites._Tour;
using static Core.Dto.Enums;

namespace Core.Entites._Home;

public class HomeTourPopularComposition
{
  [Key]
  public int Id {get; set;}

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public Tour? Tour { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public Agency? Agency { get; set; }

  public int Order {get; set;}

  public PopularType PopularType {get; set;}
  
}
