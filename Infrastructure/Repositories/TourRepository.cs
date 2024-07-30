


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
      return await _context.Tours.Include(x => x.TourSimilar).FirstOrDefaultAsync(x => x.Id == id && x.IsArchived == false);
    }

    public async Task<List<Tour>> GetList(int idAgency)
    {
      return await _context.Tours.Include(x => x.TourDirection).Include(x => x.TourGalleryImages).Include(x => x.TourDirection).Include(x => x.TourSearchQueryCompositions)!.ThenInclude(x => x.TourSearchQuery).Where(x => x.IdAgency == idAgency && x.IsArchived == false).ToListAsync();
    }

    public async Task<List<Tour>> GetList(int idAgency, int idCategory)
    {
      return await _context.Tours.Include(x => x.TourDirection).Include(x => x.TourGalleryImages).Include(x => x.TourSearchQueryCompositions)!.ThenInclude(x => x.TourSearchQuery).Include(x => x.TourCategoryCompositions).Where(x => x.IdAgency == idAgency && x.IsArchived == false && x.TourCategoryCompositions!.Any(x => x.IdTourCategory == idCategory)).ToListAsync();
    }


}
