using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Dapper;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class TaskRepository(IDbConnectionFactory connection) : ITaskRepository
    {
        public async Task AddTextTaskAsync(string text, int userId, string? description = null)
        {
            using var dbConnection = connection.CreateConnection();

            await dbConnection.ExecuteAsync(new CommandDefinition("""

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

        public async Task<int> GetCountTask()
        {
            using var dbConnection = connection.CreateConnection();

            int count = await dbConnection.ExecuteScalarAsync<int>(new CommandDefinition("""

                SELECT COUNT(*) FROM users
                
                """));

            return count;
        }

        public async Task<IEnumerable<TextTask>> GetTasksAsync(int userId)
        {
            using var dbConnection = connection.CreateConnection();

            IEnumerable<TextTask> tasks = await dbConnection.QueryAsync<TextTask>(new CommandDefinition("""

                SELECT * FROM TextTasks
                WHERE userId = @UserId;
                
                """,
                new
                {
                    UserId = userId
                }));

            return tasks;
        }
    }
}
