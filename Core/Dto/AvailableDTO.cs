

using System.ComponentModel.DataAnnotations;
using Core.Entites._Tour;

namespace Core.Dto;

public class AvailableDTO
{
  public bool IsAvailable {get; set;} = false;

  public bool AreSettingsGlobal { get; set; }

  public int? MaxSeats { get; set; }

  public bool? InfantsCountAsSeats { get; set; }

  public bool? AllowInfants { get; set; }

  public bool? AllowMinors { get; set; }

  public List<TourDatePricingComposition>? TourDatePricingCompositions { get; set; }
}

public class SelectedDateDTO
{
  [Required]
  public required int IdDatePricing { get; set; }

  [Required]
  public required List<DateOnly> Dates {get; set;}
}
