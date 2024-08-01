using Core.Entites._Agency;
using Core.Entites._Tour;
using Core.Repositories;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Core.Services;

public class AgencyService
{

  private readonly IGenericRepository<Agency> _genericRepository;
  private readonly IGenericRepository<AgencyCurrencyComposition> _genericCurrencyComposition;
  private readonly IGenericRepository<TourCategory> _genericCategoryRepository;
  private readonly IMemoryCache _cache;
  private readonly ILogger<AgencyService> _logger;

  public AgencyService(IGenericRepository<Agency> genericRepository, IGenericRepository<TourCategory> genericCategoryRepository, IGenericRepository<AgencyCurrencyComposition> genericCurrencyComposition, IMemoryCache cache, ILogger<AgencyService> logger)
  {
    _genericRepository = genericRepository;
    _genericCategoryRepository = genericCategoryRepository;
    _genericCurrencyComposition = genericCurrencyComposition;
    _cache = cache;
    _logger = logger;
  }

  public async Task<Agency> GetInfo()
  {
    var agency = new Agency();
    try
    {
      var cache = _cache.Get<Agency>("Agency.GetInfo1");
      if (cache != null) return cache;

      agency = await _genericRepository.GetOrNull(x => x.Id == 1, "AgencySocialCompositions.Social") ?? new Agency();
      agency.AgencySocialCompositions = agency.AgencySocialCompositions?.OrderBy(x => x.Order).ToList();
      return _cache.Set("Agency.GetInfo1", agency);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return agency;
  }


  public async Task<List<AgencyCurrencyComposition>> GetCurrency()
  {
    var list = new List<AgencyCurrencyComposition>();
    try
    {
      var cache = _cache.Get<List<AgencyCurrencyComposition>>("Agency.GetCurrency1");
      if (cache != null) return cache;

      list = await _genericCurrencyComposition.GetList(x => x.IdAgency == 1, "Currency");
      list = list.OrderBy(x => x.Order).ToList();
      return _cache.Set("Agency.GetCurrency1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }

  public async Task<List<TourCategory>> GetTourCategories()
  {
    var list = new List<TourCategory>();
    try
    {
      var cache = _cache.Get<List<TourCategory>>("Agency.GetTourCategories1");
      if (cache != null) return cache;

      list = await _genericCategoryRepository.GetList(x => x.IdAgency == 1);
      list = list.OrderBy(x => x.Order).ToList();
      return _cache.Set("Agency.GetTourCategories1", list);
    }
    catch (Exception e)
    {
      _logger.LogError(e, "Error");
    }
    return list;
  }
}
