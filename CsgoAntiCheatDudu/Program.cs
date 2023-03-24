using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using Common.Utils;
using CsAntiCheat.Views;
using CsgoAntiCheatDudu;
using CsgoAntiCheatDudu.Services;
using CsgoAntiCheatDudu.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Newtonsoft.Json;

public class Program
{
    [MTAThread]
    static async Task Main()
    {

        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(services
            .AddLogging());

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);


        //Application.Run(new Login(serviceProvider));





        Application.Run(new Home(serviceProvider));
        AllocConsole();
    }


    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool AllocConsole();
    static void ConfigureServices(ServiceCollection services)
    {

        var migrationAssembly = typeof(CsgoAntiCheatDudu.ApplicationContext).GetTypeInfo().Assembly.GetName().Name;
        services.AddDbContext<CsgoAntiCheatDudu.ApplicationContext>(
            o => o.UseMySql(
                "Server=csantixiter.mysql.uhserver.com;Port=3306;User Id=dudkiller1;Password=Dudu@1131183004;Database=csantixiter",
                new MySqlServerVersion(new Version(5, 6)),
                x => x.MigrationsAssembly(migrationAssembly)
                    .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)), ServiceLifetime.Scoped);
        services.AddLogging();

        services.AddTransient<IDropboxService, DropboxService>();
        services.AddSingleton<CacheService>();

        services.AddSingleton<HostedService>();

    }





    //var app = builder.Build();

    //using (var steam = new SteamBridge())
    //{
    //    var steamId = steam.GetSteamId().ToString(CultureInfo.InvariantCulture);

    //    if (string.IsNullOrEmpty(steamId) || steamId == "0")
    //    {
    //        Console.WriteLine("Abra a steam antes de abrir o anticheat o cara de buceta");
    //        app.Lifetime.StopApplication();
    //        Console.ReadLine();
    //        return;
    //    }
    //}

    //app.Run();

}