﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using SimpleApp.DataAccess;
using Microsoft.AspNetCore.Mvc;
using SimpleApp.DataAccess.Entity;
using SimpleApp.Infrastructure.CQRS;
using SimpleApp.Infrastructure.CQRS.Command;
using SimpleApp.Infrastructure.CQRS.Query;

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
            services.InstallBussinessLogicHandlers();
            services.AddDbContext<SimpleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SimpleDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SimpleDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


            services.AddScoped<IQueryDispatcher, DefaultQueryDispatcher>();
            services.AddScoped<ICommandDispatcher, DefaultCommandDispatcher>();
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
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                // Mapping of endpoints goes here:
                endpoints.MapControllers();
                //endpoints.MapRazorPages();
                //endpoints.MapHub<MyChatHub>()
                //endpoints.MapGrpcService<MyCalculatorService>()
            });
        }
    }
}
