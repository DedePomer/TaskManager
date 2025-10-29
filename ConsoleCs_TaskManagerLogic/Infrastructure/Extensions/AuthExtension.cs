using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConsoleCs_TaskManagerLogic.Infrastructure.Extensions
{
    public static class AuthExtension
    {
        public static void AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(o=>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration["AuthSettings:SecretKey"]!)),
                    };
                });

            //авторизация должна быть в другом екстеншене
            services.AddAuthorization(options =>
            {
                options.AddPolicy("CreateApiConnectionPolicy", policy =>
                    policy.RequireAssertion(context =>
                    {
                        var nickname = context.User.FindFirst("name")?.Value;
                        return nickname == configuration["ApiKeyCreatorUser"];
                    }));
            });
        }
    }
}
