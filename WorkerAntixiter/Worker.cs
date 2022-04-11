using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using WorkerAntixiter.Services;
using Timer = System.Timers.Timer;

namespace WorkerAntixiter
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private System.Threading.Timer t;
        private readonly HostzoneService _hostzoneService;

        public Worker(ApplicationContext context, HostzoneService hostzoneService, IServiceProvider serviceProvider)
        {
            _hostzoneService = hostzoneService;
            _serviceProvider = serviceProvider;
        }
        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Test();
        }



        public void Test()
        {
            Timer t = new Timer(30000);
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            t.Start();
        }

        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {

            var _context = _serviceProvider.GetRequiredService<ApplicationContext>();
            var players = await _context.Players.AsNoTracking().ToListAsync();
            var temDelecao = false;
            foreach (var player in players)
            {
                if (player.IsAntiCheatOpen == false || DateTime.Now > player.Expiration)
                {

                    Console.WriteLine(JsonConvert.SerializeObject(player));

                    Console.WriteLine($"Expulsando jogador {DateTime.Now.ToString("G")}");
                    var cookie = await _hostzoneService.Logar();
                    await _hostzoneService.KikarJogador(player.Name, cookie);
                    _context.Players.Remove(player);
                    temDelecao = true;
                }
            }

            if (temDelecao)
            {
               await _context.SaveChangesAsync();
               temDelecao = false;
            }

        }
    }
}
