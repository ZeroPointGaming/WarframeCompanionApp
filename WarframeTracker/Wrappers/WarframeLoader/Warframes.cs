using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Warframes.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.Warframes
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