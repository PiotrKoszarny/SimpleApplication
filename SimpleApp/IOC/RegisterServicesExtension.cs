using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;

namespace SimpleApp.IOC
{
    public static class RegisterServicesExtension
    {
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
