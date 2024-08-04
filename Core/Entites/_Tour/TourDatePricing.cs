using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Dto.Enums;

namespace Core.Entites._Tour;

public class TourDatePricing
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }

  public DateOnly StartDate { get; set; }

  public DateOnly? EndDate { get; set; }

  public ReservationInterval ReservationInterval { get; set; }

  // Todo: Por el momento todos los tours
  // Se pueden reservar todos los días
  // public int? ReservationIntervalNNNDay {get; set;}

  public bool AreSettingsGlobal { get; set; }

  public int? MaxSeats { get; set; }

  public bool? InfantsCountAsSeats { get; set; }

  public bool? AllowInfants { get; set; }

  public bool? AllowMinors { get; set; }

  public List<TourNotWorkingWeekDay>? TourNotWorkingWeekDays { get; set; }

  public List<TourNotWorkingDay>? TourNotWorkingDays { get; set; }

  public List<TourDatePricingComposition>? TourDatePricingCompositions { get; set; }

  // Todo: Por el momento todos los tours
  // Se pueden reservar todos los días
  // public List<TourManualDate>? TourManualDates { get; set; }
}
