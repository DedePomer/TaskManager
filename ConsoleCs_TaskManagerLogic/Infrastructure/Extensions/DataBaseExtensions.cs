using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Extensions
{
    public static class DataBaseExtensions
    {
        public static void AddDataBase(this IServiceCollection collection, IConfiguration configuration)
        {
            var databasePath = configuration["DatabasePath"];
            ArgumentNullException.ThrowIfNullOrEmpty(databasePath, nameof(databasePath));
            collection.AddSingleton<IDbConnectionFactory>(new SqliteConnectionFactory(databasePath));
        }
    }
}
