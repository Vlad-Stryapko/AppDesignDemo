using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServicesAndRepos.DataAccess;
using ServicesAndRepos.DataAccess.EntityFramework;
using ServicesAndRepos.Services;
using ServicesAndRepos.Services.Interfaces.Emails;
using ServicesAndRepos.Services.Interfaces.Orders;

namespace ServicesAndRepos.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var connectionString = Configuration.GetConnectionString("Database");
            services.AddDbContext<ServicesAndReposContext>(option => option.UseSqlServer(connectionString),
                ServiceLifetime.Scoped);

            services
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddTransient<IEmailService, EmailService>()
                .AddTransient<IOrderService, OrderService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
