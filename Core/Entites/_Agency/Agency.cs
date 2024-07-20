using System.ComponentModel.DataAnnotations;

namespace Core.Entites._Agency;

public class Agency
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Location { get; set; } = "";

    public string BusinessHours { get; set; } = "";

    public string PhoneContact { get; set; } = "";

    public string EmailContact { get; set; } = "";

    public string Copyright { get; set; } = "";

    public virtual List<AgencyCurrencyComposition>? AgencyCurrencyCompositions { get; set; }

    public virtual List<AgencySocialComposition>? AgencySocialCompositions { get; set; }
}
