using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/earthCycle
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Earth
{
    public class Data
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("isDay")]
        public bool IsDay;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("timeLeft")]
        public string TimeLeft;
    }
}