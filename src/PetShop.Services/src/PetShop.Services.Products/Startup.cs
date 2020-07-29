using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PetShop.Services.Entities;

namespace PetShop.Services.Products
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
            services.AddControllers();

            var dbProvider = Configuration["Database:Provider"];
            var dbName = Configuration["Database:Name"];
            var connectionString = Configuration.GetConnectionString(dbName);

            _ = dbProvider switch
            {
                "SqlServer" => services.AddDbContext<PetShopContext>(options =>
                     options.UseSqlServer(connectionString,
                     sqlServerOptions => sqlServerOptions.EnableRetryOnFailure())),

                "Cosmos" => services.AddDbContext<PetShopContext>(options =>
                     options.UseCosmos(connectionString, dbName)),

                _ => throw new NotSupportedException("Supported providers: SqlServer and Cosmos")
            };
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
