using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        ITask GetAllTask(string login);
        void AddTextTask(string text, string? description = default);
        void DeleteTask(int id);
    }
}
