using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asp.Versioning;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.API;

[ApiController]
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class HomeController : ControllerBase
{
  private readonly HomeService _homeService;

  public HomeController(HomeService homeService)
  {
    _homeService = homeService;
  }

  [Route("GetCarousel")]
  public async Task<IActionResult> GetCarousel()
  {
    return Ok(await _homeService.GetCarousel());
  }

  [Route("GetOffers")]
  public async Task<IActionResult> GetOffers()
  {
    return Ok(await _homeService.GetOffers());
  }
}
