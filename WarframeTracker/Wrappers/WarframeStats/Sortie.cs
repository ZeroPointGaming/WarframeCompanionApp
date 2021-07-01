using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/sortie
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Sortie
{
    public class Variant
    {
        [JsonProperty("boss")]
        public string Boss;

        [JsonProperty("planet")]
        public string Planet;

        [JsonProperty("missionType")]
        public string MissionType;

        [JsonProperty("modifier")]
        public string Modifier;

        [JsonProperty("modifierDescription")]
        public string ModifierDescription;

        [JsonProperty("node")]
        public string Node;
    }

    public class Sortie
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("startString")]
        public string StartString;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("active")]
        public bool Active;

        [JsonProperty("rewardPool")]
        public string RewardPool;

        [JsonProperty("variants")]
        public List<Variant> Variants;

        [JsonProperty("boss")]
        public string Boss;

        [JsonProperty("faction")]
        public string Faction;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("eta")]
        public string Eta;
    }
}