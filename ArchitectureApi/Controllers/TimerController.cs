using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
public class TimerController : Controller
{
    private readonly IAuthProvider _authProvider;
    private readonly IVisitService _visitService;

    public TimerController(IAuthProvider authProvider, IVisitService visitService)
    {
        _authProvider = authProvider;
        _visitService = visitService;
    }

    [HttpGet("{visitId}")]
    [ActionName("timer/get")]
    public async Task<IActionResult> GetTimer([FromRoute] int visitId)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return BadRequest("Error getting user from token.");

        var timer = await _visitService.GetTimer(authDto.Id, visitId);
        return Ok(timer);
    }
}