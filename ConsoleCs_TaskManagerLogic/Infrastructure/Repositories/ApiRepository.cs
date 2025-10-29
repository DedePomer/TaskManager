using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Helpers;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Dapper;
using System.Data.Common;

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

        public async Task<bool> IsApiKeyExistAsync(ApiAuthSettingsBase settings)
        {
            using var dbConnection = connection.CreateConnection();

            bool isExist = await dbConnection.ExecuteScalarAsync<bool>(new CommandDefinition("""

                SELECT EXISTS
                ( SELECT 1 FROM ApiKeys
                 WHERE id = @Id AND secret = @Secret);
                
                """,
                new
                {
                    Id = settings.Id,
                    Secret = settings.Secret
                }));

            return isExist;
        }
    }
}
