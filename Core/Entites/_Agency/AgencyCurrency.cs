using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entites._Agency;

public class AgencyCurrency
{
  [Key]
  public int Id { get; set; }

  [Column(TypeName = "money")]
  public decimal ExchangeRateToMXN { get; set; }

  public string Name {get; set;} = "";
}
