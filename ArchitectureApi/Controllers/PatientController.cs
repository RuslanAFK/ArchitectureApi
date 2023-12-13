using ArchitectureApi.BusinessLogic.Factories;
using ArchitectureApi.Dtos;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
//[Authorize(Roles = "Patient")]
public class PatientController : Controller
{
    private readonly IVisitService _visitService;
    private readonly IDoctorService _doctorService;
    private readonly IPatientService _patientService;

    public PatientController(IVisitService visitService, IDoctorService doctorService, IPatientService patientService)
    {
        _visitService = visitService;
        _doctorService = doctorService;
        _patientService = patientService;
    }

    [HttpGet]
    [Route("/api/patient/signup")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccount(SignupDto data)
    {
        var patient = new UserBuilder(data.FirstName, data.LastName)
            .WithSecondName(data.SecondName)
            .WithAvatar(data.Avatar)
            .AsPatient()
            .Build();

        _patientService.Signup(patient);
        return Ok();
    }
    
    [HttpGet]
    [Route("/api/patient/visits")]
    public async Task<IActionResult> GetVisits()
    {
        var userName = User.Identity?.Name;
        if (userName == null)
        {
            return Unauthorized();
        }

        var visits = _visitService.GetVisits(userName);
        return Ok(visits);
    }
    
    [HttpGet]
    [Route("/api/patient/treatments")]
    public async Task<IActionResult> GetTreatments()
    {
        var userName = User.Identity?.Name;
        if (userName == null)
        {
            return Unauthorized();
        }

        var visits = _visitService.GetTreatments(userName);
        return Ok(visits);
    }
    
    [HttpPost]
    [Route("/api/patient/set-appointment")]
    public async Task<IActionResult> SetAppointment(SetAppointmentDto dto)
    {
       /* var userName = User.Identity?.Name;
        var freeSlots = _doctorService.GetDoctorFreeSlots(dto.DoctorId);
        if (!freeSlots.Any(x => x.From == dto.Time))
        {
            return BadRequest("No timeslots matched.");
        }

        var isTaken = _doctorService.IsDoctorTaken(dto.DoctorId, dto.Time);
        if (isTaken)
        {
            return BadRequest("Already taken.");
        }

        var doctor = _doctorService.GetById(dto.DoctorId)!;
        var patient = _patientService.GetByUsername(userName);
        if (patient == null)
        {
            return NotFound("Patient not found.");
        }
*/
        var visit = await _visitService.Create(new User(), new User(), dto.Time);
        return Ok(visit);
    } 
}