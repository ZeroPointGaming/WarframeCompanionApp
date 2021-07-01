using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Enemy.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.Enemies
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
        public double? Chance;

        [JsonProperty("rotation")]
        public string Rotation;
    }

    public class Affector
    {
        [JsonProperty("element")]
        public string Element;

        [JsonProperty("modifier")]
        public double Modifier;
    }

    public class Resistance
    {
        [JsonProperty("amount")]
        public int Amount;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("affectors")]
        public List<Affector> Affectors;
    }

    public class Patchlog
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("date")]
        public DateTime Date;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("imgUrl")]
        public string ImgUrl;

        [JsonProperty("additions")]
        public string Additions;

        [JsonProperty("changes")]
        public string Changes;

        [JsonProperty("fixes")]
        public string Fixes;
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

        [JsonProperty("regionBits")]
        public int RegionBits;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("imageName")]
        public string ImageName;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("tradable")]
        public bool Tradable;

        [JsonProperty("drops")]
        public List<Drop> Drops;

        [JsonProperty("resistances")]
        public List<Resistance> Resistances;

        [JsonProperty("patchlogs")]
        public List<Patchlog> Patchlogs;

        [JsonProperty("faction")]
        public string Faction;
    }


}