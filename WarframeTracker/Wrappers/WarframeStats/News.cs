using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/news
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.News
{
    public class Events
    {
        public List<Root> NewsEvents;
    }

    public class Translations
    {
        [JsonProperty("en")]
        public string En;

        [JsonProperty("fr")]
        public string Fr;

        [JsonProperty("it")]
        public string It;

        [JsonProperty("de")]
        public string De;

        [JsonProperty("es")]
        public string Es;

        [JsonProperty("pt")]
        public string Pt;

        [JsonProperty("ru")]
        public string Ru;

        [JsonProperty("pl")]
        public string Pl;

        [JsonProperty("tr")]
        public string Tr;

        [JsonProperty("ja")]
        public string Ja;

        [JsonProperty("zh")]
        public string Zh;

        [JsonProperty("ko")]
        public string Ko;

        [JsonProperty("tc")]
        public string Tc;
    }

    public class Root
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("message")]
        public string Message;

        [JsonProperty("link")]
        public string Link;

        [JsonProperty("imageLink")]
        public string ImageLink;

        [JsonProperty("priority")]
        public bool Priority;

        [JsonProperty("date")]
        public DateTime Date;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("update")]
        public bool Update;

        [JsonProperty("primeAccess")]
        public bool PrimeAccess;

        [JsonProperty("stream")]
        public bool Stream;

        [JsonProperty("translations")]
        public Translations Translations;

        [JsonProperty("asString")]
        public string AsString;
    }


}