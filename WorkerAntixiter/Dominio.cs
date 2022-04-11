namespace WorkerAntixiter
{
    public class Player
    {
        public string SteamId { get; set; }
        public string Name { get; set; }

        public bool IsConnected { get; set; }

        public string Map { get; set; }

        public DateTime LastPhotoTaken { get; set; }

        public bool IsAntiCheatOpen { get; set; }
        public DateTime Expiration { get; set; }


        public bool CanITakePhoto()
        {
            var seconds = (LastPhotoTaken - DateTime.Now).Seconds;
            if (seconds <= 30)
                return true;

            return false;
        }
    }
}
