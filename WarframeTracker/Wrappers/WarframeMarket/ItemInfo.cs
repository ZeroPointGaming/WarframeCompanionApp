using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframe.market/v1/items/{url_name}
/// </summary>
namespace WarframeTracker.WarframeMarket.ItemInfo
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