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
using Common.Services;
using Timer = System.Timers.Timer;
using Common;
using Common.Utils;
using System.Text.RegularExpressions;
using System.Threading;

namespace WorkerAntixiter
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private System.Threading.Timer t;
        private readonly HostzoneService _hostzoneService;
        private List<Player> PlayerCache = new List<Player>();


        //Cache
        public DateTime DateCokkie { get; set; } = DateTime.MinValue;
        private string Cookie { get; set; }

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
            Timer t = new Timer(10000);
            t.AutoReset = true;
            t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            t.Start();
        }


        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            try
            {
                var _context = _serviceProvider.GetRequiredService<ApplicationContext>();
                var playersDb = await _context.Players.AsNoTracking().ToListAsync();
                var temDelecao = false;


                if(DateTime.Now > DateCokkie)
                {
                    Cookie = await _hostzoneService.Logar();
                    DateCokkie = DateTime.Now.AddHours(2);
                }


                var result = await _hostzoneService.StatusMatch(Cookie);
                var allPlayers = result;

                var tt = allPlayers.Split("\n");

                var map = Regex.Match(result, "map(?!s)[\\s\\S] +:[\\s\\S]+")?.Value.Split("\n").First().Split(":").Last();
                var players2 = tt.Where(x => x.StartsWith("#")).ToList();
                players2.RemoveAt(0);
                players2.Remove(players2.Last());
                foreach (var item in players2)
                {
                    var name = Regex.Match(item, "\"[\\s\\S\\d]+\"");
                    var steamId = Regex.Match(item, "STEAM_1:[0-9]{1}:[0-9]+");

                    var playerToSave = new Player { Expiration = DateTime.Now.AddMinutes(1), IsAntiCheatOpen = true, IsConnected = true, Map = map, Name = name.Value.Replace("\"", ""), SteamId = SteamUtils.TranslateSteamID(steamId.Value).ToString() };
                    if (!PlayerCache.Any(x => x.SteamId == playerToSave.SteamId))
                    {
                        var player = playersDb.FirstOrDefault(x => x.SteamId == playerToSave.SteamId);
                        if (player == null)
                        {
                            _context.Players.Add(playerToSave);

                        }
                        else
                        {
                            player.IsConnected = true;
                            player.Expiration = DateTime.Now.AddMinutes(1);
                            player.IsAntiCheatOpen = true;

                            player.Map = map;
                            _context.Update(player);
                        }
                        PlayerCache.Add(playerToSave);

                    }
                }
                await _context.SaveChangesAsync();


                foreach (var player in playersDb.Where(x => x.IsConnected))
                {
                    if (player.IsAntiCheatOpen == false || DateTime.Now > player.Expiration)
                    {
                        if (DateTime.Now > DateCokkie)
                        {
                            Cookie = await _hostzoneService.Logar();
                            DateCokkie = DateTime.Now.AddHours(2);
                        }
                        if(player.Name != "GOTV-Hostzone.com.br")
                        {

                        await _hostzoneService.KikarJogador(player.Name, Cookie);
                        await _hostzoneService.KickMessage($"Jogador {player.Name} sem o anticheat.", Cookie);
                            player.IsAntiCheatOpen = false;
                            player.IsConnected = false;
                            PlayerCache= PlayerCache.Where(x => x.SteamId != player.SteamId).ToList();
                            _context.Update(player);
                            temDelecao = true;
                        }




                    }
                }

                if (temDelecao)
                {
                    await _context.SaveChangesAsync();
                    temDelecao = false;
                }
            }
            catch (Exception)
            {

                //
            }


        }


    }
}
