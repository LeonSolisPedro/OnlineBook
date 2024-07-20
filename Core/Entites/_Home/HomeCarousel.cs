using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Agency;

namespace Core.Entites._Home;

public class HomeCarousel
{
  [Key]
  public int Id { get; set; }

  public string Image { get; set; } = "";

  public int Order {get; set;}

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }


}
