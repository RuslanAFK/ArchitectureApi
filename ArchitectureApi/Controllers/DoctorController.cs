using ArchitectureApi.Dtos;
using ArchitectureApi.Extensions;
using ArchitectureApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
public class DoctorController : Controller
{
    private readonly IDoctorService _doctorService;

    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet("{id:int}")]
    [ActionName("doctor/info")]
    public async Task<IActionResult> GetDoctor([FromRoute] int id)
    {
        var doctor = _doctorService.GetDoctorInfoById(id);
        if (doctor is null)
            return NotFound();
        return Ok(doctor);
    }
    
    [HttpGet]
    [ActionName("doctor/list")]
    public async Task<IActionResult> GetDoctors([FromQuery] FilterDto dto)
    {
        var doctors = _doctorService.GetAllDoctorsInfo()
            .Filter(dto.Filter).Paginate(dto.PageSize, dto.Page);
        
        return Ok(doctors);
    }
}