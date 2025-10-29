using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;
using ConsoleCs_TaskManagerLogic.Model.DataType;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class ApiService(IApiRepository apiRepository)
    {
        public async Task RegisterApiKeyAsync(string secret)
        {
            await apiRepository.AddApiKeyAsync(secret);
        }

        public async Task<bool> IsApiKeyExistAsync(ApiAuthSettings settings)
        { 
            return  await apiRepository.IsApiKeyExistAsync(settings);
        }
    }
}
