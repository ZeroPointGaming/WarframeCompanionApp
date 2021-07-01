using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: http://www.oggtechnologies.com/api/ducatsorplat/v2/MainItemData.json
/// API Return: Information aboult vaulted items/warframes etc
/// </summary>
namespace WarframeTracker.OGTech.ValutedItemData
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