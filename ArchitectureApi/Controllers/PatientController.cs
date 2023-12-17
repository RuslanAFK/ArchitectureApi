using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using ArchitectureApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Authorize(Roles = "Patient")]
[Route("api/[action]")]
public class PatientController : Controller
{
    private readonly IPatientService _patientService;

    private readonly IAuthProvider _authProvider;

    public PatientController(IPatientService patientService, IAuthProvider authProvider)
    {
        _patientService = patientService;
        _authProvider = authProvider;
    }

    [HttpPost]
    [ActionName("patient/signup")]
    [AllowAnonymous]
    public async Task<IActionResult> CreateAccount(SignupDto data)
    {
        _patientService.Signup(data);
        return Ok();
    }
    
    [HttpPost]
    [ActionName("patient/signin")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn(SigninDto data)
    {
        var token = await _patientService.Signin(data);
        if (token is null)
            return BadRequest("Wrong email or password.");
        
        return Ok(new
        {
            Token = token
        });
    }
    
    [HttpGet]
    [ActionName("patient/cabinet")]
    public async Task<IActionResult> PersonalCabinet()
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return BadRequest("Error getting user from token.");
        
        var patient = await _patientService.GetPersonalInfoById(authDto.Id);
        return Ok(patient);
    }
    
    [HttpPost]
    [ActionName("patient/edit-cabinet")]
    public async Task<IActionResult> EditCabinet(EditPatientDto data)
    {
        var authDto = _authProvider.GetCurrent(HttpContext);
        if (authDto is null)
            return BadRequest("Error getting user from token.");
        
        await _patientService.EditPersonalInfoById(authDto.Id, data);
        return Ok();
    }
}