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

    public SharedController(IVisitService visitService, IAuthProvider authProvider)
    {
        _visitService = visitService;
        _authProvider = authProvider;
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
}