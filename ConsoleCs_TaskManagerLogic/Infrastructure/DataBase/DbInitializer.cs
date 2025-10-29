using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
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
                    name text,
                    password blob
                );
                """);

            connection.Execute("""
                CREATE TABLE If NOT EXISTS TextTasks
                (
                    id INTEGER PRIMARY KEY,
                    text text,
                    discription text, 
                    userId INTEGER,
                    FOREIGN KEY(userId) REFERENCES Users(id)
                );
                """);

            connection.Execute("""
                CREATE TABLE If NOT EXISTS ApiKeys
                (
                    id TEXT PRIMARY KEY DEFAULT (
                    strftime('%Y%m%d%H%M%f', 'now') || '_' || substr(hex(randomblob(4)), 1, 6)),
                    secret blob                   
                );
                """);

            var keysCount = connection.ExecuteScalar<int>("""

                SELECT COUNT(*) FROM ApiKeys   

                """);
            if (keysCount == 0)
            {
                const string secret = "MyServiceSecret";

                connection.Execute(new CommandDefinition("""

                    INSERT INTO ApiKeys (secret)
                    VALUES  
                    (@Secret)

                    """,
                    new
                    {
                        Secret = HashHelper.GetHash(secret)                        
                    }));
            }


            var userCount = connection.ExecuteScalar<int>("""

                SELECT COUNT(*) FROM Users   

                """);
            if (userCount == 0)
            {
                const string name = "admin";
                const string password = "admin";

                connection.Execute(new CommandDefinition("""

                    INSERT INTO Users (id, name, password)
                    VALUES  
                    (1, @Name, @Password)

                    """, 
                    new { Name = name, 
                    Password = HashHelper.GetHash(password) }));
            }
        }
    }
}
