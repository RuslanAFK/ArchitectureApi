using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
[Authorize(Roles = "Patient")]
public class VisitController : Controller
{
    private readonly IVisitService _visitService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    private readonly IAuthProvider _authProvider;

    public VisitController(IVisitService visitService, IDoctorService doctorService, IPatientService patientService, IAuthProvider authProvider)
    {
        _visitService = visitService;
        _doctorService = doctorService;
        _patientService = patientService;
        _authProvider = authProvider;
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
        var freeSlots = _doctorService.GetDoctorFreeSlots(dto.DoctorId);
        if (!freeSlots.Any(x => x.From == dto.Time))
        {
            return BadRequest("No timeslots at given time.");
        }

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