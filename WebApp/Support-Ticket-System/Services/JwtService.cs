
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Support_Ticket_System.Common.Config;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Support_Ticket_System.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtConfig _config;

        public JwtService(IOptions<JwtConfig> config)
        {
            _config = config.Value;
        }

        public string GenerateToken(string email, string role)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.Name, email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_config.ExpiresInMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

