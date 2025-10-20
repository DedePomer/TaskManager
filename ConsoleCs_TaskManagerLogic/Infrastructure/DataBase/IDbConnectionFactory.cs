using System.Data;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.DataBase
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
