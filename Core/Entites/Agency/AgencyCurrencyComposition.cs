

using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites;

public class AgencyCurrencyComposition
{
  [ForeignKey("AgencyCurrency")]
  public int IdAgencyCurrency { get; set; }

  public virtual AgencyCurrency? AgencyCurrency { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public int Order { get; set; }
}
