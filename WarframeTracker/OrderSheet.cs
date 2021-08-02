using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WarframeTracker.WebInterface;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace WarframeTracker
{
    public partial class OrderSheet : Form
    {
        #region Delcare variables
        Debug.Debug Debugger = new Debug.Debug();
        WTWebClient WebManager = new WTWebClient();
        private Dictionary<string, string> L_Orders = new Dictionary<string, string>();
        #endregion

        public OrderSheet()
        {
            InitializeComponent();
        }

        private void OrderSheet_Load(object sender, EventArgs e)
        {
            try
            {
                RefereshOrders();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode) { Debugger.Log($"Error in OrderSheet->OrderSheet_Load{Environment.NewLine}Stack Trace: {ex}"); }
            }
        }

        private void OrderLabel_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = sender as TextBox;
                string user = txt.Text.Split(" ").FirstOrDefault();
                Clipboard.SetText(L_Orders[user]);

                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Updated clipboard information: {L_Orders[user]}");
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Error in OrderSheet-OrderLabel_Click function. {Environment.NewLine}Data: {sender}{Environment.NewLine}Stack trace: {ex}");
                }
            }
        }

        private void RefereshOrders()
        {
            #region Reset
            try
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                L_Orders.Clear();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode) { Debugger.Log($"Error in OrderSheet->RefreshOrders->ResetFunction{Environment.NewLine}Stack Trace: {ex}"); }
            }
            #endregion

            try
            {
                #region Clean data
                string formatted_item = GlobalData.activeItemName.ToLower().Replace(" ", "_");
                string formatted_part = GlobalData.activeSearch.ToLower().Replace(" ", "_");
                string built_query = $"{formatted_item}_{formatted_part}";

                this.Text = $"{GlobalData.activeItemName}_{GlobalData.activeSearch} Open Orders";
                #endregion

                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Order URL Name: {built_query}");
                }

                HttpWebRequest request = WebManager.GenerateRequest($"{built_query}", "OrderCall");
                HttpWebResponse response = WebManager.GenerateResponse(request);

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var ObjText = reader.ReadToEnd();
                        reader.Close(); reader.Dispose();

                        WarframeMarket.ItemOrders.Root Orders = JsonConvert.DeserializeObject<WarframeMarket.ItemOrders.Root>(ObjText);

                        //Sort the order list by platinum cost
                        Orders.Payload.Orders.Sort(delegate (WarframeMarket.ItemOrders.Order x, WarframeMarket.ItemOrders.Order y)
                        {
                            return x.Platinum.CompareTo(y.Platinum);
                        });

                        foreach (WarframeMarket.ItemOrders.Order _order in Orders.Payload.Orders)
                        {
                            #region Generate list of wisper commands for the orders list
                            if (!L_Orders.ContainsKey(_order.User.IngameName))
                            {
                                L_Orders.Add(_order.User.IngameName, $"/w {_order.User.IngameName} i would like to buy {GlobalData.activeItemName} {GlobalData.activeSearch} for {_order.Platinum}. Warframe Companion App!");
                            }
                            #endregion

                            #region Create a new control and add it to the layout panels
                            TextBox new_label = new TextBox();
                            new_label.Text = $"{_order.User.IngameName} is {_order.OrderType}ing {GlobalData.activeItemName} {GlobalData.activeSearch} and is {_order.User.Status}. Asking price is {_order.Platinum} on {_order.Platform}.";
                            new_label.Width = this.Width;
                            new_label.ReadOnly = true;
                            new_label.BorderStyle = BorderStyle.None;
                            new_label.BackColor = Properties.Settings.Default.background_color;
                            new_label.ForeColor = Properties.Settings.Default.foreground_color;
                            new_label.Click += OrderLabel_Click;

                            if (new_label.Text.Contains("buying"))
                            {
                                if (new_label.Text.ToLower().Contains("offline") & OfflineCheckbox.Checked)
                                {
                                    flowLayoutPanel1.Controls.Add(new_label);
                                }
                                else if (new_label.Text.ToLower().Contains("online") & OnlineCheckbox.Checked)
                                {
                                    flowLayoutPanel1.Controls.Add(new_label);
                                }
                                else if (new_label.Text.ToLower().Contains("ingame") & InGameCheckbox.Checked)
                                {
                                    flowLayoutPanel1.Controls.Add(new_label);
                                }
                            }
                            else if (new_label.Text.Contains("selling"))
                            {
                                if (new_label.Text.ToLower().Contains("offline") & OfflineCheckbox.Checked)
                                {
                                    flowLayoutPanel2.Controls.Add(new_label);
                                }
                                else if (new_label.Text.ToLower().Contains("online") & OnlineCheckbox.Checked)
                                {
                                    flowLayoutPanel2.Controls.Add(new_label);
                                }
                                else if (new_label.Text.ToLower().Contains("ingame") & InGameCheckbox.Checked)
                                {
                                    flowLayoutPanel2.Controls.Add(new_label);
                                }
                            }
                            #endregion
                        }

                        response.Close(); response.Close();
                    }
                    else
                    {
                        if (Properties.Settings.Default.debug_mode)
                        {
                            Debugger.Log($"Error loading order list.{Environment.NewLine}Response status code: {response.StatusCode} {Environment.NewLine}Response Payload: {reader.ReadToEnd()}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Error loading order list OrderSheet->RefreshOrders({GlobalData.activeItemName} {GlobalData.activeSearch}){Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RefereshOrders();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode) { Debugger.Log($"Exception in OrderSheet->RefreshButton_Click{Environment.NewLine}Stack Trace: {ex}"); }
            }
        }
    }
}
