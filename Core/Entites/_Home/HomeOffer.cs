using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Agency;

namespace Core.Entites._Home;

public class HomeOffer
{
  [Key]
  public int Id { get; set; }

  public string Name { get; set; } = "";

  public string Image { get; set; } = "";

  public string ImageThumbnail { get; set; } = "";

  public bool IncludesHotel { get; set; }

  public bool IncludesFlights { get; set; }

  public bool IncludesTransportation { get; set; }

  public string MoreInfoLink { get; set; } = "";

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

  public bool IsArchived {get; set;}

}
