using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/nightwave
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Nightwave
{
    public class Params
    {

    }

    public class ActiveChallenge
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

        [JsonProperty("isDaily")]
        public bool IsDaily;

        [JsonProperty("isElite")]
        public bool IsElite;

        [JsonProperty("desc")]
        public string Desc;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("reputation")]
        public int Reputation;
    }

    public class Root
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

        [JsonProperty("season")]
        public int Season;

        [JsonProperty("tag")]
        public string Tag;

        [JsonProperty("phase")]
        public int Phase;

        [JsonProperty("params")]
        public Params Params;

        [JsonProperty("possibleChallenges")]
        public List<object> PossibleChallenges;

        [JsonProperty("activeChallenges")]
        public List<ActiveChallenge> ActiveChallenges;

        [JsonProperty("rewardTypes")]
        public List<string> RewardTypes;
    }


}