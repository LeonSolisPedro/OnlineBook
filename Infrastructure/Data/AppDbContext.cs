
using Core.Entites;
using Core.Entites._Agency;
using Core.Entites._Home;
using Core.Entites._Other;
using Core.Entites._Tour;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Agency> Agencies => Set<Agency>();
    public DbSet<Tour> Tours => Set<Tour>();
    public DbSet<TourDirection> TourDirections => Set<TourDirection>();
    public DbSet<TourInclude> TourIncludes => Set<TourInclude>();
    public DbSet<TourItinerary> TourItineraries => Set<TourItinerary>();
    public DbSet<TourCategory> TourCategories => Set<TourCategory>();
    public DbSet<TourCategoryComposition> TourCategoryCompositions => Set<TourCategoryComposition>();
    public DbSet<TourSearchQuery> TourSearchQueries => Set<TourSearchQuery>();
    public DbSet<TourSearchQueryComposition> TourSearchQueryCompositions => Set<TourSearchQueryComposition>();
    public DbSet<TourSimilar> TourSimilars => Set<TourSimilar>();
    public DbSet<TourGalleryImage> TourGalleryImages => Set<TourGalleryImage>();
    public DbSet<AgencyCurrency> AgencyCurrencies => Set<AgencyCurrency>();
    public DbSet<AgencyCurrencyComposition> AgencyCurrencyCompositions => Set<AgencyCurrencyComposition>();
    public DbSet<TourClassPricing> TourClassPricings => Set<TourClassPricing>();
    public DbSet<TourDatePricing> TourDatePricings => Set<TourDatePricing>();
    public DbSet<TourDatePricingComposition> TourDatePricingCompositions => Set<TourDatePricingComposition>();
    public DbSet<TourNotWorkingDay> TourNotWorkingDays => Set<TourNotWorkingDay>();
    public DbSet<TourRepeatSpecificDate> TourRepeatSpecificDates => Set<TourRepeatSpecificDate>();
    public DbSet<TourReservation> TourReservations => Set<TourReservation>();
    public DbSet<AgencySocial> AgencySocials => Set<AgencySocial>();
    public DbSet<AgencySocialComposition> AgencySocialCompositions => Set<AgencySocialComposition>();
    public DbSet<HomeTourPopularComposition> HomeTourPopularCompositions => Set<HomeTourPopularComposition>();
    public DbSet<OtherGallery> OtherGalleries => Set<OtherGallery>();
    public DbSet<HomeCarousel> HomeCarousels => Set<HomeCarousel>();
    public DbSet<HomeOffer> HomeOffers => Set<HomeOffer>();
    public DbSet<OtherPrivacyNotice> OtherPrivacyNotices => Set<OtherPrivacyNotice>();
    public DbSet<OtherTermsCondition> OtherTermsConditions => Set<OtherTermsCondition>();
    public DbSet<OtherContactForm> OtherContactForms => Set<OtherContactForm>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TourCategoryComposition>().HasKey(x => new { x.IdTour, x.IdTourCategory });
        modelBuilder.Entity<TourSearchQueryComposition>().HasKey(x => new { x.IdTour, x.IdTourSearchQuery });
        modelBuilder.Entity<TourDatePricingComposition>().HasKey(x => new { x.IdTourClassPricing, x.IdTourDatePricing });
        modelBuilder.Entity<TourNotWorkingDay>().HasKey(x => new { x.IdTourClassPricing, x.Day });
        modelBuilder.Entity<TourRepeatSpecificDate>().HasKey(x => new { x.IdTourClassPricing, x.Day });
        modelBuilder.Entity<AgencySocialComposition>().HasKey(x => new {x.IdAgencySocial, x.IdAgency});
        modelBuilder.Entity<AgencyCurrencyComposition>().HasKey(x => new { x.IdAgency, x.IdAgencyCurrency });
        
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
