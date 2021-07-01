using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Arc-Melee.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.ArcMelee
{
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

    public class DamageTypes
    {
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

        [JsonProperty("damagePerShot")]
        public List<double> DamagePerShot;

        [JsonProperty("totalDamage")]
        public int? TotalDamage;

        [JsonProperty("criticalChance")]
        public double? CriticalChance;

        [JsonProperty("criticalMultiplier")]
        public double? CriticalMultiplier;

        [JsonProperty("procChance")]
        public double? ProcChance;

        [JsonProperty("fireRate")]
        public int? FireRate;

        [JsonProperty("masteryReq")]
        public int? MasteryReq;

        [JsonProperty("productCategory")]
        public string ProductCategory;

        [JsonProperty("slot")]
        public int? Slot;

        [JsonProperty("omegaAttenuation")]
        public double? OmegaAttenuation;

        [JsonProperty("blockingAngle")]
        public int? BlockingAngle;

        [JsonProperty("comboDuration")]
        public int? ComboDuration;

        [JsonProperty("followThrough")]
        public double? FollowThrough;

        [JsonProperty("range")]
        public double? Range;

        [JsonProperty("slamAttack")]
        public int? SlamAttack;

        [JsonProperty("slamRadialDamage")]
        public int? SlamRadialDamage;

        [JsonProperty("slamRadius")]
        public int? SlamRadius;

        [JsonProperty("slideAttack")]
        public int? SlideAttack;

        [JsonProperty("heavyAttackDamage")]
        public int? HeavyAttackDamage;

        [JsonProperty("heavySlamAttack")]
        public int? HeavySlamAttack;

        [JsonProperty("heavySlamRadialDamage")]
        public int? HeavySlamRadialDamage;

        [JsonProperty("heavySlamRadius")]
        public int? HeavySlamRadius;

        [JsonProperty("windUp")]
        public double? WindUp;

        [JsonProperty("channeling")]
        public double? Channeling;

        [JsonProperty("damageTypes")]
        public DamageTypes DamageTypes;

        [JsonProperty("marketCost")]
        public int? MarketCost;

        [JsonProperty("polarities")]
        public List<object> Polarities;

        [JsonProperty("stancePolarity")]
        public string StancePolarity;

        [JsonProperty("tags")]
        public List<string> Tags;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("wikiaThumbnail")]
        public string WikiaThumbnail;

        [JsonProperty("wikiaUrl")]
        public string WikiaUrl;

        [JsonProperty("disposition")]
        public int? Disposition;
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
    }

    public class Root
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("uniqueName")]
        public string UniqueName;

        [JsonProperty("damagePerShot")]
        public List<double> DamagePerShot;

        [JsonProperty("totalDamage")]
        public double TotalDamage;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("criticalChance")]
        public double CriticalChance;

        [JsonProperty("criticalMultiplier")]
        public double CriticalMultiplier;

        [JsonProperty("procChance")]
        public double ProcChance;

        [JsonProperty("fireRate")]
        public double FireRate;

        [JsonProperty("masteryReq")]
        public int MasteryReq;

        [JsonProperty("productCategory")]
        public string ProductCategory;

        [JsonProperty("slot")]
        public int Slot;

        [JsonProperty("omegaAttenuation")]
        public double OmegaAttenuation;

        [JsonProperty("blockingAngle")]
        public int BlockingAngle;

        [JsonProperty("comboDuration")]
        public int ComboDuration;

        [JsonProperty("followThrough")]
        public double FollowThrough;

        [JsonProperty("range")]
        public double Range;

        [JsonProperty("slamAttack")]
        public int SlamAttack;

        [JsonProperty("slamRadialDamage")]
        public int SlamRadialDamage;

        [JsonProperty("slamRadius")]
        public int SlamRadius;

        [JsonProperty("slideAttack")]
        public int SlideAttack;

        [JsonProperty("heavyAttackDamage")]
        public int HeavyAttackDamage;

        [JsonProperty("heavySlamAttack")]
        public int HeavySlamAttack;

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

        [JsonProperty("damageTypes")]
        public DamageTypes DamageTypes;

        [JsonProperty("marketCost")]
        public int MarketCost;

        [JsonProperty("polarities")]
        public List<string> Polarities;

        [JsonProperty("tags")]
        public List<string> Tags;

        [JsonProperty("wikiaThumbnail")]
        public string WikiaThumbnail;

        [JsonProperty("wikiaUrl")]
        public string WikiaUrl;

        [JsonProperty("disposition")]
        public int Disposition;

        [JsonProperty("patchlogs")]
        public List<Patchlog> Patchlogs;
    }


}