using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Agency;
using Core.Entites._Tour;
using Core.Repositories;

namespace Core.Services;

public class AgencyService
{

  private readonly IGenericRepository<Agency> _genericRepository;
  private readonly IGenericRepository<AgencyCurrencyComposition> _genericCurrencyComposition;
  private readonly IGenericRepository<TourCategory> _genericCategoryRepository;

  public AgencyService(IGenericRepository<Agency> genericRepository, IGenericRepository<TourCategory> genericCategoryRepository, IGenericRepository<AgencyCurrencyComposition> genericCurrencyComposition)
  {
    _genericRepository = genericRepository;
    _genericCategoryRepository = genericCategoryRepository;
    _genericCurrencyComposition = genericCurrencyComposition;
  }

  public async Task<Agency> GetInfo()
  {
    var list = await _genericRepository.GetOrNull(x => x.Id == 1, "AgencySocialCompositions.Social") ?? new Agency();
    list.AgencySocialCompositions = list.AgencySocialCompositions?.OrderBy(x => x.Order).ToList();
    return list;
  }


  public async Task<List<AgencyCurrencyComposition>> GetCurrency()
  {
    var list = await _genericCurrencyComposition.GetList(x => x.IdAgency == 1, "Currency");
    list = list.OrderBy(x => x.Order).ToList();
    return list;
  }

  public async Task<List<TourCategory>> GetTourCategories()
  {
    var list = await _genericCategoryRepository.GetList(x => x.IdAgency == 1);
    list = list.OrderBy(x => x.Order).ToList();
    return list;
  }
}
