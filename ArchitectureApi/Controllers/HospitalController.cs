using ArchitectureApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
public class HospitalController : Controller
{
    private readonly IHospitalService _hospitalService;
    public HospitalController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }
    [HttpGet]
    [Route("/static/name")]
    public IActionResult GetVisits()
    {
        var name = _hospitalService.GetHospitalName();
        return Ok(name);
    }
}