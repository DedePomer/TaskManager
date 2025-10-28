using ConsoleCs_TaskManagerLogic.Model.DataType;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class ApiAuthService(ApiAuthSettings apiSettings)
    {
        public bool IsValid(ApiAuthSettings settings)
        {
            return apiSettings.Id == settings.Id && apiSettings.Secret == settings.Secret;
        }
    }
}
