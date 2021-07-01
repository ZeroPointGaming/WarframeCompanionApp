using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/fissures
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Fissures
{
    public class FissureEvent
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

        [JsonProperty("node")]
        public string Node;

        [JsonProperty("missionType")]
        public string MissionType;

        [JsonProperty("missionKey")]
        public string MissionKey;

        [JsonProperty("enemy")]
        public string Enemy;

        [JsonProperty("enemyKey")]
        public string EnemyKey;

        [JsonProperty("nodeKey")]
        public string NodeKey;

        [JsonProperty("tier")]
        public string Tier;

        [JsonProperty("tierNum")]
        public int TierNum;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("isStorm")]
        public bool IsStorm;
    }
}