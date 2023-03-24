using Common;

namespace CsgoAntiCheatDudu.Services
{
    public class CacheService
    {
        public  DateTime LastUpdateDate { get; set; }
        public string LoggedSteamIdUser { get; set; }

        public List<Player> Players { get; set; } = new List<Player>();
        public bool NewPlayer { get; set; }

        public TokenDropbox TokenDropbox { get; set; } = null;


        public bool IsToUpdated()
        {
            if ((LastUpdateDate - DateTime.Now).Seconds <= 30)
                return true;

            return false;
        }

    }
}
