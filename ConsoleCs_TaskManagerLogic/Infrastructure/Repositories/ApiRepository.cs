using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
using Dapper;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Repositories
{
    public class ApiRepository(IDbConnectionFactory connection) : IApiRepository
    {

        public async Task AddApiKeyAsync(string secret)
        {
            using var dbConnection = connection.CreateConnection();

            await dbConnection.ExecuteAsync(new CommandDefinition("""

                    INSERT INTO ApiKeys (secret)
                    VALUES  
                    (@Secret)

                    """,
                   new
                   {
                       Secret = HashHelper.GetHash(secret)
                   }));
        }
    }
}
