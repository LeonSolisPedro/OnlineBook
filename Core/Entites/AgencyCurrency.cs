

using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites;

public class AgencyCurrency
{
  [ForeignKey("CurrencyRate")]
  public int IdCurrencyRate { get; set; }

  public virtual CurrencyRate? CurrencyRate { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public int Order { get; set; }
}
