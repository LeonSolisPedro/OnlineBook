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
public class TermsController : ControllerBase
{
  private readonly OtherWebService _otherWebService;

  public TermsController(OtherWebService otherWebService)
  {
    _otherWebService = otherWebService;
  }


  [Route("TermsCondition")]
  public async Task<IActionResult> TermsCondition()
  {
    return Ok(await _otherWebService.TermsCondition());
  }

  [Route("PrivacyNotice")]
  public async Task<IActionResult> PrivacyNotice()
  {
    return Ok(await _otherWebService.PrivacyNotice());
  }
}
