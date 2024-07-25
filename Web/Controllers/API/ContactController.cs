using Asp.Versioning;
using Core.Entites._Other;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.API;

[ApiController]
[ApiVersion(1)]
[Route("api/v{v:apiVersion}/[controller]")]
public class ContactController : ControllerBase
{
  private readonly OtherWebService _otherWebService;

  public ContactController(OtherWebService otherWebService)
  {
    _otherWebService = otherWebService;
  }


  [Route("SendInfo")]
  [HttpPost]
  public async Task<IActionResult> SendInfo(OtherContactForm model)
  {
    return Ok(await _otherWebService.SendInfo(model));
  }
}
