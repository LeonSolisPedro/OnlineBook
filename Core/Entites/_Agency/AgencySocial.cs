using System.ComponentModel.DataAnnotations;
using static Core.Dto.Enums;

namespace Core.Entites._Agency;

public class AgencySocial
{
  [Key]
  public int Id { get; set; }

  public string Link { get; set; } = "";

  public SocialName SocialName { get; set; }
}
