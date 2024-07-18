
using Core.Entites;
using Core.Entites.Tour;
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
    public DbSet<CurrencyRate> CurrencyRates => Set<CurrencyRate>();
    public DbSet<AgencyCurrency> AgencyCurrencies => Set<AgencyCurrency>();
    public DbSet<TourClassPricing> TourClassPricings => Set<TourClassPricing>();
    public DbSet<TourDatePricing> TourDatePricings => Set<TourDatePricing>();
    public DbSet<TourDatePricingComposition> TourDatePricingCompositions => Set<TourDatePricingComposition>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TourCategoryComposition>().HasKey(x => new {x.IdTour, x.IdTourCategory});
        modelBuilder.Entity<TourSearchQueryComposition>().HasKey(x => new {x.IdTour, x.IdTourSearchQuery});
        modelBuilder.Entity<TourDatePricingComposition>().HasKey(x => new {x.IdTourClassPricing, x.IdTourDatePricing});

        modelBuilder.Entity<AgencyCurrency>().HasKey(x => new {x.IdAgency, x.IdCurrencyRate});
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
