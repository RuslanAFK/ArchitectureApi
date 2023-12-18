using ArchitectureApi.Dtos;

namespace ArchitectureApi.BusinessLogic.Services.Abstract;

public interface IAuthService
{
    Task<AuthResponse?> Login(SigninDto user);
}