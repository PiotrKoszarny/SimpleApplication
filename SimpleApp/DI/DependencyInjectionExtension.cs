using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SimpleApp.SignalRHub;

namespace SimpleApp.DI
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterSignalR(this IServiceCollection services)
        {
            services.AddSignalR();

            return services;
        }

        public static IApplicationBuilder ConfigurationSignlarR(this IApplicationBuilder app)
        {
            app.UseEndpoints(enpoints =>
            {
                enpoints.MapHub<ChatHub>("/chat-hub");
            });

            return app;
        }
    }
}
