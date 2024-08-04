using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;
using static Core.Dto.Enums;

namespace Core.Entites._Tour;

public class TourReservation
{
  [Key]
  public int Id { get; set; }

  [ForeignKey("TourClassPricing")]
  public int IdTourClassPricing { get; set; }

  public virtual TourClassPricing? TourClassPricing { get; set; }


  [ForeignKey("TourDatePricing")]
  public int IdTourDatePricing { get; set; }

  public virtual TourDatePricing? TourDatePricing { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }

  public virtual Agency? Agency { get; set; }


  public string Name { get; set; } = "";

  public string LastName { get; set; } = "";


  public int PhoneNumber { get; set; }

  public Gender Gender { get; set; }

  public DateOnly BirthDay { get; set; }

  public string Email { get; set; } = "";

  public DateTime ReservationDate { get; set; }

  public string ReservationDateTimeZone { get; set; } = "";

  public DateTime LastEditedDate { get; set; }

  public string LastEditedDateTimeZone { get; set; } = "";

  public DateTime PaymentDay { get; set; }

  public string PaymentDayTimeZone { get; set; } = "";

  public DateOnly DepartureDate { get; set; }

  public TourReservationStatus Status { get; set; }


  public int TotalOcupiedSeats { get; set; }

  public bool InfantsCountAsSeat { get; set; }


  public int NumberOfAdults { get; set; }

  public int NumberOfMinors { get; set; }

  public int NumberOfInfants { get; set; }

  public string TourClassPricingData { get; set; } = "";

  public string TourDatePricingData { get; set; } = "";

  public string AdultsData { get; set; } = "";

  public string MinorsData { get; set; } = "";

  [Column(TypeName = "money")]
  public decimal TotalPricePaid { get; set; }

  [Column(TypeName = "money")]
  public decimal AdultsPricinginMXN { get; set; }

  [Column(TypeName = "money")]
  public decimal MinorsPricinginMXN { get; set; }

  [Column(TypeName = "money")]
  public decimal InfantsPricinginMXN { get; set; }


}
