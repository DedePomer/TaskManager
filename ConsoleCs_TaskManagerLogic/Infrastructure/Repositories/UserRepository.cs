using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
using Dapper;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connection;
        public UserRepository(IDbConnectionFactory connection) 
        {
            _connection = connection;
        }


        public void AddUser(string login, string password)
        {
            using var connection = _connection.CreateConnection();

            connection.Execute(new CommandDefinition("""

                INSERT INTO Users (name,password)
                VALUES (@Name, @Pasword);

                """,
                new { Name = login,
                    Pasword = HashHelper.GetHash(password) }));
        }

        public int GetUserIdByName(string login)
        {
            using var connection = _connection.CreateConnection();

            int id = connection.ExecuteScalar<int>(new CommandDefinition("""

                 SELECT id FROM Users
                 WHERE name = @Name;
                
                """,
               new { Name = login }));

            return id;
        }

        public bool IsUserExist(string login)
        {
            using var connection = _connection.CreateConnection();

            bool isExist = connection.ExecuteScalar<bool>(new CommandDefinition("""

                SELECT EXISTS
                ( SELECT 1 FROM Users
                 WHERE name = @Name);
                
                """, 
                new { Name = login }));
            
            return isExist;
        }

        public bool IsUserExist(string login, string password)
        {

            using var connection = _connection.CreateConnection();

            bool isExist = connection.ExecuteScalar<bool>(new CommandDefinition("""

                SELECT EXISTS
                ( SELECT 1 FROM Users
                 WHERE name = @Name AND password = @Password);
                
                """,
                new { Name = login,
                Password = HashHelper.GetHash(password)
                }));

            return isExist;
        }




    }
}
