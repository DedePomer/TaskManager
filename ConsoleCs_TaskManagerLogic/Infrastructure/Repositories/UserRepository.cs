using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;

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
            throw new NotImplementedException();
        }

        public bool IsUserExists(string login, string password)
        {
            throw new NotImplementedException();
        }
    }
}
