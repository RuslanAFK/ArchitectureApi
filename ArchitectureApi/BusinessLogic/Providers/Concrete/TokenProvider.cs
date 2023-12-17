using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Services.Services;

public class TokenProvider : ITokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public string GenerateToken(int id, string roleName)
    {
        using var rsa = RSA.Create();
        rsa.ImportRSAPrivateKey(Convert.FromBase64String(_configuration["Jwt:PrivateKey"]!), out _);
        var securityKey = new RsaSecurityKey(rsa);

        var claims = GenerateClaims(id, roleName);
        var token = GenerateTokenObject(claims, securityKey);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private JwtSecurityToken GenerateTokenObject(IEnumerable<Claim> claims, RsaSecurityKey securityKey)
    {
        var signingCredentials = GenerateSigningCredentials(securityKey);
        var jwtDate = GetCurrentTime();
        return new JwtSecurityToken(
            claims: claims,
            notBefore: jwtDate,
            expires: jwtDate.AddMinutes(60),
            signingCredentials: signingCredentials
        );
    }

    private SigningCredentials GenerateSigningCredentials(RsaSecurityKey securityKey)
    {
        var algorithm = SecurityAlgorithms.RsaSha256;
        var signingCredentials = new SigningCredentials(securityKey, algorithm)
        {
            CryptoProviderFactory = new CryptoProviderFactory { CacheSignatureProviders = false }
        };
        return signingCredentials;
    }
    private List<Claim> GenerateClaims(int sid, string roleName)
    {
        var uniqueNameClaim = new Claim(ClaimTypes.Sid, sid.ToString());
        var roleClaim = new Claim(ClaimTypes.Role, roleName);
        return new List<Claim> { uniqueNameClaim, roleClaim };
    }

    private DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }

}