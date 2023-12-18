using ArchitectureApi.BusinessLogic.Services.Abstract;
using ArchitectureApi.Data.Repositories.Abstract;
using ArchitectureApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Services;

namespace ArchitectureApi.BusinessLogic.Services.Concrete;

public class AuthService : IAuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly ITokenProvider _tokenProvider;

    public AuthService(IUsersRepository usersRepository, ITokenProvider tokenProvider)
    {
        _usersRepository = usersRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<AuthResponse?> Login(SigninDto user)
    {
        var found = await _usersRepository.Get().AsNoTracking()
            .FirstOrDefaultAsync(x => user.Email == x.Email && x.Password == user.Password);
        return found is null
            ? null
            : new AuthResponse
            {
                Role = found.Role,
                Token = _tokenProvider.GenerateToken(found.Id, found.Role)
            };
    }
}