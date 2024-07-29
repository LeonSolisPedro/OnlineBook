using Asp.Versioning;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.API;

[ApiController]
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class ToursController : ControllerBase
{

  private readonly TourService _TourService;

    public ToursController(TourService tourService)
    {
        _TourService = tourService;
    }

    [Route("GetTour/{id}")]
  public async Task<IActionResult> GetTour(int id)
  {
    return Ok(await _TourService.GetTour(id));
  }
}
