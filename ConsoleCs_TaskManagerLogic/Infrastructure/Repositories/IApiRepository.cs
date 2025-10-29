using ConsoleCs_TaskManagerLogic.Model.DataType;
using System.ComponentModel;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface IApiRepository
    {
        Task AddApiKeyAsync(string secret);
        Task<bool> IsApiKeyExistAsync(ApiAuthSettings settings);
    }
}
