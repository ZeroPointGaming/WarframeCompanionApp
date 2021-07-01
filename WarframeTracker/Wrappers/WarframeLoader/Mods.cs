using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Read Mods.json from hardcoded data files on disk. Prechached files fetched from Warframe api, Will integrate the api call here at some point [LZMA Implementation]
/// </summary>
namespace WarframeTracker.Items.Mods
{
    public class LevelStat
    {
        [JsonProperty("stats")]
        public List<string> Stats;
    }

    public class Drop
    {
        [JsonProperty("location")]
        public string Location;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("chance")]
        public double? Chance;

        [JsonProperty("rarity")]
        public string Rarity;
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

    public class UpgradeValue
    {
        [JsonProperty("value")]
        public double Value;

        [JsonProperty("locTag")]
        public string LocTag;

        [JsonProperty("reverseValueSymbol")]
        public bool? ReverseValueSymbol;
    }

    public class UpgradeEntry
    {
        [JsonProperty("tag")]
        public string Tag;

        [JsonProperty("prefixTag")]
        public string PrefixTag;

        [JsonProperty("suffixTag")]
        public string SuffixTag;

        [JsonProperty("upgradeValues")]
        public List<UpgradeValue> UpgradeValues;
    }

    public class Complication
    {
        [JsonProperty("fullName")]
        public string FullName;

        [JsonProperty("description")]
        public string Description;
    }

    public class AvailableChallenge
    {
        [JsonProperty("fullName")]
        public string FullName;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("complications")]
        public List<Complication> Complications;
    }

    public class Root
    {
        [JsonProperty("uniqueName")]
        public string UniqueName;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("polarity")]
        public string Polarity;

        [JsonProperty("rarity")]
        public string Rarity;

        [JsonProperty("baseDrain")]
        public int BaseDrain;

        [JsonProperty("fusionLimit")]
        public int FusionLimit;

        [JsonProperty("compatName")]
        public string CompatName;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("levelStats")]
        public List<LevelStat> LevelStats;

        [JsonProperty("imageName")]
        public string ImageName;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("isAugment")]
        public bool IsAugment;

        [JsonProperty("tradable")]
        public bool Tradable;

        [JsonProperty("wikiaThumbnail")]
        public string WikiaThumbnail;

        [JsonProperty("wikiaUrl")]
        public string WikiaUrl;

        [JsonProperty("transmutable")]
        public bool Transmutable;

        [JsonProperty("drops")]
        public List<Drop> Drops;

        [JsonProperty("patchlogs")]
        public List<Patchlog> Patchlogs;

        [JsonProperty("isUtility")]
        public bool? IsUtility;

        [JsonProperty("modSet")]
        public string ModSet;

        [JsonProperty("isExilus")]
        public bool? IsExilus;

        [JsonProperty("excludeFromCodex")]
        public bool? ExcludeFromCodex;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("upgradeEntries")]
        public List<UpgradeEntry> UpgradeEntries;

        [JsonProperty("availableChallenges")]
        public List<AvailableChallenge> AvailableChallenges;

        [JsonProperty("modSetValues")]
        public List<double> ModSetValues;
    }


}