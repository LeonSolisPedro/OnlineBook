using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites;
using Core.Entites._Agency;
using Core.Entites._Home;
using Core.Entites._Other;
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

      #endregion


      #region Tour 1

      var tourCategory1 = new TourCategory
      {
        Name = "Playas",
        Order = 1,
        Agency = agency1
      };

      var tourSearchQuery1 = new TourSearchQuery
      {
        Name = "Diversión",
        Order = 1,
        Agency = agency1
      };

      var tourSearchQuery2 = new TourSearchQuery
      {
        Name = "Relajación",
        Order = 4,
        Agency = agency1
      };

      var direction1 = new TourDirection
      {
        Name = "Cancún",
        Agency = agency1
      };

      var tour1 = new Tour
      {
        Title = "Playa en Cancún",
        TourType = TourType.SINGLEDAY,
        Image = "imagenCancun.png",
        ImageThumbnail = "imagenCancunthumbnail.png",
        MetaKeywords = "playa, Cancún, tour, viaje, vacaciones, arena, mar, México, sol, turismo",
        Description = @"<p>Descubre la belleza de las playas de Cancún en un tour inolvidable. Relájate en la arena blanca y disfruta del mar turquesa mientras tomas el sol. Este destino paradisíaco en México ofrece un ambiente perfecto para descansar y desconectar del estrés diario. Además, podrás explorar la vida marina con actividades como snorkel y buceo, o simplemente pasear por la orilla mientras contemplas el atardecer.</p>
            <p>En Cancún, las opciones son infinitas. Puedes visitar el centro de la ciudad para experimentar la cultura local, probar la deliciosa gastronomía mexicana en los restaurantes cercanos o hacer una excursión a las ruinas mayas cercanas para aprender más sobre la historia de la región. Los tours están diseñados para ofrecerte una experiencia completa, combinando el relax de la playa con la emoción de descubrir nuevos lugares y actividades.</p>",
        LinkVideo = "https://youtube.com",
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
            new() {Tour = tour1, TourSearchQuery = tourSearchQuery2}
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
            new() {Agency = agency1, Tour = tour1, Day = 1, Description = @"
  <p>Comienza tu día con un delicioso desayuno en un café local a las 8:00 AM. Después, dirígete a la playa a las 9:00 AM para disfrutar de un relajante baño en el mar turquesa y tomar el sol en la arena blanca. A las 11:00 AM, participa en una sesión de snorkel para explorar la vibrante vida marina.</p>
  <p>Al mediodía, disfruta de un almuerzo en un restaurante frente al mar, degustando la gastronomía local. A las 2:00 PM, realiza una excursión a las ruinas mayas cercanas, donde podrás aprender sobre la historia y la cultura de la región. Regresa a la playa a las 4:00 PM para relajarte y nadar un poco más.</p>
  <p>Termina tu día con una cena a las 6:00 PM en un restaurante con vistas al mar, y luego disfruta de un paseo por la orilla mientras contemplas el atardecer. A las 8:00 PM, regresa a tu alojamiento para descansar y reflexionar sobre un día lleno de aventuras y relax en Cancún.</p>"}
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


      #region Tour 2

      var tourCategory3 = new TourCategory
      {
        Name = "Aventuras",
        Order = 3,
        Agency = agency1
      };

      // var tourSearchQuery1 = new TourSearchQuery
      // {
      //   Name = "Diversión",
      //   Order = 1,
      //   Agency = agency1
      // };


      var tourSearchQuery3 = new TourSearchQuery
      {
        Name = "Exploración",
        Order = 1,
        Agency = agency1
      };


      // var direction1 = new TourDirection
      // {
      //   Name = "Cancún",
      //   Agency = agency1
      // };

      var tour2 = new Tour
      {
        Title = "Aventura en Xcaret",
        TourType = TourType.SINGLEDAY,
        Image = "imagenXcaret.png",
        ImageThumbnail = "imagenXcaretthumbnail.png",
        MetaKeywords = "aventura, Xcaret, tour, viaje, diversión, México, parque, naturaleza, eco-turismo",
        Description = @"<p>Explora las maravillas naturales de Xcaret en un emocionante tour de un día. Sumérgete en la belleza de los ríos subterráneos, nada en caletas y lagunas cristalinas, y descubre la rica fauna y flora del parque. Xcaret ofrece una combinación perfecta de aventura y relax, con actividades para todas las edades.</p>
                          <p>Visita el acuario, el mariposario, y aprende sobre la cultura maya a través de espectáculos y exposiciones. Este tour es ideal para familias y amantes de la naturaleza que buscan una experiencia única y memorable.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "documentoXcaret.pdf",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction1
      };

      var tourCategoryCompositions2 = new List<TourCategoryComposition>
          {
            new() {Tour = tour2, TourCategory = tourCategory3}
          };

      var tourSearchQueryCompositions2 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour2, TourSearchQuery = tourSearchQuery3},
            new() {Tour = tour2, TourSearchQuery = tourSearchQuery1}
          };


      var tourItinerary2 = new List<TourItinerary>
{
  new() {Agency = agency1, Tour = tour2, Day = 1, Description = @"
<p>Inicia tu día en Xcaret a las 8:00 AM con un recorrido por los ríos subterráneos. A las 10:00 AM, disfruta de las playas y caletas, relajándote o explorando la vida marina con snorkel. Al mediodía, saborea un almuerzo en uno de los restaurantes del parque, con una vista espectacular.</p>
<p>A las 2:00 PM, visita el acuario y el mariposario, aprendiendo sobre la biodiversidad local. Participa en actividades culturales y disfruta de espectáculos que te llevarán a conocer más sobre la herencia maya. Termina tu día con una cena y un paseo nocturno por el parque, regresando a tu hotel a las 8:00 PM.</p>"}
};

      var tourIncludes2 = new List<TourInclude>
{
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer traje de baño", Tour = tour2 },
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Uso de protector solar biodegradable", Tour = tour2 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Transporte", Tour = tour2 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Almuerzo", Tour = tour2 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Bebidas alcohólicas", Tour = tour2 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour2 }
};

      var tourgalleryimages2 = new List<TourGalleryImage>
{
  new() {Agency = agency1, Tour = tour2, Image = $"image_{agency1.Name}_5.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_5.jpg"  },
  new() {Agency = agency1, Tour = tour2, Image = $"image_{agency1.Name}_6.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_6.jpg"  },
  new() {Agency = agency1, Tour = tour2, Image = $"image_{agency1.Name}_7.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_7.jpg"  },
  new() {Agency = agency1, Tour = tour2, Image = $"image_{agency1.Name}_8.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_8.jpg"  },
};

      tour2.TourIncludes = tourIncludes2;
      tour2.TourCategoryCompositions = tourCategoryCompositions2;
      tour2.TourSearchQueryCompositions = tourSearchQueryCompositions2;
      tour2.TourItineraries = tourItinerary2;
      tour2.TourGalleryImages = tourgalleryimages2;


      #endregion



      #region Tour 3

      // var tourCategory1 = new TourCategory
      // {
      //   Name = "Playas",
      //   Order = 1,
      //   Agency = agency1
      // };

      // var tourSearchQuery1 = new TourSearchQuery
      // {
      //   Name = "Diversión",
      //   Order = 1,
      //   Agency = agency1
      // };

      // var tourSearchQuery2 = new TourSearchQuery
      // {
      //   Name = "Relajación",
      //   Order = 4,
      //   Agency = agency1
      // };

      var direction2 = new TourDirection
      {
        Name = "Isla Mujeres",
        Agency = agency1
      };

      var tour3 = new Tour
      {
        Title = "Isla Mujeres",
        TourType = TourType.SINGLEDAY,
        Image = "imagenIslaMujeres.png",
        ImageThumbnail = "imagenIslaMujeresthumbnail.png",
        MetaKeywords = "isla, Mujeres, tour, viaje, playa, mar, México, sol, vacaciones, turismo",
        Description = @"<p>Explora la encantadora Isla Mujeres en un tour de un día. Disfruta de la tranquilidad de sus playas, nada en aguas cristalinas y descubre la belleza natural de este paraíso mexicano. Este tour es ideal para quienes buscan una escapada relajante y pintoresca.</p>
    <p>Pasea por el centro de la isla, prueba la deliciosa comida local y visita el parque Garrafón para actividades acuáticas y vistas espectaculares. Isla Mujeres ofrece una experiencia única llena de paz y belleza natural.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "documentoIslaMujeres.pdf",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction2
      };


      var tourCategoryCompositions3 = new List<TourCategoryComposition>
            {
              new() {Tour = tour3, TourCategory = tourCategory1}
            };

      var tourSearchQueryCompositions3 = new List<TourSearchQueryComposition>
            {
              new() {Tour = tour3, TourSearchQuery = tourSearchQuery1},
              new() {Tour = tour3, TourSearchQuery = tourSearchQuery2}
            };


      var tourItinerary3 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour3, Day = 1, Description = @"
  <p>Comienza tu día tomando un ferry a Isla Mujeres a las 8:00 AM. A las 9:00 AM, relájate en la playa Norte, conocida por sus aguas tranquilas y arena blanca. A las 11:00 AM, participa en una sesión de snorkel para explorar los arrecifes de coral cercanos.</p>
  <p>Al mediodía, disfruta de un almuerzo en un restaurante local, degustando mariscos frescos. A las 2:00 PM, visita el parque Garrafón para realizar tirolesa y kayak, o simplemente disfruta de las vistas panorámicas. Termina tu día paseando por el centro de la isla, comprando recuerdos y probando más delicias locales antes de regresar en ferry a las 6:00 PM.</p>"}
  };

      var tourIncludes3 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar protector solar", Tour = tour3 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer traje de baño", Tour = tour3 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Transporte en ferry", Tour = tour3 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Almuerzo", Tour = tour3 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Actividades opcionales en Garrafón", Tour = tour3 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour3 }
  };

      var tourgalleryimages3 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour3, Image = $"image_{agency1.Name}_9.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_9.jpg"  },
    new() {Agency = agency1, Tour = tour3, Image = $"image_{agency1.Name}_10.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_10.jpg"  },
    new() {Agency = agency1, Tour = tour3, Image = $"image_{agency1.Name}_11.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_11.jpg"  },
    new() {Agency = agency1, Tour = tour3, Image = $"image_{agency1.Name}_12.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_12.jpg"  },
  };

      tour3.TourIncludes = tourIncludes3;
      tour3.TourCategoryCompositions = tourCategoryCompositions3;
      tour3.TourSearchQueryCompositions = tourSearchQueryCompositions3;
      tour3.TourItineraries = tourItinerary3;
      tour3.TourGalleryImages = tourgalleryimages3;
      #endregion



      #region Tour 4

      var tourCategory2 = new TourCategory
      {
        Name = "Cenotes",
        Order = 1,
        Agency = agency1
      };

      // var tourSearchQuery3 = new TourSearchQuery
      // {
      //   Name = "Exploración",
      //   Order = 1,
      //   Agency = agency1
      // };

      // var tourSearchQuery1 = new TourSearchQuery
      // {
      //   Name = "Diversión",
      //   Order = 1,
      //   Agency = agency1
      // };

      var direction3 = new TourDirection
      {
        Name = "Yucatán",
        Agency = agency1
      };

      var tour4 = new Tour
      {
        Title = "Chichén Itzá y Cenote",
        TourType = TourType.SINGLEDAY,
        Image = "imagenChichenItza.png",
        ImageThumbnail = "imagenChichenItzathumbnail.png",
        MetaKeywords = "Chichén Itzá, cenote, tour, viaje, historia, México, arqueología, mayas, turismo",
        Description = @"<p>Descubre la majestuosidad de Chichén Itzá y refréscate en un cenote cercano en este tour de un día. Conoce la historia de la civilización maya mientras exploras las impresionantes ruinas arqueológicas y aprende sobre su cultura y arquitectura.</p>
    <p>Después de la visita a Chichén Itzá, disfruta de un almuerzo tradicional y báñate en un cenote sagrado, una experiencia única que te conectará con la naturaleza y la historia de la región. Este tour combina aventura, historia y naturaleza en un solo día.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "documentoChichenItza.pdf",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction3
      };


      var tourCategoryCompositions4 = new List<TourCategoryComposition>
          {
            new() {Tour = tour4, TourCategory = tourCategory2}
          };

      var tourSearchQueryCompositions4 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour4, TourSearchQuery = tourSearchQuery3},
            new() {Tour = tour4, TourSearchQuery = tourSearchQuery1}
          };

      var tourItinerary4 = new List<TourItinerary>
{
  new() {Agency = agency1, Tour = tour4, Day = 1, Description = @"
<p>Salida desde Cancún a las 7:00 AM, llegando a Chichén Itzá a las 9:00 AM. Explora las ruinas arqueológicas con un guía experto hasta las 12:00 PM. Aprende sobre la historia y cultura maya mientras visitas la pirámide de Kukulkán y el Templo de los Guerreros.</p>
<p>A las 12:30 PM, disfruta de un almuerzo buffet con platillos tradicionales. A las 2:00 PM, dirígete a un cenote cercano para nadar y relajarte en sus aguas cristalinas. Termina el día con un paseo por la selva antes de regresar a Cancún, llegando alrededor de las 6:00 PM.</p>"}
};


      var tourIncludes4 = new List<TourInclude>
{
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar sombrero", Tour = tour4 },
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer ropa ligera", Tour = tour4 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Transporte en autobús", Tour = tour4 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Almuerzo buffet", Tour = tour4 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Entradas a Chichén Itzá", Tour = tour4 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Bebidas en el almuerzo", Tour = tour4 }
};

      var tourgalleryimages4 = new List<TourGalleryImage>
{
  new() {Agency = agency1, Tour = tour4, Image = $"image_{agency1.Name}_13.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_13.jpg"  },
  new() {Agency = agency1, Tour = tour4, Image = $"image_{agency1.Name}_14.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_14.jpg"  },
  new() {Agency = agency1, Tour = tour4, Image = $"image_{agency1.Name}_15.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_15.jpg"  },
  new() {Agency = agency1, Tour = tour4, Image = $"image_{agency1.Name}_16.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_16.jpg"  },
};


      tour4.TourIncludes = tourIncludes4;
      tour4.TourCategoryCompositions = tourCategoryCompositions4;
      tour4.TourSearchQueryCompositions = tourSearchQueryCompositions4;
      tour4.TourItineraries = tourItinerary4;
      tour4.TourGalleryImages = tourgalleryimages4;


      #endregion

      #region Tour 5


      // var tourCategory3 = new TourCategory
      // {
      //   Name = "Aventuras",
      //   Order = 3,
      //   Agency = agency1
      // };

      // var tourSearchQuery1 = new TourSearchQuery
      // {
      //   Name = "Diversión",
      //   Order = 1,
      //   Agency = agency1
      // };

      // var tourSearchQuery2 = new TourSearchQuery
      // {
      //   Name = "Relajación",
      //   Order = 4,
      //   Agency = agency1
      // };


      // var direction1 = new TourDirection
      // {
      //   Name = "Cancún",
      //   Agency = agency1
      // };


      var tour5 = new Tour
      {
        Title = "Nado con Delfines",
        TourType = TourType.SINGLEDAY,
        Image = "imagenDelfines.png",
        ImageThumbnail = "imagenDelfinesthumbnail.png",
        MetaKeywords = "delfines, nado, tour, viaje, mar, México, aventura, vacaciones, turismo",
        Description = @"<p>Vive una experiencia única nadando con delfines en Cancún. Este tour de un día te permitirá interactuar de cerca con estos increíbles animales, aprender sobre su comportamiento y disfrutar de un momento mágico en el mar.</p>
    <p>Después del nado, relájate en la playa y disfruta de las instalaciones del parque marino. Este tour es perfecto para los amantes de la naturaleza y aquellos que buscan una experiencia inolvidable durante sus vacaciones.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "documentoDelfines.pdf",
        Duration = 3,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction1
      };

      var tourCategoryCompositions5 = new List<TourCategoryComposition>
          {
            new() {Tour = tour5, TourCategory = tourCategory3}
          };

      var tourSearchQueryCompositions5 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour5, TourSearchQuery = tourSearchQuery1},
            new() {Tour = tour5, TourSearchQuery = tourSearchQuery2}
          };


      var tourItinerary5 = new List<TourItinerary>
{
  new() {Agency = agency1, Tour = tour5, Day = 1, Description = @"
<p>Inicia tu día llegando al parque marino a las 9:00 AM. A las 10:00 AM, participa en una sesión informativa sobre los delfines y sus comportamientos. A las 11:00 AM, ingresa al agua para nadar con los delfines, interactuar con ellos y aprender más sobre su vida marina.</p>
<p>Después de la sesión de nado, disfruta de un almuerzo en el parque marino a la 1:00 PM. A las 2:30 PM, relájate en la playa o participa en otras actividades acuáticas como snorkel o kayak. Termina tu día a las 5:00 PM con una visita a la tienda de recuerdos antes de regresar a tu hotel.</p>"}
};

      var tourIncludes5 = new List<TourInclude>
{
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar ropa de baño", Tour = tour5 },
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer toallas", Tour = tour5 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Entrada al parque marino", Tour = tour5 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Almuerzo", Tour = tour5 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Fotografías con delfines", Tour = tour5 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Bebidas en el almuerzo", Tour = tour5 }
};

      var tourgalleryimages5 = new List<TourGalleryImage>
{
  new() {Agency = agency1, Tour = tour5, Image = $"image_{agency1.Name}_17.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_17.jpg"  },
  new() {Agency = agency1, Tour = tour5, Image = $"image_{agency1.Name}_18.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_18.jpg"  },
  new() {Agency = agency1, Tour = tour5, Image = $"image_{agency1.Name}_19.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_19.jpg"  },
  new() {Agency = agency1, Tour = tour5, Image = $"image_{agency1.Name}_20.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_20.jpg"  },
};

      tour5.TourIncludes = tourIncludes5;
      tour5.TourCategoryCompositions = tourCategoryCompositions5;
      tour5.TourSearchQueryCompositions = tourSearchQueryCompositions5;
      tour5.TourItineraries = tourItinerary5;
      tour5.TourGalleryImages = tourgalleryimages5;


      #endregion



      #region Tour 6


      // var tourCategory2 = new TourCategory
      // {
      //   Name = "Cenotes",
      //   Order = 1,
      //   Agency = agency1
      // };

      // var tourCategory3 = new TourCategory
      // {
      //   Name = "Aventuras",
      //   Order = 3,
      //   Agency = agency1
      // };


      // var tourSearchQuery3 = new TourSearchQuery
      // {
      //   Name = "Exploración",
      //   Order = 1,
      //   Agency = agency1
      // };


      var tourSearchQuery4 = new TourSearchQuery
      {
        Name = "Fitness",
        Order = 1,
        Agency = agency1
      };


      var direction4 = new TourDirection
      {
        Name = "Mérida",
        Agency = agency1
      };

      var tour6 = new Tour
      {
        Title = "Tour de Cenotes",
        TourType = TourType.MULTIDAY,
        Image = "imagenCenotes.png",
        ImageThumbnail = "imagenCenotesthumbnail.png",
        MetaKeywords = "cenotes, tour, viaje, aventura, México, naturaleza, excursión, vacaciones, turismo",
        Description = @"<p>Embárcate en una emocionante aventura de dos días explorando los cenotes más impresionantes de la península de Yucatán. Este tour te llevará a descubrir estas maravillas naturales, donde podrás nadar, bucear y relajarte en sus aguas cristalinas.</p>
    <p>Disfruta de un itinerario cuidadosamente planeado que incluye visitas a múltiples cenotes, actividades al aire libre y la oportunidad de aprender sobre la historia y la geología de estas formaciones naturales únicas. Ideal para los amantes de la naturaleza y la aventura.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "documentoCenotes.pdf",
        Duration = 2,
        DurationType = DurationType.DAYS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction4
      };


      var tourCategoryCompositions6 = new List<TourCategoryComposition>
          {
            new() {Tour = tour6, TourCategory = tourCategory2},
            new() {Tour = tour6, TourCategory = tourCategory3},
          };

      var tourSearchQueryCompositions6 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour1, TourSearchQuery = tourSearchQuery3},
            new() {Tour = tour1, TourSearchQuery = tourSearchQuery4}
          };

      var tourItinerary6 = new List<TourItinerary>
{
  new() {Agency = agency1, Tour = tour6, Day = 1, Description = @"
<p>Salida desde Cancún a las 8:00 AM hacia el primer cenote. Llega a las 9:30 AM y disfruta de una mañana nadando y explorando sus aguas. A las 12:00 PM, dirígete a un segundo cenote para más aventuras acuáticas.</p>
<p>Almuerzo a las 1:00 PM en un restaurante local. Continúa el recorrido a las 3:00 PM con una visita a un tercer cenote, donde puedes bucear y relajarte hasta las 6:00 PM. Cena y alojamiento en un hotel cercano.</p>"},
  new() {Agency = agency1, Tour = tour6, Day = 2, Description = @"
<p>Comienza el segundo día con un desayuno a las 8:00 AM. A las 9:00 AM, visita un cenote subterráneo y aprende sobre su formación geológica. A las 11:00 AM, realiza actividades de snorkel y fotografía subacuática.</p>
<p>Después de un almuerzo a las 12:30 PM, visita un cenote abierto para una tarde de relajación y exploración. Termina el tour a las 4:00 PM y regresa a Cancún, llegando alrededor de las 6:00 PM.</p>"}
};

      var tourIncludes6 = new List<TourInclude>
{
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar equipo de snorkel", Tour = tour6 },
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer zapatos acuáticos", Tour = tour6 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Transporte en autobús", Tour = tour6 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Alojamiento en hotel", Tour = tour6 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Comidas no especificadas", Tour = tour6 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour6 }
};

      var tourgalleryimages6 = new List<TourGalleryImage>
{
  new() {Agency = agency1, Tour = tour6, Image = $"image_{agency1.Name}_21.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_21.jpg"  },
  new() {Agency = agency1, Tour = tour6, Image = $"image_{agency1.Name}_22.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_22.jpg"  },
  new() {Agency = agency1, Tour = tour6, Image = $"image_{agency1.Name}_23.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_23.jpg"  },
  new() {Agency = agency1, Tour = tour6, Image = $"image_{agency1.Name}_24.jpg", ImageThumbnail = $"image_thumbnail_{agency1.Name}_24.jpg"  },
};

      tour6.TourIncludes = tourIncludes6;
      tour6.TourCategoryCompositions = tourCategoryCompositions6;
      tour6.TourSearchQueryCompositions = tourSearchQueryCompositions6;
      tour6.TourItineraries = tourItinerary6;
      tour6.TourGalleryImages = tourgalleryimages6;

      #endregion
      
      _context.Tours.Add(tour1);
      _context.Tours.Add(tour2);
      _context.Tours.Add(tour3);
      _context.Tours.Add(tour4);
      _context.Tours.Add(tour5);
      _context.Tours.Add(tour6);
      await _context.SaveChangesAsync();


      #region Other

      var populartours = new List<HomeTourPopularComposition>
      {
        new() {Tour = tour1, Agency = agency1, PopularType = PopularType.POPULAR, Order = 1},
        new() {Tour = tour2, Agency = agency1, PopularType = PopularType.POPULAR, Order = 2},

        new() {Tour = tour3, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 1},
        new() {Tour = tour4, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 1},
      };

      var otherGallery = new List<OtherGallery>
      {
        new() {Image = "fullresolutionimage1.png", ImageThumbnail = "imagethumbnail1.png", Order = 1, IsFavorite = false, Agency = agency1},
        new() {Image = "fullresolutionimage2.png", ImageThumbnail = "imagethumbnail2.png", Order = 2, IsFavorite = true, Agency = agency1},
        new() {Image = "fullresolutionimage3.png", ImageThumbnail = "imagethumbnail3.png", Order = 3, IsFavorite = true, Agency = agency1},
        new() {Image = "fullresolutionimage4.png", ImageThumbnail = "imagethumbnail4.png", Order = 4, IsFavorite = false, Agency = agency1},
        new() {Image = "fullresolutionimage5.png", ImageThumbnail = "imagethumbnail5.png", Order = 5, IsFavorite = true, Agency = agency1},
        new() {Image = "fullresolutionimage6.png", ImageThumbnail = "imagethumbnail6.png", Order = 6, IsFavorite = false, Agency = agency1},
        new() {Image = "fullresolutionimage7.png", ImageThumbnail = "imagethumbnail7.png", Order = 7, IsFavorite = true, Agency = agency1},
        new() {Image = "fullresolutionimage8.png", ImageThumbnail = "imagethumbnail8.png", Order = 8, IsFavorite = false, Agency = agency1},
      };

      _context.HomeTourPopularCompositions.AddRange(populartours);
      _context.OtherGalleries.AddRange(otherGallery);
      await _context.SaveChangesAsync();

      #endregion




    }
  }
}
