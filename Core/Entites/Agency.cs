using System.ComponentModel.DataAnnotations;

namespace Core.Entites;

public class Agency
{
  [Key]
  public int Id { get; set; }

  public string Name { get; set; } = "";
  
  public virtual List<AgencyCurrency>? AgencyCurrencies {get; set;}
}
