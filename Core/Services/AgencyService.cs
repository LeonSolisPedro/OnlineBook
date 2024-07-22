using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entites._Agency;
using Core.Repositories;

namespace Core.Services;

public class AgencyService
{

  private readonly IGenericRepository<Agency> _genericRepository;

  public AgencyService(IGenericRepository<Agency> genericRepository)
  {
    _genericRepository = genericRepository;
  }

  public async Task<Agency> GetInfo()
  {
    return await _genericRepository.GetOrNull(x => x.Id == 1, "AgencySocialCompositions.AgencySocial");
  }
}
