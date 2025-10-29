using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
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
            ApiAuthSettingsBase settingsBase = new ApiAuthSettingsBase() 
            { 
                Id = settings.Id,
                Secret = HashHelper.GetHashFromString(settings.Secret)
            };
            return  await apiRepository.IsApiKeyExistAsync(settingsBase);
        }
    }
}
