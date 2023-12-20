using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
[Authorize]
public class SharedController : Controller
{
    private readonly IAuthProvider _authProvider;
    private readonly IVisitService _visitService;
    private readonly ISharedService _sharedService;

    public SharedController(IVisitService visitService, IAuthProvider authProvider, ISharedService sharedService)
    {
        _visitService = visitService;
        _authProvider = authProvider;
        _sharedService = sharedService;
    }


    [HttpGet]
    [ActionName("shared/visits")]
    public async Task<IActionResult> GetVisits()
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return BadRequest("Error getting user from token.");

        var visits = await _visitService.GetVisits(authDto.Id);
        return Ok(visits);
    }
    
    [HttpGet]
    [ActionName("shared/cabinet")]
    public async Task<IActionResult> PersonalCabinet()
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();
        
        var patient = await _sharedService.GetPersonalInfoById(authDto.Id);
        return Ok(patient);
    }
}