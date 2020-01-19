using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.Hosting;
using SimpleApp.BusinessLogicLayer.Services;

namespace SimpleApp.IOC
{
    public static class DiRegisterExtension
    {
        public static void RegisterMassTransit(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMassTransit(x =>
            {
                x.AddBus(provider =>
                    Bus.Factory.CreateUsingRabbitMq(cfg =>
                        {
                            cfg.Host("localhost", host =>
                            {
                                host.Password("guest");
                                host.Username("guest");
                            });
                        }
                    ));
                serviceCollection.AddSingleton<IHostedService, BusService.BusService>();
            });
        }



        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
