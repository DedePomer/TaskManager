namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        void AddUser(string login, string password);
        bool IsUserWithThisLoginExist(string login);
    }
}
