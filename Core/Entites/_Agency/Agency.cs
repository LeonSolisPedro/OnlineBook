using System.ComponentModel.DataAnnotations;
using Core.Entites._Home;
using Core.Entites._Other;

namespace Core.Entites._Agency;

public class Agency
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Location { get; set; } = "";

    public string BusinessHours { get; set; } = "";

    public string PhoneContact { get; set; } = "";

    public string EmailContact { get; set; } = "";

    public string Copyright { get; set; } = "";

    public virtual List<AgencyCurrencyComposition>? AgencyCurrencyCompositions { get; set; }

    public virtual List<AgencySocialComposition>? AgencySocialCompositions { get; set; }

    public virtual List<OtherGallery>? OtherGalleries { get; set; }

    public virtual List<HomeCarousel>? HomeCarousels { get; set; }

    public virtual List<HomeOffer>? HomeOffers {get; set;}

    public virtual List<HomeTourPopularComposition>? HomeTourPopularCompositions { get; set; }

    public virtual OtherPrivacyNotice? OtherPrivacyNotice {get; set;}

    public virtual OtherTermsCondition? OtherTermsCondition {get; set;}

    public virtual List<OtherContactForm>? OtherContactForms {get; set;}

}
