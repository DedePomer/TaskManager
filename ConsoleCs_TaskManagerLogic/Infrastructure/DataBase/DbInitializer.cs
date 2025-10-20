using Dapper;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.DataBase
{
    public class DbInitializer
    {
        private readonly IDbConnectionFactory _connectionFactory;
        public DbInitializer(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Initialize()
        {
            using var connection = _connectionFactory.CreateConnection();

            connection.Execute("""
                CREATE TABLE If NOT EXISTS Users
                (
                    id INTEGER PRIMARY KEY,
                    name text
                );
                """);

            connection.Execute("""
                CREATE TABLE If NOT EXISTS TextTasks
                (
                    id INTEGER PRIMARY KEY,
                    text text,
                    discription text,                    
                    FOREIGN KEY(userId) REFERENCES Users(id)
                );
                """);




        }
    }
}
