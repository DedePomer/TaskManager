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
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<IApiRepository, ApiRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<TaskService>();// чёта не захотелось делать интерфе
            services.AddSingleton<ApiService>();

            services.AddScoped<ITokenService, JwtService>();
            services.Configure<AuthSettings>(configuration.GetSection("AuthSettings"));
            services.Configure<ApiAuthSettingsBase>(configuration.GetSection("ServiceSetting"));
        }
    }
}
