using Core.Entites._Tour;

namespace Core.Repositories;

public interface ITourRepository
{
    public Task<Tour?> GetTour(int id);

    public Task<List<Tour>> GetList(int idAgency);

    public Task<List<Tour>> GetList(int idAgency, int idCategory);

    public Task<List<TourSimilar>> GetTourSimilar(int idTour);

    public Task<TourDatePricing?> GetDates(int idTour);

    public Task<TourDatePricing?> GetAvailability(int idTourDatePricing);

    public Task<List<TourReservation>> GetReservations(int idTourDatePricing, DateOnly date);

}
