using Core.Entites._Agency;
using Core.Entites._Tour;
using Core.Repositories;
using Microsoft.Extensions.Caching.Memory;

namespace Core.Services;

public class AgencyService
{

  private readonly IGenericRepository<Agency> _genericRepository;
  private readonly IGenericRepository<AgencyCurrencyComposition> _genericCurrencyComposition;
  private readonly IGenericRepository<TourCategory> _genericCategoryRepository;
  private readonly IMemoryCache _cache;

  public AgencyService(IGenericRepository<Agency> genericRepository, IGenericRepository<TourCategory> genericCategoryRepository, IGenericRepository<AgencyCurrencyComposition> genericCurrencyComposition, IMemoryCache cache)
  {
    _genericRepository = genericRepository;
    _genericCategoryRepository = genericCategoryRepository;
    _genericCurrencyComposition = genericCurrencyComposition;
    _cache = cache;
  }

  public async Task<Agency> GetInfo()
  {
    var cache = _cache.Get<Agency>("GetInfo1");
    if(cache != null) return cache;

    var agency = await _genericRepository.GetOrNull(x => x.Id == 1, "AgencySocialCompositions.Social") ?? new Agency();
    agency.AgencySocialCompositions = agency.AgencySocialCompositions?.OrderBy(x => x.Order).ToList();
    _cache.Set("GetInfo1", agency);
    return agency;
  }


  public async Task<List<AgencyCurrencyComposition>> GetCurrency()
  {
    var cache = _cache.Get<List<AgencyCurrencyComposition>>("GetCurrency1");
    if(cache != null) return cache;

    var list = await _genericCurrencyComposition.GetList(x => x.IdAgency == 1, "Currency");
    list = list.OrderBy(x => x.Order).ToList();
    _cache.Set("GetCurrency1", list);
    return list;
  }

  public async Task<List<TourCategory>> GetTourCategories()
  {
    var cache = _cache.Get<List<TourCategory>>("GetTourCategories1");
    if(cache != null) return cache;

    var list = await _genericCategoryRepository.GetList(x => x.IdAgency == 1);
    list = list.OrderBy(x => x.Order).ToList();
    _cache.Set("GetTourCategories1", list);
    return list;
  }
}
