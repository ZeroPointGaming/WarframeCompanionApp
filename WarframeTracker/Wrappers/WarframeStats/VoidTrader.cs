using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/voidTrader
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Baro
{
    public class Data
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

        [JsonProperty("character")]
        public string Character;

        [JsonProperty("location")]
        public string Location;

        [JsonProperty("inventory")]
        public List<object> Inventory;

        [JsonProperty("psId")]
        public string PsId;

        [JsonProperty("endString")]
        public string EndString;
    }
}