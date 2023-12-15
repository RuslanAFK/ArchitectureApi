using ArchitectureApi.Dtos;
using ArchitectureApi.Enums;
using ArchitectureApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
public class PatientController : Controller
{
    private readonly IPatientService _patientService;

    private readonly IPatientProvider _patientProvider;

    public PatientController(IPatientService patientService, IPatientProvider patientProvider)
    {
        _patientService = patientService;
        _patientProvider = patientProvider;
    }

    [HttpGet]
    [ActionName("patient/signup")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccount(SignupDto data)
    {
        _patientService.Signup(data);
        return Ok();
    }
    
    [HttpGet]
    [ActionName("patient/cabinet")]
    [AllowAnonymous]
    public async Task<IActionResult> PersonalCabinet(SignupDto data)
    {
        var authDto = _patientProvider.Current;
        if (authDto is null || authDto.Role != Roles.Patient.ToString())
        {
            return Unauthorized();
        }

        var patient = _patientService.GetPersonalInfoById(authDto.Id);
        return Ok(patient);
    }
    
    [HttpGet]
    [ActionName("patient/edit-cabinet")]
    [AllowAnonymous]
    public async Task<IActionResult> EditCabinet(EditPatientDto data)
    {
        var authDto = _patientProvider.Current;
        if (authDto is null || authDto.Role != Roles.Patient.ToString())
        {
            return Unauthorized();
        }
        
        _patientService.EditPersonalInfoById(authDto.Id, data);
        return Ok();
    }
}