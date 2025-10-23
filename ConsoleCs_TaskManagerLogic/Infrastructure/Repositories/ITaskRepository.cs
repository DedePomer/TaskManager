using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        Task<ITask> GetAllTaskAsync(int userId);
        Task AddTextTaskAsync(string text, int userId, string? description = default);
        Task DeleteTaskAsync(int id);
    }
}
