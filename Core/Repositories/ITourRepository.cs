using Core.Entites._Tour;

namespace Core.Repositories;

public interface ITourRepository
{
    public Task<Tour?> GetTour(int id);

    public Task<List<Tour>> GetList(int idAgency);

    public Task<List<Tour>> GetList(int idAgency, int idCategory);

    public Task<List<TourSimilar>> GetTourSimilar(int idTour);
}
