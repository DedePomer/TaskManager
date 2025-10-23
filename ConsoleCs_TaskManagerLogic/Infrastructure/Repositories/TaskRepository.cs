using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
using ConsoleCs_TaskManagerLogic.Model.Interfaces;
using Dapper;
using System.Xml.Linq;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class TaskRepository(IDbConnectionFactory _connection) : ITaskRepository
    {
        public void AddTextTask(string text, string? description = null)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                    INSERT INTO Tasks (id, name, password)
                    VALUES  
                    (0, @Name, @Password)

                    """,
                   new
                   {
                       Name = name,
                       Password = HashHelper.GetHash(password)
                   }));

            throw new NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public ITask GetAllTask(string login)
        {
            throw new NotImplementedException();
        }
    }
}
