using System.ComponentModel;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface IApiRepository
    {
       void AddApiKeyAsync(string secret);
    }
}
