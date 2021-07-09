using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Pets.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.Pets
{
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
    }

    public class Root
    {
        [JsonProperty("uniqueName")]
        public string UniqueName;

        [JsonProperty("name")]
        public string Name;

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

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("productCategory")]
        public string ProductCategory;

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

        [JsonProperty("damagePerShot")]
        public List<int> DamagePerShot;

        [JsonProperty("totalDamage")]
        public int? TotalDamage;

        [JsonProperty("criticalChance")]
        public int? CriticalChance;

        [JsonProperty("criticalMultiplier")]
        public int? CriticalMultiplier;

        [JsonProperty("procChance")]
        public int? ProcChance;

        [JsonProperty("fireRate")]
        public int? FireRate;

        [JsonProperty("masteryReq")]
        public int? MasteryReq;

        [JsonProperty("excludeFromCodex")]
        public bool? ExcludeFromCodex;

        [JsonProperty("omegaAttenuation")]
        public int? OmegaAttenuation;

        [JsonProperty("buildPrice")]
        public int? BuildPrice;

        [JsonProperty("buildTime")]
        public int? BuildTime;

        [JsonProperty("skipBuildTimePrice")]
        public int? SkipBuildTimePrice;

        [JsonProperty("buildQuantity")]
        public int? BuildQuantity;

        [JsonProperty("consumeOnBuild")]
        public bool? ConsumeOnBuild;

        [JsonProperty("components")]
        public List<Component> Components;
    }

}