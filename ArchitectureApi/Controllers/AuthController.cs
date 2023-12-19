using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectureApi.Controllers;

[ApiController]
[Route("api/[action]")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost]
    [ActionName("auth/login")]
    public async Task<IActionResult> SignIn(SigninDto data)
    {
        var response = await _authService.Login(data);
        if (response is null)
            return BadRequest("Wrong email or password.");
        
        return Ok(response);
    }
}