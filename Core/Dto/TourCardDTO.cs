using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Dto;

public class TourCardDTO
{

  public int Id { get; set; }

  public string Image { get; set; } = "";

  public string Title { get; set; } = "";

  public string Description { get; set; } = "";

  public string URL { get; set; } = "";

  public string Duration {get; set;} = "";

  public decimal PriceInMXN {get; set;}

}
