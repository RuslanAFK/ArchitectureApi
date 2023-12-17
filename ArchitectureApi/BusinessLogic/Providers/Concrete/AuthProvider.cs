using System.Security.Claims;
using ArchitectureApi.BusinessLogic.Providers.Abstract;
using ArchitectureApi.Dtos;

namespace ArchitectureApi.BusinessLogic.Providers.Concrete;

public class AuthProvider : IAuthProvider
{
    public AuthDto? GetCurrent(HttpContext httpContext)
    {
        var user = httpContext?.User;
        if (user is null)
            return null;

        var role = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        int.TryParse(user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value, out var id);

        if (role is null || id == default)
            return null;

        return new AuthDto()
        {
            Role = role,
            Id = id
        };
    }
}