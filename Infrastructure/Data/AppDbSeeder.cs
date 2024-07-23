using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Entites._Agency;
using Core.Entites._Home;
using Core.Entites._Tour;
using static Core.Dto.Enums;

namespace Infrastructure.Data;

public class AppDbSeeder
{
  public static async Task SeedAsync(AppDbContext _context)
  {


    if (!_context.Tours.Any())
    {

      #region Global

        var currency1 = new AgencyCurrency
        {
          ExchangeRateToMXN = 0m,
          Name = "MXN"
        };
  
        var currency2 = new AgencyCurrency
        {
          ExchangeRateToMXN = 18.02m,
          Name = "USD"
        };
  
        var currency3 = new AgencyCurrency
        {
          ExchangeRateToMXN = 19.63m,
          Name = "EUR"
        };
  
        var social1 = new AgencySocial
        {
          Name = "facebook"
        };
  
        var social2 = new AgencySocial
        {
          Name = "twitter"
        };
  
        var social3 = new AgencySocial
        {
          Name = "whatsapp"
        };
  
        var social4 = new AgencySocial
        {
          Name = "google"
        };
  
        var social5 = new AgencySocial
        {
          Name = "instagram"
        };
  
        var social6 = new AgencySocial
        {
          Name = "pinterest"
        };
  
        var social7 = new AgencySocial
        {
          Name = "youtube"
        };
  
        var social8 = new AgencySocial
        {
          Name = "linkedin"
        };
  
        var social9 = new AgencySocial
        {
          Name = "tiktok"
        };

      #endregion

      #region Agency 1

        var agency1 = new Agency
        {
          Name = "Agencía 1",
          Location = "Cuauhtémoc, 06060, CDMX",
          BusinessHours = "Lun - Vie: 9:00 a 17:00",
          PhoneContact = "5555555555",
          EmailContact = "pedro@wintercr.com",
          Copyright = "Derechos Reservados Agencía 1"
        };

        var agencySocial1 = new List<AgencySocialComposition>
        {
          new() {Agency = agency1, Social = social1, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 1},
          new() {Agency = agency1, Social = social2, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 2},
          new() {Agency = agency1, Social = social3, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 3},
          new() {Agency = agency1, Social = social4, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 4},
          new() {Agency = agency1, Social = social5, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 5},
          new() {Agency = agency1, Social = social6, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 6},
          new() {Agency = agency1, Social = social7, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 7},
          new() {Agency = agency1, Social = social8, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 8},
          new() {Agency = agency1, Social = social9, Link = "https://www.linkedin.com/in/leonsolispedro/", Order = 9},
        };
  
        var agencyCurrency1 = new List<AgencyCurrencyComposition>
        {
          new() {Agency = agency1, Currency = currency1, Order = 1},
          new() {Agency = agency1, Currency = currency2, Order = 2},
        };

        var homeCarousel1 = new List<HomeCarousel>
        {
          new() {Image = "imagen1.png", Agency = agency1, Order = 1},
          new() {Image = "imagen2.png", Agency = agency1, Order = 2},
        };

        var homeOffers1 = new List<HomeOffer>
        {
          new() {Image = "imagen1.png", ImageThumbnail = "imagen1.png", Name = "Oferta 1", IncludesHotel = true, IncludesFlights = true, IncludesTransportation = true, MoreInfoLink = "https://wintercr.com"},
          new() {Image = "imagen2.png", ImageThumbnail = "imagen2.png", Name = "Oferta 2", IncludesHotel = true, IncludesFlights = true, IncludesTransportation = true, MoreInfoLink = "https://wintercr.com"},
        };

        agency1.AgencySocialCompositions = agencySocial1;
        agency1.AgencyCurrencyCompositions = agencyCurrency1;
        agency1.HomeCarousels = homeCarousel1;
        agency1.HomeOffers = homeOffers1;
  
  
        var tourCategory1 = new TourCategory
        {
          Name = "Playas",
          Order = 1,
          Agency = agency1
        };
        _context.TourCategories.Add(tourCategory1);
  
        var tourCategory2 = new TourCategory
        {
          Name = "Cenotes",
          Order = 2,
          Agency = agency1
        };
        _context.TourCategories.Add(tourCategory2);
  
        var tourSearchQuery1 = new TourSearchQuery
        {
          Name = "Diversión",
          Order = 1,
          Agency = agency1
        };
        _context.TourSearchQueries.Add(tourSearchQuery1);
  
        var tourSearchQuery2 = new TourSearchQuery
        {
          Name = "Exploración",
          Order = 2,
          Agency = agency1
        };
        _context.TourSearchQueries.Add(tourSearchQuery2);
  
        var tourSearchQuery3 = new TourSearchQuery
        {
          Name = "Deporte y Fitness",
          Order = 3,
          Agency = agency1
        };
        _context.TourSearchQueries.Add(tourSearchQuery3);
  
        var tourSearchQuery4 = new TourSearchQuery
        {
          Name = "Relajación",
          Order = 4,
          Agency = agency1
        };
        _context.TourSearchQueries.Add(tourSearchQuery4);
  
        var direction1 = new TourDirection
        {
          Name = "Cancún",
          Agency = agency1
        };
  
        var tour1 = new Tour
        {
          Title = "Playa en Cancún",
          Image = "image.png",
          ImageThumbnail = "imagethumbnail.png",
          MetaKeywords = "holi,holo",
          Description = "<p>Aquí va <b>Descripcion</b></p>",
          LinkVideo = "https://wintercr.com",
          LinkPDFItinerary = "documento.pdf",
          Duration = 2,
          DurationType = DurationType.HOURS,
          IsInternational = false,
          Agency = agency1,
          TourDirection = direction1
        };
  
  
        var tourCategoryCompositions1 = new List<TourCategoryComposition>
        {
          new() {Tour = tour1, TourCategory = tourCategory1}
        };
  
        var tourSearchQueryCompositions1 = new List<TourSearchQueryComposition>
        {
          new() {Tour = tour1, TourSearchQuery = tourSearchQuery1},
          new() {Tour = tour1, TourSearchQuery = tourSearchQuery4}
        };
  
  
        var tourIncludes1 = new List<TourInclude>
        {
          new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer Agua", Tour = tour1 },
          new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Use gafas de sol", Tour = tour1 },
          new() { IncludeType = IncludeType.INCLUDES, Description = "Comidas", Tour = tour1 },
          new() { IncludeType = IncludeType.INCLUDES, Description = "Toallas", Tour = tour1 },
          new() { IncludeType = IncludeType.EXCLUDES, Description = "Sandalias", Tour = tour1 },
          new(){ IncludeType = IncludeType.EXCLUDES, Description = "Cubrebocas", Tour = tour1 }
        };
  
        var tourItinerary1 = new List<TourItinerary>
        {
          new() {Agency = agency1, Tour = tour1, Day = 1, Description = "<p>Empezamos el día con un chapuzón, disfratermos del sol y actividades divertidas </p>"}
        };
  
        var tourgalleryimages1 = new List<TourGalleryImage>
        {
          new() {Agency = agency1, Tour = tour1, Image = $"image_{agency1.Name}_1.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_1.jpg"  },
          new() {Agency = agency1, Tour = tour1, Image = $"image_{agency1.Name}_2.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_2.jpg"  },
          new() {Agency = agency1, Tour = tour1, Image = $"image_{agency1.Name}_3.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_3.jpg"  },
          new() {Agency = agency1, Tour = tour1, Image = $"image_{agency1.Name}_4.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_4.jpg"  },
        };
  
        tour1.TourIncludes = tourIncludes1;
        tour1.TourCategoryCompositions = tourCategoryCompositions1;
        tour1.TourSearchQueryCompositions = tourSearchQueryCompositions1;
        tour1.TourItineraries = tourItinerary1;
        tour1.TourGalleryImages = tourgalleryimages1;
      #endregion



      _context.Tours.Add(tour1);
      await _context.SaveChangesAsync();


    }
  }
}
