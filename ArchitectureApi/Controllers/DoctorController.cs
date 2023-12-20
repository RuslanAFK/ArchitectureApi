using ArchitectureApi.BusinessLogic.Dtos;
using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using ArchitectureApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureApi.Controllers;

[ApiController]
[Authorize(Roles = "Doctor")]
[Route("api/[action]")]
public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;
    private readonly IVisitService _visitService;
    private readonly IAuthProvider _authProvider;

    public DoctorController(IDoctorService doctorService, IVisitService visitService, IAuthProvider authProvider)
    {
        _doctorService = doctorService;
        _visitService = visitService;
        _authProvider = authProvider;
    }

    [HttpGet("{id:int}")]
    [AllowAnonymous]
    [ActionName("doctor/info")]
    public async Task<IActionResult> GetDoctor([FromRoute] int id)
    {
        var doctor = await _doctorService.GetDoctorInfoById(id);
        if (doctor is null)
            return BadRequest($"Doctor with id {id} not found.");
        
        return Ok(doctor);
    }
    
    [HttpGet]
    [AllowAnonymous]
    [ActionName("doctor/list")]
    public async Task<IActionResult> GetDoctors([FromQuery] FilterDto dto)
    {
        var doctors = await _doctorService.GetAllDoctorsInfo()
            .Filter(dto.Filter).Paginate(dto.PageSize, dto.Page).ToListAsync();
        
        return Ok(doctors);
    }
    
    [HttpPost]
    [ActionName("doctor/feedback")]
    public async Task<IActionResult> VisitFeedback([FromBody] FeedbackDto dto)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();

        var done = await _visitService.SetFeedback(authDto!.Id, dto);

        if (!done)
        {
            return BadRequest("Visit not found.");
        }

        if (dto.Approve)
        {
            return Ok("Successfully approved visit.");
        }
        return Ok("Successfully declined visit.");
    }
    
    [HttpPost]
    [Authorize(Roles = "Doctor")]
    [ActionName("doctor/set-treatment")]
    public async Task<IActionResult> SetTreatment([FromBody] TreatmentDto dto)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();
        
        var done = await _visitService.SetTreatment(authDto!.Id, dto);

        if (!done)
        {
            return BadRequest("Visit not found.");
        }
        return Ok("Successfully added treatment.");
    }
}