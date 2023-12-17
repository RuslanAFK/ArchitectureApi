namespace Services.Services;

public interface ITokenProvider
{
    string GenerateToken(int username, string roleName);
}