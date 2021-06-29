using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Warframe.Market Api Integration
/// <summary>
/// API String: https://api.warframe.market/v1/items/{url_name}
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeMarket.ItemInfo
{
    public class Drop
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("link")]
        public string Link;
    }

    #region LanguageSubclasse
    public class En
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Ru
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Ko
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Fr
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Sv
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class De
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class ZhHant
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class ZhHans
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Pt
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Es
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }

    public class Pl
    {
        [JsonProperty("item_name")]
        public string ItemName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("wiki_link")]
        public string WikiLink;

        [JsonProperty("drop")]
        public List<Drop> Drop;
    }
    #endregion

    public class ItemsInSet
    {
        [JsonProperty("sub_icon")]
        public string SubIcon;

        [JsonProperty("mastery_level")]
        public int MasteryLevel;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("thumb")]
        public string Thumb;

        [JsonProperty("icon")]
        public string Icon;

        [JsonProperty("icon_format")]
        public string IconFormat;

        [JsonProperty("url_name")]
        public string UrlName;

        [JsonProperty("ducats")]
        public int Ducats;

        [JsonProperty("tags")]
        public List<string> Tags;

        [JsonProperty("trading_tax")]
        public int TradingTax;

        [JsonProperty("set_root")]
        public bool SetRoot;

        [JsonProperty("en")]
        public En En;

        [JsonProperty("ru")]
        public Ru Ru;

        [JsonProperty("ko")]
        public Ko Ko;

        [JsonProperty("fr")]
        public Fr Fr;

        [JsonProperty("sv")]
        public Sv Sv;

        [JsonProperty("de")]
        public De De;

        [JsonProperty("zh-hant")]
        public ZhHant ZhHant;

        [JsonProperty("zh-hans")]
        public ZhHans ZhHans;

        [JsonProperty("pt")]
        public Pt Pt;

        [JsonProperty("es")]
        public Es Es;

        [JsonProperty("pl")]
        public Pl Pl;
    }

    public class Item
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("items_in_set")]
        public List<ItemsInSet> ItemsInSet;
    }

    public class Payload
    {
        [JsonProperty("item")]
        public Item Item;
    }

    public class Root
    {
        [JsonProperty("payload")]
        public Payload Payload;
    }


}

/// <summary>
/// API String: https://api.warframe.market/v1/items/{url_name}/orders
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeMarket.ItemOrders
{
    public class User
    {
        [JsonProperty("reputation")]
        public int Reputation;

        [JsonProperty("region")]
        public string Region;

        [JsonProperty("last_seen")]
        public DateTime LastSeen;

        [JsonProperty("ingame_name")]
        public string IngameName;

        [JsonProperty("avatar")]
        public string Avatar;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("id")]
        public string Id;
    }

    public class Order
    {
        [JsonProperty("platform")]
        public string Platform;

        [JsonProperty("creation_date")]
        public DateTime CreationDate;

        [JsonProperty("visible")]
        public bool Visible;

        [JsonProperty("region")]
        public string Region;

        [JsonProperty("platinum")]
        public double Platinum;

        [JsonProperty("quantity")]
        public int Quantity;

        [JsonProperty("last_update")]
        public DateTime LastUpdate;

        [JsonProperty("order_type")]
        public string OrderType;

        [JsonProperty("user")]
        public User User;

        [JsonProperty("id")]
        public string Id;
    }

    public class Payload
    {
        [JsonProperty("orders")]
        public List<Order> Orders;
    }

    public class Root
    {
        [JsonProperty("payload")]
        public Payload Payload;
    }

}

/// <summary>
/// API String: https://api.warframe.market/v1/items
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeMarket.GetAllItems
{
    public class Item
    {
        [JsonProperty("url_name")]
        public string UrlName;

        [JsonProperty("thumb")]
        public string Thumb;

        [JsonProperty("id")]
        public string Id;

        [JsonProperty("item_name")]
        public string ItemName;
    }

    public class Payload
    {
        [JsonProperty("items")]
        public List<Item> Items;
    }

    public class Root
    {
        [JsonProperty("payload")]
        public Payload Payload;
    }


}

