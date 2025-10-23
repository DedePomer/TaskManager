using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        ITask GetAllTask(int id);
        void AddTextTask(string text, int userId, string? description = default);
        void DeleteTask(int id);
    }
}
