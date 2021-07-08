using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframestat.us/{platform}
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.WarframeStats.WorldSpace
{
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

    public class News
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

    public class Reward
    {
        [JsonProperty("items")]
        public List<string> Items;

        [JsonProperty("countedItems")]
        public List<object> CountedItems;

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

    public class Reward2
    {
        [JsonProperty("items")]
        public List<string> Items;

        [JsonProperty("countedItems")]
        public List<object> CountedItems;

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

    public class Message
    {
    }

    public class InterimStep
    {
        [JsonProperty("goal")]
        public int Goal;

        [JsonProperty("reward")]
        public Reward Reward;

        [JsonProperty("message")]
        public Message Message;
    }

    public class Metadata
    {
    }

    public class NextAlt
    {
        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("activation")]
        public DateTime Activation;
    }

    public class Event
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

        [JsonProperty("maximumScore")]
        public object MaximumScore;

        [JsonProperty("currentScore")]
        public object CurrentScore;

        [JsonProperty("smallInterval")]
        public object SmallInterval;

        [JsonProperty("largeInterval")]
        public object LargeInterval;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("tooltip")]
        public string Tooltip;

        [JsonProperty("node")]
        public string Node;

        [JsonProperty("concurrentNodes")]
        public List<object> ConcurrentNodes;

        [JsonProperty("scoreLocTag")]
        public string ScoreLocTag;

        [JsonProperty("rewards")]
        public List<Reward> Rewards;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("health")]
        public float Health;

        [JsonProperty("interimSteps")]
        public List<InterimStep> InterimSteps;

        [JsonProperty("progressSteps")]
        public List<object> ProgressSteps;

        [JsonProperty("isPersonal")]
        public bool IsPersonal;

        [JsonProperty("isCommunity")]
        public bool IsCommunity;

        [JsonProperty("regionDrops")]
        public List<object> RegionDrops;

        [JsonProperty("archwingDrops")]
        public List<object> ArchwingDrops;

        [JsonProperty("asString")]
        public string AsString;

        [JsonProperty("metadata")]
        public Metadata Metadata;

        [JsonProperty("completionBonuses")]
        public List<object> CompletionBonuses;

        [JsonProperty("scoreVar")]
        public string ScoreVar;

        [JsonProperty("altExpiry")]
        public DateTime AltExpiry;

        [JsonProperty("altActivation")]
        public DateTime AltActivation;

        [JsonProperty("nextAlt")]
        public NextAlt NextAlt;
    }

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

    public class SyndicateMission
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

    public class Fissure
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

    public class GlobalUpgrade
    {
        [JsonProperty("start")]
        public DateTime Start;

        [JsonProperty("end")]
        public DateTime End;

        [JsonProperty("upgrade")]
        public string Upgrade;

        [JsonProperty("operation")]
        public string Operation;

        [JsonProperty("operationSymbol")]
        public string OperationSymbol;

        [JsonProperty("upgradeOperationValue")]
        public int UpgradeOperationValue;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("desc")]
        public string Desc;
    }

    public class FlashSale
    {
        [JsonProperty("item")]
        public string Item;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("discount")]
        public int Discount;

        [JsonProperty("regularOverride")]
        public int RegularOverride;

        [JsonProperty("premiumOverride")]
        public int PremiumOverride;

        [JsonProperty("isShownInMarket")]
        public bool IsShownInMarket;

        [JsonProperty("isFeatured")]
        public bool IsFeatured;

        [JsonProperty("isPopular")]
        public bool IsPopular;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("eta")]
        public string Eta;
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

    public class VoidTrader
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

    public class DailyDeal
    {
        [JsonProperty("item")]
        public string Item;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("originalPrice")]
        public int OriginalPrice;

        [JsonProperty("salePrice")]
        public int SalePrice;

        [JsonProperty("total")]
        public int Total;

        [JsonProperty("sold")]
        public int Sold;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("discount")]
        public int Discount;
    }

    public class Simaris
    {
        [JsonProperty("target")]
        public string Target;

        [JsonProperty("isTargetActive")]
        public bool IsTargetActive;

        [JsonProperty("asString")]
        public string AsString;
    }

    public class ConclaveChallenge
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("amount")]
        public int Amount;

        [JsonProperty("mode")]
        public string Mode;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("eta")]
        public string Eta;

        [JsonProperty("expired")]
        public bool Expired;

        [JsonProperty("daily")]
        public bool Daily;

        [JsonProperty("rootChallenge")]
        public bool RootChallenge;

        [JsonProperty("endString")]
        public string EndString;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("standing")]
        public int Standing;

        [JsonProperty("asString")]
        public string AsString;
    }

    public class EarthCycle
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

    public class CetusCycle
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

        [JsonProperty("isCetus")]
        public bool IsCetus;

        [JsonProperty("shortString")]
        public string ShortString;
    }

    public class CambionCycle
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("active")]
        public string Active;
    }

    public class ConstructionProgress
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("fomorianProgress")]
        public string FomorianProgress;

        [JsonProperty("razorbackProgress")]
        public string RazorbackProgress;

        [JsonProperty("unknownProgress")]
        public string UnknownProgress;
    }

    public class VallisCycle
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("isWarm")]
        public bool IsWarm;

        [JsonProperty("state")]
        public string State;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("timeLeft")]
        public string TimeLeft;

        [JsonProperty("shortString")]
        public string ShortString;
    }

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

    public class Nightwave
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

    public class Arbitration
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

    public class Mission
    {
        [JsonProperty("node")]
        public string Node;

        [JsonProperty("faction")]
        public string Faction;

        [JsonProperty("type")]
        public string Type;
    }

    public class SentientOutposts
    {
        [JsonProperty("mission")]
        public Mission Mission;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("active")]
        public bool Active;

        [JsonProperty("id")]
        public string Id;
    }

    public class CurrentReward
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("cost")]
        public int Cost;
    }

    public class Rotation
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("cost")]
        public int Cost;
    }

    public class SteelPath
    {
        [JsonProperty("currentReward")]
        public CurrentReward CurrentReward;

        [JsonProperty("activation")]
        public DateTime Activation;

        [JsonProperty("expiry")]
        public DateTime Expiry;

        [JsonProperty("remaining")]
        public string Remaining;

        [JsonProperty("rotation")]
        public List<Rotation> Rotation;
    }

    public class Root
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp;

        [JsonProperty("news")]
        public List<News> News;

        [JsonProperty("events")]
        public List<Event> Events;

        [JsonProperty("alerts")]
        public List<object> Alerts;

        [JsonProperty("sortie")]
        public Sortie Sortie;

        [JsonProperty("syndicateMissions")]
        public List<SyndicateMission> SyndicateMissions;

        [JsonProperty("fissures")]
        public List<Fissure> Fissures;

        [JsonProperty("globalUpgrades")]
        public List<GlobalUpgrade> GlobalUpgrades;

        [JsonProperty("flashSales")]
        public List<FlashSale> FlashSales;

        [JsonProperty("invasions")]
        public List<Invasion> Invasions;

        [JsonProperty("darkSectors")]
        public List<object> DarkSectors;

        [JsonProperty("voidTrader")]
        public VoidTrader VoidTrader;

        [JsonProperty("dailyDeals")]
        public List<DailyDeal> DailyDeals;

        [JsonProperty("simaris")]
        public Simaris Simaris;

        [JsonProperty("conclaveChallenges")]
        public List<ConclaveChallenge> ConclaveChallenges;

        [JsonProperty("persistentEnemies")]
        public List<object> PersistentEnemies;

        [JsonProperty("earthCycle")]
        public EarthCycle EarthCycle;

        [JsonProperty("cetusCycle")]
        public CetusCycle CetusCycle;

        [JsonProperty("cambionCycle")]
        public CambionCycle CambionCycle;

        [JsonProperty("weeklyChallenges")]
        public List<object> WeeklyChallenges;

        [JsonProperty("constructionProgress")]
        public ConstructionProgress ConstructionProgress;

        [JsonProperty("vallisCycle")]
        public VallisCycle VallisCycle;

        [JsonProperty("nightwave")]
        public Nightwave Nightwave;

        [JsonProperty("kuva")]
        public List<object> Kuva;

        [JsonProperty("arbitration")]
        public Arbitration Arbitration;

        [JsonProperty("sentientOutposts")]
        public SentientOutposts SentientOutposts;

        [JsonProperty("steelPath")]
        public SteelPath SteelPath;
    }


}