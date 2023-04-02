using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace ServiceCenter.Web.Api.AuthService;

public class TokenService
{
    private const int ExpirationTimeInMinutes = 30;

    public string CreateToken(IdentityUser user)
    {
        var expiration =
            DateTime.UtcNow.AddMinutes(ExpirationTimeInMinutes);
        var token = CreateJwtToken(
            CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);

    }

    private JwtSecurityToken CreateJwtToken(
        List<Claim> claims, 
        SigningCredentials credentials,
        DateTime expiration) =>
        new(
            "apiWithAuthBackend",
            "apiWithAuthBackend",
            claims,
            expires: expiration,
            signingCredentials: credentials
        );
    
    private List<Claim> CreateClaims(IdentityUser user)
    {
        try
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "TokenForTheApiWithAuth"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                new Claim("UserId", user.Id),
                new Claim("Username", user.UserName),
                new Claim("Email", user.Email)
            };
            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    private SigningCredentials CreateSigningCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("superSecretKey@345")
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}