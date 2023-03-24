using Common;
using Common.Services;
using Common.Utils;
using CsgoAntiCheatDudu.Services;
using CsgoAntiCheatDudu.Utils;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Globalization;
using System.Timers;
using Timer = System.Timers.Timer;

namespace CsgoAntiCheatDudu
{
    public class HostedService 
    {
        private readonly IServiceProvider _serviceProvider;
        private System.Threading.Timer t;
        private readonly CacheService _cacheService;
        private readonly ILogger<HostedService> _logger;

        public List<string> Messages = new List<string>();
        private readonly IDropboxService _dropboxService;

        public HostedService(IServiceProvider serviceProvider, CacheService cacheService, ILogger<HostedService> logger, IDropboxService dropboxService)
        {
            _serviceProvider = serviceProvider;
            _cacheService = cacheService;
            _logger = logger;
            _dropboxService = dropboxService;
        }

        public async Task StartVerification()
        {
            try
            {


                using (var steam = new SteamBridge())
                {
                    var steamId = steam.GetSteamId().ToString(CultureInfo.InvariantCulture);

                    if (string.IsNullOrEmpty(steamId) || steamId == "0")
                    {
                        Messages.Add("Abra a steam antes de abrir o anticheat o cara de buceta");
                        await Task.Delay(5000);
                        Application.Exit();
                        return;
                    }
                }


                if (Messages.Count > 10)
                    Messages.Clear();

                Messages.Add("Processando.");

                var serviceScopeFactory = _serviceProvider.GetService<IServiceScopeFactory>();
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetService<ApplicationContext>();

                    var temDelecao = false;

                    string currentSteamIdLoggedUser = "";

                    if (string.IsNullOrEmpty(currentSteamIdLoggedUser))
                    {
                        using (var steam = new SteamBridge())
                            currentSteamIdLoggedUser = steam.GetSteamId().ToString(CultureInfo.InvariantCulture);

                        if (!string.IsNullOrEmpty(currentSteamIdLoggedUser))
                            _cacheService.LoggedSteamIdUser = currentSteamIdLoggedUser;
                        else
                        {
                            Messages.Add("Abra a steam cara de buceta.");

                        }

                    }


                    var loggedUserAssociatedCs = _context.Players.FirstOrDefault(x => x.SteamId == _cacheService.LoggedSteamIdUser);

                    if(_cacheService.TokenDropbox == null)
                    {
                        _cacheService.TokenDropbox = _context.TokenDropboxes.FirstOrDefault();
                    }

                    if(_cacheService.TokenDropbox != null && DateTime.Now > _cacheService.TokenDropbox.Expiration)
                    {
                        _cacheService.TokenDropbox = _context.TokenDropboxes.FirstOrDefault(x => x.Expiration > DateTime.Now);
                    }

                    if (loggedUserAssociatedCs != null && loggedUserAssociatedCs.IsAntiCheatOpen == false && loggedUserAssociatedCs.IsConnected == false)
                    {
                        loggedUserAssociatedCs.IsAntiCheatOpen = true;
                        loggedUserAssociatedCs.Expiration = DateTime.Now.AddHours(1);
                        _context.Players.Update(loggedUserAssociatedCs);
                       await _context.SaveChangesAsync();
                    }

                    if (loggedUserAssociatedCs!= null && loggedUserAssociatedCs.IsConnected == false)
                    {
                        Messages.Add("Conecte-se ao servidor pau no cú do caralho");
                        return;
                    }


                    var isToUpdate = _cacheService.IsToUpdated();

                    var player = loggedUserAssociatedCs;

                    var updateDb = false;

                    if ((player != null) && (string.IsNullOrEmpty(player?.Map) == false) || player != null && (player.Expiration - DateTime.Now).Seconds < 30)
                    {
                        updateDb = true;

                        player.IsConnected = true;
                        player.Expiration = DateTime.Now.AddMinutes(1);
                        
                        player.IsAntiCheatOpen = true;
                        _context.Update(player);

                    }

                    if (updateDb)
                    {
                        _cacheService.LastUpdateDate = DateTime.Now.AddMinutes(1);
                        await _context.SaveChangesAsync();
                        updateDb = false;
                    }


                    if (player != null && (!string.IsNullOrEmpty(loggedUserAssociatedCs.Map)) && player.CanITakePhoto())
                    {
                        player.LastPhotoTaken = DateTime.Now.AddMinutes(1);
                        var image = ImageHandler.GetSreenshot();
                        var byteOfImage = ImageHandler.ImageToByte(image);
                        var result = await _dropboxService.SendImage(byteOfImage, loggedUserAssociatedCs.Name, loggedUserAssociatedCs.Map);
                        if (result != null)
                            Messages.Add("Análise efetuada; clean");

                        updateDb = true;
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ee)
            {
                Messages.Add($"Erro... {ee.Message}");

            }
        }
    }
}
