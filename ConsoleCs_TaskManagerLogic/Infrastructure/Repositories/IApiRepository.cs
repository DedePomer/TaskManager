using System.ComponentModel;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface IApiRepository
    {
        Task AddApiKeyAsync(string secret);
    }
}
