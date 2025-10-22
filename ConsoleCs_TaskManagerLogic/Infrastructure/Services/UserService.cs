using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }



        public bool IsUserExist(string login)
        {
            return _repository.IsUserExist(login);
        }

        public void RegisterUser(string login, string password)
        {
            _repository.AddUser(login, password);
        }
    }
}
