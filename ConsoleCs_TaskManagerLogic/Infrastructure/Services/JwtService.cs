using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.Extensions.Options;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class JwtService(IOptions<AuthSettings> options) : ITokenService
    {
        public string GenerateToken(string login)
        {
            var token = 
            throw new NotImplementedException();
        }
    }
}
