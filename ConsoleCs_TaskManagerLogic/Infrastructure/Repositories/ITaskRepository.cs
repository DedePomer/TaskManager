using ConsoleCs_TaskManagerLogic.Model.DataType;
using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TextTask>> GetAllTaskAsync(int userId);
        Task AddTextTaskAsync(string text, int userId, string? description = default);
        Task DeleteTaskAsync(int id);
    }
}
