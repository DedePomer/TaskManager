using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;

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
    }
}
