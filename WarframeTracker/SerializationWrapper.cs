using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region LocalSaveCode Api
/// <summary>
/// Simple warframe listbox serilization wrapper
/// </summary>
namespace WarframeTracker.SerializationWrappers.Base.Old
{
    public class Item
    {
        public Item(string name, bool isChecked)
        {
            Name = name;
            IsChecked = isChecked;
        }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isChecked")]
        public bool IsChecked { get; set; }
    }

    public class Root
    {
        [JsonProperty("items")]
        public List<Item> Items = new List<Item>();
    }
}

/// <summary>
/// Used for saving api fetched data to local data cache. Prevents overuse of api endpoints.
/// </summary>
namespace WarframeTracker.SerializationWrappers.Base.New
{
    
}
#endregion

#region Official Warframe Api Integration
/// <summary>
/// API String: http://content.warframe.com/PublicExport/index_en.txt.lzma [LZMA] is a 7zip compression algorithm [FUTURE TODO]
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeAPI.Manifests
{
    ///TODO decompress and write methods to integrate warframe mobile api data. [LZMA]
}

/// <summary>
/// API String: http://content.warframe.com/dynamic/worldState.php JSON Response [Events, world state, global news messages]
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeAPI.WorldState
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Id
    {
        [JsonProperty("$oid")]
        public string Oid;
    }

    public class Messages
    {
        [JsonProperty("LanguageCode")]
        public string LanguageCode;

        [JsonProperty("Message")]
        public string Message;
    }

    public class Date2
    {
        [JsonProperty("$numberLong")]
        public string NumberLong;
    }

    public class Dates
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class Event
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Messages")]
        public List<Messages> Messages;

        [JsonProperty("Prop")]
        public string Prop;

        [JsonProperty("Date")]
        public Dates Date;

        [JsonProperty("Priority")]
        public bool Priority;

        [JsonProperty("MobileOnly")]
        public bool MobileOnly;

        [JsonProperty("ImageUrl")]
        public string ImageUrl;

        [JsonProperty("Community")]
        public bool? Community;
    }

    public class Activation
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class Expiry
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class UpgradeId
    {
        [JsonProperty("$oid")]
        public string Oid;
    }

    public class Reward
    {
        [JsonProperty("credits")]
        public int Credits;

        [JsonProperty("xp")]
        public int Xp;

        [JsonProperty("items")]
        public List<string> Items;

        [JsonProperty("countedItems")]
        public List<object> CountedItems;
    }

    public class InterimReward
    {
        [JsonProperty("credits")]
        public int Credits;

        [JsonProperty("xp")]
        public int Xp;

        [JsonProperty("items")]
        public List<string> Items;

        [JsonProperty("countedItems")]
        public List<object> CountedItems;
    }

    public class Goals
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Node")]
        public string Node;

        [JsonProperty("ScoreVar")]
        public string ScoreVar;

        [JsonProperty("ScoreLocTag")]
        public string ScoreLocTag;

        [JsonProperty("Count")]
        public int Count;

        [JsonProperty("HealthPct")]
        public double HealthPct;

        [JsonProperty("Regions")]
        public List<int> Regions;

        [JsonProperty("Desc")]
        public string Desc;

        [JsonProperty("ToolTip")]
        public string ToolTip;

        [JsonProperty("OptionalInMission")]
        public bool OptionalInMission;

        [JsonProperty("Tag")]
        public string Tag;

        [JsonProperty("UpgradeIds")]
        public List<UpgradeId> UpgradeIds;

        [JsonProperty("Personal")]
        public bool Personal;

        [JsonProperty("Community")]
        public bool Community;

        [JsonProperty("Goal")]
        public int Goal;

        [JsonProperty("Reward")]
        public Reward Reward;

        [JsonProperty("InterimGoals")]
        public List<int> InterimGoals;

        [JsonProperty("InterimRewards")]
        public List<InterimReward> InterimRewards;
    }

    public class Variant
    {
        [JsonProperty("missionType")]
        public string MissionType;

        [JsonProperty("modifierType")]
        public string ModifierType;

        [JsonProperty("node")]
        public string Node;

        [JsonProperty("tileset")]
        public string Tileset;
    }

    public class Sorty
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Boss")]
        public string Boss;

        [JsonProperty("Reward")]
        public string Reward;

        [JsonProperty("ExtraDrops")]
        public List<object> ExtraDrops;

        [JsonProperty("Seed")]
        public int Seed;

        [JsonProperty("Variants")]
        public List<Variant> Variants;

        [JsonProperty("Twitter")]
        public bool Twitter;
    }

    public class Job
    {
        [JsonProperty("jobType")]
        public string JobType;

        [JsonProperty("rewards")]
        public string Rewards;

        [JsonProperty("masteryReq")]
        public int MasteryReq;

        [JsonProperty("minEnemyLevel")]
        public int MinEnemyLevel;

        [JsonProperty("maxEnemyLevel")]
        public int MaxEnemyLevel;

        [JsonProperty("xpAmounts")]
        public List<int> XpAmounts;

        [JsonProperty("endless")]
        public bool? Endless;

        [JsonProperty("bonusXpMultiplier")]
        public double? BonusXpMultiplier;

        [JsonProperty("locationTag")]
        public string LocationTag;

        [JsonProperty("isVault")]
        public bool? IsVault;
    }

    public class SyndicateMission
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Tag")]
        public string Tag;

        [JsonProperty("Seed")]
        public int Seed;

        [JsonProperty("Nodes")]
        public List<string> Nodes;

        [JsonProperty("Jobs")]
        public List<Job> Jobs;
    }

    public class ActiveMission
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Region")]
        public int Region;

        [JsonProperty("Seed")]
        public int Seed;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Node")]
        public string Node;

        [JsonProperty("MissionType")]
        public string MissionType;

        [JsonProperty("Modifier")]
        public string Modifier;
    }

    public class ExpiryDate
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class GlobalUpgrade
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("ExpiryDate")]
        public ExpiryDate ExpiryDate;

        [JsonProperty("UpgradeType")]
        public string UpgradeType;

        [JsonProperty("OperationType")]
        public string OperationType;

        [JsonProperty("Value")]
        public int Value;

        [JsonProperty("Nodes")]
        public List<string> Nodes;
    }

    public class StartDate
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class EndDate
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class ExperimentFeatured
    {
        [JsonProperty("ExperimentGroup")]
        public string ExperimentGroup;

        [JsonProperty("FeaturedIndex")]
        public int FeaturedIndex;
    }

    public class FlashSale
    {
        [JsonProperty("TypeName")]
        public string TypeName;

        [JsonProperty("StartDate")]
        public StartDate StartDate;

        [JsonProperty("EndDate")]
        public EndDate EndDate;

        [JsonProperty("Featured")]
        public bool Featured;

        [JsonProperty("Popular")]
        public bool Popular;

        [JsonProperty("ShowInMarket")]
        public bool ShowInMarket;

        [JsonProperty("BannerIndex")]
        public int BannerIndex;

        [JsonProperty("Discount")]
        public int Discount;

        [JsonProperty("RegularOverride")]
        public int RegularOverride;

        [JsonProperty("PremiumOverride")]
        public int PremiumOverride;

        [JsonProperty("BogoBuy")]
        public int BogoBuy;

        [JsonProperty("BogoGet")]
        public int BogoGet;

        [JsonProperty("ExperimentFeatured")]
        public List<ExperimentFeatured> ExperimentFeatured;
    }

    public class ChainID
    {
        [JsonProperty("$oid")]
        public string Oid;
    }

    public class AttackerMissionInfo
    {
        [JsonProperty("seed")]
        public int Seed;

        [JsonProperty("faction")]
        public string Faction;
    }

    public class CountedItem
    {
        [JsonProperty("ItemType")]
        public string ItemType;

        [JsonProperty("ItemCount")]
        public int ItemCount;
    }

    public class DefenderReward
    {
        [JsonProperty("countedItems")]
        public List<CountedItem> CountedItems;
    }

    public class DefenderMissionInfo
    {
        [JsonProperty("seed")]
        public int Seed;

        [JsonProperty("faction")]
        public string Faction;

        [JsonProperty("missionReward")]
        public List<object> MissionReward;
    }

    public class Invasion
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Faction")]
        public string Faction;

        [JsonProperty("DefenderFaction")]
        public string DefenderFaction;

        [JsonProperty("Node")]
        public string Node;

        [JsonProperty("Count")]
        public int Count;

        [JsonProperty("Goal")]
        public int Goal;

        [JsonProperty("LocTag")]
        public string LocTag;

        [JsonProperty("Completed")]
        public bool Completed;

        [JsonProperty("ChainID")]
        public ChainID ChainID;

        [JsonProperty("AttackerReward")]
        public object AttackerReward;

        [JsonProperty("AttackerMissionInfo")]
        public AttackerMissionInfo AttackerMissionInfo;

        [JsonProperty("DefenderReward")]
        public DefenderReward DefenderReward;

        [JsonProperty("DefenderMissionInfo")]
        public DefenderMissionInfo DefenderMissionInfo;

        [JsonProperty("Activation")]
        public Activation Activation;
    }

    public class NodeOverride
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Node")]
        public string Node;

        [JsonProperty("Hide")]
        public bool Hide;

        [JsonProperty("Seed")]
        public int? Seed;

        [JsonProperty("LevelOverride")]
        public string LevelOverride;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Faction")]
        public string Faction;

        [JsonProperty("CustomNpcEncounters")]
        public List<string> CustomNpcEncounters;

        [JsonProperty("EnemySpec")]
        public string EnemySpec;

        [JsonProperty("ExtraEnemySpec")]
        public string ExtraEnemySpec;
    }

    public class VoidTrader
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Character")]
        public string Character;

        [JsonProperty("Node")]
        public string Node;
    }

    public class VoidStorm
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Node")]
        public string Node;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("ActiveMissionTier")]
        public string ActiveMissionTier;
    }

    public class PrimeAccessAvailability
    {
        [JsonProperty("State")]
        public string State;
    }

    public class DailyDeal
    {
        [JsonProperty("StoreItem")]
        public string StoreItem;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Discount")]
        public int Discount;

        [JsonProperty("OriginalPrice")]
        public int OriginalPrice;

        [JsonProperty("SalePrice")]
        public int SalePrice;

        [JsonProperty("AmountTotal")]
        public int AmountTotal;

        [JsonProperty("AmountSold")]
        public int AmountSold;
    }

    public class LibraryInfo
    {
        [JsonProperty("LastCompletedTargetType")]
        public string LastCompletedTargetType;
    }

    public class StartDate2
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class EndDate2
    {
        [JsonProperty("$date")]
        public Dates Date;
    }

    public class Param
    {
        [JsonProperty("n")]
        public string N;

        [JsonProperty("v")]
        public int V;
    }

    public class SubChallenge
    {
        [JsonProperty("$oid")]
        public string Oid;
    }

    public class PVPChallengeInstance
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("challengeTypeRefID")]
        public string ChallengeTypeRefID;

        [JsonProperty("startDate")]
        public StartDate StartDate;

        [JsonProperty("endDate")]
        public EndDate EndDate;

        [JsonProperty("params")]
        public List<Param> Params;

        [JsonProperty("isGenerated")]
        public bool IsGenerated;

        [JsonProperty("PVPMode")]
        public string PVPMode;

        [JsonProperty("subChallenges")]
        public List<SubChallenge> SubChallenges;

        [JsonProperty("Category")]
        public string Category;
    }

    public class AllianceId
    {
        [JsonProperty("$oid")]
        public string Oid;
    }

    public class FeaturedGuild
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Tier")]
        public int Tier;

        [JsonProperty("AllianceId")]
        public AllianceId AllianceId;
    }

    public class ActiveChallenge
    {
        [JsonProperty("_id")]
        public Id Id;

        [JsonProperty("Daily")]
        public bool Daily;

        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("Challenge")]
        public string Challenge;
    }

    public class SeasonInfo
    {
        [JsonProperty("Activation")]
        public Activation Activation;

        [JsonProperty("Expiry")]
        public Expiry Expiry;

        [JsonProperty("AffiliationTag")]
        public string AffiliationTag;

        [JsonProperty("Season")]
        public int Season;

        [JsonProperty("Phase")]
        public int Phase;

        [JsonProperty("Params")]
        public string Params;

        [JsonProperty("ActiveChallenges")]
        public List<ActiveChallenge> ActiveChallenges;
    }

    public class Root
    {
        [JsonProperty("WorldSeed")]
        public string WorldSeed;

        [JsonProperty("Version")]
        public int Version;

        [JsonProperty("MobileVersion")]
        public string MobileVersion;

        [JsonProperty("BuildLabel")]
        public string BuildLabel;

        [JsonProperty("Time")]
        public int Time;

        [JsonProperty("Events")]
        public List<Event> Events;

        [JsonProperty("Goals")]
        public List<Goals> Goals;

        [JsonProperty("Alerts")]
        public List<object> Alerts;

        [JsonProperty("Sorties")]
        public List<Sorty> Sorties;

        [JsonProperty("SyndicateMissions")]
        public List<SyndicateMission> SyndicateMissions;

        [JsonProperty("ActiveMissions")]
        public List<ActiveMission> ActiveMissions;

        [JsonProperty("GlobalUpgrades")]
        public List<GlobalUpgrade> GlobalUpgrades;

        [JsonProperty("FlashSales")]
        public List<FlashSale> FlashSales;

        [JsonProperty("Invasions")]
        public List<Invasion> Invasions;

        [JsonProperty("HubEvents")]
        public List<object> HubEvents;

        [JsonProperty("NodeOverrides")]
        public List<NodeOverride> NodeOverrides;

        [JsonProperty("VoidTraders")]
        public List<VoidTrader> VoidTraders;

        [JsonProperty("VoidStorms")]
        public List<VoidStorm> VoidStorms;

        [JsonProperty("PrimeAccessAvailability")]
        public PrimeAccessAvailability PrimeAccessAvailability;

        [JsonProperty("PrimeVaultAvailabilities")]
        public List<bool> PrimeVaultAvailabilities;

        [JsonProperty("DailyDeals")]
        public List<DailyDeal> DailyDeals;

        [JsonProperty("LibraryInfo")]
        public LibraryInfo LibraryInfo;

        [JsonProperty("PVPChallengeInstances")]
        public List<PVPChallengeInstance> PVPChallengeInstances;

        [JsonProperty("PersistentEnemies")]
        public List<object> PersistentEnemies;

        [JsonProperty("PVPAlternativeModes")]
        public List<object> PVPAlternativeModes;

        [JsonProperty("PVPActiveTournaments")]
        public List<object> PVPActiveTournaments;

        [JsonProperty("ProjectPct")]
        public List<double> ProjectPct;

        [JsonProperty("ConstructionProjects")]
        public List<object> ConstructionProjects;

        [JsonProperty("TwitchPromos")]
        public List<object> TwitchPromos;

        [JsonProperty("ExperimentRecommended")]
        public List<object> ExperimentRecommended;

        [JsonProperty("ForceLogoutVersion")]
        public int ForceLogoutVersion;

        [JsonProperty("FeaturedGuilds")]
        public List<FeaturedGuild> FeaturedGuilds;

        [JsonProperty("SeasonInfo")]
        public SeasonInfo SeasonInfo;

        [JsonProperty("Tmp")]
        public string Tmp;
    }


}
#endregion

