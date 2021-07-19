using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Parent Namespace for our WebInterface which contains all our web interfacing classes and methods.
/// </summary>
namespace WarframeTracker.WebInterface
{
    /// <summary>
    /// Parent class for WarframeTrackers localized web functions.
    /// </summary>
    public class WTWebClient
    {
        /// <summary>
        /// Generates a WebRequest object given the wanted webrequest type.
        /// </summary>
        /// <param name="url_name">An api query string for Warframe.Market api calls.</param>
        /// <param name="request_type">A String type which will return the requested api request.</param>
        /// <returns></returns>
        public HttpWebRequest GenerateRequest(string url_name, string request_type, string platform = "pc")
        {
            switch (request_type)
            {
                #region Warframe.Market Requests
                case "ItemCall":
                    HttpWebRequest item_request = (HttpWebRequest)WebRequest.Create($"https://api.warframe.market/v1/items/{url_name}");
                    return item_request;

                case "OrderCall":
                    HttpWebRequest order_request = (HttpWebRequest)WebRequest.Create($"https://api.warframe.market/v1/items/{url_name}/orders");
                    return order_request;

                case "AllItems":
                    HttpWebRequest all_items_request = (HttpWebRequest)WebRequest.Create($"https://api.warframe.market/v1/items");
                    return all_items_request;

                case "RivenOrders":
                    HttpWebRequest riven_orders_request = (HttpWebRequest)WebRequest.Create($"https://api.warframe.market/v1/auctions/search?type=riven&weapon_url_name={url_name}");
                    return riven_orders_request;
                #endregion

                #region Warframestatus.us Requests
                case "WorldState":
                    HttpWebRequest world_state_request = (HttpWebRequest)WebRequest.Create($"https://api.warframestat.us/{Properties.Settings.Default.platform}");
                    return world_state_request;

                case "Drops":
                    HttpWebRequest drops_request = (HttpWebRequest)WebRequest.Create($"http://drops.warframestat.us/data/all.json");
                    return drops_request;
                #endregion

                #region Vault Data Requests
                case "VaultData":
                    HttpWebRequest vault_data_request = (HttpWebRequest)WebRequest.Create($"http://www.oggtechnologies.com/api/ducatsorplat/v2/MainItemData.json");
                    return vault_data_request;
                #endregion

                default:
                    return null;
            }            
        }

        /// <summary>
        /// Returns a response object given a input request.
        /// </summary>
        /// <param name="IncomingRequest">A HTTPWebRequest object is sent to retrieve its response object.</param>
        /// <returns></returns>
        public HttpWebResponse GenerateResponse(HttpWebRequest IncomingRequest)
        {
            return (HttpWebResponse)IncomingRequest.GetResponse();
        }

        /// <summary>
        /// Completes a image url for warframe.market images
        /// </summary>
        /// <param name="subpart">Input parameter is the second half of the url string "icon/etc/etc/etc/file.png" for example.</param>
        /// <returns></returns>
        public string GetImageURL(string subpart)
        {
            return "$https://warframe.market/static/assets/{subpart}";
        }

        //Return Image From URL
        public Image DownloadImage(string fromUrl)
        {
            try
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    using (Stream stream = webClient.OpenRead(fromUrl))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch
            {
                Image empty = Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/not_found.png");
                return empty;
            }
        }

