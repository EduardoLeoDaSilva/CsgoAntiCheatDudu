using System.Globalization;
using System.Reflection;
using CsgoAntiCheatDudu;
using CsgoAntiCheatDudu.Services;
using CsgoAntiCheatDudu.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationAssembly = typeof(ApplicationContext).GetTypeInfo().Assembly.GetName().Name;
builder.Services.AddDbContext<ApplicationContext>(
    o => o.UseMySql(
        connString,
        new MySqlServerVersion(new Version(5, 6)),
        x => x.MigrationsAssembly(migrationAssembly)
            .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
builder.Services.AddLogging();

builder.Services.AddTransient<IDropboxService, DropboxService>();
builder.Services.AddSingleton<CacheService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

using (var steam = new SteamBridge())
{
    var steamId = steam.GetSteamId().ToString(CultureInfo.InvariantCulture);

    if (string.IsNullOrEmpty(steamId) || steamId == "0")
    {
        Console.WriteLine("Abra a steam pau no cú");
        app.Lifetime.StopApplication();
        return;
    }

}

app.Run();