/// <summary>
/// API String: http://www.oggtechnologies.com/api/ducatsorplat/v2/MainItemData.json
/// API Return: Information aboult vaulted items/warframes etc
/// </summary>
namespace WarframeTracker.SerializationWrappers.OGTech.ValutedItemData
{
    public class Metadata
    {
        [JsonProperty("code")]
        public int Code;
    }

    public class Relic
    {
        [JsonProperty("Vaulted")]
        public bool Vaulted;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("Rarity")]
        public string Rarity;
    }

    public class Component
    {
        [JsonProperty("Relics")]
        public List<Relic> Relics;

        [JsonProperty("Ducats")]
        public int Ducats;

        [JsonProperty("Name")]
        public string Name;
    }

    public class Data
    {
        [JsonProperty("Vaulted")]
        public bool Vaulted;

        [JsonProperty("Name")]
        public string Name;

        [JsonProperty("ReleaseDate")]
        public string ReleaseDate;

        [JsonProperty("EstimatedVaultedDate")]
        public string EstimatedVaultedDate;

        [JsonProperty("VaultedDate")]
        public string VaultedDate;

        [JsonProperty("Components")]
        public List<Component> Components;
    }

    public class Root
    {
        [JsonProperty("metadata")]
        public Metadata Metadata;

        [JsonProperty("data")]
        public List<Data> Data;
    }
}