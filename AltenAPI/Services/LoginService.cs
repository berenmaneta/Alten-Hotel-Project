using AltenAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AltenAPI.Services
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration configuration;

        public LoginService(IConfiguration _configuration)
        {
            this.configuration = _configuration;
        }

        public IResult Login(UserDto loggedInUser)
        {
            if (loggedInUser is null) return Results.NotFound("User not found");

            var claims = new[]
            {
                    new Claim(ClaimTypes.NameIdentifier, loggedInUser.Username),
                    new Claim(ClaimTypes.Email, loggedInUser.EmailAddress),
                    new Claim(ClaimTypes.GivenName, loggedInUser.GivenName),
                    new Claim(ClaimTypes.Surname, loggedInUser.Surname),
                    new Claim(ClaimTypes.Role, loggedInUser.Role),
                    new Claim("UserID", loggedInUser.Id.ToString())
                };

            var token = new JwtSecurityToken
            (
                issuer: configuration.GetValue<string>("Jwt:Issuer"),
                audience: configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(60),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Key"))),
                    SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Results.Ok(tokenString);
        }
    }
}
