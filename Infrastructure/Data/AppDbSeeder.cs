using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Entites._Agency;
using Core.Entites._Tour;

namespace Infrastructure.Data;

public class AppDbSeeder
{
  public static async Task SeedAsync(AppDbContext _context)
  {


    if (!_context.Tours.Any())
    {

      //Global

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

      // var 

      var agency1 = new Agency
      {
        Name = "Agencía 1"
      };

      var agencyCurrency1 = new List<AgencyCurrencyComposition>
      {
        new() {Agency = agency1, AgencyCurrency = currency1, Order = 1},
        new() {Agency = agency1, AgencyCurrency = currency2, Order = 2},
      };

      agency1.AgencyCurrencyCompositions = agencyCurrency1;


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
        DurationType = Core.Dto.Enums.DurationType.HOURS,
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
        new() { IncludeType = Core.Dto.Enums.IncludeType.RECOMENDATIONS, Description = "Traer Agua", Tour = tour1 },
        new() { IncludeType = Core.Dto.Enums.IncludeType.RECOMENDATIONS, Description = "Use gafas de sol", Tour = tour1 },
        new() { IncludeType = Core.Dto.Enums.IncludeType.INCLUDES, Description = "Comidas", Tour = tour1 },
        new() { IncludeType = Core.Dto.Enums.IncludeType.INCLUDES, Description = "Toallas", Tour = tour1 },
        new() { IncludeType = Core.Dto.Enums.IncludeType.EXCLUDES, Description = "Sandalias", Tour = tour1 },
        new(){ IncludeType = Core.Dto.Enums.IncludeType.EXCLUDES, Description = "Cubrebocas", Tour = tour1 }
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



      _context.Tours.Add(tour1);
      await _context.SaveChangesAsync();


    }
  }
}
