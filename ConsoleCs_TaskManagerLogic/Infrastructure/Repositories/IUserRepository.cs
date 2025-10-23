namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        void AddUser(string login, string password);
        bool IsUserExist(string login);
        bool IsUserExist(string login, string password);
        int GetUserIdByName(string login);
    }
}
