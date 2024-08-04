

using Core.Entites._Tour;
using static Core.Dto.Enums;

namespace Core.Dto;

public class GetDatesDTO
{

  public int IdTourDatePricing { get; set; }

  public TourType TourType {get; set;}

  public ReservationInterval ReservationInterval { get; set; }

  public int Duration { get; set; }

  public DateOnly StartDate { get; set; }

  public DateOnly EndDate { get; set; }

  public List<DayOfWeek> TourNotWorkingWeekDays { get; set; } = [];

  public List<DateOnly> TourNotWorkingDays { get; set; } = [];

  // Todo: Por el momento todos los tours
  // Se pueden reservar todos los días
  // public List<TourManualDate>? TourManualDates { get; set; }
}
