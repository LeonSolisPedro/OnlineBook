using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites._Agency;

public class AgencySocialComposition
{
  [ForeignKey("Social")]
  public int IdAgencySocial { get; set; }

  public virtual AgencySocial? Social { get; set; }

  public string Link {get; set;} = "";

  public int Order {get; set;}

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
