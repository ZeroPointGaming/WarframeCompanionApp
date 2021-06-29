using System;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using WarframeTracker.SerializationWrappers.Base.Old;
using WarframeTracker.WebInterface;
using System.Net;
using System.Drawing;
//lzma compression using SevenZip.Compression.LZMA;

namespace WarframeTracker
{
    public partial class Form1 : Form
    {
        #region Declare Class Instances
        WTWebClient WebManager = new WTWebClient();
        Debug.Debug Debugger = new Debug.Debug();
        #endregion

        #region Declare Local Variables
        public string local_Json_directory = Environment.CurrentDirectory.ToString() + "/data/json";
        public string local_media_directory = Environment.CurrentDirectory.ToString() + "/data/img/";
        public bool DebugMode = true;
        #endregion

        #region Form Events
        public Form1()
        {
            //Initialize the UI Components for the form.
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            WarframeListBox.SelectedItem = "Ash";
        }
        #endregion

        /// <summary>
        /// Test case to test api interface. Verified Working
        /// </summary>
        private void TestCase()
        {
            HttpWebRequest request = WebManager.GenerateRequest("meso_t5_relic", "ItemCall");
            HttpWebResponse response = WebManager.GenerateResponse(request);

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                var ObjText = reader.ReadToEnd();
                reader.Close();reader.Dispose();

                SerializationWrappers.WarframeMarket.ItemInfo.Root ItemReturned = JsonConvert.DeserializeObject<SerializationWrappers.WarframeMarket.ItemInfo.Root>(ObjText);    
                MessageBox.Show(ItemReturned.Payload.Item.ItemsInSet[0].En.ItemName);

                //pictureBox1.Load(WebManager.GetImageURL("icons/en/thumbs/heliocor.49fc1b3f6c4e4a550a15ad7c96885195.128x128.png")); //Verified Working
            }
        }

        #region Warframe Code
        public string activeWarframe = "";
        public bool tradeable = false;
        //When you change the selection in the warframe listbox, digest api information reguarding the warframe.
        private void WarframeListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SerializationWrappers.WarframeAPI.Items.Warframes.Root Warframe = new SerializationWrappers.WarframeAPI.Items.Warframes.Root();

                List<SerializationWrappers.WarframeAPI.Items.Warframes.Root> Warframes = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json"));

                foreach (SerializationWrappers.WarframeAPI.Items.Warframes.Root frame in Warframes)
                {
                    if (frame.Name.ToString() == WarframeListBox.SelectedItem.ToString())
                    {
                        //Set static vars
                        activeWarframe = frame.Name.ToString();
                        tradeable = frame.Tradable;

                        //Set main warframe image
                        SelectedWarframeImageBox.BackgroundImage = WebManager.ServiceImage(frame.Name.ToString(), frame.WikiaThumbnail);

                        //Set Abilities Ino
                        WarframeAbilityGroupbox1.Text = frame.Abilities[0].Name.ToString();
                        WarframeAbilityTextBox1.Text = frame.Abilities[0].Description.ToString();
                        WarframeAbilityGroupbox2.Text = frame.Abilities[1].Name.ToString();
                        WarframeAbilityTextbox2.Text = frame.Abilities[1].Description.ToString();
                        WarframeAbilityGroupbox3.Text = frame.Abilities[2].Name.ToString();
                        WarframeAbilityTextbox3.Text = frame.Abilities[2].Description.ToString();
                        WarframeAbilityGroupbox4.Text = frame.Abilities[3].Name.ToString();
                        WarframeAbilityTextbox4.Text = frame.Abilities[3].Description.ToString();
                        PassiveAbilityTextbox.Text = frame.PassiveDescription.ToString();

                        //Warframe Componets, Drop Locations, Chances, Etc
                        foreach (SerializationWrappers.WarframeAPI.Items.Warframes.Component comp in frame.Components)
                        {
                            switch (comp.Name)
                            {
                                case "Blueprint":
                                    BPComponentImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                    FrameBPTxtBox.Text = WebManager.GetBlueprintInfo(frame.Name);
                                    break;
                                case "Chassis":
                                    ChassCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                    FrameChassTxtBox.Text = "";

                                    if (comp.Drops != null)
                                    {
                                        FrameChassTxtBox.Text = comp.Description + " Can be found on: " + comp.Drops[0].Location + " with a drop chance of " + Math.Round((double)comp.Drops[0].Chance * (double)100).ToString() + "% With a rarity class of " + comp.Drops[0].Rarity;
                                    }
                                    else
                                    {
                                        FrameChassTxtBox.Text = "Information Missing, Coming Soon!";
                                    }
                                    break;
                                case "Neuroptics":
                                    NueroCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                    FrameNueroTxtBox.Text = "";

                                    if (comp.Drops != null)
                                    {
                                        FrameNueroTxtBox.Text = comp.Description + " Can be found on: " + comp.Drops[0].Location + " with a drop chance of " + Math.Round((double)comp.Drops[0].Chance * (double)100).ToString() + "% With a rarity class of " + comp.Drops[0].Rarity;
                                    }
                                    else
                                    {
                                        FrameNueroTxtBox.Text = "Information Missing, Coming Soon!";
                                    }
                                    break;
                                case "Systems":
                                    SysCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                    FrameSysTxtBox.Text = "";

                                    if (comp.Drops != null)
                                    {
                                        FrameSysTxtBox.Text = comp.Description + " Can be found on: " + comp.Drops[0].Location + " with a drop chance of " + Math.Round((double)comp.Drops[0].Chance * (double)100).ToString() + "% With a rarity class of " + comp.Drops[0].Rarity;
                                    }
                                    else
                                    {
                                        FrameSysTxtBox.Text = "Information Missing, Coming Soon!";
                                    }
                                    break;
                                default:

                                    break;
                            }
                        }

                        //Debug Info
                        if (DebugMode)
                        {
                            Debugger.Log("Updated UI for " + WarframeListBox.SelectedItem.ToString());
                        }
                    }
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log("Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file." + ex.ToString());
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log("Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file." + ex.ToString());
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log("Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred." + Environment.NewLine + "Stack Trace: " + ex.ToString());
                }
            }
        }

        /// <summary>
        /// Temporary function to download all data from api endpoints, incorperate it into local database style save sources, save it to disk for future use.
        /// FUNCTIONAL!!
        /// </summary>
        private void GenerateData()
        {
            List<SerializationWrappers.WarframeAPI.Items.Warframes.Root> Warframes = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json"));

            //Reset warframes list incase of new data appeneded to the json file.
            WarframeListBox.Items.Clear();

            foreach (SerializationWrappers.WarframeAPI.Items.Warframes.Root frame in Warframes)
            {
                WarframeListBox.Items.Add(frame.Name.ToString());
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        #region Warframe Context Menu Commands
        private void findSetOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = WarframeListBox.SelectedItem.ToString() + " Set"; //Set static variable to handle on the orders page.
                new OrderSheet().Show(); //Launch order page
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }

        private void findNueroOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = WarframeListBox.SelectedItem.ToString() + " Neuroptics"; //Set static variable to handle on the orders page.
                new OrderSheet().Show(); //Launch order page
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }

        private void fiindChassiesOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = WarframeListBox.SelectedItem.ToString() + " Chassis"; //Set static variable to handle on the orders page.
                new OrderSheet().Show(); //Launch order page
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }

        private void findSystemsOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = WarframeListBox.SelectedItem.ToString() + " Systems"; //Set static variable to handle on the orders page.
                new OrderSheet().Show(); //Launch order page
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }
        #endregion
    }
}