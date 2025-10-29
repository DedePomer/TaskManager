using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class ApiService(IApiRepository apiRepository)
    {
        public async Task RegisterApiKeyAsync(string secret)
        {
            await apiRepository.AddApiKeyAsync(secret);
        }
    }
}
