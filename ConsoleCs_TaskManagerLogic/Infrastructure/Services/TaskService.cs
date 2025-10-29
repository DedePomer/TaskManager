using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;
using ConsoleCs_TaskManagerLogic.Model.DataType;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class TaskService(ITaskRepository _taskRepository, IUserRepository _userRepository)
    {
        public async Task AddTextTaskAsync(string text, string login, string? description = null)
        {
            int userId = _userRepository.GetUserIdByName(login);
            if (userId != 0)
            {
                await _taskRepository.AddTextTaskAsync(text, userId, description);
            }
        }

        public async Task<List<TextTask>> GetTasksAsync(string login)
        {
            int userId = _userRepository.GetUserIdByName(login);
            if (userId != 0)
            {
                IEnumerable<TextTask> tasks =  await _taskRepository.GetTasksAsync(userId);
                return tasks.ToList();
            }
            throw new NotImplementedException();
        }

        public async Task<int> GetCount()
        {
            return await _taskRepository.GetCountTask();
        }

    }
}
