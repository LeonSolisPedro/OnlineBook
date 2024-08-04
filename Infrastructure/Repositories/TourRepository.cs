


using Core.Entites._Tour;
using Core.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TourRepository : ITourRepository
{
  private readonly AppDbContext _context;

    public TourRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Tour?> GetTour(int id)
    {
      return await _context.Tours.Include(x => x.TourDirection).Include(x => x.TourGalleryImages).Include(x => x.TourItineraries).Include(x => x.TourIncludes).FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
    }

    public async Task<List<TourSimilar>> GetTourSimilar(int idTour)
    {
      return await _context.TourSimilars.Include(ts => ts.Tour1).ThenInclude(t => t!.TourDirection).Include(ts => ts.Tour1).ThenInclude(t => t!.TourGalleryImages).Include(ts => ts.Tour2).ThenInclude(t => t!.TourDirection).Include(ts => ts.Tour2).ThenInclude(t => t!.TourGalleryImages).Where(x => x.IdTour1 == idTour || x.IdTour2 == idTour).ToListAsync();
    }

    public async Task<List<Tour>> GetList(int idAgency)
    {
      return await _context.Tours.Include(x => x.TourDirection).Include(x => x.TourGalleryImages).Include(x => x.TourDirection).Include(x => x.TourSearchQueryCompositions)!.ThenInclude(x => x.TourSearchQuery).Where(x => x.IdAgency == idAgency && x.IsArchived == false).ToListAsync();
    }

    public async Task<List<Tour>> GetList(int idAgency, int idCategory)
    {
      return await _context.Tours.Include(x => x.TourDirection).Include(x => x.TourGalleryImages).Include(x => x.TourSearchQueryCompositions)!.ThenInclude(x => x.TourSearchQuery).Include(x => x.TourCategoryCompositions).Where(x => x.IdAgency == idAgency && x.IsArchived == false && x.TourCategoryCompositions!.Any(x => x.IdTourCategory == idCategory)).ToListAsync();
    }

    public async Task<TourDatePricing?> GetDates(int idTour)
    {
      var today = DateOnly.FromDateTime(DateTime.UtcNow);
      return await _context.TourDatePricings.Where(x => x.IdTour == idTour && x.StartDate <= today && (x.EndDate == null || x.EndDate >= today)).Include(x => x.Tour).Include(x => x.TourNotWorkingDays).Include(x => x.TourNotWorkingWeekDays).FirstOrDefaultAsync();
    }

    public async Task<TourDatePricing?> GetAvailability(int idTourDatePricing)
    {
      return await _context.TourDatePricings.Where(x => x.Id == idTourDatePricing).Include(x => x.Tour).Include(x => x.TourNotWorkingDays).Include(x => x.TourNotWorkingWeekDays).Include(x => x.TourDatePricingCompositions)!.ThenInclude(x => x.TourClassPricing).FirstOrDefaultAsync();
    }

    public async Task<List<TourReservation>> GetReservations(int idTourDatePricing, DateOnly date)
    {
      return await _context.TourReservations.Where(x => x.IdTourDatePricing == idTourDatePricing && x.DepartureDate == date).Include(x => x.TourDatePricing).ThenInclude(x => x!.Tour).ToListAsync();
    }


}
