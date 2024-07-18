
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Dto.Enums;


namespace Core.Entites.Tour;

public class TourInclude
{
  [Key]
  public int Id { get; set; }

  public IncludeType IncludeType { get; set; }

  public string Description { get; set; } = "";

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }
}
