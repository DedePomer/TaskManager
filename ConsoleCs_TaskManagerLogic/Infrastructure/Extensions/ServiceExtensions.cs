using ConsoleCs_TaskManagerLogic.Infrastructure.DataBase;
using ConsoleCs_TaskManagerLogic.Infrastructure.Repositories;
using ConsoleCs_TaskManagerLogic.Infrastructure.Services;
using ConsoleCs_TaskManagerLogic.Model.DataType;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DbInitializer>();

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();

            services.AddScoped<ITokenService, JwtService>();
            services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
        }
    }
}
