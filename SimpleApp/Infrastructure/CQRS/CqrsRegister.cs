using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;

namespace SimpleApp.Infrastructure.CQRS
{
    public static class CqrsRegister
    {
        public static void RegisterQueryHandler(IEnumerable<Assembly> assemblies, IServiceCollection services)
        {
            services.Scan(x =>
            {
                x.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        public static void RegisterCommandHandler(IEnumerable<Assembly> assemblies, IServiceCollection services)
        {
            services.Scan(x =>
            {
                x.FromAssemblies(assemblies)
                    .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime();
            });
        }

        public static void InstallBussinessLogicHandlers(this IServiceCollection services)
        {
            var assemblies = new List<Assembly> { Assembly.GetExecutingAssembly() };

            RegisterQueryHandler(assemblies, services);
            RegisterCommandHandler(assemblies, services);
        }
    }
}