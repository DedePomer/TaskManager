using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<DbInitializer>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
