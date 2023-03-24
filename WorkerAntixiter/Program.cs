
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
using Common.Services;

// See https://aka.ms/new-console-template for more information

public static partial class Program{
   
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();

    }



    static IHostBuilder CreateHostBuilder(string[] args)
{
    var cfg = Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {


            var connString = "Server=csantixiter.mysql.uhserver.com;Port=3306;User Id=dudkiller1;Password=Dudu@1131183004;Database=csantixiter";
            var migrationAssembly = typeof(ApplicationContext).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<ApplicationContext>(
                o => o.UseMySql(
                    connString,
                    new MySqlServerVersion(new Version(5, 6)),
                    x => x.MigrationsAssembly(migrationAssembly)), ServiceLifetime.Transient);
            services.AddLogging();
            services.AddTransient<HostzoneService>();

            services.AddHostedService<Worker>();
        });


    return cfg;
}



}