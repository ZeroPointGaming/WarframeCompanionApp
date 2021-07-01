using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}/invasions
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.Invasions
{
    public class Invasions
    {
        public List<Invasion> ActiveInvasions;
    }

    public class CountedItem
    {
        [JsonProperty("count")]
        public int Count;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("key")]
        public string Key;
    }

    public class AttackerReward
    {
        [JsonProperty("items")]
        public List<object> Items;

        [JsonProperty("countedItems")]
        public List<CountedItem> CountedItems;

        [JsonProperty("credits")]
        public int Credits;

        [JsonProperty("asString")]
        public string AsString;

        [JsonProperty("itemString")]
        public string ItemString;

        [JsonProperty("thumbnail")]
        public string Thumbnail;

        [JsonProperty("color")]
        public int Color;
    }

    public class Reward
    {
        [JsonProperty("items")]
        public List<object> Items;

        [JsonProperty("countedItems")]
        public List<CountedItem> CountedItems;

        [JsonProperty("credits")]
        public int Credits;

        [JsonProperty("asString")]
        public string AsString;

        [JsonProperty("itemString")]
        public string ItemString;

        [JsonProperty("thumbnail")]
        public string Thumbnail;

        [JsonProperty("color")]
        public int Color;
    }

    public class Attacker
    {
        [JsonProperty("reward")]
        public Reward Reward;

        [JsonProperty("faction")]
        public string Faction;

        [JsonProperty("factionKey")]
        public string FactionKey;
    }

    public class DefenderReward
    {
        [JsonProperty("items")]
        public List<object> Items;

        [JsonProperty("countedItems")]
        public List<CountedItem> CountedItems;

        [JsonProperty("credits")]
        public int Credits;

        [JsonProperty("asString")]
        public string AsString;

        [JsonProperty("itemString")]
        public string ItemString;

        [JsonProperty("thumbnail")]
        public string Thumbnail;

        [JsonProperty("color")]
        public int Color;
    }

    public class Defender
    {
        [JsonProperty("reward")]
        public Reward Reward;

        [JsonProperty("faction")]
        public string Faction;

        [JsonProperty("factionKey")]
        public string FactionKey;
    }

    public class Invasion
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("startString")]
        public string StartString;

        [JsonProperty("node")]
        public string Node;

        [JsonProperty("nodeKey")]
        public string NodeKey;

        [JsonProperty("desc")]
        public string Desc;

        [JsonProperty("attackerReward")]
        public AttackerReward AttackerReward;

        [JsonProperty("attackingFaction")]
        public string AttackingFaction;

        [JsonProperty("attacker")]
        public Attacker Attacker;

        [JsonProperty("defenderReward")]
        public DefenderReward DefenderReward;

        [JsonProperty("defendingFaction")]
        public string DefendingFaction;

        [JsonProperty("defender")]
        public Defender Defender;

        [JsonProperty("vsInfestation")]
        public bool VsInfestation;

        [JsonProperty("count")]
        public int Count;

        [JsonProperty("requiredRuns")]
        public int RequiredRuns;

        [JsonProperty("completion")]
        public double Completion;

        [JsonProperty("completed")]
        public bool Completed;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("rewardTypes")]
        public List<string> RewardTypes;
    }


}