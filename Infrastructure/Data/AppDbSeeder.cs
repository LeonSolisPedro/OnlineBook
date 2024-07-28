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
        Name = "Agencia",
        Location = "Cuauhtémoc, 06060, CDMX",
        BusinessHours = "Lun - Vie: 9:00 a 17:00",
        PhoneContact = "5555555555",
        EmailContact = "pedro@wintercr.com",
        Copyright = "Derechos Reservados Agencia"
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
          new() {Agency = agency1, Currency = currency3, Order = 3},
        };

      var homeCarousel1 = new List<HomeCarousel>
        {
          new() {Image = $"/storage/home/1/image1.webp", Agency = agency1, Order = 1},
          new() {Image = $"/storage/home/1/image2.webp", Agency = agency1, Order = 2},
          new() {Image = $"/storage/home/1/image3.webp", Agency = agency1, Order = 3},
          new() {Image = $"/storage/home/1/image4.webp", Agency = agency1, Order = 4},
          new() {Image = $"/storage/home/1/image5.webp", Agency = agency1, Order = 5},
        };

      var homeOffers1 = new List<HomeOffer>
        {
          new() {Image = "/storage/offers/1/image1.webp", ImageThumbnail = "/storage/offers/1/image1_thumbnail.webp", Name = "Puerto Vallarta 2 x 1", IncludesHotel = true, IncludesFlights = true, MoreInfoLink = "https://www.linkedin.com/in/leonsolispedro/"},
          new() {Image = "/storage/offers/1/image2.webp", ImageThumbnail = "/storage/offers/1/image2_thumbnail.webp", Name = "Xcaret Descuento", IncludesHotel = true, IncludesFlights = true, IncludesTransportation = true, MoreInfoLink = "https://www.linkedin.com/in/leonsolispedro/"},
          new() {Image = "/storage/offers/1/image3.webp", ImageThumbnail = "/storage/offers/1/image3_thumbnail.webp", Name = "Oaxaca Gastronómico", IncludesFlights = true, IncludesTransportation = true, MoreInfoLink = "https://www.linkedin.com/in/leonsolispedro/"},
          new() {Image = "/storage/offers/1/image4.webp", ImageThumbnail = "/storage/offers/1/image4_thumbnail.webp", Name = "Tour Estudiantes", IncludesHotel = true, IncludesFlights = true, IncludesTransportation = true, MoreInfoLink = "https://www.linkedin.com/in/leonsolispedro/"},
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


      var tourCategory2 = new TourCategory
      {
        Name = "Aventuras",
        Order = 2,
        Agency = agency1
      };



      var tourCategory3 = new TourCategory
      {
        Name = "Cenotes",
        Order = 3,
        Agency = agency1
      };


      var tourCategory4 = new TourCategory
      {
        Name = "Gastronomía",
        Order = 4,
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
        Order = 2,
        Agency = agency1
      };

      var tourSearchQuery3 = new TourSearchQuery
      {
        Name = "Exploración",
        Order = 3,
        Agency = agency1
      };


      var tourSearchQuery4 = new TourSearchQuery
      {
        Name = "Fitness",
        Order = 4,
        Agency = agency1
      };

      var tourSearchQuery5 = new TourSearchQuery
      {
        Name = "Gastronomía",
        Order = 5,
        Agency = agency1
      };




      #endregion


      #region Tour 1

      var direction1 = new TourDirection
      {
        Name = "Cancún",
        Agency = agency1
      };

      var tour1 = new Tour
      {
        Title = "Playa en Cancún",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/1/imagenCancun.webp",
        ImageThumbnail = "/storage/tours/1/imagenCancun_thumbnail.webp",
        MetaKeywords = "playa, Cancún, tour, viaje, vacaciones, arena, mar, México, sol, turismo",
        Description = @"<p>Descubre la belleza de las playas de Cancún en un tour inolvidable. Relájate en la arena blanca y disfruta del mar turquesa mientras tomas el sol. Este destino paradisíaco en México ofrece un ambiente perfecto para descansar y desconectar del estrés diario. Además, podrás explorar la vida marina con actividades como snorkel y buceo, o simplemente pasear por la orilla mientras contemplas el atardecer.</p>
            <p>En Cancún, las opciones son infinitas. Puedes visitar el centro de la ciudad para experimentar la cultura local, probar la deliciosa gastronomía mexicana en los restaurantes cercanos o hacer una excursión a las ruinas mayas cercanas para aprender más sobre la historia de la región. Los tours están diseñados para ofrecerte una experiencia completa, combinando el relax de la playa con la emoción de descubrir nuevos lugares y actividades.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/1/documento.pdf",
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
            new() {Agency = agency1, Tour = tour1, Image = "/storage/tours/1/gallery/image1.webp", ImageThumbnail = "/storage/tours/1/gallery/image1_thumbnail.webp"  },
            new() {Agency = agency1, Tour = tour1, Image = "/storage/tours/1/gallery/image2.webp", ImageThumbnail = "/storage/tours/1/gallery/image2_thumbnail.webp"  },
            new() {Agency = agency1, Tour = tour1, Image = "/storage/tours/1/gallery/image3.webp", ImageThumbnail = "/storage/tours/1/gallery/image3_thumbnail.webp"  },
          };

      tour1.TourIncludes = tourIncludes1;
      tour1.TourCategoryCompositions = tourCategoryCompositions1;
      tour1.TourSearchQueryCompositions = tourSearchQueryCompositions1;
      tour1.TourItineraries = tourItinerary1;
      tour1.TourGalleryImages = tourgalleryimages1;

      #endregion


      #region Tour 2


      // var direction1 = new TourDirection
      // {
      //   Name = "Cancún",
      //   Agency = agency1
      // };

      var tour2 = new Tour
      {
        Title = "Aventura en Xcaret",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/2/imagenXcaret.webp",
        ImageThumbnail = "/storage/tours/2/imagenXcaretthumbnail.webp",
        MetaKeywords = "aventura, Xcaret, tour, viaje, diversión, México, parque, naturaleza, eco-turismo",
        Description = @"<p>Explora las maravillas naturales de Xcaret en un emocionante tour de un día. Sumérgete en la belleza de los ríos subterráneos, nada en caletas y lagunas cristalinas, y descubre la rica fauna y flora del parque. Xcaret ofrece una combinación perfecta de aventura y relax, con actividades para todas las edades.</p>
                          <p>Visita el acuario, el mariposario, y aprende sobre la cultura maya a través de espectáculos y exposiciones. Este tour es ideal para familias y amantes de la naturaleza que buscan una experiencia única y memorable.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/2/documentoXcaret.pdf",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction1
      };

      var tourCategoryCompositions2 = new List<TourCategoryComposition>
          {
            new() {Tour = tour2, TourCategory = tourCategory2}
          };

      var tourSearchQueryCompositions2 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour2, TourSearchQuery = tourSearchQuery1},
            new() {Tour = tour2, TourSearchQuery = tourSearchQuery3}
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
  new() {Agency = agency1, Tour = tour2, Image = "/storage/tours/2/gallery/image1.webp", ImageThumbnail = "/storage/tours/2/gallery/image1_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour2, Image = "/storage/tours/2/gallery/image2.webp", ImageThumbnail = "/storage/tours/2/gallery/image2_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour2, Image = "/storage/tours/2/gallery/image3.webp", ImageThumbnail = "/storage/tours/2/gallery/image3_thumbnail.webp"  },
};

      tour2.TourIncludes = tourIncludes2;
      tour2.TourCategoryCompositions = tourCategoryCompositions2;
      tour2.TourSearchQueryCompositions = tourSearchQueryCompositions2;
      tour2.TourItineraries = tourItinerary2;
      tour2.TourGalleryImages = tourgalleryimages2;


      #endregion



      #region Tour 3

      var direction2 = new TourDirection
      {
        Name = "Isla Mujeres",
        Agency = agency1
      };

      var tour3 = new Tour
      {
        Title = "Isla Mujeres",
        TourType = TourType.SINGLEDAY,
        Image = "imagenIslaMujeres.webp",
        ImageThumbnail = "imagenIslaMujeresthumbnail.webp",
        MetaKeywords = "isla, Mujeres, tour, viaje, playa, mar, México, sol, vacaciones, turismo",
        Description = @"<p>Explora la encantadora Isla Mujeres en un tour de un día. Disfruta de la tranquilidad de sus playas, nada en aguas cristalinas y descubre la belleza natural de este paraíso mexicano. Este tour es ideal para quienes buscan una escapada relajante y pintoresca.</p>
    <p>Pasea por el centro de la isla, prueba la deliciosa comida local y visita el parque Garrafón para actividades acuáticas y vistas espectaculares. Isla Mujeres ofrece una experiencia única llena de paz y belleza natural.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/3/documentoIslaMujeres.pdf",
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
    new() {Agency = agency1, Tour = tour3, Image = "/storage/tours/3/gallery/image1.webp", ImageThumbnail = "/storage/tours/3/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour3, Image = "/storage/tours/3/gallery/image2.webp", ImageThumbnail = "/storage/tours/3/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour3, Image = "/storage/tours/3/gallery/image3.webp", ImageThumbnail = "/storage/tours/3/gallery/image3_thumbnail.webp"  },
  };

      tour3.TourIncludes = tourIncludes3;
      tour3.TourCategoryCompositions = tourCategoryCompositions3;
      tour3.TourSearchQueryCompositions = tourSearchQueryCompositions3;
      tour3.TourItineraries = tourItinerary3;
      tour3.TourGalleryImages = tourgalleryimages3;
      #endregion



      #region Tour 4

      var direction3 = new TourDirection
      {
        Name = "Yucatán",
        Agency = agency1
      };

      var tour4 = new Tour
      {
        Title = "Chichén Itzá y Cenote",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/4/imagenChichenItza.webp",
        ImageThumbnail = "/storage/tours/4/imagenChichenItzathumbnail.webp",
        MetaKeywords = "Chichén Itzá, cenote, tour, viaje, historia, México, arqueología, mayas, turismo",
        Description = @"<p>Descubre la majestuosidad de Chichén Itzá y refréscate en un cenote cercano en este tour de un día. Conoce la historia de la civilización maya mientras exploras las impresionantes ruinas arqueológicas y aprende sobre su cultura y arquitectura.</p>
    <p>Después de la visita a Chichén Itzá, disfruta de un almuerzo tradicional y báñate en un cenote sagrado, una experiencia única que te conectará con la naturaleza y la historia de la región. Este tour combina aventura, historia y naturaleza en un solo día.</p>",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction3
      };


      var tourCategoryCompositions4 = new List<TourCategoryComposition>
          {
            new() {Tour = tour4, TourCategory = tourCategory3}
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
  new() {Agency = agency1, Tour = tour4, Image = "/storage/tours/4/gallery/image1.webp", ImageThumbnail = "/storage/tours/4/gallery/image1_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour4, Image = "/storage/tours/4/gallery/image2.webp", ImageThumbnail = "/storage/tours/4/gallery/image2_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour4, Image = "/storage/tours/4/gallery/image3.webp", ImageThumbnail = "/storage/tours/4/gallery/image3_thumbnail.webp"  },
};


      tour4.TourIncludes = tourIncludes4;
      tour4.TourCategoryCompositions = tourCategoryCompositions4;
      tour4.TourSearchQueryCompositions = tourSearchQueryCompositions4;
      tour4.TourItineraries = tourItinerary4;
      tour4.TourGalleryImages = tourgalleryimages4;


      #endregion

      #region Tour 5


      // var direction1 = new TourDirection
      // {
      //   Name = "Cancún",
      //   Agency = agency1
      // };


      var tour5 = new Tour
      {
        Title = "Nado con Delfines",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/5/imagenDelfines.webp",
        ImageThumbnail = "/storage/tours/5/imagenDelfinesthumbnail.webp",
        MetaKeywords = "delfines, nado, tour, viaje, mar, México, aventura, vacaciones, turismo",
        Description = @"<p>Vive una experiencia única nadando con delfines en Cancún. Este tour de un día te permitirá interactuar de cerca con estos increíbles animales, aprender sobre su comportamiento y disfrutar de un momento mágico en el mar.</p>
    <p>Después del nado, relájate en la playa y disfruta de las instalaciones del parque marino. Este tour es perfecto para los amantes de la naturaleza y aquellos que buscan una experiencia inolvidable durante sus vacaciones.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/5/documentoDelfines.pdf",
        Duration = 3,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction1
      };

      var tourCategoryCompositions5 = new List<TourCategoryComposition>
          {
            new() {Tour = tour5, TourCategory = tourCategory1}
          };

      var tourSearchQueryCompositions5 = new List<TourSearchQueryComposition>
          {
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
  new() {Agency = agency1, Tour = tour5, Image = "/storage/tours/5/gallery/image1.webp", ImageThumbnail = "/storage/tours/5/gallery/image1_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour5, Image = "/storage/tours/5/gallery/image2.webp", ImageThumbnail = "/storage/tours/5/gallery/image2_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour5, Image = "/storage/tours/5/gallery/image3.webp", ImageThumbnail = "/storage/tours/5/gallery/image3_thumbnail.webp"  },
};

      tour5.TourIncludes = tourIncludes5;
      tour5.TourCategoryCompositions = tourCategoryCompositions5;
      tour5.TourSearchQueryCompositions = tourSearchQueryCompositions5;
      tour5.TourItineraries = tourItinerary5;
      tour5.TourGalleryImages = tourgalleryimages5;


      #endregion



      #region Tour 6


      // var direction3 = new TourDirection
      // {
      //   Name = "Yucatán",
      //   Agency = agency1
      // };

      var tour6 = new Tour
      {
        Title = "Tour de Cenotes",
        TourType = TourType.MULTIDAY,
        Image = "/storage/tours/6/imagenCenotes.webp",
        ImageThumbnail = "/storage/tours/6/imagenCenotesthumbnail.webp",
        MetaKeywords = "cenotes, tour, viaje, aventura, México, naturaleza, excursión, vacaciones, turismo",
        Description = @"<p>Embárcate en una emocionante aventura de dos días explorando los cenotes más impresionantes de la península de Yucatán. Este tour te llevará a descubrir estas maravillas naturales, donde podrás nadar, bucear y relajarte en sus aguas cristalinas.</p>
    <p>Disfruta de un itinerario cuidadosamente planeado que incluye visitas a múltiples cenotes, actividades al aire libre y la oportunidad de aprender sobre la historia y la geología de estas formaciones naturales únicas. Ideal para los amantes de la naturaleza y la aventura.</p>",
        Duration = 2,
        DurationType = DurationType.DAYS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction3
      };


      var tourCategoryCompositions6 = new List<TourCategoryComposition>
          {
            new() {Tour = tour6, TourCategory = tourCategory3},
            new() {Tour = tour6, TourCategory = tourCategory2},
          };

      var tourSearchQueryCompositions6 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour6, TourSearchQuery = tourSearchQuery2},
            new() {Tour = tour6, TourSearchQuery = tourSearchQuery4}
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
  new() {Agency = agency1, Tour = tour6, Image = "/storage/tours/6/gallery/image1.webp", ImageThumbnail = "/storage/tours/6/gallery/image1_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour6, Image = "/storage/tours/6/gallery/image2.webp", ImageThumbnail = "/storage/tours/6/gallery/image2_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour6, Image = "/storage/tours/6/gallery/image3.webp", ImageThumbnail = "/storage/tours/6/gallery/image3_thumbnail.webp"  },
};

      tour6.TourIncludes = tourIncludes6;
      tour6.TourCategoryCompositions = tourCategoryCompositions6;
      tour6.TourSearchQueryCompositions = tourSearchQueryCompositions6;
      tour6.TourItineraries = tourItinerary6;
      tour6.TourGalleryImages = tourgalleryimages6;

      #endregion


      #region Tour 7

      var direction5 = new TourDirection
      {
        Name = "Ciudad de México",
        Agency = agency1
      };

      var tour7 = new Tour
      {
        Title = "Tour Histórico en Ciudad de México",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/7/imagenCDMX.webp",
        ImageThumbnail = "/storage/tours/7/imagenCDMXthumbnail.webp",
        MetaKeywords = "Ciudad de México, tour, histórico, viaje, vacaciones, cultura, México, turismo",
        Description = @"<p>Explora la rica historia de la Ciudad de México en este tour de un día. Visita el Zócalo, la Catedral Metropolitana y el Palacio de Bellas Artes. Aprende sobre la historia y cultura de México con guías expertos y disfruta de la gastronomía local en un restaurante tradicional.</p>
    <p>Este tour es ideal para aquellos interesados en la historia y la cultura de una de las ciudades más grandes y vibrantes del mundo. Descubre monumentos icónicos y maravíllate con la arquitectura colonial.</p>",
        Duration = 5,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction5
      };

      var tourCategoryCompositions7 = new List<TourCategoryComposition>
          {
            new() {Tour = tour7, TourCategory = tourCategory2},
            new() {Tour = tour7, TourCategory = tourCategory4},
          };

      var tourSearchQueryCompositions7 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour7, TourSearchQuery = tourSearchQuery5},
            new() {Tour = tour7, TourSearchQuery = tourSearchQuery3}
          };

      var tourItinerary7 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour7, Day = 1, Description = @"
  <p>Comienza tu día a las 8:00 AM en el Zócalo, el corazón de la Ciudad de México. A las 9:00 AM, visita la Catedral Metropolitana y explora su impresionante arquitectura y rica historia. A las 10:30 AM, dirígete al Palacio Nacional para admirar los murales de Diego Rivera.</p>
  <p>A las 12:00 PM, disfruta de un almuerzo en un restaurante tradicional mexicano. A las 2:00 PM, visita el Templo Mayor, donde aprenderás sobre la antigua civilización azteca. A las 4:00 PM, pasea por el Palacio de Bellas Artes y sus jardines.</p>
  <p>Termina el día con una caminata por el Paseo de la Reforma a las 6:00 PM, disfrutando de las vistas y la atmósfera de esta vibrante ciudad antes de regresar a tu hotel a las 8:00 PM.</p>"}
  };

      var tourIncludes7 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar calzado cómodo", Tour = tour7 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer cámara fotográfica", Tour = tour7 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Guía turístico", Tour = tour7 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a museos", Tour = tour7 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour7 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour7 }
  };

      var tourgalleryimages7 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour7, Image = "/storage/tours/7/gallery/image1.webp", ImageThumbnail = "/storage/tours/7/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour7, Image = "/storage/tours/7/gallery/image2.webp", ImageThumbnail = "/storage/tours/7/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour7, Image = "/storage/tours/7/gallery/image3.webp", ImageThumbnail = "/storage/tours/7/gallery/image3_thumbnail.webp"  },
  };

      tour7.TourIncludes = tourIncludes7;
      tour7.TourCategoryCompositions = tourCategoryCompositions7;
      tour7.TourSearchQueryCompositions = tourSearchQueryCompositions7;
      tour7.TourItineraries = tourItinerary7;
      tour7.TourGalleryImages = tourgalleryimages7;
      #endregion


      #region Tour 8

      var direction6 = new TourDirection
      {
        Name = "Puebla",
        Agency = agency1
      };

      var tour8 = new Tour
      {
        Title = "Experiencia Cultural en Puebla",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/8/imagenPuebla.webp",
        ImageThumbnail = "/storage/tours/8/imagenPueblathumbnail.webp",
        MetaKeywords = "Puebla, tour, cultural, viaje, vacaciones, México, historia, turismo",
        Description = @"<p>Descubre la riqueza cultural de Puebla en un tour de un día. Visita la Catedral de Puebla, la Biblioteca Palafoxiana y la Capilla del Rosario. Disfruta de la famosa gastronomía poblana con una degustación de mole poblano y chiles en nogada.</p>
    <p>Este tour te llevará a través de la historia y la cultura de esta encantadora ciudad colonial, famosa por su arquitectura y deliciosa comida. Ideal para los amantes de la cultura y la historia.</p>",
        Duration = 5,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction6
      };


      var tourCategoryCompositions8 = new List<TourCategoryComposition>
          {
            new() {Tour = tour8, TourCategory = tourCategory2},
            new() {Tour = tour8, TourCategory = tourCategory4},
          };

      var tourSearchQueryCompositions8 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour8, TourSearchQuery = tourSearchQuery5},
            new() {Tour = tour8, TourSearchQuery = tourSearchQuery3}
          };

      var tourItinerary8 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour8, Day = 1, Description = @"
  <p>Comienza tu día a las 8:00 AM visitando la majestuosa Catedral de Puebla. A las 10:00 AM, explora la Biblioteca Palafoxiana, una de las bibliotecas más antiguas de América. A las 11:30 AM, maravíllate con la Capilla del Rosario y su impresionante decoración barroca.</p>
  <p>A la 1:00 PM, disfruta de un almuerzo tradicional poblano, degustando platos como mole poblano y chiles en nogada. A las 3:00 PM, visita el Barrio del Artista, donde podrás admirar y comprar artesanías locales. Termina el día con una visita al mercado de El Parián a las 5:00 PM.</p>
  <p>Regresa a tu hotel a las 7:00 PM, llevando contigo recuerdos inolvidables y experiencias culturales enriquecedoras de la ciudad de Puebla.</p>"}
  };

      var tourIncludes8 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar calzado cómodo", Tour = tour8 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer efectivo para compras", Tour = tour8 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Guía turístico", Tour = tour8 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a sitios", Tour = tour8 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour8 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour8 }
  };

      var tourgalleryimages8 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour8, Image = "/storage/tours/8/gallery/image1.webp", ImageThumbnail = "/storage/tours/8/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour8, Image = "/storage/tours/8/gallery/image2.webp", ImageThumbnail = "/storage/tours/8/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour8, Image = "/storage/tours/8/gallery/image3.webp", ImageThumbnail = "/storage/tours/8/gallery/image3_thumbnail.webp"  },
  };

      tour8.TourIncludes = tourIncludes8;
      tour8.TourCategoryCompositions = tourCategoryCompositions8;
      tour8.TourSearchQueryCompositions = tourSearchQueryCompositions8;
      tour8.TourItineraries = tourItinerary8;
      tour8.TourGalleryImages = tourgalleryimages8;


      #endregion



      #region Tour 9

      var direction7 = new TourDirection
      {
        Name = "Oaxaca",
        Agency = agency1
      };

      var tour9 = new Tour
      {
        Title = "Tour Gastronómico en Oaxaca",
        TourType = TourType.MULTIDAY,
        Image = "/storage/tours/9/imagenOaxaca.webp",
        ImageThumbnail = "/storage/tours/9/imagenOaxacathumbnail.webp",
        MetaKeywords = "Oaxaca, tour, gastronómico, viaje, comida, vacaciones, México, turismo",
        Description = @"<p>Experimenta los sabores únicos de Oaxaca en este tour de dos días. Disfruta de la comida tradicional oaxaqueña, incluyendo mole, tlayudas y mezcal. Visita mercados locales, aprende sobre la cultura culinaria y participa en una clase de cocina con un chef local.</p>
    <p>Este tour es perfecto para los amantes de la gastronomía que desean sumergirse en los sabores y tradiciones de una de las regiones culinarias más ricas de México.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/9/documentoOaxaca.pdf",
        Duration = 2,
        DurationType = DurationType.DAYS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction7
      };


      var tourCategoryCompositions9 = new List<TourCategoryComposition>
          {
            new() {Tour = tour9, TourCategory = tourCategory4}
          };

      var tourSearchQueryCompositions9 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour9, TourSearchQuery = tourSearchQuery5},
            new() {Tour = tour9, TourSearchQuery = tourSearchQuery1}
          };

      var tourItinerary9 = new List<TourItinerary>
  {
  new() {Agency = agency1, Tour = tour9, Day = 1, Description = @"
  <p>Comienza el día con una visita al Mercado de Benito Juárez a las 9:00 AM, donde podrás degustar una variedad de productos locales. A las 11:00 AM, participa en una clase de cocina con un chef local, aprendiendo a preparar mole y tlayudas.</p>
  <p>Después de un almuerzo preparado por ti mismo, visita una fábrica de mezcal a las 3:00 PM para conocer el proceso de producción y degustar diferentes tipos de mezcal. Termina el día con una cena</p>"},
  new() {Agency = agency1, Tour = tour9, Day = 2, Description = @"
  <p>Comienza el segundo día con un desayuno típico oaxaqueño a las 8:00 AM. A las 9:00 AM, visita el Mercado 20 de Noviembre para explorar más de la gastronomía local. A las 11:00 AM, realiza un recorrido por una plantación de cacao y aprende sobre la elaboración del chocolate oaxaqueño.</p>
  <p>Después de un almuerzo en el mercado, visita el Jardín Etnobotánico a las 2:00 PM para conocer las plantas nativas de la región. Termina el tour con una cena en un restaurante local a las 7:00 PM, disfrutando de una degustación de platos tradicionales.</p>"}
  };

      var tourIncludes9 = new List<TourInclude>
{
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer cámara fotográfica", Tour = tour9 },
  new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Usar ropa cómoda", Tour = tour9 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Clases de cocina", Tour = tour9 },
  new() { IncludeType = IncludeType.INCLUDES, Description = "Degustaciones", Tour = tour9 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzos", Tour = tour9 },
  new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour9 }
};

      var tourgalleryimages9 = new List<TourGalleryImage>
{
  new() {Agency = agency1, Tour = tour9, Image = "/storage/tours/9/gallery/image1.webp", ImageThumbnail = "/storage/tours/9/gallery/image1_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour9, Image = "/storage/tours/9/gallery/image2.webp", ImageThumbnail = "/storage/tours/9/gallery/image2_thumbnail.webp"  },
  new() {Agency = agency1, Tour = tour9, Image = "/storage/tours/9/gallery/image3.webp", ImageThumbnail = "/storage/tours/9/gallery/image3_thumbnail.webp"  },
};

      tour9.TourIncludes = tourIncludes9;
      tour9.TourCategoryCompositions = tourCategoryCompositions9;
      tour9.TourSearchQueryCompositions = tourSearchQueryCompositions9;
      tour9.TourItineraries = tourItinerary9;
      tour9.TourGalleryImages = tourgalleryimages9;

      #endregion


      #region Tour 10

      var direction8 = new TourDirection
      {
        Name = "Guadalajara",
        Agency = agency1
      };


      var tour10 = new Tour
      {
        Title = "Tour de Tequila en Guadalajara",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/10/imagenGuadalajara.webp",
        ImageThumbnail = "/storage/tours/10/imagenGuadalajarathumbnail.webp",
        MetaKeywords = "Guadalajara, tour, tequila, viaje, vacaciones, México, bebida, turismo",
        Description = @"<p>Descubre el proceso de elaboración del tequila en este tour de un día en Guadalajara. Visita destilerías famosas y conoce la historia de esta icónica bebida mexicana. Disfruta de catas de diferentes tipos de tequila y aprende a diferenciar sus sabores únicos.</p>
    <p>Este tour es ideal para los amantes de las bebidas espirituosas que desean conocer más sobre el proceso de destilación del tequila y disfrutar de un día en la región de Jalisco.</p>",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction8
      };


      var tourCategoryCompositions10 = new List<TourCategoryComposition>
          {
            new() {Tour = tour10, TourCategory = tourCategory4}
          };

      var tourSearchQueryCompositions10 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour10, TourSearchQuery = tourSearchQuery5},
            new() {Tour = tour10, TourSearchQuery = tourSearchQuery1}
          };

      var tourItinerary10 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour10, Day = 1, Description = @"
  <p>Comienza el día con una visita a las plantaciones de agave a las 9:00 AM, donde aprenderás sobre el cultivo de la planta base del tequila. A las 11:00 AM, dirígete a una destilería local para ver el proceso de destilación en acción y disfrutar de una cata de tequila.</p>
  <p>A las 1:00 PM, almuerza en un restaurante típico de Jalisco, probando platos locales que maridan perfectamente con el tequila. A las 3:00 PM, visita una segunda destilería para conocer diferentes métodos de producción y degustar más variedades de tequila.</p>
  <p>Termina el tour a las 5:00 PM con una visita al Museo del Tequila y el Mariachi en el centro de Guadalajara, donde podrás aprender sobre la historia y la cultura del tequila y la música tradicional mexicana.</p>"}
  };

      var tourIncludes10 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar calzado cómodo", Tour = tour10 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer sombrero para el sol", Tour = tour10 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a destilerías", Tour = tour10 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Degustaciones", Tour = tour10 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour10 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour10 }
  };

      var tourgalleryimages10 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour10, Image = "/storage/tours/10/gallery/image1.webp", ImageThumbnail = "/storage/tours/10/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour10, Image = "/storage/tours/10/gallery/image2.webp", ImageThumbnail = "/storage/tours/10/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour10, Image = "/storage/tours/10/gallery/image3.webp", ImageThumbnail = "/storage/tours/10/gallery/image3_thumbnail.webp"  },
  };

      tour10.TourIncludes = tourIncludes10;
      tour10.TourCategoryCompositions = tourCategoryCompositions10;
      tour10.TourSearchQueryCompositions = tourSearchQueryCompositions10;
      tour10.TourItineraries = tourItinerary10;
      tour10.TourGalleryImages = tourgalleryimages10;

      #endregion


      #region Tour 11

      var direction9 = new TourDirection
      {
        Name = "Monterrey",
        Agency = agency1
      };


      var tour11 = new Tour
      {
        Title = "Tour de Aventura en Monterrey",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/11/imagenMonterrey.webp",
        ImageThumbnail = "/storage/tours/11/imagenMonterreythumbnail.webp",
        MetaKeywords = "Monterrey, tour, aventura, viaje, vacaciones, México, turismo, naturaleza",
        Description = @"<p>Experimenta la emoción de las actividades al aire libre en Monterrey con este tour de un día. Disfruta de una caminata en el Parque Chipinque, seguido de una visita a la impresionante Cascada Cola de Caballo. Termina el día con un paseo en bote en el Paseo Santa Lucía.</p>
    <p>Este tour es perfecto para los amantes de la naturaleza y la aventura que desean explorar la belleza natural de Monterrey y disfrutar de un día lleno de actividades emocionantes.</p>",
        Duration = 5,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction9
      };


      var tourCategoryCompositions11 = new List<TourCategoryComposition>
          {
            new() {Tour = tour11, TourCategory = tourCategory2}
          };

      var tourSearchQueryCompositions11 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour11, TourSearchQuery = tourSearchQuery4},
            new() {Tour = tour11, TourSearchQuery = tourSearchQuery3}
          };

      var tourItinerary11 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour11, Day = 1, Description = @"
  <p>Comienza el día con una caminata en el Parque Chipinque a las 8:00 AM, disfrutando de las vistas panorámicas y la vida silvestre local. A las 10:00 AM, dirígete a la Cascada Cola de Caballo para maravillarte con su impresionante caída de agua.</p>
  <p>A las 12:00 PM, disfruta de un almuerzo campestre en el área de picnic cercana. A las 2:00 PM, visita el Parque Fundidora para explorar sus atracciones y museos. A las 4:00 PM, embarca en un paseo en bote por el Paseo Santa Lucía, disfrutando del paisaje urbano y los canales.</p>
  <p>Termina el tour a las 6:00 PM con una cena en un restaurante local, degustando platillos típicos de Monterrey antes de regresar a tu hotel a las 8:00 PM.</p>"}
  };

      var tourIncludes11 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar ropa deportiva", Tour = tour11 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer cámara fotográfica", Tour = tour11 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a parques", Tour = tour11 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Paseo en bote", Tour = tour11 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour11 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour11 }
  };

      var tourgalleryimages11 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour11, Image = "/storage/tours/11/gallery/image1.webp", ImageThumbnail = "/storage/tours/11/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour11, Image = "/storage/tours/11/gallery/image2.webp", ImageThumbnail = "/storage/tours/11/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour11, Image = "/storage/tours/11/gallery/image3.webp", ImageThumbnail = "/storage/tours/11/gallery/image3_thumbnail.webp"  },
  };

      tour11.TourIncludes = tourIncludes11;
      tour11.TourCategoryCompositions = tourCategoryCompositions11;
      tour11.TourSearchQueryCompositions = tourSearchQueryCompositions11;
      tour11.TourItineraries = tourItinerary11;
      tour11.TourGalleryImages = tourgalleryimages11;
      #endregion


      #region Tour 12

      var direction10 = new TourDirection
      {
        Name = "Guanajuato",
        Agency = agency1
      };

      var tour12 = new Tour
      {
        Title = "Tour de Arte en San Miguel de Allende",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/12/imagenSanMiguel.webp",
        ImageThumbnail = "/storage/tours/12/imagenSanMiguelthumbnail.webp",
        MetaKeywords = "San Miguel de Allende, tour, arte, viaje, vacaciones, México, cultura, turismo",
        Description = @"<p>Descubre el vibrante mundo del arte en San Miguel de Allende en este tour de un día. Visita galerías de arte contemporáneo, estudios de artistas locales y participa en talleres creativos. Aprende sobre la historia artística de la ciudad y disfruta de un ambiente cultural único.</p>
    <p>Este tour es ideal para los amantes del arte y la cultura que desean sumergirse en la creatividad de San Miguel de Allende y explorar sus numerosas galerías y estudios.</p>",
        LinkVideo = "https://youtube.com",
        LinkPDFItinerary = "/storage/tours/12/documentoSanMiguel.pdf",
        Duration = 5,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction10
      };

      var tourCategoryCompositions12 = new List<TourCategoryComposition>
          {
            new() {Tour = tour12, TourCategory = tourCategory2}
          };

      var tourSearchQueryCompositions12 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour12, TourSearchQuery = tourSearchQuery3},
            new() {Tour = tour12, TourSearchQuery = tourSearchQuery1}
          };

      var tourItinerary12 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour12, Day = 1, Description = @"
  <p>Comienza el día a las 9:00 AM con una visita a la Galería de Arte Contemporáneo, donde podrás admirar obras de artistas locales e internacionales. A las 11:00 AM, dirígete a un estudio de un artista local para conocer su proceso creativo y técnicas.</p>
  <p>A la 1:00 PM, disfruta de un almuerzo en un café artístico, rodeado de obras de arte. A las 2:30 PM, participa en un taller de pintura o escultura, guiado por un artista experimentado. A las 4:00 PM, explora el Mercado de Artesanías para comprar recuerdos únicos.</p>
  <p>Termina el tour a las 6:00 PM con una visita a una galería de arte tradicional, donde aprenderás sobre la historia del arte en San Miguel de Allende antes de regresar a tu hotel a las 8:00 PM.</p>"}
  };

      var tourIncludes12 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar ropa cómoda", Tour = tour12 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Traer cuaderno de bocetos", Tour = tour12 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a galerías", Tour = tour12 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Taller creativo", Tour = tour12 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour12 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour12 }
  };

      var tourgalleryimages12 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour12, Image = "/storage/tours/12/gallery/image1.webp", ImageThumbnail = "/storage/tours/12/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour12, Image = "/storage/tours/12/gallery/image2.webp", ImageThumbnail = "/storage/tours/12/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour12, Image = "/storage/tours/12/gallery/image3.webp", ImageThumbnail = "/storage/tours/12/gallery/image3_thumbnail.webp"  },
  };

      tour12.TourIncludes = tourIncludes12;
      tour12.TourCategoryCompositions = tourCategoryCompositions12;
      tour12.TourSearchQueryCompositions = tourSearchQueryCompositions12;
      tour12.TourItineraries = tourItinerary12;
      tour12.TourGalleryImages = tourgalleryimages12;


      #endregion


      #region Tour 13

      var direction11 = new TourDirection
      {
        Name = "Tulum",
        Agency = agency1
      };


      var tour13 = new Tour
      {
        Title = "Tour de Playa y Ruinas en Tulum",
        TourType = TourType.SINGLEDAY,
        Image = "/storage/tours/13/imagenTulum.webp",
        ImageThumbnail = "/storage/tours/13/imagenTulumthumbnail.webp",
        MetaKeywords = "Tulum, tour, playa, ruinas, viaje, vacaciones, México, turismo, historia",
        Description = @"<p>Explora las hermosas playas y las impresionantes ruinas mayas de Tulum en este tour de un día. Disfruta de la arena blanca y las aguas turquesas, y aprende sobre la historia de la civilización maya en las ruinas de Tulum. Este tour combina historia y relajación en un entorno paradisíaco.</p>
    <p>Ideal para aquellos que desean disfrutar de la belleza natural de Tulum y conocer más sobre la historia y cultura maya.</p>",
        LinkVideo = "https://youtube.com",
        Duration = 6,
        DurationType = DurationType.HOURS,
        IsInternational = false,
        Agency = agency1,
        TourDirection = direction11
      };

      var tourCategoryCompositions13 = new List<TourCategoryComposition>
          {
            new() {Tour = tour13, TourCategory = tourCategory1}
          };

      var tourSearchQueryCompositions13 = new List<TourSearchQueryComposition>
          {
            new() {Tour = tour13, TourSearchQuery = tourSearchQuery3},
            new() {Tour = tour13, TourSearchQuery = tourSearchQuery2}
          };

      var tourItinerary13 = new List<TourItinerary>
  {
    new() {Agency = agency1, Tour = tour13, Day = 1, Description = @"
  <p>Comienza el día con una visita a las ruinas de Tulum a las 9:00 AM, explorando los antiguos templos y edificios con una guía que te explicará la historia y cultura maya. A las 11:00 AM, baja a la playa cercana y disfruta de tiempo libre para nadar y relajarte en la arena blanca.</p>
  <p>A la 1:00 PM, almuerza en un restaurante frente al mar, degustando mariscos frescos y platos locales. A las 2:30 PM, realiza una caminata por la reserva natural de Sian Ka'an, observando la flora y fauna de la región.</p>
  <p>Termina el tour a las 5:00 PM con una visita a un cenote cercano, donde podrás nadar en sus aguas cristalinas antes de regresar a tu hotel a las 7:00 PM.</p>"}
  };

      var tourIncludes13 = new List<TourInclude>
  {
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Llevar traje de baño", Tour = tour13 },
    new() { IncludeType = IncludeType.RECOMENDATIONS, Description = "Usar protector solar", Tour = tour13 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Entradas a ruinas", Tour = tour13 },
    new() { IncludeType = IncludeType.INCLUDES, Description = "Guía turístico", Tour = tour13 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Almuerzo", Tour = tour13 },
    new() { IncludeType = IncludeType.EXCLUDES, Description = "Propinas", Tour = tour13 }
  };

      var tourgalleryimages13 = new List<TourGalleryImage>
  {
    new() {Agency = agency1, Tour = tour13, Image = "/storage/tours/13/gallery/image1.webp", ImageThumbnail = "/storage/tours/13/gallery/image1_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour13, Image = "/storage/tours/13/gallery/image2.webp", ImageThumbnail = "/storage/tours/13/gallery/image2_thumbnail.webp"  },
    new() {Agency = agency1, Tour = tour13, Image = "/storage/tours/13/gallery/image3.webp", ImageThumbnail = "/storage/tours/13/gallery/image3_thumbnail.webp"  },
  };

      tour13.TourIncludes = tourIncludes13;
      tour13.TourCategoryCompositions = tourCategoryCompositions13;
      tour13.TourSearchQueryCompositions = tourSearchQueryCompositions13;
      tour13.TourItineraries = tourItinerary13;
      tour13.TourGalleryImages = tourgalleryimages13;

      #endregion

      #region Similar Tours
      var tourSimilars1 = new List<TourSimilar>
{
  new() {Tour = tour5, Agency = agency1},
  new() {Tour = tour13, Agency = agency1},
  new() {Tour = tour3, Agency = agency1},
};
      tour1.TourSimilar = tourSimilars1;



      var tourSimilars2 = new List<TourSimilar>
{
  new() {Tour = tour6, Agency = agency1},
  new() {Tour = tour4, Agency = agency1},
  new() {Tour = tour11, Agency = agency1},
};
      tour2.TourSimilar = tourSimilars2;



      var tourSimilars3 = new List<TourSimilar>
{
  new() {Tour = tour1, Agency = agency1},
  new() {Tour = tour13, Agency = agency1},
  new() {Tour = tour5, Agency = agency1},
};
      tour3.TourSimilar = tourSimilars3;


      var tourSimilars4 = new List<TourSimilar>
{
  new() {Tour = tour6, Agency = agency1},
  new() {Tour = tour2, Agency = agency1},
  new() {Tour = tour11, Agency = agency1},
};
      tour4.TourSimilar = tourSimilars4;


      var tourSimilars5 = new List<TourSimilar>
{
  new() {Tour = tour1, Agency = agency1},
  new() {Tour = tour13, Agency = agency1},
  new() {Tour = tour3, Agency = agency1},
};
      tour5.TourSimilar = tourSimilars5;


      var tourSimilars6 = new List<TourSimilar>
{
  new() {Tour = tour4, Agency = agency1},
  new() {Tour = tour2, Agency = agency1},
  new() {Tour = tour11, Agency = agency1},
};
      tour6.TourSimilar = tourSimilars6;


      var tourSimilars7 = new List<TourSimilar>
{
  new() {Tour = tour8, Agency = agency1},
  new() {Tour = tour9, Agency = agency1},
  new() {Tour = tour12, Agency = agency1},
};
      tour7.TourSimilar = tourSimilars7;


      var tourSimilars8 = new List<TourSimilar>
{
  new() {Tour = tour7, Agency = agency1},
  new() {Tour = tour9, Agency = agency1},
  new() {Tour = tour12, Agency = agency1},
};
      tour8.TourSimilar = tourSimilars8;


      var tourSimilars9 = new List<TourSimilar>
{
  new() {Tour = tour10, Agency = agency1},
  new() {Tour = tour8, Agency = agency1},
  new() {Tour = tour7, Agency = agency1},
};
      tour9.TourSimilar = tourSimilars9;


      var tourSimilars10 = new List<TourSimilar>
{
  new() {Tour = tour9, Agency = agency1},
  new() {Tour = tour8, Agency = agency1},
  new() {Tour = tour7, Agency = agency1},
};
      tour10.TourSimilar = tourSimilars10;


      var tourSimilars11 = new List<TourSimilar>
{
  new() {Tour = tour2, Agency = agency1},
  new() {Tour = tour6, Agency = agency1},
  new() {Tour = tour4, Agency = agency1},
};
      tour11.TourSimilar = tourSimilars11;


      var tourSimilars12 = new List<TourSimilar>
{
  new() {Tour = tour7, Agency = agency1},
  new() {Tour = tour8, Agency = agency1},
  new() {Tour = tour9, Agency = agency1},
};
      tour12.TourSimilar = tourSimilars12;

      var tourSimilars13 = new List<TourSimilar>
{
  new() {Tour = tour1, Agency = agency1},
  new() {Tour = tour3, Agency = agency1},
  new() {Tour = tour5, Agency = agency1},
};
      tour13.TourSimilar = tourSimilars13;

      #endregion

      _context.Tours.Add(tour1);
      _context.Tours.Add(tour2);
      _context.Tours.Add(tour3);
      _context.Tours.Add(tour4);
      _context.Tours.Add(tour5);
      _context.Tours.Add(tour6);
      _context.Tours.Add(tour7);
      _context.Tours.Add(tour8);
      _context.Tours.Add(tour9);
      _context.Tours.Add(tour10);
      _context.Tours.Add(tour11);
      _context.Tours.Add(tour12);
      _context.Tours.Add(tour13);
      await _context.SaveChangesAsync();


      #region Other

      var populartours = new List<HomeTourPopularComposition>
      {
        new() {Tour = tour1, Agency = agency1, PopularType = PopularType.POPULAR, Order = 1},
        new() {Tour = tour2, Agency = agency1, PopularType = PopularType.POPULAR, Order = 2},
        new() {Tour = tour9, Agency = agency1, PopularType = PopularType.POPULAR, Order = 3},
        new() {Tour = tour5, Agency = agency1, PopularType = PopularType.POPULAR, Order = 4},
        new() {Tour = tour10, Agency = agency1, PopularType = PopularType.POPULAR, Order = 5},
        new() {Tour = tour3, Agency = agency1, PopularType = PopularType.POPULAR, Order = 6},

        new() {Tour = tour13, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 1},
        new() {Tour = tour6, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 2},
        new() {Tour = tour12, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 3},
        new() {Tour = tour4, Agency = agency1, PopularType = PopularType.OTHERTOURS, Order = 4},
      };

      var otherGallery = new List<OtherGallery>
      {
        new() {Image = "/storage/gallery/1/image1.webp", ImageThumbnail = "/storage/gallery/1/image1_thumbnail.webp", Order = 1, IsFavorite = false, Agency = agency1},
        new() {Image = "/storage/gallery/1/image2.webp", ImageThumbnail = "/storage/gallery/1/image2_thumbnail.webp", Order = 2, IsFavorite = true, Agency = agency1},
        new() {Image = "/storage/gallery/1/image3.webp", ImageThumbnail = "/storage/gallery/1/image3_thumbnail.webp", Order = 3, IsFavorite = true, Agency = agency1},
        new() {Image = "/storage/gallery/1/image4.webp", ImageThumbnail = "/storage/gallery/1/image4_thumbnail.webp", Order = 4, IsFavorite = false, Agency = agency1},
        new() {Image = "/storage/gallery/1/image5.webp", ImageThumbnail = "/storage/gallery/1/image5_thumbnail.webp", Order = 5, IsFavorite = true, Agency = agency1},
        new() {Image = "/storage/gallery/1/image6.webp", ImageThumbnail = "/storage/gallery/1/image6_thumbnail.webp", Order = 6, IsFavorite = false, Agency = agency1},
        new() {Image = "/storage/gallery/1/image7.webp", ImageThumbnail = "/storage/gallery/1/image7_thumbnail.webp", Order = 7, IsFavorite = true, Agency = agency1},
        new() {Image = "/storage/gallery/1/image8.webp", ImageThumbnail = "/storage/gallery/1/image8_thumbnail.webp", Order = 8, IsFavorite = false, Agency = agency1},
      };


      var terms = new OtherTermsCondition
      {
        Agency = agency1,
        LastEditedDate = DateOnly.FromDateTime(DateTime.UtcNow),
        Text = @"
<h4>Términos y Condiciones</h4>
    <p>Bienvenido a nuestra página de demostración. Al utilizar este sitio web, usted acepta los siguientes términos y condiciones:</p>
    <ul>
        <li>El contenido de esta página es solo para fines demostrativos y no representa ningún servicio real.</li>
        <li>No nos hacemos responsables de cualquier pérdida o daño que pueda resultar del uso de este sitio web.</li>
        <li>Nos reservamos el derecho de modificar estos términos en cualquier momento sin previo aviso.</li>
        <li>Todos los derechos sobre el contenido y diseño de esta página son propiedad de sus respectivos dueños.</li>
        <li>El uso de esta página implica la aceptación de estos términos y condiciones.</li>
    </ul>
    <p>Gracias por visitar nuestra página de demostración.</p>
    
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.</p><ul>
        <li>El contenido de esta página es solo para fines demostrativos y no representa ningún servicio real.</li>
        <li>No nos hacemos responsables de cualquier pérdida o daño que pueda resultar del uso de este sitio web.</li>
        <li>Nos reservamos el derecho de modificar estos términos en cualquier momento sin previo aviso.</li>
        <li>Todos los derechos sobre el contenido y diseño de esta página son propiedad de sus respectivos dueños.</li>
        
    </ul><p>Gracias por visitar nuestra página de demostración. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Lorem ipsum a</p>
      "
      };

      var privacy = new OtherPrivacyNotice
      {
        Agency = agency1,
        LastEditedDate = DateOnly.FromDateTime(DateTime.UtcNow),
        Text = @"
<h4>Aviso de Privacidad</h4>
    <p>En nuestra página de demostración, nos tomamos en serio su privacidad. Este aviso de privacidad describe cómo recopilamos, utilizamos y protegemos su información personal.</p>
    <ul>
        <li>La información recopilada en esta página es solo con fines demostrativos y no se utilizará para ningún propósito real.</li>
        <li>No compartimos su información personal con terceros.</li>
        <li>Nos esforzamos por proteger su información personal mediante el uso de medidas de seguridad adecuadas.</li>
        <li>Usted tiene derecho a solicitar el acceso, rectificación o eliminación de su información personal en cualquier momento.</li>
        <li>Al utilizar esta página, usted acepta los términos de este aviso de privacidad.</li>
    </ul>
    <p>Si tiene alguna pregunta sobre este aviso de privacidad, por favor contáctenos.</p>
  <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum</p><ul>
        <li>La información recopilada en esta página es solo con fines demostrativos y no se utilizará para ningún propósito real.</li>
        <li>No compartimos su información personal con terceros.</li>
        <li>Nos esforzamos por proteger su información personal mediante el uso de medidas de seguridad adecuadas.</li>
        
        
    </ul><p>Gracias por visitar nuestra página de demostración. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua Lorem ipsum a</p>
        "
      };

      _context.HomeTourPopularCompositions.AddRange(populartours);
      _context.OtherGalleries.AddRange(otherGallery);
      _context.OtherTermsConditions.Add(terms);
      _context.OtherPrivacyNotices.Add(privacy);
      await _context.SaveChangesAsync();

      #endregion




    }
  }
}
