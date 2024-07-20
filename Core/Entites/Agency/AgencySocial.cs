using System.ComponentModel.DataAnnotations;

namespace Core.Entites;

public class AgencySocial
{
  [Key]
  public int Id { get; set; }

  public string Link { get; set; } = "";

  public string Name { get; set; } = "";
}
