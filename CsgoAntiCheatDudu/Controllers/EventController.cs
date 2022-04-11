using System.Globalization;
using CsgoAntiCheatDudu.Models;
using CsgoAntiCheatDudu.Services;
using CsgoAntiCheatDudu.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CsgoAntiCheatDudu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly ILogger<EventController> _logger;
        private readonly ApplicationContext _applicationContext;
        private readonly IDropboxService _dropboxService;
        private readonly CacheService _cacheService;


        public EventController(ILogger<EventController> logger, ApplicationContext applicationContext, IDropboxService dropboxService, CacheService cacheService)
        {
            _logger = logger;
            this._applicationContext = applicationContext;
            _dropboxService = dropboxService;
            _cacheService = cacheService;
        }

        [HttpGet]
        public ActionResult Teste1(dynamic objeto)
        {
            Console.WriteLine(objeto);
            LoggerExtensions.LogInformation(_logger, JsonConvert.SerializeObject(objeto));
            return Ok(objeto);

        }


        [HttpPost]
        public async Task<ActionResult> Teste2(dynamic objet)
        {
            var t2t = JsonConvert.DeserializeObject(objet.ToString());
            var tt3 = JsonConvert.SerializeObject(t2t);

            var tt = (BaseModel)JsonConvert.DeserializeObject<BaseModel>(tt3);


            string currentSteamIdLoggedUser = "";

            if (string.IsNullOrEmpty(currentSteamIdLoggedUser))
            {
                using (var steam = new SteamBridge())
                    currentSteamIdLoggedUser = steam.GetSteamId().ToString(CultureInfo.InvariantCulture);

                if (!string.IsNullOrEmpty(currentSteamIdLoggedUser))
                    _cacheService.LoggedSteamIdUser = currentSteamIdLoggedUser;
                else
                {
                    LoggerExtensions.LogCritical(_logger, "Abra a steam cara de buceta");
                    return Ok();
                }

            }

            if (tt.Player.Steamid != _cacheService.LoggedSteamIdUser)
            {
                LoggerExtensions.LogCritical(_logger, "Analisando");
                return Ok();
            }



            var isToUpdate = _cacheService.IsToUpdated();

            var player = isToUpdate ? _applicationContext.Players.FirstOrDefault(x => x.SteamId == tt.Player.Steamid) : null;

            var updateDb = false;

            if ((player != null) && player.Map != tt?.Map?.Name || player != null && (player.Expiration - DateTime.Now).Seconds < 30)
            {
                updateDb = true;

                player.IsConnected = true;
                player.IsAntiCheatOpen = true;
                player.Expiration = DateTime.Now.AddMinutes(1);
                player.Map = tt?.Map?.Name;
                _applicationContext.Update(player);

            }
            else if (player == null && isToUpdate)
            {
                updateDb = true;

                player = new Player
                {
                    SteamId = tt.Player.Steamid,
                    Name = tt.Player.Name,
                    IsConnected = true,
                    IsAntiCheatOpen = true,
                    Map = tt?.Map?.Name,
                    Expiration = DateTime.Now.AddMinutes(1)

                };


                _applicationContext.Add(player);

            }

            if (updateDb)
            {
                _cacheService.LastUpdateDate = DateTime.Now.AddMinutes(1);
                await _applicationContext.SaveChangesAsync();
                updateDb = false;

            }


            if (player != null && tt.Player.Activity == "playing" && tt.Map.Phase == "live" && player.CanITakePhoto())
            {
                player.LastPhotoTaken = DateTime.Now.AddMinutes(1);
                var image = ImageHandler.GetSreenshot();
                var byteOfImage = ImageHandler.ImageToByte(image);
                var result = await _dropboxService.SendImage(byteOfImage, tt.Player.Name, tt.Map.Name);
                if (result != null)
                    LoggerExtensions.LogInformation(_logger, JsonConvert.SerializeObject(result));

                updateDb = true;
                await _applicationContext.SaveChangesAsync();


            }




            LoggerExtensions.LogInformation(_logger, JsonConvert.SerializeObject(tt3));
            return Ok(objet);
        }


    }
}
