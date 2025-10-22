namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public interface IUserService
    {
        void RegisterUser(string login, string password);
        bool IsUserWithThisLoginExist(string login);
    }
}
