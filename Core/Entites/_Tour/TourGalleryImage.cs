
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entites._Agency;


namespace Core.Entites._Tour;

public class TourGalleryImage
{
  [Key]
  public int Id { get; set; }

  public string Image { get; set; } = "";

  public string ImagePreview { get; set; } = "";

  public string ImageThumbnail { get; set; } = "";

  public int Order {get; set;}

  [ForeignKey("Tour")]
  public int IdTour { get; set; }
  public virtual Tour? Tour { get; set; }


  [ForeignKey("Agency")]
  public int IdAgency { get; set; }
  public virtual Agency? Agency { get; set; }

}
