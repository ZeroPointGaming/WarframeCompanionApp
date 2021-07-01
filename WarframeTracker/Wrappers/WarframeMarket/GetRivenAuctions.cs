using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframe.market/v1/auctions/search?type=riven&weapon_url_name={url_name}
/// </summary>
namespace WarframeTracker.WarframeMarket.RivenGetAuctions
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