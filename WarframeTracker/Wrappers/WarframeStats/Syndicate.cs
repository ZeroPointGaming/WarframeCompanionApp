using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/syndicateMissions
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Syndicate
{
    public class Job
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("rewardPool")]
        public List<string> RewardPool;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("enemyLevels")]
        public List<int> EnemyLevels;

        [JsonProperty("standingStages")]
        public List<int> StandingStages;

        [JsonProperty("minMR")]
        public int MinMR;

        [JsonProperty("isVault")]
        public bool? IsVault;

        [JsonProperty("locationTag")]
        public string LocationTag;
    }

    public class Mission
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

        [JsonProperty("syndicate")]
        public string Syndicate;

        [JsonProperty("nodes")]
        public List<string> Nodes;

        [JsonProperty("jobs")]
        public List<Job> Jobs;

        [JsonProperty("eta")]
        public string Eta;
    }


}