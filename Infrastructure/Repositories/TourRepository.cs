


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
      return await _context.Tours.Include(x => x.TourGalleryImages).FirstOrDefaultAsync(x => x.Id == id);
    }
}
