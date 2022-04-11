namespace CsgoAntiCheatDudu.Services
{
    public class CacheService
    {
        public  DateTime LastUpdateDate { get; set; }
        public string LoggedSteamIdUser { get; set; }


        public bool IsToUpdated()
        {
            if ((LastUpdateDate - DateTime.Now).Seconds <= 30)
                return true;

            return false;
        }

    }
}
