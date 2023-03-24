using Newtonsoft.Json;

namespace CsgoAntiCheatDudu.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
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

        [JsonProperty("burning")]
        public int Burning { get; set; }

        [JsonProperty("money")]
        public int Money { get; set; }

        [JsonProperty("round_kills")]
        public int RoundKills { get; set; }

        [JsonProperty("round_killhs")]
        public int RoundKillhs { get; set; }

        [JsonProperty("round_totaldmg")]
        public int RoundTotaldmg { get; set; }

        [JsonProperty("equip_value")]
        public int EquipValue { get; set; }
    }

    public class Weapons
    {
        [JsonProperty("weapon_0")]
        public Weapon0 Weapon0 { get; set; }

        [JsonProperty("weapon_1")]
        public Weapon1 Weapon1 { get; set; }

        [JsonProperty("weapon_2")]
        public Weapon2 Weapon2 { get; set; }

        [JsonProperty("weapon_3")]
        public Weapon3 Weapon3 { get; set; }

        [JsonProperty("weapon_4")]
        public Weapon4 Weapon4 { get; set; }

        [JsonProperty("weapon_5")]
        public Weapon5 Weapon5 { get; set; }
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

    public class Weapon2
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


    public class Weapon3
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paintkit")]
        public string Paintkit { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ammo_reserve")]
        public int AmmoReserve { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }


    public class Weapon4
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paintkit")]
        public string Paintkit { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ammo_reserve")]
        public int AmmoReserve { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class Weapon5
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("paintkit")]
        public string Paintkit { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("ammo_reserve")]
        public int AmmoReserve { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class PlayerCs
    {
        public string SteamId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("observer_slot")]
        public int ObserverSlot { get; set; }

        [JsonProperty("team")]
        public string Team { get; set; }

        [JsonProperty("match_stats")]
        public MatchStats MatchStats { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("forward")]
        public string Forward { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("weapons")]
        public Weapons Weapons { get; set; }
    }


    public class Auth
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }

    public class Root
    {
        [JsonProperty("map")]
        public Map Map { get; set; }

        [JsonProperty("allplayers")]
        public dynamic Allplayers { get; set; }

        [JsonProperty("auth")]
        public Auth Auth { get; set; }
    }
}
