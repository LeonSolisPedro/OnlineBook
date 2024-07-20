using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites;

public class AgencySocialComposition
{
  [ForeignKey("AgencySocial")]
  public int IdAgencySocial { get; set; }

  public virtual AgencySocial? AgencySocial { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
