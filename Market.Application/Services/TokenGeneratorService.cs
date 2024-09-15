using Market.Application.Interfaces;
using Market.Domain.Common.Constants;
using Market.Domain.Common.Settings;
using Market.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Market.Application.Services
{
    public class TokenGeneratorService(IConfiguration configuration) : ITokenGeneratorService
    {
        private JwtSettings jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>()
            ?? throw new InvalidOperationException("Jwt settings is not configured!");
        public string GenerateToken(User user)
        {
            var claims = GetClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                audience: jwtSettings.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(2),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return token;
        }

        private List<Claim> GetClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimConstants.UserId, user.Id.ToString()),
                new Claim(ClaimConstants.Email, user.Email),
                new Claim(ClaimConstants.Role , user.Role.ToString())
            };
        }
    }
}
