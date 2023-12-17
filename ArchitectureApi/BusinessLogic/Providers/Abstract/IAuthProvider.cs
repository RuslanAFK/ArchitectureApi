using ArchitectureApi.Dtos;

namespace ArchitectureApi.BusinessLogic.Providers.Abstract;

public interface IAuthProvider
{
    AuthDto? GetCurrent(HttpContext httpContext);
}