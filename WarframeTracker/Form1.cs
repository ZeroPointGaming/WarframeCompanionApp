using System;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using WarframeTracker.SerializationWrappers.Base.Old;
using WarframeTracker.WebInterface;
using System.Net;
using System.Drawing;
using System.Threading;
//lzma compression using SevenZip.Compression.LZMA;

namespace WarframeTracker
{
    /// <summary> ACTIVE BUGS DIRECTORY
    /// [Identified] FLUCTUS Weapon has a empty page, need to look into what is going on.
    /// [Identified] Necrophage frames dont have images yet.
    /// [Identified] Necrophage frames dont contain components, components need to be reset between each changed frame.
    /// [FIXED] Selecting a necrophage from the warframes list causes NullReferenceException 
    /// </summary>

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
            SecondaryWeaponsComboBox.SelectedItem = "Acrid";
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

                        if (frame.PassiveDescription != null) { PassiveAbilityTextbox.Text = frame.PassiveDescription.ToString(); }

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
                            if (Weapon.Components.Count == 1)
                            {
                                //Set foundry component information
                                PWFoundrySlot0Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[0].ImageName);
                                PWFoundrySlot0Txt.Text = Weapon.Components[0].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot0Txt, Weapon.Components[0].Name);
                                toolTip1.SetToolTip(PWFoundrySlot0Img, Weapon.Components[0].Name);
                            }

                            if (Weapon.Components.Count == 2)
                            {
                                PWFoundrySlot1Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[1].ImageName);
                                PWFoundrySlot1Txt.Text = Weapon.Components[1].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot1Txt, Weapon.Components[1].Name);
                                toolTip1.SetToolTip(PWFoundrySlot1Img, Weapon.Components[1].Name);
                            }

                            if (Weapon.Components.Count == 3)
                            {
                                PWFoundrySlot2Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[2].ImageName);
                                PWFoundrySlot2Txt.Text = Weapon.Components[2].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot2Txt, Weapon.Components[2].Name);
                                toolTip1.SetToolTip(PWFoundrySlot2Img, Weapon.Components[2].Name);
                            }

                            if (Weapon.Components.Count == 4)
                            {
                                PWFoundrySlot3Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[3].ImageName);
                                PWFoundrySlot3Txt.Text = Weapon.Components[3].ItemCount.ToString();
                                toolTip1.SetToolTip(PWFoundrySlot3Txt, Weapon.Components[3].Name);
                                toolTip1.SetToolTip(PWFoundrySlot3Img, Weapon.Components[3].Name);
                            }

                            if (Weapon.Components.Count == 5)
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
        Dictionary<string, object> WorldState = new Dictionary<string, object>();

        private void LoadWorldState()
        {
            StreamReader reader;

            if (WorldState.Count > 1)
            {
                WorldState.Clear();
            }

            #region Download Data
            HttpWebRequest world_state_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "WorldState", "pc");
            HttpWebResponse world_state_response = WebManager.GenerateResponse(world_state_request);

            HttpWebRequest cambion_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "CambionCycle", "pc");
            HttpWebResponse combion_response = WebManager.GenerateResponse(cambion_request);

            HttpWebRequest cetus_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "CetusCycle", "pc");
            HttpWebResponse cetus_response = WebManager.GenerateResponse(cetus_request);

            HttpWebRequest vallis_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "OrbVallis", "pc");
            HttpWebResponse vallis_response = WebManager.GenerateResponse(vallis_request);

            HttpWebRequest baro_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Baro", "pc");
            HttpWebResponse baro_response = WebManager.GenerateResponse(baro_request);

            HttpWebRequest invasion_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Invasions", "pc");
            HttpWebResponse invasion_response = WebManager.GenerateResponse(invasion_request);

            HttpWebRequest fissure_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Fissures", "pc");
            HttpWebResponse fissure_response = WebManager.GenerateResponse(fissure_request);

            HttpWebRequest syndicate_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Syndicate", "pc");
            HttpWebResponse syndicate_response = WebManager.GenerateResponse(syndicate_request);

            HttpWebRequest news_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "News", "pc");
            HttpWebResponse news_response = WebManager.GenerateResponse(news_request);

            HttpWebRequest nightwave_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Nightwave", "pc");
            HttpWebResponse nightwave_response = WebManager.GenerateResponse(nightwave_request);

            HttpWebRequest sortie_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Sortie", "pc");
            HttpWebResponse sortie_response = WebManager.GenerateResponse(sortie_request);

            HttpWebRequest earth_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Earth", "pc");
            HttpWebResponse earth_response = WebManager.GenerateResponse(earth_request);

            HttpWebRequest arbitration_request = WebManager.GenerateRequest(SelectedItemInformation.activeItemName, "Arbitration", "pc");
            HttpWebResponse arbitration_response = WebManager.GenerateResponse(arbitration_request);

            
            reader = new StreamReader(world_state_response.GetResponseStream());
            WorldState.Add("WorldState", reader.ReadToEnd()); reader.Close(); world_state_response.Close(); world_state_response.Dispose();

            reader = new StreamReader(combion_response.GetResponseStream());
            WorldState.Add("CambionCycle", reader.ReadToEnd()); reader.Close(); combion_response.Close(); combion_response.Dispose();

            reader = new StreamReader(cetus_response.GetResponseStream());
            WorldState.Add("CetusCycle", reader.ReadToEnd()); reader.Close(); cetus_response.Close(); cetus_response.Dispose();

            reader = new StreamReader(vallis_response.GetResponseStream());
            WorldState.Add("VallisCycle", reader.ReadToEnd()); reader.Close(); vallis_response.Close(); vallis_response.Dispose();

            reader = new StreamReader(baro_response.GetResponseStream());
            WorldState.Add("Baro", reader.ReadToEnd()); reader.Close(); baro_response.Close(); baro_response.Dispose();

            reader = new StreamReader(invasion_response.GetResponseStream());
            WorldState.Add("Invasion", reader.ReadToEnd()); reader.Close(); invasion_response.Close(); invasion_response.Dispose();

            reader = new StreamReader(fissure_response.GetResponseStream());
            WorldState.Add("Fissures", reader.ReadToEnd()); reader.Close(); fissure_response.Close(); fissure_response.Dispose();

            reader = new StreamReader(syndicate_response.GetResponseStream());
            WorldState.Add("Syndicate", reader.ReadToEnd()); reader.Close(); syndicate_response.Close(); syndicate_response.Dispose();

            reader = new StreamReader(news_response.GetResponseStream());
            WorldState.Add("News", reader.ReadToEnd()); reader.Close(); news_response.Close(); news_response.Dispose();

            reader = new StreamReader(nightwave_response.GetResponseStream());
            WorldState.Add("Nightwave", reader.ReadToEnd()); reader.Close(); nightwave_response.Close(); nightwave_response.Dispose();

            reader = new StreamReader(sortie_response.GetResponseStream());
            WorldState.Add("Sortie", reader.ReadToEnd()); reader.Close(); sortie_response.Close(); sortie_response.Dispose();

            reader = new StreamReader(earth_response.GetResponseStream());
            WorldState.Add("Earth", reader.ReadToEnd()); reader.Close(); earth_response.Close(); earth_response.Dispose(); reader.Dispose();

            reader = new StreamReader(arbitration_response.GetResponseStream());
            WorldState.Add("Arbitration", reader.ReadToEnd()); reader.Close(); arbitration_response.Close(); arbitration_response.Dispose(); reader.Dispose();
            #endregion

            #region Load Data
            var objTxt = WorldState["Earth"];
            SerializationWrappers.WarframeStats.Earth.Data EarthState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Earth.Data>(objTxt.ToString());
            CycleTimersInfoBox.Text += ($"The current earth state is {EarthState.State} time and will change in {EarthState.TimeLeft}." + Environment.NewLine);

            objTxt = WorldState["CetusCycle"];
            SerializationWrappers.WarframeStats.Cetus.Data CetusState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Cetus.Data>(objTxt.ToString());
            CycleTimersInfoBox.Text += ($"The current cetus state is {CetusState.State} time and will change in {CetusState.TimeLeft}." + Environment.NewLine);

            objTxt = WorldState["VallisCycle"];
            SerializationWrappers.WarframeStats.OrbVallis.Data VallisState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.OrbVallis.Data>(objTxt.ToString());
            CycleTimersInfoBox.Text += ($"The current orb vallis state is {VallisState.State} and will change in {VallisState.TimeLeft}." + Environment.NewLine);

            objTxt = WorldState["CambionCycle"];
            SerializationWrappers.WarframeStats.CambionCycle.Data CambionState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.CambionCycle.Data>(objTxt.ToString());
            CycleTimersInfoBox.Text += ($"The current state of the cambion drift is {CambionState.Active} and expires in {(Math.Round(DateTime.Now.Subtract(CambionState.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours." + Environment.NewLine);

            objTxt = WorldState["Baro"];
            SerializationWrappers.WarframeStats.Baro.Data BaroState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Baro.Data>(objTxt.ToString());
            BaroInfoBox.Text += ($"{BaroState.Character} arrives at {BaroState.Location} at {BaroState.Expiry}.") + Environment.NewLine;

            objTxt = WorldState["Arbitration"];
            SerializationWrappers.WarframeStats.Arbitration.ArbitrationMission ArbitrationState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Arbitration.ArbitrationMission>(objTxt.ToString());
            ArbitrationInfoBox.Text += ($"{ArbitrationState.Enemy} {ArbitrationState.Type} on {ArbitrationState.Node} and expires in{(Math.Round(DateTime.Now.Subtract(ArbitrationState.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours.") + Environment.NewLine;

            objTxt = WorldState["Sortie"];
            SerializationWrappers.WarframeStats.Sortie.Sortie SortieState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Sortie.Sortie>(objTxt.ToString());
            SortieInfoBox.Text += ($"Daily sortie is {SortieState.Faction} {SortieState.Boss} and expires in{(Math.Round(DateTime.Now.Subtract(ArbitrationState.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours.") + Environment.NewLine;
            for (int i = 0; i < SortieState.Variants.Count; i++)
            {
                SortieInfoBox.Text += ($"{SortieState.Variants[i].Modifier} {SortieState.Variants[i].MissionType} on {SortieState.Variants[i].Node}" + Environment.NewLine);
            }

            objTxt = WorldState["Fissures"];
            List<SerializationWrappers.WarframeStats.Fissures.FissureEvent> FissureState = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeStats.Fissures.FissureEvent>>(objTxt.ToString());
            FissureState.Sort(delegate (SerializationWrappers.WarframeStats.Fissures.FissureEvent x, SerializationWrappers.WarframeStats.Fissures.FissureEvent y)
            {
                return x.TierNum.CompareTo(y.TierNum);
            });
            for (int i = 0; i < FissureState.Count; i++)
            {
                var expireTime = (Math.Round(DateTime.Now.Subtract(FissureState[i].Expiry).TotalMinutes * 10) / 10).ToString().Replace("-", "");
                if (double.Parse(expireTime) > 60)
                {
                    FissureInfoBox.Text += ($"Tier {FissureState[i].TierNum} {FissureState[i].Tier} Relic {FissureState[i].MissionType} Mission. Enemy Type {FissureState[i].Enemy} at {FissureState[i].Node} Expiring in {Math.Round(double.Parse(expireTime) / 60)} hours.") + Environment.NewLine;
                }
                else
                {
                    FissureInfoBox.Text += ($"Tier {FissureState[i].TierNum} {FissureState[i].Tier} Relic {FissureState[i].MissionType} Mission. Enemy Type {FissureState[i].Enemy} at {FissureState[i].Node} Expiring in {expireTime} minutes.") + Environment.NewLine;
                }
            }

            objTxt = WorldState["Nightwave"];
            SerializationWrappers.WarframeStats.Nightwave.Root NightwaveState = JsonConvert.DeserializeObject<SerializationWrappers.WarframeStats.Nightwave.Root>(objTxt.ToString());
            NightwaveChalContainer.Text = $"Nightwave Challenges For Season {NightwaveState.Season} Expires on {NightwaveState.Expiry}";
            for (int i = 0; i < NightwaveState.ActiveChallenges.Count; i++)
            {
                NightwaveInfoBox.Text += ($"{NightwaveState.ActiveChallenges[i].Desc} for {NightwaveState.ActiveChallenges[i].Reputation} points. Expires on {NightwaveState.ActiveChallenges[i].Expiry}" + Environment.NewLine);
            }
            #endregion
        }

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

            foreach (SerializationWrappers.WarframeAPI.Items.PrimaryWeapons.Root Primary_Weapon in Primary_Weapons)
            {
                if (Primary_Weapon.ProductCategory != "SentinelWeapons")
                {
                    PrimaryWeaponComboBox.Items.Add(Primary_Weapon.Name.ToString());
                }
            }
            #endregion

            #region Load Secondary Weapons
            List<SerializationWrappers.WarframeAPI.Items.SecondaryWeapons.Root> Secondary_Weapons = JsonConvert.DeserializeObject<List<SerializationWrappers.WarframeAPI.Items.SecondaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Secondary.json"));

            foreach (SerializationWrappers.WarframeAPI.Items.SecondaryWeapons.Root Secondary_Weapon in Secondary_Weapons)
            {
                if (Secondary_Weapon.ProductCategory != "SentinelWeapons")
                {
                    SecondaryWeaponsComboBox.Items.Add(Secondary_Weapon.Name.ToString());
                }
            }
            #endregion

            #region Load Melee Weapons

            #endregion

            #region Load Companion Data

            #endregion

            #region Load World State Data
            LoadWorldState();
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
        private void FindOrderInformation(string item_name, string order_type, bool tradeable)
        {
            if (tradeable)
            {
                SelectedItemInformation.activeItemName = $"{item_name} {order_type}";
                new OrderSheet().Show();
            }
            else
            {
                MessageBox.Show("The item you have searched is not a tradeable item.");
            }
        }

        #region Warframe Context Menu Commands
        private void findSetOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(WarframeComboBox.SelectedItem.ToString(), "Set", tradeable);
        }

        private void findNueroOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(WarframeComboBox.SelectedItem.ToString(), "Nueroptics", tradeable);
        }

        private void fiindChassiesOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(WarframeComboBox.SelectedItem.ToString(), "Chassis", tradeable);
        }

        private void findSystemsOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(WarframeComboBox.SelectedItem.ToString(), "Systems", tradeable);
        }

        private void findBlueprintOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(WarframeComboBox.SelectedItem.ToString(), "Blueprint", tradeable);
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