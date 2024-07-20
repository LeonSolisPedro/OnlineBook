

using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entites;

public class TourCategoryComposition
{
    [ForeignKey("TourCategory")]
    public int IdTourCategory {get; set;}
    public virtual TourCategory? TourCategory {get; set;}
    
    [ForeignKey("Tour")]
    public int IdTour {get; set;}
    public virtual Tour? Tour {get; set;}
}
