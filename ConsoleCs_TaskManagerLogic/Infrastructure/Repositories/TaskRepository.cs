using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Model.Interfaces;
using Dapper;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class TaskRepository(IDbConnectionFactory _connection) : ITaskRepository
    {
        public async Task AddTextTaskAsync(string text, int userId, string? description = null)
        {
            using var connection = _connection.CreateConnection();

            await connection.ExecuteAsync(new CommandDefinition("""

                    INSERT INTO TextTasks (text, discription, userId)
                    VALUES  
                    (@Text, @Description, @UserId)

                    """,
                   new
                   {
                       Text = text,
                       Description = description,
                       UserId = userId
                   }));
        }

        public async Task DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ITask> GetAllTaskAsync(int userId)
        {
            using var connection = _connection.CreateConnection();

            await connection.ExecuteAsync(new CommandDefinition("""

                    INSERT INTO TextTasks (text, discription, userId)
                    VALUES  
                    (@Text, @Description, @UserId)

                    """,
                   new
                   {
                       Text = text,
                       Description = description,
                       UserId = userId
                   }));
        }
    }
}
