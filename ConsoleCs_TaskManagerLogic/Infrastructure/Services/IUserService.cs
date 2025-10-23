namespace ConsoleCs_TaskManagerLogic.Infrastructure.Services
{
    public interface IUserService
    {
        void RegisterUser(string login, string password);
        bool IsUserExist(string login);
        bool IsUserExist(string login, string password);
        int GetUserIdByName(string login);
    }
}
