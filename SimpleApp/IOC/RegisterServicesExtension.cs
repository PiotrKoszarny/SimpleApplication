using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SimpleApp.BusinessLogicLayer.Services;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;
using SimpleApp.Settings;

namespace SimpleApp.IOC
{
    public static class RegisterServicesExtension
    {
        public static void AddAuthenticationExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var appsettingsSection = configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appsettingsSection);

            var settings = appsettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(settings.Secret);
            services.AddAuthentication(auth =>
                {
                    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(bearer =>
                {
                    bearer.RequireHttpsMetadata = false;
                    bearer.SaveToken = true;
                    bearer.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                    };
                });
            services.AddScoped<IUserService, UserService>();
        }

        public static void RegisterCqrsHandler(this IServiceCollection services)
        {
            services.InstallBussinessLogicHandlers();
            services.AddScoped<IQueryDispatcher, DefaultQueryDispatcher>();
            services.AddScoped<ICommandDispatcher, DefaultCommandDispatcher>();
        }

        private static void RegisterQueryHandler(IEnumerable<Assembly> assemblies, IServiceCollection services)
        {
            services.Scan(x =>
            {
                x.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        private static void RegisterCommandHandler(IEnumerable<Assembly> assemblies, IServiceCollection services)
        {
            services.Scan(x =>
            {
                x.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        private static void InstallBussinessLogicHandlers(this IServiceCollection services)
        {
            var assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() };

            RegisterQueryHandler(assemblies, services);
            RegisterCommandHandler(assemblies, services);
        }
    }
}
