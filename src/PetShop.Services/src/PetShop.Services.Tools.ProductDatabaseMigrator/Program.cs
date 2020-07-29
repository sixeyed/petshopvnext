using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Services.Entities;
using PetShop.Services.Tools.ProductDatabaseMigrator.Data;

namespace PetShop.Services.Tools.ProductMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("config/connectionstrings.json")
                .Build();

            var sourceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddTransient<Source>()
                .AddDbContext<PetShopContext>(options =>
                     options.UseSqlServer(config.GetConnectionString("MSPetShop4"),
                     sqlServerOptions => sqlServerOptions.EnableRetryOnFailure()))
                .BuildServiceProvider();

            var targetProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(config)
                .AddTransient<Target>()
                .AddDbContext<PetShopContext>(options =>
                     options.UseCosmos(config.GetConnectionString("petshop-db"), "petshop-db"))
                .BuildServiceProvider();

            var source = sourceProvider.GetService<Source>();
            var target = targetProvider.GetService<Target>();

            target.SaveProducts(source.GetProducts());
        }
    }
}
