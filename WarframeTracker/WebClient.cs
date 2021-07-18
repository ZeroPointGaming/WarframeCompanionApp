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
                "Excalibur Umbra" => description,
                "Excalibur Prime" => description,
                "Frost" => $"{warframe_name}'s main blueprint can be purchased from the Market.",
                "Gara" => $"{warframe_name}'s main blueprint will be awarded upon completion of the Saya's Vigil quest.",
                "Garuda" => $"{warframe_name}",
                "Gauss" => $"{warframe_name}",
                "Grendel" => $"{warframe_name}",
                "Harrow" => $"{warframe_name}",
                "Hildryn" => $"{warframe_name}",
                "Hydroid" => $"{warframe_name}",
                "Hydroid Prime" => description,
                "Inaros" => $"{warframe_name}",
                "Inaros Prime" => description,
                "Ivara" => $"{warframe_name}",
                "Ivara Prime" => description,
                "Khora" => $"{warframe_name}",
                "Lavos" => $"{warframe_name}",
                "Limbo" => $"{warframe_name}",
                "Limbo Prime" => description,
                "Loki" => $"{warframe_name}",
                "Loki Prime" => description,
                "Mag" => $"{warframe_name}",
                "Mag Prime" => description,
                "Mesa" => $"{warframe_name}",
                "Mesa Prime" => description,
                "Mirage" => $"{warframe_name}",
                "Mirage Prime" => description,
                "Nekros" => $"{warframe_name}",
                "Nekros Prime" => description,
                "Nezha" => $"{warframe_name}",
                "Nezha Prime" => description,
                "Nidus" => $"{warframe_name}",
                "Nova" => $"{warframe_name}",
                "Nova prime" => description,
                "Nyx" => $"{warframe_name}",
                "Nyx Prime" => description,
                "Oberon" => $"{warframe_name}",
                "Oberon Prime" => description,
                "Octavia" => $"{warframe_name}",
                "Octavia Prime" => description,
                "Protea" => $"{warframe_name}",
                "Revenant" => $"{warframe_name}",
                "Rhino" => $"{warframe_name}",
                "Rhino Prime" => description,
                "Saryn" => $"{warframe_name}",
                "Saryn Prime" => description,
                "Sevagoth" => $"{warframe_name}",
                "Titania" => $"{warframe_name}",
                "Titania Prime" => description,
                "Trinity" => $"{warframe_name}",
                "Trinity Prime" => description,
                "Valkyr" => $"{warframe_name}",
                "Valkyr Prime" => description,
                "Vauban" => $"{warframe_name}",
                "Vauban Prime" => description,
                "Volt" => $"{warframe_name}",
                "Volt Prime" => description,
                "Wisp" => $"{warframe_name}",
                "Wukong" => $"{warframe_name}",
                "Wukong Prime" => description,
                "Xaku" => $"{warframe_name}",
                "Zephyr" => $"{warframe_name}",
                "Zephyr Prime" => description,
                _ => description,
            };
        }
    }
}
