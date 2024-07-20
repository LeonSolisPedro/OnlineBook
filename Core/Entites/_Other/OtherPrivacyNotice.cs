using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;

namespace Core.Entites._Other;

public class OtherPrivacyNotice
{

  [Key]
  public int Id { get; set; }

  [Column(TypeName = "ntext")]
  [MaxLength]
  public string Text { get; set; } = "";

  public DateOnly LastEditedDate { get; set; }

  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }
}
