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
                this.Text = SelectedItemInformation.activeItemName + " Open Orders";
                SelectedItemInformation.activeItemName = SelectedItemInformation.activeItemName.ToLower().Replace(" ", "_");

                if (DebugMode)
                {
                    Debugger.Log("Order URL Name: " + SelectedItemInformation.activeItemName.ToString());
                }

                HttpWebRequest request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "OrderCall");
                HttpWebResponse response = WebManager.GenerateResponse(request);

                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var ObjText = reader.ReadToEnd();
                    reader.Close(); reader.Dispose();

                    WarframeMarket.ItemOrders.Root Orders = JsonConvert.DeserializeObject<WarframeMarket.ItemOrders.Root>(ObjText);

                    Orders.Payload.Orders.Sort(delegate (WarframeMarket.ItemOrders.Order x, WarframeMarket.ItemOrders.Order y)
                    {
                        return x.Platinum.CompareTo(y.Platinum);
                    });

                    foreach (WarframeMarket.ItemOrders.Order _order in Orders.Payload.Orders)
                    {
                        Label new_label = new Label();
                        new_label.Text = _order.OrderType + " order posted by " + _order.User.IngameName + " who is " + _order.User.Status + " asking price is " + _order.Platinum + " on " + _order.Platform;
                        new_label.Width = this.Width;

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

    public static class SelectedItemInformation
    {
        public static string activeItemName = "";
    }
}