        /// <summary>
        /// Replace images that are not very pleasant to look at from the WIKI imports.
        /// </summary>
        /// <param name="name">Warframe Name Input</param>
        /// <param name="alt_url">Warframe Image Origin Path Input</param>
        /// <returns>Returns an image downloaded from the specified links.</returns>
        public Image ServiceImage(string name, string alt_url = "")
        {
            Image empty = Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/not_found.png");

            switch (name)
            {
                #region Warframes
                case "Atlas Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/9/99/AtlasPrimeNewLook.png/revision/latest/scale-to-width-down/295?cb=20200208124530");
                case "Banshee Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/8/85/BansheePrimeNewLook.png/revision/latest/scale-to-width-down/286?cb=20190719014541");
                case "Equinox":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/e/ee/EquinoxSolo.png/revision/latest/scale-to-width-down/291?cb=20150731173954");
                case "Equinox Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/7/72/EquinoxPrimeHybridNewLook.png/revision/latest/scale-to-width-down/310?cb=20190719014723");
                case "Chroma Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/6/69/ChromaPrimeNewLook.png/revision/latest/scale-to-width-down/293?cb=20200208125702");
                case "Gara Prime":
                    if (File.Exists(Environment.CurrentDirectory.ToString() + "/data/img/gara_prime.jpg"))
                    {
                        return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/gara_prime.jpg");
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: gara_prime.jpg");
                        return empty;
                    }
                case "Hydroid Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/c/c3/HydroidPrimeNewLook.png/revision/latest/scale-to-width-down/293?cb=20200208133019");
                case "Inaros Prime":
                    if (File.Exists(Environment.CurrentDirectory.ToString() + "/data/img/inaros_prime.jpg"))
                    {
                        return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/inaros_prime.jpg");
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: inaros_prime.jpg");
                        return empty;
                    }
                case "Lavos":
                    if (File.Exists(Environment.CurrentDirectory.ToString() + "/data/img/lavos.jpg"))
                    {
                        return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/lavos.jpg");
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: lavos.jpg");
                        return empty;
                    }
                case "Nezha Prime":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/c/c5/NezhaPrimeIcon272.png/revision/latest/scale-to-width-down/272?cb=20201029014155");
                case "Nova prime":
                    string octavia = Environment.CurrentDirectory.ToString() + "/data/img/nova_prime.jpg";
                    if (File.Exists(octavia))
                    {
                        return Image.FromFile(octavia);
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: nova_prime.jpg");
                        return empty;
                    }
                case "Octavia Prime":
                    if (File.Exists(Environment.CurrentDirectory.ToString() + "/data/img/octavia_prime.jpg"))
                    {
                        return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/octavia_prime.jpg");
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: octavia_prime.jpg");
                        return empty;
                    }
                case "Sevagoth":
                    if (File.Exists(Environment.CurrentDirectory.ToString() + "/data/img/sevagoth.jpg"))
                    {
                        return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/sevagoth.jpg");
                    }
                    else
                    {
                        MessageBox.Show("Data File Missing: sevagoth.jpg");
                        return empty;
                    }
                case "Xaku":
                    return DownloadImage("https://static.wikia.nocookie.net/warframe/images/0/06/Xaku.PNG/revision/latest/scale-to-width-down/270?cb=20200907135937");
                #endregion

                case "Credits":
                    return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/credits.jpg");
                case "Platinum":
                    return Image.FromFile(Environment.CurrentDirectory.ToString() + "/data/img/platinum.jpg");

                default:
                    if (name != null)
                    {
                        return DownloadImage(alt_url);
                    }
                    else
                    {
                        return empty;
                    }
            }
        }

        public string GetBlueprintInfo(string warframe_name)
        {
            string description = "";

            return warframe_name switch
            {
                "Ash" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Atlas" => $"{warframe_name}' blueprint is awarded after completing The Jordas Precept Quest, which unlocks the Jordas Golem Archwing Assassination mission on Eris that drops the remaining component blueprints. Additional main blueprints can be bought from Cephalon Simaris for 50,000 Simaris Standing.",
                "Banshee" => $"{warframe_name}'s blueprints can be researched from the Tenno Lab in the Dojo.",
                "Baruuk" => $"{warframe_name}'s blueprints can be purchased from Little Duck, using Vox Solaris standing. The main blueprint requires players to be at Agent rank, while component blueprints require Hand rank. Each blueprint costs 5,000 Standing, totaling to 20,000 standing.",
                "Chroma" => $"{warframe_name}'s main blueprint is rewarded upon completion of the quest The New Strange. Component blueprints are awarded by completing Junctions.The Neuroptics will be rewarded after completing the Uranus Junction, the Chassis the Neptune Junction and the Systems the Pluto Junction. Additional blueprints can be bought from Cephalon Simaris; 25,000 for component blueprints and 50,000 for main blueprint.",
                "Ember" => $"{warframe_name}'s main blueprint can be purchased from the Market. Ember's component blueprints are acquired from General Sargas Ruk (Tethys, Saturn).",
                "Equinox" => $"{warframe_name} requires a unique method to craft: Tenno must forge both the Equinox Night Aspect and Equinox Day Aspect in the Foundry – each of which requires its respective Neuroptics, Chassis, and Systems – before the Warframe itself can be built. Component and Aspect blueprints can be obtained by defeating Tyl Regor on Titania, Uranus. Equinox's main blueprint can be purchased from the Market.",
                "Equinox Prime" => description,
                "Excalibur" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Excalibur Umbra" => $"The blueprint for Excalibur Umbra is given to players upon completing the first mission of The Sacrifice quest, and the ability to build the Warframe is granted on completing the second mission. Unlike other Warframes, Umbra requires no further components and is crafted entirely from the single blueprint. However, even after being crafted, he cannot be used until the penultimate mission, where he is automatically Rank 30 with a free, pre-installed Orokin Reactor and Warframe slot. A second blueprint will not be given on replays.",
                "Excalibur Prime" => $"{warframe_name} was only obtainable by upgrading a Warframe account to Founders status of Hunter or greater, which is no longer available.",
                "Frost" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Gara" => $"{warframe_name}'s main blueprint will be awarded upon completion of the Saya's Vigil quest.",
                "Garuda" => $"{warframe_name}'s main blueprint will be awarded upon completion of the Vox Solaris quest. Garuda's component blueprints are acquired from Orb Vallis Bounties.",
                "Gauss" => $"{warframe_name}' main blueprint can be purchased from the Market. Gauss' component blueprints drop from Tier C Disruption on Kappa, Sedna (Kelpie, Sedna for Consoles). Each component has a 7.84% drop chance.",
                "Grendel" => $"{warframe_name}'s main blueprint can be purchased from the Market. Grendel's component blueprints are awarded by completing certain missions on Europa using Locators, which can be purchased from the Arbitration Honors vendor found in any Relay for 25 Vitus Essence each.",
                "Harrow" => $"{warframe_name}'s main blueprint is awarded upon completion of the Chains of Harrow quest.",
                "Hildryn" => $"{warframe_name}'s main blueprint can be bought from Little Duck for 5,000 standing upon reaching the rank of Agent with Vox Solaris. Her component blueprints can be acquired as drops from the Exploiter Orb.",
                "Hydroid" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Inaros" => $"{warframe_name}' main and component blueprints are obtainable from the Sands of Inaros quest. The quest blueprint is purchasable from Baro Ki'Teer.",
                "Ivara" => $"{warframe_name}'s main and component blueprints are acquired from Spy missions (including Nightmare Mode) depending on mission level. Alerts and sorties do not reward identified caches therefore are exempt. All parts are in Rotation C of their respective reward tables, meaning they require three successful data extractions to be an eligible reward for the mission. Eligible missions are detailed in the tables below.",
                "Khora" => $"{warframe_name}'s main and component blueprints are acquired from standard Sanctuary Onslaught rotation C (round 6).",
                "Lavos" => $"{warframe_name}'s main and component blueprints are available from Father with Entrati standing. The main blueprint requires players to be at Rank 2 - Acquaintance, while component blueprints require Rank 3 - Associate.",
                "Limbo" => $"{warframe_name}'s main blueprint can be purchased from the Market. ",
                "Loki" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Mag" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Mesa" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Mirage" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Nekros" => $"{warframe_name}' main blueprint can be purchased from the Market.",
                "Nezha" => $"{warframe_name}'s blueprints are researched from the Tenno Lab in the dojo.",
                "Nidus" => $"{warframe_name}' main blueprint is acquired from The Glast Gambit quest, additional main blueprints can be bought from Cephalon Simaris for 50,000 standing.",
                "Nova" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Nyx" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Oberon" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Octavia" => $"{warframe_name}'s main blueprint is acquired upon completion of the Octavia's Anthem quest.",
                "Protea" => $"{warframe_name}'s main blueprint is rewarded upon completion of The Deadlock Protocol quest.",
                "Revenant" => $"{warframe_name}'s main blueprint is awarded upon completion of the Mask of the Revenant quest, which is unlocked after reaching the rank of 'Observer' with The Quills.",
                "Rhino" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Saryn" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Sevagoth" => $"{warframe_name}'s main blueprint is acquired after completing the Call of the Tempestarii quest.",
                "Titania" => $"{warframe_name}'s main and component blueprints are obtainable from The Silver Grove quest.",
                "Trinity" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Valkyr" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Vauban" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Volt" => $"{warframe_name}'s blueprints can be researched from the Tenno Lab in the dojo.",
                "Wisp" => $"{warframe_name}'s main and components blueprints are acquired from defeating the Ropalolyst on The Ropalolyst, Jupiter.",
                "Wukong" => $"{warframe_name}'s blueprints can be researched from the Tenno Lab in the dojo.",
                "Xaku" => $"{warframe_name}'s main blueprint will be awarded upon completion of the Heart of Deimos quest.",
                "Zephyr" => $"{warframe_name}'s blueprints can be researched from the Tenno Lab in the dojo.",
                "Yareli" => $"{warframe_name}'s main blueprint is acquired by completing The Waverider quest. Component blueprints are acquired through Research inside the VentKids' Bash Lab within the Clan Dojo.",
                _ => description,
            };
        }
    }
}
