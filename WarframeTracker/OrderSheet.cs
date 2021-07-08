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
        public bool DebugMode = true;
        Debug.Debug Debugger = new Debug.Debug();
        WTWebClient WebManager = new WTWebClient();

        public OrderSheet()
        {
            InitializeComponent();
        }

        private void OrderSheet_Load(object sender, EventArgs e)
        {
            RefereshOrders();
        }

        private void RefereshOrders()
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            try
            {
                GlobalData.activeItemName = GlobalData.activeItemName.ToLower().Replace(" ", "_");
                GlobalData.activeSearch = GlobalData.activeSearch.ToLower().Replace(" ", "_");
                this.Text = $"{GlobalData.activeItemName}_{GlobalData.activeSearch} Open Orders";

                if (DebugMode)
                {
                    Debugger.Log($"Order URL Name: {GlobalData.activeItemName}_{GlobalData.activeSearch}");
                }

                HttpWebRequest request = WebManager.GenerateRequest($"{GlobalData.activeItemName}_{GlobalData.activeSearch}", "OrderCall");
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
                            TextBox new_label = new TextBox();
                            new_label.Text = _order.OrderType + " order posted by " + _order.User.IngameName + " who is " + _order.User.Status + " asking price is " + _order.Platinum + " on " + _order.Platform;
                            new_label.Width = this.Width;
                            new_label.ReadOnly = true;
                            new_label.BorderStyle = BorderStyle.None;

                            if (new_label.Text.Contains("buy"))
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
                            else if (new_label.Text.Contains("sell"))
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
                        }

                        response.Close(); response.Close();
                    }
                    else
                    {
                        Debugger.Log($"Error loading order list.{Environment.NewLine}Response status code: {response.StatusCode} {Environment.NewLine}Response Payload: {reader.ReadToEnd()}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefereshOrders();
        }
    }
}
