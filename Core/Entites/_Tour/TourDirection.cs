using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;

namespace Core.Entites._Tour;

public class TourDirection
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = "";

    [ForeignKey("Agency")]
    public int IdAgency { get; set; }
    public virtual Agency? Agency { get; set; }
    public virtual List<Tour>? Tours { get; set; }

}
