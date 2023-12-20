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
    private readonly IDoctorService _doctorService;

    private readonly IAuthProvider _authProvider;

    public PatientController(IPatientService patientService, IAuthProvider authProvider, IVisitService visitService, IDoctorService doctorService)
    {
        _patientService = patientService;
        _authProvider = authProvider;
        _visitService = visitService;
        _doctorService = doctorService;
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
    
    [HttpGet]
    [ActionName("patient/treatments")]
    public async Task<IActionResult> GetTreatments()
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return BadRequest("Error getting user from token.");

        var visits = await _visitService.GetTreatments(authDto.Id);
        return Ok(visits);
    }
    
    [HttpPost]
    [ActionName("patient/set-appointment")]
    public async Task<IActionResult> SetAppointment(SetAppointmentDto dto)
    {
        var authDto = _authProvider.GetCurrent(HttpContext)!;

        var isTaken = await _doctorService.IsDoctorTaken(dto.DoctorId, dto.Time);
        if (isTaken)
        {
            return BadRequest("Timeslot is already taken.");
        }

        var doctor = await _doctorService.GetById(dto.DoctorId)!;
        var patient = await _patientService.GetById(authDto.Id);
        if (patient == null)
            return BadRequest("Patient not found.");
        if (doctor == null)
            return BadRequest("Doctor not found.");
        
        await _visitService.Create(doctor!, patient, dto.Time, dto.Notes);
        return Ok();
    } 
}