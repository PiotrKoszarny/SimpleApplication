using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using SimpleApp.DataAccess;
using SimpleApp.DataAccess.Entity;
using System;
using MediatR;
using System.Reflection;
using SimpleApp.Settings;
using Microsoft.Extensions.Options;
using SimpleApp.BusinessLogicLayer.Services;
using SimpleApp.IOC;
using Microsoft.Extensions.FileProviders;
using System.IO;

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
                options.UseSqlServer(Configuration.GetConnectionString("TargerDatabase")));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>()
                    .AddEntityFrameworkStores<SimpleDbContext>()
                    .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddOptions();

            services.AddCors(options => options.AddPolicy("AllowAll",
                p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Services
            services.RegisterServices();

            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddSingleton<IFileSettings>(x => x.GetService<IOptions<AppSettings>>().Value);
            services.AddDirectoryBrowser();
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

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
            });
            var path = Configuration.GetSection("AppSettings")["PhotoPath"];

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                path)
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                 path)
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
