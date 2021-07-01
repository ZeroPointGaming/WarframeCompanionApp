using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Arc-Gun.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.ArcGun
{
    public class Drop
    {
        [JsonProperty("location")]
        public string Location;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("chance")]
        public double Chance;

        [JsonProperty("rotation")]
        public string Rotation;
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

    public class DamageTypes
    {
        [JsonProperty("impact")]
        public double Impact;

        [JsonProperty("heat")]
        public int Heat;

        [JsonProperty("slash")]
        public double? Slash;

        [JsonProperty("puncture")]
        public double? Puncture;

        [JsonProperty("radiation")]
        public int? Radiation;

        [JsonProperty("magnetic")]
        public int? Magnetic;
    }

    public class Falloff
    {
        [JsonProperty("start")]
        public int Start;

        [JsonProperty("end")]
        public double End;

        [JsonProperty("reduction")]
        public double Reduction;
    }

    public class AreaAttack
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("falloff")]
        public Falloff Falloff;

        [JsonProperty("blast")]
        public int Blast;

        [JsonProperty("damage")]
        public string Damage;

        [JsonProperty("crit_chance")]
        public int? CritChance;

        [JsonProperty("crit_mult")]
        public double? CritMult;

        [JsonProperty("status_chance")]
        public double? StatusChance;

        [JsonProperty("radiation")]
        public int? Radiation;
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
        public int TotalDamage;

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

        [JsonProperty("accuracy")]
        public double Accuracy;

        [JsonProperty("omegaAttenuation")]
        public double OmegaAttenuation;

        [JsonProperty("noise")]
        public string Noise;

        [JsonProperty("trigger")]
        public string Trigger;

        [JsonProperty("magazineSize")]
        public int MagazineSize;

        [JsonProperty("reloadTime")]
        public double ReloadTime;

        [JsonProperty("multishot")]
        public int Multishot;

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

        [JsonProperty("damage")]
        public string Damage;

        [JsonProperty("damageTypes")]
        public DamageTypes DamageTypes;

        [JsonProperty("marketCost")]
        public int MarketCost;

        [JsonProperty("polarities")]
        public List<string> Polarities;

        [JsonProperty("projectile")]
        public string Projectile;

        [JsonProperty("statusChance")]
        public int StatusChance;

        [JsonProperty("tags")]
        public List<string> Tags;

        [JsonProperty("wikiaThumbnail")]
        public string WikiaThumbnail;

        [JsonProperty("wikiaUrl")]
        public string WikiaUrl;

        [JsonProperty("disposition")]
        public int Disposition;

        [JsonProperty("areaAttack")]
        public AreaAttack AreaAttack;
    }


}