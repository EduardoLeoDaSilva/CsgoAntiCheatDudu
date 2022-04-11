
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.FeatureManagement;
using Serilog;
using System.IO;
using System.Reflection;
using WorkerAntixiter;
using WorkerAntixiter.Services;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
CreateHostBuilder(args).Build().Run();

static IHostBuilder CreateHostBuilder(string[] args)
{
    var cfg = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            var configuration = GetConfiguration();

            var connString = configuration.GetConnectionString("DefaultConnection");
            var migrationAssembly = typeof(ApplicationContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationContext>(
                o => o.UseMySql(
                    connString,
                    new MySqlServerVersion(new Version(5, 6)),
                    x => x.MigrationsAssembly(migrationAssembly)));
            services.AddLogging();
            services.AddTransient<HostzoneService>();

            services.AddHostedService<Worker>();
        });


    return cfg;
}


 static IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}