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
            GenerateData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WarframeComboBox.SelectedItem = "Ash";
            PrimaryWeaponComboBox.SelectedItem = "Acceltra";
        }
        #endregion

        #region Combobox Event Code
        public string activeWarframe = "";
        public bool tradeable = false;
        //When you change the selection in the warframe listbox, digest api information reguarding the warframe.
        private void WarframeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<SerializationWrappers.WarframeAPI.Items.Warframes.Root> Warframes = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json"));

                foreach (SerializationWrappers.WarframeAPI.Items.Warframes.Root frame in Warframes)
                {
                    if (frame.Name.ToString() == WarframeComboBox.SelectedItem.ToString())
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
                            Debugger.Log("Updated UI for " + WarframeComboBox.SelectedItem.ToString());
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

        private void PrimaryWeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Reset
            PWDataTxt.Text = "";
            PWFoundryCreditsTxt.Text = "";
            PWFoundrySlot0Txt.Text = "";
            PWFoundrySlot1Txt.Text = "";
            PWFoundrySlot2Txt.Text = "";
            PWFoundrySlot3Txt.Text = "";
            PWFoundrySlot4Txt.Text = "";
            PWCompDataTxt.Text = "";
            PWFoundrySlot0Img.BackgroundImage = null;
            PWFoundrySlot1Img.BackgroundImage = null;
            PWFoundrySlot2Img.BackgroundImage = null;
            PWFoundrySlot3Img.BackgroundImage = null;
            PWFoundrySlot4Img.BackgroundImage = null;
            PWFoundryCreditsImg.BackgroundImage = null;
            PWFoundryCreditsTxt.Text = "";
            PWFoundryMarketPriceLbl.Text = "";
            PWFoundryBuildTime.Text = "";
            PWFoundrySkipBuildLbl.Text = "";
            #endregion

            try
            {
                List<SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root> Weapons = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Primary.json"));

                foreach (SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root Weapon in Weapons)
                {
                    if (Weapon.Name.ToString() == PrimaryWeaponComboBox.SelectedItem.ToString())
                    {
                        //Set main Weapon image
                        if (Weapon.WikiaThumbnail != null)
                        {
                            PrimaryGunImageBox.BackgroundImage = WebManager.ServiceImage(Weapon.Name.ToString(), Weapon.WikiaThumbnail);
                            PrimaryWeaponContainer.Text = Weapon.Name.ToString();
                            if (Weapon.SkipBuildTimePrice > 0)
                            {
                                PWFoundrySkipBuildLbl.Text = "Skip Build Time Cost: " + Weapon.SkipBuildTimePrice.ToString() + " platinum";
                                PWFoundrySkipBuildLbl.Visible = true;
                            }
                            else
                            {
                                PWFoundrySkipBuildLbl.Visible = false;
                            }
                        }

                        //Set foundry build cost in credits section
                        PWFoundryCreditsImg.BackgroundImage = Image.FromFile(local_media_directory + "credits.png");
                        PWFoundryCreditsTxt.Text = Weapon.BuildPrice.ToString();
                        toolTip1.SetToolTip(PWFoundryCreditsTxt, "Build Cost");

                        if (Weapon.Components != null)
                        {
                            if (Weapon.Components.Count > 0)
                            {
                                //Set foundry component information
                                PWFoundrySlot0Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[0].ImageName);
                                PWFoundrySlot0Txt.Text = Weapon.Components[0].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot0Txt, Weapon.Components[0].Name);
                                toolTip1.SetToolTip(PWFoundrySlot0Img, Weapon.Components[0].Name);
                            }

                            if (Weapon.Components[1] != null)
                            {
                                PWFoundrySlot1Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[1].ImageName);
                                PWFoundrySlot1Txt.Text = Weapon.Components[1].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot1Txt, Weapon.Components[1].Name);
                                toolTip1.SetToolTip(PWFoundrySlot1Img, Weapon.Components[1].Name);
                            }

                            if (Weapon.Components[2] != null)
                            {
                                PWFoundrySlot2Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[2].ImageName);
                                PWFoundrySlot2Txt.Text = Weapon.Components[2].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot2Txt, Weapon.Components[2].Name);
                                toolTip1.SetToolTip(PWFoundrySlot2Img, Weapon.Components[2].Name);
                            }

                            if (Weapon.Components[3] != null)
                            {
                                PWFoundrySlot3Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[3].ImageName);
                                PWFoundrySlot3Txt.Text = Weapon.Components[3].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot3Txt, Weapon.Components[3].Name);
                                toolTip1.SetToolTip(PWFoundrySlot3Img, Weapon.Components[3].Name);
                            }

                            if (Weapon.Components.Count > 4)
                            {
                                PWFoundrySlot4Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[4].ImageName);
                                PWFoundrySlot4Txt.Text = Weapon.Components[4].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot4Txt, Weapon.Components[4].Name);
                                toolTip1.SetToolTip(PWFoundrySlot4Img, Weapon.Components[4].Name);
                            }
                        }

                        //Set market cost and build time
                        if (Weapon.MarketCost > 0)
                        {
                            PWFoundryMarketPriceLbl.Text = "Market Price: " + Weapon.MarketCost.ToString() + " Platinum";
                            PWFoundryMarketPriceLbl.Visible = true;
                        }
                        else
                        {
                            PWFoundryMarketPriceLbl.Visible = false;
                        }

                        if (Weapon.BuildTime > 0)
                        {
                            PWFoundryBuildTime.Text = "Build Time: " + (Weapon.BuildTime / 60).ToString() + " Minutes";
                            PWFoundryBuildTime.Visible = true;
                        }
                        else
                        {
                            PWFoundryBuildTime.Visible = false;
                        }

                        //Other Weapon Data
                        PWDataTxt.Text += "Cricical Chance: " + Math.Round(Weapon.CriticalChance * 100) + Environment.NewLine;
                        PWDataTxt.Text += "Cricical Multiplier: " + Weapon.CriticalMultiplier + Environment.NewLine;
                        PWDataTxt.Text += "Proc Chance: " + Math.Round(Weapon.ProcChance * 100) + Environment.NewLine;
                        PWDataTxt.Text += "Fire Rate: " + Weapon.FireRate + Environment.NewLine;
                        PWDataTxt.Text += "Accuracy: " + Weapon.Accuracy + Environment.NewLine;
                        PWDataTxt.Text += "Multishot: " + Weapon.Multishot + Environment.NewLine;
                        PWDataTxt.Text += "Reload Time: " + Weapon.ReloadTime + "s" + Environment.NewLine;

                        //Export Damage Ammounts
                        for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                        {
                            switch (i)
                            {
                                case 0:
                                    PWDataTxt.Text += "Base Physical Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 1:
                                    PWDataTxt.Text += "Impact/Puncture Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 2:
                                    PWDataTxt.Text += "Slash Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 3:
                                    PWDataTxt.Text += "Heat Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 4:
                                    PWDataTxt.Text += "Cold Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 5:
                                    PWDataTxt.Text += "Electricity Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 6:
                                    PWDataTxt.Text += "Toxin Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 7:
                                    PWDataTxt.Text += "Blast Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 8:
                                    PWDataTxt.Text += "Radiation Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 9:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 10:
                                    PWDataTxt.Text += "Magnetic Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 11:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 12:
                                    PWDataTxt.Text += "Corrosive Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 13:
                                    PWDataTxt.Text += "Viral Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 14:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 15:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 16:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 17:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 18:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                case 19:
                                    PWDataTxt.Text += "??? Damage: " + Math.Round(Weapon.DamagePerShot[i]).ToString() + Environment.NewLine;
                                    break;
                                default:
                                    PWDataTxt.Text = "Error";
                                    break;
                            }
                        }

                        //Export component drop data
                        if (Weapon.Components != null)
                        {
                            for (int i = 0; i < Weapon.Components.Count; i++) ///INDEX WAS OUT OF RANGE EXCEPTION OCCURRED AT LINE 360 
                            {
                                if (Weapon.Components[i].Drops != null)
                                {
                                    for (int c = 0; c < Weapon.Components[i].Drops.Count; c++)
                                    {
                                        if (!Weapon.Components[i].Drops[c].Type.Contains("Forma"))
                                        {
                                            PWCompDataTxt.Text +=
                                            Weapon.Components[i].Drops[c].Type + " Drops from " + Weapon.Components[i].Drops[c].Location + " with a " +
                                            Math.Round((double)(Weapon.Components[i].Drops[c].Chance * 100)).ToString() + " % chance with a rarity class of " +
                                            Weapon.Components[i].Drops[c].Rarity + Environment.NewLine;
                                        }
                                    }

                                    PWCompDataTxt.Text += "----------------------------------------------------------------------" + Environment.NewLine;
                                }
                            }
                        }

                        //Debug Info
                        if (DebugMode)
                        {
                            Debugger.Log("Updated UI for " + PrimaryWeaponComboBox.SelectedItem.ToString());
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
        #endregion

        #region Data Generation Code
        /// <summary>
        /// Generate & Regenerate all application data.
        /// </summary>
        private void GenerateData()
        {
            #region Resets
            WarframeComboBox.Items.Clear();
            PrimaryWeaponComboBox.Items.Clear();
            #endregion

            #region Warframes
            List<SerializationWrappers.WarframeAPI.Items.Warframes.Root> Warframes = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json"));

            foreach (SerializationWrappers.WarframeAPI.Items.Warframes.Root frame in Warframes)
            {
                WarframeComboBox.Items.Add(frame.Name.ToString());
            }
            #endregion

            #region Load Primary Weapons
            List<SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root> Primary_Weapons = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Primary.json"));

            foreach (SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root Weapon in Primary_Weapons)
            {
                if (Weapon.ProductCategory != "SentinelWeapons")
                {
                    PrimaryWeaponComboBox.Items.Add(Weapon.Name.ToString());
                }
            }
            #endregion

            #region Load Secondary Weapons

            #endregion

            #region Load Melee Weapons

            #endregion

            #region Load Companion Data

            #endregion

            #region Load World State Data

            #endregion 
        }
        #endregion

        #region Settings Code

        #endregion

        #region Build Guides Code

        #endregion

        #region Crafting Guides Code

        #endregion

        #region World Cycle Code

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        #region ContextMenu Code
        #region Warframe Context Menu Commands
        private void findSetOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = WarframeComboBox.SelectedItem.ToString() + " Set"; //Set static variable to handle on the orders page.
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
                SelectedItemInformation.activeItemName = WarframeComboBox.SelectedItem.ToString() + " Neuroptics"; //Set static variable to handle on the orders page.
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
                SelectedItemInformation.activeItemName = WarframeComboBox.SelectedItem.ToString() + " Chassis"; //Set static variable to handle on the orders page.
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
                SelectedItemInformation.activeItemName = WarframeComboBox.SelectedItem.ToString() + " Systems"; //Set static variable to handle on the orders page.
                new OrderSheet().Show(); //Launch order page
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }

        #endregion

        #region Primary Weapons Context Menu Commands

        #endregion

        #region Secondary Weapons Context Menu Commands

        #endregion

        #region Melee Weapons Context Menu Commands

        #endregion

        #region Companions Context Menu Commands

        #endregion

        #region World Cycle Context Menu

        #endregion

        #endregion

    }
}