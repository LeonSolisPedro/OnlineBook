using Core.Entites._Tour;

namespace Core.Repositories;

public interface ITourRepository
{
    public Task<Tour?> GetTour(int id);
}
