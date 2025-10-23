using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class JwtService(IOptions<AuthSettings> options) : ITokenService
    {
        public string GenerateToken(string login)
        {
            var claims = new List<Claim>
            {
                new Claim("name", login)
            };
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.Add(options.Value.Expire),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Value.SecretKey)),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
