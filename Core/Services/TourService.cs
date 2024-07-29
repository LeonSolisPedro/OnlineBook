using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Tour;
using Core.Repositories;

namespace Core.Services;

public class TourService
{
  private readonly ITourRepository _tourRepository;

  public TourService(ITourRepository tourRepository)
  {
    _tourRepository = tourRepository;
  }


  public async Task<Tour?> GetTour(int id)
  {
    return await _tourRepository.GetTour(id);
  }
}
