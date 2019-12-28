using GreenPipes;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using SimpleApp.DataAccess;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Infrastructure.CQRS;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;
using SimpleApp.IOC;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace SimpleApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SimpleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SimpleDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<SimpleDbContext>()
                    .AddDefaultTokenProviders();

            //services.RegisterMassTransit();

            services.AddAuthenticationExtension(Configuration);
            services.AddMvc();

            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.RegisterCqrsHandler();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
