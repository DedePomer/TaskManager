namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public interface ITokenService
    {
        string GenerateToken(string login);
    }
}
