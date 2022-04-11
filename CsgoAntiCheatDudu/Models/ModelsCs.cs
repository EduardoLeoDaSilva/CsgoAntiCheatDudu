using Newtonsoft.Json;

namespace CsgoAntiCheatDudu.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Provider
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("appid")]
        public int Appid { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("steamid")]
        public string Steamid { get; set; }

        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }
    }

    public class Round
    {
        [JsonProperty("phase")]
        public string Phase { get; set; }

        [JsonProperty("bomb")]
        public string Bomb { get; set; }
    }

    public class TeamCt
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("consecutive_round_losses")]
        public int ConsecutiveRoundLosses { get; set; }

        [JsonProperty("timeouts_remaining")]
        public int TimeoutsRemaining { get; set; }

        [JsonProperty("matches_won_this_series")]
        public int MatchesWonThisSeries { get; set; }
    }

    public class TeamT
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("consecutive_round_losses")]
        public int ConsecutiveRoundLosses { get; set; }

        [JsonProperty("timeouts_remaining")]
        public int TimeoutsRemaining { get; set; }

        [JsonProperty("matches_won_this_series")]
        public int MatchesWonThisSeries { get; set; }
    }

    public class Map
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phase")]
        public string Phase { get; set; }

        [JsonProperty("round")]
        public int Round { get; set; }

        [JsonProperty("team_ct")]
        public TeamCt TeamCt { get; set; }

        [JsonProperty("team_t")]
        public TeamT TeamT { get; set; }

        [JsonProperty("num_matches_to_win_series")]
        public int NumMatchesToWinSeries { get; set; }

        [JsonProperty("current_spectators")]
        public int CurrentSpectators { get; set; }

        [JsonProperty("souvenirs_total")]
        public int SouvenirsTotal { get; set; }
    }

    public class MatchStats
    {
        [JsonProperty("kills")]
        public int Kills { get; set; }

        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("deaths")]
        public int Deaths { get; set; }

        [JsonProperty("mvps")]
        public int Mvps { get; set; }

        [JsonProperty("score")]
        public int Score { get; set; }
    }

    public class Weapon0
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paintkit")]
        public string Paintkit { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class Weapon1
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paintkit")]
        public string Paintkit { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ammo_clip")]
        public int AmmoClip { get; set; }

        [JsonProperty("ammo_clip_max")]
        public int AmmoClipMax { get; set; }

        [JsonProperty("ammo_reserve")]
        public int AmmoReserve { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class Weapons
    {
        [JsonProperty("weapon_0")]
        public Weapon0 Weapon0 { get; set; }

        [JsonProperty("weapon_1")]
        public Weapon1 Weapon1 { get; set; }
    }

    public class State
    {
        [JsonProperty("health")]
        public int Health { get; set; }

        [JsonProperty("armor")]
        public int Armor { get; set; }

        [JsonProperty("helmet")]
        public bool Helmet { get; set; }

        [JsonProperty("flashed")]
        public int Flashed { get; set; }

        [JsonProperty("smoked")]
        public int Smoked { get; set; }

        [JsonProperty("burning")]
        public int Burning { get; set; }

        [JsonProperty("money")]
        public int Money { get; set; }

        [JsonProperty("round_kills")]
        public int RoundKills { get; set; }

        [JsonProperty("round_killhs")]
        public int RoundKillhs { get; set; }

        [JsonProperty("equip_value")]
        public int EquipValue { get; set; }
    }

    public class Player
    {
        [JsonProperty("match_stats")]
        public MatchStats MatchStats { get; set; }

        [JsonProperty("weapons")]
        public Weapons Weapons { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("steamid")]
        public string Steamid { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("observer_slot")]
        public int ObserverSlot { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("activity")]
        public string Activity { get; set; }
    }

    public class Auth
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public class BaseModel
    {
        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        [JsonProperty("round")]
        public Round Round { get; set; }

        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }
    }


}
