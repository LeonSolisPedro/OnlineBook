using Asp.Versioning;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.API;

[ApiController]
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class AgencyController : ControllerBase
{
  private readonly AgencyService _agencyService;

  public AgencyController(AgencyService agencyService)
  {
    _agencyService = agencyService;
  }

  [Route("GetInfo")]
  public async Task<IActionResult> GetInfo()
  {
    return Ok(await _agencyService.GetInfo());
  }

  [Route("GetCurrency")]
  public async Task<IActionResult> GetCurrency()
  {
    return Ok(await _agencyService.GetCurrency());
  }

  [Route("GetTourCategories")]
  public async Task<IActionResult> GetTourCategories()
  {
    return Ok(await _agencyService.GetTourCategories());
  }
}
