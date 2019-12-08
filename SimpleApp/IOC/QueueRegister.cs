using Microsoft.Extensions.DependencyInjection;
using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace SimpleApp.IOC
{
    public static class QueueRegister
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
    }
}
