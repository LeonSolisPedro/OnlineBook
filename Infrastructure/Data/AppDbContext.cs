
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
    public DbSet<DirectionTour> DirectionTours => Set<DirectionTour>();
    public DbSet<TourInclude> TourIncludes => Set<TourInclude>();
    public DbSet<TourItinerary> TourItineraries => Set<TourItinerary>();
    public DbSet<TourCategory> TourCategories => Set<TourCategory>();
    public DbSet<TourCategoryComposition> TourCategoryCompositions => Set<TourCategoryComposition>();
    public DbSet<TourSearchQuery> TourSearchQueries => Set<TourSearchQuery>();
    public DbSet<TourSearchQueryComposition> TourSearchQueryCompositions => Set<TourSearchQueryComposition>();
    public DbSet<SimilarTour> SimilarTours => Set<SimilarTour>();
    public DbSet<TourGalleryImage> TourGalleryImages => Set<TourGalleryImage>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TourCategoryComposition>().HasKey(x => new {x.IdTour, x.IdTourCategory});
        modelBuilder.Entity<TourSearchQueryComposition>().HasKey(x => new {x.IdTour, x.IdTourSearchQuery});
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
