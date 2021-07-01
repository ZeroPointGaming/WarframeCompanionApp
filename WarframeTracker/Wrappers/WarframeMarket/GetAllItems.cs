using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframe.market/v1/items
/// </summary>
namespace WarframeTracker.WarframeMarket.GetAllItems
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