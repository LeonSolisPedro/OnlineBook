using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Agency;
using static Core.Dto.Enums;

namespace Core.Entites._Other;

public class OtherContactForm
{
  [Key]
  public int Id { get; set; }

  public ContactStatus Status { get; set; }

  public DateTime ContactDate { get; set; }

  public string ContactDateTimeZone { get; set; } = "";

  public DateTime? LastEditedDate { get; set; }

  public string? LastEditedDateTimeZone { get; set; }

  [Required]
  public string Name { get; set; } = "";

  [Required]
  public string LastName { get; set; } = "";

  [Required]
  [StringLength(10, MinimumLength = 10)]
  [RegularExpression(@"^\d{10}$")]
  public string PhoneNumber { get; set; } = "";

  [Required]
  [EmailAddress]
  public string Email { get; set; } = "";

  [Required]
  public string Comments { get; set; } = "";

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
