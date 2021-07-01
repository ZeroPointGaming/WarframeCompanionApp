using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/arbitration 
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Arbitration
{
    public class ArbitrationMission
    {
        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("enemy")]
        public string Enemy;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("archwing")]
        public bool Archwing;

        [JsonProperty("sharkwing")]
        public bool Sharkwing;

        [JsonProperty("node")]
        public string Node;
    }

}