/// <summary>
/// API String: https://api.warframe.market/v1/auctions/search?type=riven&weapon_url_name={url_name}
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeMarket.RivenGetAuctions
{
    public class Attribute
    {
        [JsonProperty("positive")]
        public bool Positive;

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("url_name")]
        public string UrlName;
    }

    public class Item
    {
        [JsonProperty("mastery_level")]
        public int MasteryLevel;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("mod_rank")]
        public int ModRank;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("polarity")]
        public string Polarity;

        [JsonProperty("re_rolls")]
        public int ReRolls;

        [JsonProperty("weapon_url_name")]
        public string WeaponUrlName;

        [JsonProperty("attributes")]
        public List<Attribute> Attributes;
    }

    public class Owner
    {
        [JsonProperty("reputation")]
        public int Reputation;

        [JsonProperty("region")]
        public string Region;

        [JsonProperty("last_seen")]
        public DateTime LastSeen;

        [JsonProperty("ingame_name")]
        public string IngameName;

        [JsonProperty("avatar")]
        public string Avatar;

        [JsonProperty("status")]
        public string Status;

        [JsonProperty("id")]
        public string Id;
    }

    public class Auction
    {
        [JsonProperty("starting_price")]
        public int StartingPrice;

        [JsonProperty("private")]
        public bool Private;

        [JsonProperty("note")]
        public string Note;

        [JsonProperty("minimal_reputation")]
        public int MinimalReputation;

        [JsonProperty("visible")]
        public bool Visible;

        [JsonProperty("item")]
        public Item Item;

        [JsonProperty("buyout_price")]
        public int? BuyoutPrice;

        [JsonProperty("owner")]
        public Owner Owner;

        [JsonProperty("platform")]
        public string Platform;

        [JsonProperty("closed")]
        public bool Closed;

        [JsonProperty("top_bid")]
        public int? TopBid;

        [JsonProperty("winner")]
        public object Winner;

        [JsonProperty("is_marked_for")]
        public object IsMarkedFor;

        [JsonProperty("marked_operation_at")]
        public object MarkedOperationAt;

        [JsonProperty("created")]
        public DateTime Created;

        [JsonProperty("updated")]
        public DateTime Updated;

        [JsonProperty("note_raw")]
        public string NoteRaw;

        [JsonProperty("is_direct_sell")]
        public bool IsDirectSell;

        [JsonProperty("id")]
        public string Id;
    }

    public class Payload
    {
        [JsonProperty("auctions")]
        public List<Auction> Auctions;
    }

    public class Root
    {
        [JsonProperty("payload")]
        public Payload Payload;
    }
}
#endregion

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

#region Official Warframe Aapi Integration
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

