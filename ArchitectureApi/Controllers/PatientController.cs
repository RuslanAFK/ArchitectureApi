using ArchitectureApi.BusinessLogic.Dtos;
using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Authorize(Roles = "Patient")]
[Route("api/[action]")]
public class PatientController : Controller
{
    private readonly IPatientService _patientService;
    private readonly IVisitService _visitService;

    private readonly IAuthProvider _authProvider;

    public PatientController(IPatientService patientService, IAuthProvider authProvider, IVisitService visitService)
    {
        _patientService = patientService;
        _authProvider = authProvider;
        _visitService = visitService;
    }
    
    [HttpGet]
    [ActionName("patient/cabinet")]
    public async Task<IActionResult> PersonalCabinet()
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();
        
        var patient = await _patientService.GetPersonalInfoById(authDto.Id);
        return Ok(patient);
    }
    
    [HttpPost]
    [ActionName("patient/edit-cabinet")]
    public async Task<IActionResult> EditCabinet(EditPatientDto data)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();
        
        await _patientService.EditPersonalInfoById(authDto.Id, data);
        return Ok();
    }
    
    [HttpPost]
    [ActionName("patient/delete-visit")]
    public async Task<IActionResult> DeleteVisit(DeleteVisitDto data)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return Unauthorized();
        
        var done = await _visitService.DeleteVisit(authDto.Id, data.VisitId);
        if (!done)
            return BadRequest("Visit not found.");
        
        return Ok("Successfully deleted visit.");
    }
}