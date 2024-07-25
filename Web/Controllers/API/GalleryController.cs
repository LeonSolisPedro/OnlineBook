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
public class GalleryController : ControllerBase
{
  private readonly OtherWebService _otherWebService;

  public GalleryController(OtherWebService otherWebService)
  {
    _otherWebService = otherWebService;
  }


  [Route("GetGalleries")]
  public async Task<IActionResult> GetGalleries()
  {
    return Ok(await _otherWebService.GetGalleries());
  }

}
