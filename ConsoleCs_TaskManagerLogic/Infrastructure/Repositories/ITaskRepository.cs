using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface ITaskRepository
    {
        ITask GetAllTask(string login);
    }
}
