using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
using ConsoleCs_TaskManagerLogic.Model.Interfaces;
using Dapper;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class TaskRepository(IDbConnectionFactory _connection) : ITaskRepository
    {
        public void AddTextTask(string text, int userId, string? description = null)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                    INSERT INTO Tasks (text, discription, userId)
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

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public ITask GetAllTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}
