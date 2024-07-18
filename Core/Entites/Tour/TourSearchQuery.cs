using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Core.Entites.Tour;

public class TourSearchQuery
{
  [Key]
  public int Id { get; set; }

  public string Name { get; set; } = "";

  public int Order { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