/// <summary>
/// Read Warframes.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeAPI.Items.Warframes
{
    public class Ability
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;
    }

    public class Drop
    {
        [JsonProperty("location")]
        public string Location;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("rarity")]
        public string Rarity;
    }

    public class Component
    {
        [JsonProperty("uniqueName")]
        public string UniqueName;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("itemCount")]
        public int ItemCount;

        [JsonProperty("imageName")]
        public string ImageName;

        [JsonProperty("tradable")]
        public bool Tradable;

        [JsonProperty("drops")]
        public List<Drop> Drops;

        [JsonProperty("primeSellingPrice")]
        public int? PrimeSellingPrice;

        [JsonProperty("ducats")]
        public int? Ducats;
    }

    public class Patchlog
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("date")]
        public DateTime Date;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("additions")]
        public string Additions;

        [JsonProperty("changes")]
        public string Changes;

        [JsonProperty("fixes")]
        public string Fixes;

        [JsonProperty("imgUrl")]
        public string ImgUrl;
    }

    public class Root
    {
        [JsonProperty("uniqueName")]
        public string UniqueName;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("health")]
        public int Health;

        [JsonProperty("shield")]
        public int Shield;

        [JsonProperty("armor")]
        public int Armor;

        [JsonProperty("stamina")]
        public int Stamina;

        [JsonProperty("power")]
        public int Power;

        [JsonProperty("masteryReq")]
        public int MasteryReq;

        [JsonProperty("sprintSpeed")]
        public double SprintSpeed;

        [JsonProperty("passiveDescription")]
        public string PassiveDescription;

        [JsonProperty("abilities")]
        public List<Ability> Abilities;

        [JsonProperty("productCategory")]
        public string ProductCategory;

        [JsonProperty("buildPrice")]
        public int BuildPrice;

        [JsonProperty("buildTime")]
        public int BuildTime;

        [JsonProperty("skipBuildTimePrice")]
        public int SkipBuildTimePrice;

        [JsonProperty("buildQuantity")]
        public int BuildQuantity;

        [JsonProperty("consumeOnBuild")]
        public bool ConsumeOnBuild;

        [JsonProperty("components")]
        public List<Component> Components;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("imageName")]
        public string ImageName;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("tradable")]
        public bool Tradable;

        [JsonProperty("patchlogs")]
        public List<Patchlog> Patchlogs;

        [JsonProperty("aura")]
        public string Aura;

        [JsonProperty("conclave")]
        public bool Conclave;

        [JsonProperty("color")]
        public int Color;

        [JsonProperty("introduced")]
        public string Introduced;

        [JsonProperty("polarities")]
        public List<string> Polarities;

        [JsonProperty("sex")]
        public string Sex;

        [JsonProperty("sprint")]
        public double Sprint;

        [JsonProperty("wikiaThumbnail")]
        public string WikiaThumbnail;

        [JsonProperty("wikiaUrl")]
        public string WikiaUrl;

        [JsonProperty("releaseDate")]
        public string ReleaseDate;

        [JsonProperty("vaultDate")]
        public string VaultDate;

        [JsonProperty("estimatedVaultDate")]
        public string EstimatedVaultDate;

        [JsonProperty("vaulted")]
        public bool? Vaulted;

        [JsonProperty("exalted")]
        public List<string> Exalted;
    }


}
#endregion

#region WarframeStats.us Api Integration
/// <summary>
/// API String: https://api.warframestat.us/{platform}/arbitration 
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Arbitration
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.WorldSpace
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
        public int MaximumScore;

        [JsonProperty("currentScore")]
        public int CurrentScore;

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
        public int Health;

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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/alerts
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Alerts
{
    //API RETURN NULL - NOT FUNCTIONAL CURRENTLY SEE https://api.warframestat.us/pc/alerts
}

/// <summary>
/// API String: https://api.warframestat.us/{platform}/cambionCycle
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.CambionCycle
{
    public class Data
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
}

/// <summary>
/// API String: https://api.warframestat.us/{platform}/cetusCycle
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Cetus
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

        [JsonProperty("isCetus")]
        public bool IsCetus;

        [JsonProperty("shortString")]
        public string ShortString;
    }
}

/// <summary>
/// API String: https://api.warframestat.us/{platform}/vallisCycle
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.OrbVallis
{
    public class Data
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
}

/// <summary>
/// API String: https://api.warframestat.us/{platform}/voidTrader
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Baro
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/invasions
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Invasions
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/fissures
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Fissures
{
    public class Fissures
    {
        public List<FissureEvent> Events;
    }

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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/syndicateMissions
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Syndicate
{
    public class Missions
    {
        public List<Mission> ActiveMissions;
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/news
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.News
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/nightwave
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Nightwave
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

/// <summary>
/// API String: https://api.warframestat.us/{platform}/sortie
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Sortie
{
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
}

/// <summary>
/// API String: https://api.warframestat.us/{platform}/earthCycle
/// API Parameters: [Platforms: "pc" "ps4" "xb1" "swi"] [Language: "de" "es" "fr" "it" "ko" "pl" "pt" "ru" "zh" "en"]
/// API Responses: 200, 400, 500
/// </summary>
namespace WarframeTracker.SerializationWrappers.WarframeStats.Earth
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
