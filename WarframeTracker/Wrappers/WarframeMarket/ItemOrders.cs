using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// API String: https://api.warframe.market/v1/items/{url_name}/orders
/// </summary>
namespace WarframeTracker.WarframeMarket.ItemOrders
{
    public class User
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

    public class Order
    {
        [JsonProperty("platform")]
        public string Platform;

        [JsonProperty("creation_date")]
        public DateTime CreationDate;

        [JsonProperty("visible")]
        public bool Visible;

        [JsonProperty("region")]
        public string Region;

        [JsonProperty("platinum")]
        public double Platinum;

        [JsonProperty("quantity")]
        public int Quantity;

        [JsonProperty("last_update")]
        public DateTime LastUpdate;

        [JsonProperty("order_type")]
        public string OrderType;

        [JsonProperty("user")]
        public User User;

        [JsonProperty("id")]
        public string Id;
    }

    public class Payload
    {
        [JsonProperty("orders")]
        public List<Order> Orders;
    }

    public class Root
    {
        [JsonProperty("payload")]
        public Payload Payload;
    }

}