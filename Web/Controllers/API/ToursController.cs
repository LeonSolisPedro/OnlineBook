using Asp.Versioning;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.API;

[ApiController]
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class ToursController : ControllerBase
{

  private readonly TourService _tourService;

  public ToursController(TourService tourService)
  {
    _tourService = tourService;
  }

  [Route("GetTour/{id}")]
  public async Task<IActionResult> GetTour(int id)
  {
    return Ok(await _tourService.GetTour(id));
  }

  [Route("GetList")]
  public async Task<IActionResult> GetList(int? idCategory)
  {
    if (idCategory.HasValue) return Ok(await _tourService.GetList(idCategory.Value));
    return Ok(await _tourService.GetList());
  }
}
