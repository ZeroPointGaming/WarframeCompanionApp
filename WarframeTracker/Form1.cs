using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using WarframeTracker.WebInterface;
//lzma compression using SevenZip.Compression.LZMA;

namespace WarframeTracker
{
    public partial class Form1 : Form
    {
        #region Declare Local Variables
        WTWebClient WebManager = new WTWebClient();
        Debug.Debug Debugger = new Debug.Debug();
        public string local_Json_directory = $"{Environment.CurrentDirectory}/data/json";
        public string local_media_directory = $"{Environment.CurrentDirectory}/data/img/";
        public string save_file = $"{Environment.CurrentDirectory}/data/inventory.json";

        private List<Items.Warframes.Root> Warframes = new List<Items.Warframes.Root>();
        private List<Items.PrimaryWeapons.Root> Primary_Weapons = new List<Items.PrimaryWeapons.Root>();
        private List<Items.SecondaryWeapons.Root> Secondary_Weapons = new List<Items.SecondaryWeapons.Root>();
        private List<Items.Melee.Root> Melee_Weapons = new List<Items.Melee.Root>();
        private List<Items.Sentinels.Root> Sentinel_List = new List<Items.Sentinels.Root>();
        private List<Items.Pets.Root> Pets_List = new List<Items.Pets.Root>();
        private List<Items.Archwing.Root> Archwings = new List<Items.Archwing.Root>();
        private List<Items.ArcGun.Root> ArchGuns = new List<Items.ArcGun.Root>();
        private List<Items.ArcMelee.Root> ArcMelee = new List<Items.ArcMelee.Root>();
        private List<Items.Arcanes.Root> Arcanes = new List<Items.Arcanes.Root>();
        private List<Items.Mods.Root> Mods = new List<Items.Mods.Root>();

        private ToolStripMenuItem WarframeMarketOptions = new ToolStripMenuItem();

        private string line_seperator = $"---------------------------------------------------------------{Environment.NewLine}";
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
            WarframeComboBox.SelectedIndex = 0;
            PrimaryWeaponComboBox.SelectedIndex = 0;
            SecondaryWeaponsComboBox.SelectedIndex = 0;
            MeleeWeaponsComboBox.SelectedIndex = 0;
            CompanionsComboBox.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GenerateData();
        }
        #endregion

        #region Combobox Event Code
        private void WarframeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Resets
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
            WarframeAbilitiesTxt.Text = "";
            SelectedWarframeImageBox.BackgroundImage = null;
            BPComponentImgBox.BackgroundImage = null;
            ChassCompImgBox.BackgroundImage = null;
            SysCompImgBox.BackgroundImage = null;
            NueroCompImgBox.BackgroundImage = null;
            WarframeComponentContainer.Text = String.Empty;
            WarframeComponentTxt.Text = String.Empty;
            #endregion

            try
            {
                #region Set Static Variables
                Items.Warframes.Root frame = GlobalData.WarframeDatabase[$"{WarframeComboBox.SelectedItem}"];
                GlobalData.activeItemName = frame.Name;
                WarframeComponentContainer.Text = $"{frame.Name} Components";
                #endregion

                #region Set Objct Image
                SelectedWarframeImageBox.BackgroundImage = WebManager.ServiceImage(frame.Name, frame.WikiaThumbnail);
                #endregion

                #region Set Abilities
                for (int i = 0; i < frame.Abilities.Count; i++)
                {
                    WarframeAbilitiesTxt.Text += $"{frame.Abilities[i].Name}:{Environment.NewLine}{frame.Abilities[i].Description}{Environment.NewLine}{line_seperator}";
                }

                if (frame.PassiveDescription != null) { WarframeAbilitiesTxt.Text += $"Passive Ability: {frame.PassiveDescription}{Environment.NewLine}"; }
                #endregion

                #region Set Warframe Componets, Drop Locations, Chances, Etc
                if (frame.Components != null)
                {
                    if (frame.Name.ToLower().Contains("prime"))
                    {
                        ToolStripMenuItem CheckVaultBtn = new ToolStripMenuItem();
                        CheckVaultBtn.Text = $"{frame.Name} Vault Status";
                        CheckVaultBtn.Click += GetContextMenuFunction;
                        FindOrdersMenu.Items.Add(CheckVaultBtn);
                        FindOrdersMenu.Items.Add(WarframeMarketOptions);
                        WarframeMarketOptions.Text = $"Warframe.Market Orders";
                        GenerateOrderMenu(frame.Name, "Set");
                    }

                    foreach (Items.Warframes.Component comp in frame.Components)
                    {
                        switch (comp.Name)
                        {
                            case "Blueprint":
                                BPComponentImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Blueprint");

                                    if (comp.Drops != null)
                                    {
                                        List<String> RelicLocations = SearchPrimeRelicItems($"{frame.Name} Blueprint");
                                        for (int i = 0; i < RelicLocations.Count; i++)
                                        {
                                            WarframeComponentTxt.Text += $"{RelicLocations[i]}{Environment.NewLine}";
                                        }
                                        WarframeComponentTxt.Text += line_seperator;
                                    }
                                }
                                else
                                {
                                    if (comp.Drops != null)
                                    {
                                        WarframeComponentTxt.Text += $"{frame.Name} {comp.Name} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}{Environment.NewLine}";
                                    }
                                    else
                                    {
                                        WarframeComponentTxt.Text += $"{WebManager.GetBlueprintInfo(frame.Name)}{Environment.NewLine}";
                                    }
                                }
                                break;
                            case "Chassis":
                                ChassCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Chassis");

                                    if (comp.Drops != null)
                                    {
                                        List<String> RelicLocations = SearchPrimeRelicItems($"{frame.Name} Chassis");
                                        for (int i = 0; i < RelicLocations.Count; i++)
                                        {
                                            WarframeComponentTxt.Text += $"{RelicLocations[i]}{Environment.NewLine}";
                                        }
                                        WarframeComponentTxt.Text += line_seperator;
                                    }
                                }
                                else
                                {
                                    if (comp.Drops != null)
                                    {
                                        WarframeComponentTxt.Text += $"{frame.Name} {comp.Name} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}{Environment.NewLine}";
                                    }
                                    else
                                    {
                                        WarframeComponentTxt.Text += $"Chassis Information Missing, Coming Soon!{Environment.NewLine}";
                                    }
                                }
                                break;
                            case "Neuroptics":
                                NueroCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Neuroptics");

                                    if (comp.Drops != null)
                                    {
                                        List<String> RelicLocations = SearchPrimeRelicItems($"{frame.Name} Neuroptics");
                                        for (int i = 0; i < RelicLocations.Count; i++)
                                        {
                                            WarframeComponentTxt.Text += $"{RelicLocations[i]}{Environment.NewLine}";
                                        }
                                        WarframeComponentTxt.Text += line_seperator;
                                    }
                                }
                                else
                                {
                                    if (comp.Drops != null)
                                    {
                                        WarframeComponentTxt.Text += $"{frame.Name} {comp.Name} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}{Environment.NewLine}";
                                    }
                                    else
                                    {
                                        WarframeComponentTxt.Text += $"Neuroptics Information Missing, Coming Soon!{Environment.NewLine}";
                                    }
                                }
                                break;
                            case "Systems":
                                SysCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Systems");

                                    if (comp.Drops != null)
                                    {
                                        List<String> RelicLocations = SearchPrimeRelicItems($"{frame.Name} Systems");
                                        for (int i = 0; i < RelicLocations.Count; i++)
                                        {
                                            WarframeComponentTxt.Text += $"{RelicLocations[i]}{Environment.NewLine}";
                                        }
                                        WarframeComponentTxt.Text += line_seperator;
                                    }
                                }
                                else
                                {
                                    if (comp.Drops != null)
                                    {
                                        WarframeComponentTxt.Text += $"{frame.Name} {comp.Name} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}{Environment.NewLine}";
                                    }
                                    else
                                    {
                                        WarframeComponentTxt.Text += $"Systems Information Missing, Coming Soon!{Environment.NewLine}";
                                    }
                                }
                                break;
                            default:

                                break;
                        }
                    }
                }
                #endregion

                //Debug Info
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Updated UI for {WarframeComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        private void PrimaryWeaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Reset
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
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
            PWComponentContainer.Visible = true;
            PWFoundryPanel.Visible = true;
            #endregion

            try
            {
                #region Set Static Variables
                Items.PrimaryWeapons.Root Weapon = GlobalData.PrimaryWeaponDatabase[$"{PrimaryWeaponComboBox.SelectedItem}"];
                GlobalData.activeItemName = Weapon.Name;
                #endregion

                #region Set main Weapon image
                if (Weapon.WikiaThumbnail != null)
                {
                    PrimaryGunImageBox.BackgroundImage = WebManager.ServiceImage(Weapon.Name.ToString(), Weapon.WikiaThumbnail);
                    PrimaryWeaponContainer.Text = Weapon.Name.ToString();
                    if (Weapon.SkipBuildTimePrice > 0)
                    {
                        PWFoundrySkipBuildLbl.Text = $"Skip Build Time Cost: {Weapon.SkipBuildTimePrice} platinum";
                        PWFoundrySkipBuildLbl.Visible = true;
                    }
                    else
                    {
                        PWFoundrySkipBuildLbl.Visible = false;
                    }
                }
                #endregion

                #region Set build cost in credits section
                PWFoundryCreditsImg.BackgroundImage = Image.FromFile(local_media_directory + "credits.png");
                PWFoundryCreditsTxt.Text = $"{Weapon.BuildPrice}";
                toolTip1.SetToolTip(PWFoundryCreditsTxt, "Build Cost");
                #endregion

                #region Set Foundry Component Data
                if (Weapon.Components != null)
                {
                    for (int i = 0; i < Weapon.Components.Count; i++)
                    {
                        if (i == 0)
                        {
                            //Set  component information
                            PWFoundrySlot0Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[0].ImageName);
                            PWFoundrySlot0Txt.Text = Weapon.Components[0].ItemCount.ToString();
                            toolTip1.SetToolTip(PWFoundrySlot0Txt, Weapon.Components[0].Name);
                            toolTip1.SetToolTip(PWFoundrySlot0Img, Weapon.Components[0].Name);
                        }
                        else if (i == 1)
                        {
                            PWFoundrySlot1Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[1].ImageName);
                            PWFoundrySlot1Txt.Text = Weapon.Components[1].ItemCount.ToString();
                            toolTip1.SetToolTip(PWFoundrySlot1Txt, Weapon.Components[1].Name);
                            toolTip1.SetToolTip(PWFoundrySlot1Img, Weapon.Components[1].Name);
                        }
                        else if (i == 2)
                        {
                            PWFoundrySlot2Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[2].ImageName);
                            PWFoundrySlot2Txt.Text = Weapon.Components[2].ItemCount.ToString();
                            toolTip1.SetToolTip(PWFoundrySlot2Txt, Weapon.Components[2].Name);
                            toolTip1.SetToolTip(PWFoundrySlot2Img, Weapon.Components[2].Name);
                        }
                        else if (i == 3)
                        {
                            PWFoundrySlot3Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[3].ImageName);
                            PWFoundrySlot3Txt.Text = Weapon.Components[3].ItemCount.ToString();
                            toolTip1.SetToolTip(PWFoundrySlot3Txt, Weapon.Components[3].Name);
                            toolTip1.SetToolTip(PWFoundrySlot3Img, Weapon.Components[3].Name);
                        }
                        else if (i == 4)
                        {
                            PWFoundrySlot4Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[4].ImageName);
                            PWFoundrySlot4Txt.Text = Weapon.Components[4].ItemCount.ToString();
                            toolTip1.SetToolTip(PWFoundrySlot4Txt, Weapon.Components[4].Name);
                            toolTip1.SetToolTip(PWFoundrySlot4Img, Weapon.Components[4].Name);
                        }
                    }
                }
                #endregion

                #region Set Market Cost & Build Time
                if (Weapon.MarketCost > 0)
                {
                    PWFoundryMarketPriceLbl.Text = $"Market Price: {Weapon.MarketCost} Platinum";
                    PWFoundryMarketPriceLbl.Visible = true;
                }
                else
                {
                    PWFoundryMarketPriceLbl.Visible = false;
                }

                if (Weapon.BuildTime > 0)
                {
                    PWFoundryBuildTime.Text = $"Build Time: {Weapon.BuildTime / 60} Minutes";
                    PWFoundryBuildTime.Visible = true;
                }
                else
                {
                    PWFoundryBuildTime.Visible = false;
                }
                #endregion

                #region Weapon Data
                PWDataTxt.Text += $"Cricical Chance: {Math.Round(Weapon.CriticalChance * 100)}{Environment.NewLine}";
                PWDataTxt.Text += $"Cricical Multiplier: {Weapon.CriticalMultiplier}{Environment.NewLine}";
                PWDataTxt.Text += $"Proc Chance: {Math.Round(Weapon.ProcChance * 100)}{Environment.NewLine}";
                PWDataTxt.Text += $"Fire Rate: {Weapon.FireRate}{Environment.NewLine}";
                PWDataTxt.Text += $"Accuracy: {Weapon.Accuracy}{Environment.NewLine}";
                PWDataTxt.Text += $"Multishot: {Weapon.Multishot}{Environment.NewLine}";
                PWDataTxt.Text += $"Reload Time: {Weapon.ReloadTime}s{Environment.NewLine}";
                PWDataTxt.Text += $"Riven Disposition: {Weapon.OmegaAttenuation}{Environment.NewLine}";

                //Export Damage Ammounts
                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    if (Weapon.DamagePerShot[i] > 0)
                    {
                        PWDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
                    }
                }
                #endregion

                #region Component Data & Order Menu
                if (Weapon.Components != null)
                {
                    for (int i = 0; i < Weapon.Components.Count; i++)
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

                            PWCompDataTxt.Text += line_seperator;
                        }
                    }

                    if (Weapon.Name.ToLower().Contains("prime"))
                    {
                        FindOrdersMenu.Items.Add(WarframeMarketOptions);
                        WarframeMarketOptions.Text = $"Warframe.Market Orders";
                        GenerateOrderMenu(Weapon.Name, "Set");
                    }

                    foreach (Items.PrimaryWeapons.Component Comp in Weapon.Components)
                    {
                        switch (Comp.Name)
                        {
                            case "Set":
                                GenerateOrderMenu(Weapon.Name, "Set");
                                break;
                            case "Blueprint":
                                GenerateOrderMenu(Weapon.Name, "Blueprint");
                                break;
                            case "Chassis":
                                GenerateOrderMenu(Weapon.Name, "Chassis");
                                break;
                            case "Neuroptics":
                                GenerateOrderMenu(Weapon.Name, "Neuroptics");
                                break;
                            case "Systems":
                                GenerateOrderMenu(Weapon.Name, "Systems");
                                break;
                            case "Barrel":
                                GenerateOrderMenu(Weapon.Name, "Barrel");
                                break;
                            case "Stock":
                                GenerateOrderMenu(Weapon.Name, "Stock");
                                break;
                            case "Reciever":
                                GenerateOrderMenu(Weapon.Name, "Reciever");
                                break;
                            case "Blade":
                                GenerateOrderMenu(Weapon.Name, "Blade");
                                break;
                            case "Hilt":
                                GenerateOrderMenu(Weapon.Name, "Hilt");
                                break;
                            case "Head":
                                GenerateOrderMenu(Weapon.Name, "Head");
                                break;
                            case "Link":
                                GenerateOrderMenu(Weapon.Name, "Link");
                                break;
                        }
                    }
                }
                else
                {
                    PWComponentContainer.Visible = false;
                }
                #endregion

                //Debug Info
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Updated UI for {PrimaryWeaponComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        private void SecondaryWeaponsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Reset
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
            SWWeaponDataTxt.Text = "";
            SWFoundryCreditsTxt.Text = "";
            SWSlot0Txt.Text = "";
            SWSlot1Txt.Text = "";
            SWSlot2Txt.Text = "";
            SWSlot3Txt.Text = "";
            SWSlot4Txt.Text = "";
            SWComponentDataTxt.Text = "";
            SWSlot01Img.BackgroundImage = null;
            SWSlot02Img.BackgroundImage = null;
            SWSlot03Img.BackgroundImage = null;
            SWSlot04Img.BackgroundImage = null;
            SWCreditsImgBox.BackgroundImage = null;
            SWFoundryCreditsTxt.Text = "";
            SWMarketPriceLbl.Text = "";
            SWBuildTimeLbl.Text = "";
            SWFoundrySkipBuildLbl.Text = "";
            #endregion

            try
            {
                #region Set Static Variables
                Items.SecondaryWeapons.Root Weapon = GlobalData.SecondaryWeaponDatabase[$"{SecondaryWeaponsComboBox.SelectedItem}"];
                GlobalData.activeItemName = Weapon.Name;
                #endregion

                #region Set main Weapon image
                if (Weapon.WikiaThumbnail != null)
                {
                    SecondaryWeaponImageBox.BackgroundImage = WebManager.ServiceImage($"{Weapon.Name}", Weapon.WikiaThumbnail);
                    SecondaryWeaponContainer.Text = $"{Weapon.Name}";
                    if (Weapon.SkipBuildTimePrice > 0)
                    {
                        SWFoundrySkipBuildLbl.Text = $"Skip Build Time Cost: {Weapon.SkipBuildTimePrice} platinum";
                        SWFoundrySkipBuildLbl.Visible = true;
                    }
                    else
                    {
                        SWFoundrySkipBuildLbl.Visible = false;
                    }
                }
                #endregion

                #region Set build cost in credits section
                SWCreditsImgBox.BackgroundImage = Image.FromFile(local_media_directory + "credits.png");
                SWFoundryCreditsTxt.Text = Weapon.BuildPrice.ToString();
                toolTip1.SetToolTip(SWFoundryCreditsTxt, "Build Cost");
                #endregion

                #region Set Foundry Component Data
                if (Weapon.Components != null)
                {
                    for (int i = 0; i < Weapon.Components.Count; i++)
                    {
                        if (i == 0)
                        {
                            //Set  component information
                            SWFoundrySlot0Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[0].ImageName);
                            SWSlot0Txt.Text = Weapon.Components[0].ItemCount.ToString();
                            toolTip1.SetToolTip(SWSlot0Txt, Weapon.Components[0].Name);
                            toolTip1.SetToolTip(SWFoundrySlot0Img, Weapon.Components[0].Name);
                        }
                        else if (i == 1)
                        {
                            SWSlot01Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[1].ImageName);
                            SWSlot1Txt.Text = Weapon.Components[1].ItemCount.ToString();
                            toolTip1.SetToolTip(SWSlot1Txt, Weapon.Components[1].Name);
                            toolTip1.SetToolTip(SWSlot01Img, Weapon.Components[1].Name);
                        }
                        else if (i == 2)
                        {
                            SWSlot02Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[2].ImageName);
                            SWSlot2Txt.Text = Weapon.Components[2].ItemCount.ToString();
                            toolTip1.SetToolTip(SWSlot2Txt, Weapon.Components[2].Name);
                            toolTip1.SetToolTip(SWSlot02Img, Weapon.Components[2].Name);
                        }
                        else if (i == 3)
                        {
                            SWSlot03Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[3].ImageName);
                            SWSlot3Txt.Text = Weapon.Components[3].ItemCount.ToString();
                            toolTip1.SetToolTip(SWSlot3Txt, Weapon.Components[3].Name);
                            toolTip1.SetToolTip(SWSlot03Img, Weapon.Components[3].Name);
                        }
                        else if (i == 4)
                        {
                            SWSlot04Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[4].ImageName);
                            SWSlot4Txt.Text = Weapon.Components[4].ItemCount.ToString();
                            toolTip1.SetToolTip(SWSlot4Txt, Weapon.Components[4].Name);
                            toolTip1.SetToolTip(SWSlot04Img, Weapon.Components[4].Name);
                        }
                    }
                }
                #endregion

                #region Export Component Drop Data
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
                                    SWComponentDataTxt.Text += $"{Weapon.Components[i].Drops[c].Type} Drops from {Weapon.Components[i].Drops[c].Location} with a {Math.Round((double)(Weapon.Components[i].Drops[c].Chance * 100))}% chance with a rarity class of {Weapon.Components[i].Drops[c].Rarity}{Environment.NewLine}";
                                }
                            }

                            SWComponentDataTxt.Text += line_seperator;
                        }
                    }
                }
                #endregion

                #region Generate Order Menu
                if (Weapon.Components != null)
                {
                    if (Weapon.Name.ToLower().Contains("prime"))
                    {
                        FindOrdersMenu.Items.Add(WarframeMarketOptions);
                        WarframeMarketOptions.Text = $"Warframe.Market Orders";
                        GenerateOrderMenu(Weapon.Name, "Set");
                    }

                    foreach (Items.SecondaryWeapons.Component Comp in Weapon.Components)
                    {
                        switch (Comp.Name)
                        {
                            case "Set":
                                GenerateOrderMenu(Weapon.Name, "Set");
                                break;
                            case "Blueprint":
                                GenerateOrderMenu(Weapon.Name, "Blueprint");
                                break;
                            case "Chassis":
                                GenerateOrderMenu(Weapon.Name, "Chassis");
                                break;
                            case "Neuroptics":
                                GenerateOrderMenu(Weapon.Name, "Neuroptics");
                                break;
                            case "Systems":
                                GenerateOrderMenu(Weapon.Name, "Systems");
                                break;
                            case "Barrel":
                                GenerateOrderMenu(Weapon.Name, "Barrel");
                                break;
                            case "Stock":
                                GenerateOrderMenu(Weapon.Name, "Stock");
                                break;
                            case "Reciever":
                                GenerateOrderMenu(Weapon.Name, "Reciever");
                                break;
                            case "Blade":
                                GenerateOrderMenu(Weapon.Name, "Blade");
                                break;
                            case "Hilt":
                                GenerateOrderMenu(Weapon.Name, "Hilt");
                                break;
                            case "Head":
                                GenerateOrderMenu(Weapon.Name, "Head");
                                break;
                            case "Link":
                                GenerateOrderMenu(Weapon.Name, "Link");
                                break;
                        }
                    }
                }
                #endregion

                #region Set Weapon Data
                SWWeaponDataTxt.Text += $"Cricical Chance: {Math.Round(Weapon.CriticalChance * 100)} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Cricical Multiplier: {Weapon.CriticalMultiplier} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Proc Chance: {Math.Round(Weapon.ProcChance * 100)} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Fire Rate: {Weapon.FireRate} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Accuracy: {Weapon.Accuracy} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Multishot: {Weapon.Multishot} {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Reload Time: {Weapon.ReloadTime}s {Environment.NewLine}";
                SWWeaponDataTxt.Text += $"Riven Disposition: {Weapon.OmegaAttenuation}{Environment.NewLine}";

                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    if (Weapon.DamagePerShot[i] > 0)
                    {
                        SWWeaponDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
                    }
                }

                if (Weapon.MarketCost != null)
                {
                    SWMarketPriceLbl.Text = $"Market Price: {Weapon.MarketCost} Platinum";
                    SWMarketPriceLbl.Visible = true;
                }
                else
                {
                    SWMarketPriceLbl.Visible = false;
                }

                if (Weapon.BuildTime > 0)
                {
                    SWBuildTimeLbl.Text = $"Build Time: {Weapon.BuildTime / 60} Minutes";
                    SWBuildTimeLbl.Visible = true;
                }
                else
                {
                    SWBuildTimeLbl.Visible = false;
                }
                #endregion

                //Debug Info
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Updated UI for {SecondaryWeaponsComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        private void MeleeWeaponsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Reset
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
            MWDataTxt.Text = "";
            MWCreditsTxt.Text = "";
            MWSlot0Txt.Text = "";
            MWSlot1Txt.Text = "";
            MWSlot2Txt.Text = "";
            MWSlot3Txt.Text = "";
            MWSlot4Txt.Text = "";
            MWWeaponCompDataTxt.Text = "";
            MWSlot0Img.BackgroundImage = null;
            MWSlot1Img.BackgroundImage = null;
            MWSlot2Img.BackgroundImage = null;
            MWSlot3Img.BackgroundImage = null;
            MWSlot4Img.BackgroundImage = null;
            MWCreditsImg.BackgroundImage = null;
            MWCreditsTxt.Text = "";
            MWMarketPriceLbl.Text = "";
            MWCreditCostLbl.Text = "";
            MWSkipBuildCostLbl.Text = "";
            #endregion

            try
            {
                #region Set Static Variables
                Items.Melee.Root Weapon = GlobalData.MeleeWeaponDatabase[$"{MeleeWeaponsComboBox.SelectedItem}"];
                GlobalData.activeItemName = Weapon.Name;
                #endregion

                #region Set main Weapon image
                if (Weapon.WikiaThumbnail != null)
                {
                    MWImageBox.BackgroundImage = WebManager.ServiceImage(Weapon.Name.ToString(), Weapon.WikiaThumbnail);
                    MeleeWeaponContainer.Text = Weapon.Name.ToString();
                    if (Weapon.SkipBuildTimePrice > 0)
                    {
                        MWSkipBuildCostLbl.Text = $"Skip Build Time Cost: {Weapon.SkipBuildTimePrice} platinum";
                        MWSkipBuildCostLbl.Visible = true;
                    }
                    else
                    {
                        MWSkipBuildCostLbl.Visible = false;
                    }
                }
                #endregion

                #region Set  build cost in credits section
                MWCreditsImg.BackgroundImage = Image.FromFile(local_media_directory + "credits.png");
                MWCreditsTxt.Text = Weapon.BuildPrice.ToString();
                toolTip1.SetToolTip(MWCreditsTxt, "Build Cost");
                #endregion

                #region Set Foundry Component Data
                if (Weapon.Components != null)
                {
                    for (int i = 0; i < Weapon.Components.Count; i++)
                    {
                        if (i == 0)
                        {
                            //Set  component information
                            MWSlot0Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[0].ImageName);
                            MWSlot0Txt.Text = Weapon.Components[0].ItemCount.ToString();
                            toolTip1.SetToolTip(MWSlot0Txt, Weapon.Components[0].Name);
                            toolTip1.SetToolTip(MWSlot0Img, Weapon.Components[0].Name);
                        }
                        else if (i == 1)
                        {
                            MWSlot1Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[1].ImageName);
                            MWSlot1Txt.Text = Weapon.Components[1].ItemCount.ToString();
                            toolTip1.SetToolTip(MWSlot1Txt, Weapon.Components[1].Name);
                            toolTip1.SetToolTip(MWSlot1Img, Weapon.Components[1].Name);
                        }
                        else if (i == 2)
                        {
                            MWSlot2Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[2].ImageName);
                            MWSlot2Txt.Text = Weapon.Components[2].ItemCount.ToString();
                            toolTip1.SetToolTip(MWSlot2Txt, Weapon.Components[2].Name);
                            toolTip1.SetToolTip(MWSlot2Img, Weapon.Components[2].Name);
                        }
                        else if (i == 3)
                        {
                            MWSlot3Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[3].ImageName);
                            MWSlot3Txt.Text = Weapon.Components[3].ItemCount.ToString();
                            toolTip1.SetToolTip(MWSlot3Txt, Weapon.Components[3].Name);
                            toolTip1.SetToolTip(MWSlot3Img, Weapon.Components[3].Name);
                        }
                        else if (i == 4)
                        {
                            MWSlot4Img.BackgroundImage = Image.FromFile(local_media_directory + Weapon.Components[4].ImageName);
                            MWSlot4Txt.Text = Weapon.Components[4].ItemCount.ToString();
                            toolTip1.SetToolTip(MWSlot4Txt, Weapon.Components[4].Name);
                            toolTip1.SetToolTip(MWSlot4Img, Weapon.Components[4].Name);
                        }
                    }
                }
                #endregion

                #region Set Weapon Data
                if (Weapon.MarketCost != null)
                {
                    MWMarketPriceLbl.Text = $"Market Price: {Weapon.MarketCost} Platinum";
                    MWMarketPriceLbl.Visible = true;
                }
                else
                {
                    MWMarketPriceLbl.Visible = false;
                }

                if (Weapon.BuildTime > 0)
                {
                    MWCreditCostLbl.Text = $"Build Time: {Weapon.BuildTime / 60} Minutes";
                    MWCreditCostLbl.Visible = true;
                }
                else
                {
                    MWCreditCostLbl.Visible = false;
                }

                MWDataTxt.Text += $"Cricical Chance: {Math.Round(Weapon.CriticalChance * 100)} {Environment.NewLine}";
                MWDataTxt.Text += $"Cricical Multiplier: {Weapon.CriticalMultiplier} {Environment.NewLine}";
                MWDataTxt.Text += $"Proc Chance: {Math.Round(Weapon.ProcChance * 100)} {Environment.NewLine}";
                MWDataTxt.Text += $"Attack Rate: {Weapon.FireRate} {Environment.NewLine}";
                MWDataTxt.Text += $"Combo Duration: {Weapon.ComboDuration} {Environment.NewLine}";
                MWDataTxt.Text += $"Heavy Attack Damage: {Weapon.HeavyAttackDamage} {Environment.NewLine}";
                MWDataTxt.Text += $"Slam Attack Damage: {Weapon.SlamAttack} {Environment.NewLine}";
                MWDataTxt.Text += $"Slam Attack Radial Damage: {Weapon.SlamRadialDamage} {Environment.NewLine}";
                MWDataTxt.Text += $"Slam Attack Radius: {Weapon.SlamRadius} {Environment.NewLine}";
                MWDataTxt.Text += $"Heavy Slam Attack Damage: {Weapon.HeavySlamAttack} {Environment.NewLine}";
                MWDataTxt.Text += $"Heavy Slam Attack Radial Damage: {Weapon.HeavySlamRadialDamage} {Environment.NewLine}";
                MWDataTxt.Text += $"Heavy Slam Attack Radius: {Weapon.HeavySlamRadius}{Environment.NewLine}";
                MWDataTxt.Text += $"Range: {Weapon.Range}s {Environment.NewLine}";
                MWDataTxt.Text += $"Riven Disposition: {Weapon.OmegaAttenuation}{Environment.NewLine}";
                MWDataTxt.Text += $"-----------------------------------------------------";

                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    if (Weapon.DamagePerShot[i] > 0)
                    {
                        MWDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
                    }
                }
                #endregion

                #region Generate Order Menu
                if (Weapon.Components != null)
                {
                    if (Weapon.Name.ToLower().Contains("prime"))
                    {
                        FindOrdersMenu.Items.Add(WarframeMarketOptions);
                        WarframeMarketOptions.Text = $"Warframe.Market Orders";
                        GenerateOrderMenu(Weapon.Name, "Set");
                    }

                    foreach (Items.Melee.Component Comp in Weapon.Components)
                    {
                        switch (Comp.Name)
                        {
                            case "Set":
                                GenerateOrderMenu(Weapon.Name, "Set");
                                break;
                            case "Blueprint":
                                GenerateOrderMenu(Weapon.Name, "Blueprint");
                                break;
                            case "Chassis":
                                GenerateOrderMenu(Weapon.Name, "Chassis");
                                break;
                            case "Neuroptics":
                                GenerateOrderMenu(Weapon.Name, "Neuroptics");
                                break;
                            case "Systems":
                                GenerateOrderMenu(Weapon.Name, "Systems");
                                break;
                            case "Barrel":
                                GenerateOrderMenu(Weapon.Name, "Barrel");
                                break;
                            case "Stock":
                                GenerateOrderMenu(Weapon.Name, "Stock");
                                break;
                            case "Reciever":
                                GenerateOrderMenu(Weapon.Name, "Reciever");
                                break;
                            case "Blade":
                                GenerateOrderMenu(Weapon.Name, "Blade");
                                break;
                            case "Hilt":
                                GenerateOrderMenu(Weapon.Name, "Hilt");
                                break;
                            case "Head":
                                GenerateOrderMenu(Weapon.Name, "Head");
                                break;
                            case "Link":
                                GenerateOrderMenu(Weapon.Name, "Link");
                                break;
                        }
                    }
                }
                #endregion

                #region Export component drop data
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
                                    MWWeaponCompDataTxt.Text += $"{Weapon.Components[i].Drops[c].Type} Drops from {Weapon.Components[i].Drops[c].Location} with a {Math.Round((double)(Weapon.Components[i].Drops[c].Chance * 100))}% chance with a rarity class of {Weapon.Components[i].Drops[c].Rarity}{Environment.NewLine}";
                                }
                            }

                            MWWeaponCompDataTxt.Text += line_seperator;
                        }
                    }
                }
                #endregion

                //Debug Info
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Updated UI for {MeleeWeaponsComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        private void CompanionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Resets
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
            CompanionImageBox.BackgroundImage = null;
            CompanionDescriptionTxt.Text = String.Empty;
            CompanionComponentTxt.Text = String.Empty;
            CompanionStatsTxt.Text = String.Empty;
            CompanionStatsContainer.Text = "companion_name";
            CompanionDescriptionContainer.Text = "companion_name";
            CompanionComponentContainer.Text = "companion_name";
            CompanionComponentContainer.Visible = true;
            CompanionDescriptionContainer.Visible = true;
            CompanionStatsContainer.Visible = true;
            ComponentDropsContainer.Visible = true;
            CopmpanionDropsTxt.Text = String.Empty;
            #endregion

            try
            {
                if (GlobalData.PetsDatabase.ContainsKey($"{CompanionsComboBox.SelectedItem}"))
                {
                    #region Process Pets
                    Items.Pets.Root Pet = GlobalData.PetsDatabase[$"{CompanionsComboBox.SelectedItem}"];
                    GlobalData.activeItemName = Pet.Name;

                    if (Pet.ImageName != null)
                    {
                        #region Set Image 
                        CompanionImageBox.BackgroundImage = Image.FromFile($"{local_media_directory}{Pet.ImageName}");
                        #endregion

                        #region Set Companion Description
                        CompanionDescriptionContainer.Text = $"{Pet.Name} Description";
                        CompanionDescriptionTxt.Text = Pet.Description;
                        #endregion

                        #region Set Companion Stats
                        CompanionStatsContainer.Text = $"{Pet.Name} Stats";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Health: {Pet.Health}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Shield: {Pet.Shield}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Armor: {Pet.Armor}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Stamina: {Pet.Stamina}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Power: {Pet.Power}{Environment.NewLine}";
                        #endregion

                        #region Set Component Data
                        CompanionComponentContainer.Text = $"{Pet.Name} Compnent Data";

                        if (Pet.Components != null)
                        {
                            for (int i = 0; i < Pet.Components.Count; i++)
                            {
                                CompanionComponentTxt.Text += $"{Pet.Components[i].Name} x{Pet.Components[i].ItemCount}{Environment.NewLine}";

                                if (Pet.Components[i].Drops != null)
                                {
                                    for (int x = 0; x < Pet.Components[i].Drops.Count; x++)
                                    {
                                        if (!Pet.Components[i].Drops[x].Type.ToLower().Contains("forma"))
                                        {
                                            CopmpanionDropsTxt.Text += $"{Pet.Components[i].Drops[x].Type} drops from {Pet.Components[i].Drops[x].Location} with a {Math.Round((double)Pet.Components[i].Drops[x].Chance * double.Parse("100"))}% chance with a rarity class of {Pet.Components[i].Drops[x].Rarity}.{Environment.NewLine}";
                                        }
                                    }
                                }
                                else
                                {
                                    ComponentDropsContainer.Visible = false;
                                }
                            }

                            #region Generate Order Menu
                            if (Pet.Name.ToLower().Contains("prime"))
                            {
                                FindOrdersMenu.Items.Add(WarframeMarketOptions);
                                WarframeMarketOptions.Text = $"Warframe.Market Orders";
                                GenerateOrderMenu(Pet.Name, "Set");
                            }

                            for (int x = 0; x < Pet.Components.Count; x++)
                            {
                                switch (Pet.Components[x].Name)
                                {
                                    case "Set":
                                        GenerateOrderMenu(Pet.Name, "Set");
                                        break;
                                    case "Carapace":
                                        GenerateOrderMenu(Pet.Name, "Carapace");
                                        break;
                                    case "Cerebrum":
                                        GenerateOrderMenu(Pet.Name, "Cerebrum");
                                        break;
                                    case "Systems":
                                        GenerateOrderMenu(Pet.Name, "Systems");
                                        break;
                                    case "Blueprint":
                                        GenerateOrderMenu(Pet.Name, "Blueprint");
                                        break;
                                }
                            }
                            #endregion
                        }
                        else
                        {
                            CompanionComponentContainer.Visible = false;
                            ComponentDropsContainer.Visible = false;
                        }
                        #endregion
                    }
                    #endregion
                }
                else if (GlobalData.SentinelsDatabase.ContainsKey($"{CompanionsComboBox.SelectedItem}"))
                {
                    #region Process Sentinels
                    Items.Sentinels.Root Pet = GlobalData.SentinelsDatabase[$"{CompanionsComboBox.SelectedItem}"];
                    GlobalData.activeItemName = Pet.Name;

                    if (Pet.ImageName != null)
                    {
                        #region Set Image 
                        CompanionImageBox.BackgroundImage = Image.FromFile($"{local_media_directory}{Pet.ImageName}");
                        #endregion

                        #region Set Companion Description
                        CompanionDescriptionContainer.Text = $"{Pet.Name} Description";
                        CompanionDescriptionTxt.Text = Pet.Description;
                        #endregion

                        #region Set Companion Stats
                        CompanionStatsContainer.Text = $"{Pet.Name} Stats";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Health: {Pet.Health}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Shield: {Pet.Shield}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Armor: {Pet.Armor}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Stamina: {Pet.Stamina}{Environment.NewLine}";
                        CompanionStatsTxt.Text += $"{Pet.Name} Base Power: {Pet.Power}{Environment.NewLine}";
                        #endregion

                        #region Set Component Data
                        CompanionComponentContainer.Text = $"{Pet.Name} Compnent Data";

                        if (Pet.Components != null)
                        {
                            for (int i = 0; i < Pet.Components.Count; i++)
                            {
                                CompanionComponentTxt.Text += $"{Pet.Components[i].Name} x{Pet.Components[i].ItemCount}{Environment.NewLine}";

                                if (Pet.Components[i].Drops != null)
                                {
                                    for (int x = 0; x < Pet.Components[i].Drops.Count; x++)
                                    {
                                        if (!Pet.Components[i].Drops[x].Type.ToLower().Contains("forma"))
                                        {
                                            CopmpanionDropsTxt.Text += $"{Pet.Components[i].Drops[x].Type} drops from {Pet.Components[i].Drops[x].Location} with a {Math.Round((double)Pet.Components[i].Drops[x].Chance * double.Parse("100"))}% chance with a rarity class of {Pet.Components[i].Drops[x].Rarity}.{Environment.NewLine}";
                                        }
                                    }
                                }
                                else
                                {
                                    ComponentDropsContainer.Visible = false;
                                }
                            }
                        }
                        else
                        {
                            CompanionComponentContainer.Visible = false;
                            ComponentDropsContainer.Visible = false;
                        }
                        #endregion

                        #region Generate Order Menu
                        if (Pet.Name.ToLower().Contains("prime"))
                        {
                            FindOrdersMenu.Items.Add(WarframeMarketOptions);
                            WarframeMarketOptions.Text = $"Warframe.Market Orders";
                            GenerateOrderMenu(Pet.Name, "Set");
                        }

                        for (int x = 0; x < Pet.Components.Count; x++)
                        {
                            switch (Pet.Components[x].Name)
                            {
                                case "Set":
                                    GenerateOrderMenu(Pet.Name, "Set");
                                    break;
                                case "Carapace":
                                    GenerateOrderMenu(Pet.Name, "Carapace");
                                    break;
                                case "Cerebrum":
                                    GenerateOrderMenu(Pet.Name, "Cerebrum");
                                    break;
                                case "Systems":
                                    GenerateOrderMenu(Pet.Name, "Systems");
                                    break;
                                case "Blueprint":
                                    GenerateOrderMenu(Pet.Name, "Blueprint");
                                    break;
                            }
                        }

                        #endregion
                        //Debug Info
                        if (Properties.Settings.Default.debug_mode)
                        {
                            Debugger.Log($"Updated UI for {MeleeWeaponsComboBox.SelectedItem}");
                        }
                    }
                    #endregion
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Warning, An uncaught IO Exception Occurred. Please send a screenshot of this error window to our github in an issue request and explain what you were doing when the error occurred. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }
        #endregion

        #region Data Generation Code
        /// <summary>
        /// Returns the damage string for the given inputs
        /// </summary>
        /// <param name="DamageId">Damage id</param>
        /// <param name="ammount">Damage ammount</param>
        /// <returns></returns>
        private string GetDamageType(int DamageId, double ammount)
        {
            switch (DamageId)
            {
                case 0:
                    return $"Base Physical Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 1:
                    return $"Impact/Puncture Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 2:
                    return $"Slash Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 3:
                    return $"Heat Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 4:
                    return $"Cold Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 5:
                    return $"Electricity Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 6:
                    return $"Toxin Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 7:
                    return $"Blast Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 8:
                    return $"Radiation Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 9:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 10:
                    return $"Magnetic Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 11:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 12:
                    return $"Corrosive Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 13:
                    return $"Viral Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 14:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 15:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 16:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 17:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 18:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                case 19:
                    return $"??? Damage: {Math.Round(ammount)} {Environment.NewLine}";
                default:
                    return "Unknown Damage Type";
            }
        }

        /// <summary>
        /// Loads the world state into the application
        /// [NOT FINISHED]
        /// </summary>
        private void LoadWorldState()
        {
            #region Resets
            CycleTimersInfoBox.Text = String.Empty;
            SortieInfoBox.Text = String.Empty;
            NightwaveInfoBox.Text = String.Empty;
            ArbitrationInfoBox.Text = String.Empty;
            FissureInfoBox.Text = String.Empty;
            SyndicateInfoBox.Text = String.Empty;
            BaroInfoBox.Text = String.Empty;
            DailyInfoBox.Text = String.Empty;
            OstronInfoBox.Text = String.Empty;
            SolarisInfoBox.Text = String.Empty;
            EntratiInfoBox.Text = String.Empty;
            #endregion

            HttpWebRequest world_state_request = WebManager.GenerateRequest("", "WorldState", "pc");
            HttpWebResponse world_state_response = WebManager.GenerateResponse(world_state_request);

            StreamReader reader = new StreamReader(world_state_response.GetResponseStream()); 
            WarframeStats.WorldSpace.Root WorldInformation = JsonConvert.DeserializeObject<WarframeStats.WorldSpace.Root>(reader.ReadToEnd()); 
            reader.Close(); reader.Dispose(); world_state_response.Close(); world_state_response.Dispose();

            #region Load Data
            CycleTimersInfoBox.Text += ($"The current earth state is {WorldInformation.EarthCycle.State} time and will change in {WorldInformation.EarthCycle.TimeLeft}." + Environment.NewLine);
            CycleTimersInfoBox.Text += ($"The current cetus state is {WorldInformation.CetusCycle.State} time and will change in {WorldInformation.CetusCycle.TimeLeft}." + Environment.NewLine);
            CycleTimersInfoBox.Text += ($"The current orb vallis state is {WorldInformation.VallisCycle.State} and will change in {WorldInformation.VallisCycle.TimeLeft}." + Environment.NewLine);
            CycleTimersInfoBox.Text += ($"The current state of the cambion drift is {WorldInformation.CambionCycle.Active} and expires in {(Math.Round(DateTime.Now.Subtract(WorldInformation.CambionCycle.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours." + Environment.NewLine);

            BaroInfoBox.Text += ($"{WorldInformation.VoidTrader.Character} arrives at {WorldInformation.VoidTrader.Location} at {WorldInformation.VoidTrader.Expiry}.") + Environment.NewLine;
            ArbitrationInfoBox.Text += ($"{WorldInformation.Arbitration.Enemy} {WorldInformation.Arbitration.Type} on {WorldInformation.Arbitration.Node} and expires in{(Math.Round(DateTime.Now.Subtract(WorldInformation.Arbitration.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours.") + Environment.NewLine;

            SortieInfoBox.Text += ($"Daily sortie is {WorldInformation.Sortie.Faction} {WorldInformation.Sortie.Boss} and expires in{(Math.Round(DateTime.Now.Subtract(WorldInformation.Sortie.Expiry).TotalHours * 10) / 10).ToString().Replace("-", " ")} hours.") + Environment.NewLine;
            for (int i = 0; i < WorldInformation.Sortie.Variants.Count; i++)
            {
                SortieInfoBox.Text += ($"{WorldInformation.Sortie.Variants[i].Modifier} {WorldInformation.Sortie.Variants[i].MissionType} on {WorldInformation.Sortie.Variants[i].Node}" + Environment.NewLine);
            }

            WorldInformation.Fissures.Sort(delegate (WarframeStats.WorldSpace.Fissure x, WarframeStats.WorldSpace.Fissure y)
            {
                return x.TierNum.CompareTo(y.TierNum);
            });
            for (int i = 0; i < WorldInformation.Fissures.Count; i++)
            {
                var expireTime = (Math.Round(DateTime.Now.Subtract(WorldInformation.Fissures[i].Expiry).TotalMinutes * 10) / 10).ToString().Replace("-", "");
                if (double.Parse(expireTime) > 60)
                {
                    FissureInfoBox.Text += ($"Tier {WorldInformation.Fissures[i].TierNum} {WorldInformation.Fissures[i].Tier} Relic {WorldInformation.Fissures[i].MissionType} Mission. Enemy Type {WorldInformation.Fissures[i].Enemy} at {WorldInformation.Fissures[i].Node} Expiring in {Math.Round(double.Parse(expireTime) / 60)} hours.") + Environment.NewLine;
                }
                else
                {
                    FissureInfoBox.Text += ($"Tier {WorldInformation.Fissures[i].TierNum} {WorldInformation.Fissures[i].Tier} Relic {WorldInformation.Fissures[i].MissionType} Mission. Enemy Type {WorldInformation.Fissures[i].Enemy} at {WorldInformation.Fissures[i].Node} Expiring in {expireTime} minutes.") + Environment.NewLine;
                }
            }

            NightwaveChalContainer.Text = $"Nightwave Challenges For Season {WorldInformation.Nightwave.Season} Expires on {WorldInformation.Nightwave.Expiry}";
            for (int i = 0; i < WorldInformation.Nightwave.ActiveChallenges.Count; i++)
            {
                NightwaveInfoBox.Text += ($"{WorldInformation.Nightwave.ActiveChallenges[i].Desc} for {WorldInformation.Nightwave.ActiveChallenges[i].Reputation} points. Expires on {WorldInformation.Nightwave.ActiveChallenges[i].Expiry}" + Environment.NewLine);
            }

            //SyndicateGroupBox.Text = $"{}";
            for (int i = 0; i < WorldInformation.SyndicateMissions.Count; i++)
            {
                //SyndicateInfoBox.Text += ($"{WorldInformation.SyndicateMissions[i].Syndicate}" + Environment.NewLine);
            }

            //TODO Sort bounties into their respective boxes?
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
            MeleeWeaponsComboBox.Items.Clear();
            SecondaryWeaponsComboBox.Items.Clear();
            CompanionsComboBox.Items.Clear();
            #endregion

            #region IO Operations
            try
            {
                if (Warframes.Count < 1) { Warframes = JsonConvert.DeserializeObject<List<Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json")); }
                if (Primary_Weapons.Count < 1) { Primary_Weapons = JsonConvert.DeserializeObject<List<Items.PrimaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Primary.json")); }
                if (Secondary_Weapons.Count < 1) { Secondary_Weapons = JsonConvert.DeserializeObject<List<Items.SecondaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Secondary.json")); }
                if (Melee_Weapons.Count < 1) { Melee_Weapons = JsonConvert.DeserializeObject<List<Items.Melee.Root>>(File.ReadAllText(local_Json_directory + "/Melee.json")); }
                if (Sentinel_List.Count < 1) { Sentinel_List = JsonConvert.DeserializeObject<List<Items.Sentinels.Root>>(File.ReadAllText(local_Json_directory + "/Sentinels.json")); }
                if (Pets_List.Count < 1) { Pets_List = JsonConvert.DeserializeObject<List<Items.Pets.Root>>(File.ReadAllText(local_Json_directory + "/Pets.json")); }
                if (Archwings.Count < 1) { Archwings = JsonConvert.DeserializeObject<List<Items.Archwing.Root>>(File.ReadAllText(local_Json_directory + "/Archwing.json")); }
                if (ArchGuns.Count < 1) { ArchGuns = JsonConvert.DeserializeObject<List<Items.ArcGun.Root>>(File.ReadAllText(local_Json_directory + "/Arch-Gun.json")); }
                if (ArcMelee.Count < 1) { ArcMelee = JsonConvert.DeserializeObject<List<Items.ArcMelee.Root>>(File.ReadAllText(local_Json_directory + "/Arch-Melee.json")); }
                if (Arcanes.Count < 1) { Arcanes = JsonConvert.DeserializeObject<List<Items.Arcanes.Root>>(File.ReadAllText(local_Json_directory + "/Arcanes.json")); }
                if (Mods.Count < 1) { Mods = JsonConvert.DeserializeObject<List<Items.Mods.Root>>(File.ReadAllText(local_Json_directory + "/Mods.json")); }
                //if (Enemies.Count < 1) { }
            }
            catch (Exception ex)
            {
                Debugger.Log($"Error loading hadcoded json data {Environment.NewLine}Stack Trace: {ex}");
            }
            #endregion

            #region Loop Items Into Comboboxes
            if (Warframes.Count > 0)
            {
                foreach (Items.Warframes.Root frame in Warframes)
                {
                    if (!GlobalData.WarframeDatabase.ContainsKey(frame.Name)) { GlobalData.WarframeDatabase.Add(frame.Name, frame); }
                    WarframeComboBox.Items.Add(frame.Name.ToString());
                }
            }
            
            if (Primary_Weapons.Count > 0)
            {
                foreach (Items.PrimaryWeapons.Root Primary_Weapon in Primary_Weapons)
                {
                    if (!GlobalData.PrimaryWeaponDatabase.ContainsKey(Primary_Weapon.Name)) { GlobalData.PrimaryWeaponDatabase.Add(Primary_Weapon.Name, Primary_Weapon); }

                    if (Primary_Weapon.ProductCategory != "SentinelWeapons")
                    {
                        PrimaryWeaponComboBox.Items.Add(Primary_Weapon.Name.ToString());
                    }
                }
            }
            
            if (Secondary_Weapons.Count > 0)
            {
                foreach (Items.SecondaryWeapons.Root Secondary_Weapon in Secondary_Weapons)
                {
                    if (!GlobalData.SecondaryWeaponDatabase.ContainsKey(Secondary_Weapon.Name)) { GlobalData.SecondaryWeaponDatabase.Add(Secondary_Weapon.Name, Secondary_Weapon); }

                    if (Secondary_Weapon.ProductCategory != "SentinelWeapons")
                    {
                        SecondaryWeaponsComboBox.Items.Add(Secondary_Weapon.Name.ToString());
                    }
                }
            }
            
            if (Melee_Weapons.Count > 0)
            {
                foreach (Items.Melee.Root Melee_Weapon in Melee_Weapons)
                {
                    if (!GlobalData.MeleeWeaponDatabase.ContainsKey(Melee_Weapon.Name)) { GlobalData.MeleeWeaponDatabase.Add(Melee_Weapon.Name, Melee_Weapon); }
                    MeleeWeaponsComboBox.Items.Add(Melee_Weapon.Name.ToString());
                }
            }
            
            if (Pets_List.Count > 0)
            {
                foreach (Items.Pets.Root Pet in Pets_List)
                {
                    if (!GlobalData.PetsDatabase.ContainsKey(Pet.Name)) { GlobalData.PetsDatabase.Add(Pet.Name, Pet); }
                    CompanionsComboBox.Items.Add(Pet.Name);
                }
            }
            
            if (Pets_List.Count > 0)
            {
                foreach (Items.Sentinels.Root Sentinel in Sentinel_List)
                {
                    if (!GlobalData.SentinelsDatabase.ContainsKey(Sentinel.Name)) { GlobalData.SentinelsDatabase.Add(Sentinel.Name, Sentinel); }
                    CompanionsComboBox.Items.Add(Sentinel.Name);
                }
            }
            #endregion

            LoadWorldState();
        }

        /// <summary>
        /// Fetch and store the vaulted data
        /// </summary>
        private void FetchVaultData()
        {
            try
            {
                #region Resets
                GlobalData.VaultData = new OGTech.ValutedItemData.Root();
                #endregion

                HttpWebRequest vault_data_request = WebManager.GenerateRequest("", "VaultData", "pc");
                HttpWebResponse vault_data_response = WebManager.GenerateResponse(vault_data_request);

                StreamReader reader = new StreamReader(vault_data_response.GetResponseStream());
                GlobalData.VaultData = JsonConvert.DeserializeObject<OGTech.ValutedItemData.Root>(reader.ReadToEnd());
                reader.Close(); reader.Dispose(); vault_data_response.Close(); vault_data_response.Dispose();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Error fetching vault data.{Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }

        /// <summary>
        /// Fetch and store the drops data
        /// </summary>
        private void FetchDropsData()
        {
            try
            {
                #region Resets
                GlobalData.DropsData = new WarframeStats.DropData.Root();
                #endregion

                HttpWebRequest drop_data_request = WebManager.GenerateRequest("", "Drops", "pc");
                HttpWebResponse drop_data_response = WebManager.GenerateResponse(drop_data_request);

                StreamReader reader = new StreamReader(drop_data_response.GetResponseStream());
                GlobalData.DropsData = JsonConvert.DeserializeObject<WarframeStats.DropData.Root>(reader.ReadToEnd());
                reader.Close(); reader.Dispose(); drop_data_response.Close(); drop_data_response.Dispose();
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Error fetching drops data.{Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }
        #endregion

        #region Settings Code
        /// <summary>
        /// Updates the background color for application controls.
        /// </summary>
        /// <param name="new_color">Color object input</param>
        private void UpdateBackgroundColor(Color new_color)
        {
            #region GroupBoxes
            groupBox1.BackColor = new_color;
            WarframeComponentContainer.BackColor = new_color;
            groupBox6.BackColor = new_color;
            groupBox7.BackColor = new_color;
            groupBox8.BackColor = new_color;
            groupBox9.BackColor = new_color;
            groupBox10.BackColor = new_color;
            groupBox11.BackColor = new_color;
            groupBox12.BackColor = new_color;
            groupBox13.BackColor = new_color;
            groupBox14.BackColor = new_color;
            groupBox15.BackColor = new_color;
            groupBox16.BackColor = new_color;
            groupBox17.BackColor = new_color;
            groupBox18.BackColor = new_color;
            groupBox19.BackColor = new_color;
            groupBox20.BackColor = new_color;
            WarframeAbilitiesContainer.BackColor = new_color;
            CompanionComponentContainer.BackColor = new_color;
            CompanionDescriptionContainer.BackColor = new_color;
            CompanionStatsContainer.BackColor = new_color;
            ComponentDropsContainer.BackColor = new_color;
            MeleeWeaponContainer.BackColor = new_color;
            MeleeWeaponContainer.BackColor = new_color;
            NightwaveChalContainer.BackColor = new_color;
            PrimaryWeaponContainer.BackColor = new_color;
            PWComponentContainer.BackColor = new_color;
            PWWeaponDmgContainer.BackColor = new_color;
            SecondaryWeaponContainer.BackColor = new_color;
            #endregion

            #region TabPages
            SettingsTabPage.BackColor = new_color;
            WarframeTabPage.BackColor = new_color;
            MeleeWeaponsTabPage.BackColor = new_color;
            PetsTabPage.BackColor = new_color;
            PrimWeaponsTabPage.BackColor = new_color;
            SecWeaponsTabPage.BackColor = new_color;
            WorldStatePage.BackColor = new_color;
            #endregion

            #region Labels
            label1.BackColor = new_color;
            label10.BackColor = new_color;
            label2.BackColor = new_color;
            label3.BackColor = new_color;
            label4.BackColor = new_color;
            label5.BackColor = new_color;
            label6.BackColor = new_color;
            label7.BackColor = new_color;
            label8.BackColor = new_color;
            label9.BackColor = new_color;
            #endregion

            #region TextBoxes
            MWSlot0Txt.BackColor = new_color;
            MWSlot1Txt.BackColor = new_color;
            MWSlot2Txt.BackColor = new_color;
            MWSlot3Txt.BackColor = new_color;
            MWSlot4Txt.BackColor = new_color;
            PWFoundrySlot0Txt.BackColor = new_color;
            PWFoundrySlot1Txt.BackColor = new_color;
            PWFoundrySlot2Txt.BackColor = new_color;
            PWFoundrySlot3Txt.BackColor = new_color;
            PWFoundrySlot4Txt.BackColor = new_color;
            SWSlot1Txt.BackColor = new_color;
            SWSlot2Txt.BackColor = new_color;
            SWSlot3Txt.BackColor = new_color;
            SWSlot4Txt.BackColor = new_color;
            CompanionComponentTxt.BackColor = new_color;
            CompanionDescriptionTxt.BackColor = new_color; 
            CompanionStatsTxt.BackColor = new_color;
            CopmpanionDropsTxt.BackColor = new_color;
            WarframeComponentTxt.BackColor = new_color;
            MWCreditsTxt.BackColor = new_color;
            MWDataTxt.BackColor = new_color;
            MWSlot0Txt.BackColor = new_color;
            MWSlot1Txt.BackColor = new_color;
            MWSlot2Txt.BackColor = new_color;
            MWSlot3Txt.BackColor = new_color;
            MWSlot4Txt.BackColor = new_color;
            MWWeaponCompDataTxt.BackColor = new_color;
            PWCompDataTxt.BackColor = new_color;
            PWDataTxt.BackColor = new_color;
            PWFoundryCreditsTxt.BackColor = new_color;
            PWFoundrySlot0Txt.BackColor = new_color;
            PWFoundrySlot1Txt.BackColor = new_color;
            PWFoundrySlot2Txt.BackColor = new_color;
            PWFoundrySlot3Txt.BackColor = new_color;
            PWFoundrySlot4Txt.BackColor = new_color;
            SWComponentDataTxt.BackColor = new_color;
            SWFoundryCreditsTxt.BackColor = new_color;
            SWSlot0Txt.BackColor = new_color;
            SWSlot1Txt.BackColor = new_color;
            SWSlot2Txt.BackColor = new_color;
            SWSlot3Txt.BackColor = new_color;
            SWSlot4Txt.BackColor = new_color;
            SWWeaponDataTxt.BackColor = new_color;
            NightwaveInfoBox.BackColor = new_color;
            OstronInfoBox.BackColor = new_color;
            SolarisInfoBox.BackColor = new_color;
            SortieInfoBox.BackColor = new_color;
            SyndicateInfoBox.BackColor = new_color;
            ArbitrationInfoBox.BackColor = new_color;
            BaroInfoBox.BackColor = new_color;
            CycleTimersInfoBox.BackColor = new_color;
            DailyInfoBox.BackColor = new_color;
            FissureInfoBox.BackColor = new_color;
            EntratiInfoBox.BackColor = new_color;
            WarframeAbilitiesTxt.BackColor = new_color;
            #endregion

            #region ImageBoxes
            MWSlot0Img.BackColor = new_color;
            MWSlot1Img.BackColor = new_color;
            MWSlot2Img.BackColor = new_color;
            MWSlot3Img.BackColor = new_color;
            MWSlot4Img.BackColor = new_color;
            PWFoundrySlot1Img.BackColor = new_color;
            PWFoundrySlot2Img.BackColor = new_color;
            PWFoundrySlot3Img.BackColor = new_color;
            PWFoundrySlot4Img.BackColor = new_color;
            PWFoundrySlot0Img.BackColor = new_color;
            SWFoundrySlot0Img.BackColor = new_color;
            SWSlot01Img.BackColor = new_color;
            SWSlot02Img.BackColor = new_color;
            SWSlot03Img.BackColor = new_color;
            SWSlot04Img.BackColor = new_color;
            #endregion
        }

        /// <summary>
        /// Updates the foreground color for application controls.
        /// </summary>
        /// <param name="new_color">Color object input</param>
        private void UpdateForeColor(Color new_color)
        {
            #region GroupBoxes
            groupBox1.ForeColor = new_color;
            WarframeComponentContainer.ForeColor = new_color;
            groupBox6.ForeColor = new_color;
            groupBox7.ForeColor = new_color;
            groupBox8.ForeColor = new_color;
            groupBox9.ForeColor = new_color;
            groupBox10.ForeColor = new_color;
            groupBox11.ForeColor = new_color;
            groupBox12.ForeColor = new_color;
            groupBox13.ForeColor = new_color;
            groupBox14.ForeColor = new_color;
            groupBox15.ForeColor = new_color;
            groupBox16.ForeColor = new_color;
            groupBox17.ForeColor = new_color;
            groupBox18.ForeColor = new_color;
            groupBox19.ForeColor = new_color;
            groupBox20.ForeColor = new_color;
            WarframeAbilitiesContainer.ForeColor = new_color;
            CompanionComponentContainer.ForeColor = new_color;
            CompanionDescriptionContainer.ForeColor = new_color;
            CompanionStatsContainer.ForeColor = new_color;
            ComponentDropsContainer.ForeColor = new_color;
            MeleeWeaponContainer.ForeColor = new_color;
            MeleeWeaponContainer.ForeColor = new_color;
            NightwaveChalContainer.ForeColor = new_color;
            PrimaryWeaponContainer.ForeColor = new_color;
            PWComponentContainer.ForeColor = new_color;
            PWWeaponDmgContainer.ForeColor = new_color;
            SecondaryWeaponContainer.ForeColor = new_color;
            #endregion

            #region TabPages
            SettingsTabPage.ForeColor = new_color;
            WarframeTabPage.ForeColor = new_color;
            MeleeWeaponsTabPage.ForeColor = new_color;
            PetsTabPage.ForeColor = new_color;
            PrimWeaponsTabPage.ForeColor = new_color;
            SecWeaponsTabPage.ForeColor = new_color;
            WorldStatePage.ForeColor = new_color;
            #endregion

            #region Labels
            label1.ForeColor = new_color;
            label10.ForeColor = new_color;
            label2.ForeColor = new_color;
            label3.ForeColor = new_color;
            label4.ForeColor = new_color;
            label5.ForeColor = new_color;
            label6.ForeColor = new_color;
            label7.ForeColor = new_color;
            label8.ForeColor = new_color;
            label9.ForeColor = new_color;
            #endregion

            #region TextBoxes
            MWSlot0Txt.ForeColor = new_color;
            MWSlot1Txt.ForeColor = new_color;
            MWSlot2Txt.ForeColor = new_color;
            MWSlot3Txt.ForeColor = new_color;
            MWSlot4Txt.ForeColor = new_color;
            PWFoundrySlot0Txt.ForeColor = new_color;
            PWFoundrySlot1Txt.ForeColor = new_color;
            PWFoundrySlot2Txt.ForeColor = new_color;
            PWFoundrySlot3Txt.ForeColor = new_color;
            PWFoundrySlot4Txt.ForeColor = new_color;
            SWSlot1Txt.ForeColor = new_color;
            SWSlot2Txt.ForeColor = new_color;
            SWSlot3Txt.ForeColor = new_color;
            SWSlot4Txt.ForeColor = new_color;
            CompanionComponentTxt.ForeColor = new_color;
            CompanionDescriptionTxt.ForeColor = new_color;
            CompanionStatsTxt.ForeColor = new_color;
            CopmpanionDropsTxt.ForeColor = new_color;
            WarframeComponentTxt.ForeColor = new_color;
            MWCreditsTxt.ForeColor = new_color;
            MWDataTxt.ForeColor = new_color;
            MWSlot0Txt.ForeColor = new_color;
            MWSlot1Txt.ForeColor = new_color;
            MWSlot2Txt.ForeColor = new_color;
            MWSlot3Txt.ForeColor = new_color;
            MWSlot4Txt.ForeColor = new_color;
            MWWeaponCompDataTxt.ForeColor = new_color;
            PWCompDataTxt.ForeColor = new_color;
            PWDataTxt.ForeColor = new_color;
            PWFoundryCreditsTxt.ForeColor = new_color;
            PWFoundrySlot0Txt.ForeColor = new_color;
            PWFoundrySlot1Txt.ForeColor = new_color;
            PWFoundrySlot2Txt.ForeColor = new_color;
            PWFoundrySlot3Txt.ForeColor = new_color;
            PWFoundrySlot4Txt.ForeColor = new_color;
            SWComponentDataTxt.ForeColor = new_color;
            SWFoundryCreditsTxt.ForeColor = new_color;
            SWSlot0Txt.ForeColor = new_color;
            SWSlot1Txt.ForeColor = new_color;
            SWSlot2Txt.ForeColor = new_color;
            SWSlot3Txt.ForeColor = new_color;
            SWSlot4Txt.ForeColor = new_color;
            SWWeaponDataTxt.ForeColor = new_color;
            NightwaveInfoBox.ForeColor = new_color;
            OstronInfoBox.ForeColor = new_color;
            SolarisInfoBox.ForeColor = new_color;
            SortieInfoBox.ForeColor = new_color;
            SyndicateInfoBox.ForeColor = new_color;
            ArbitrationInfoBox.ForeColor = new_color;
            BaroInfoBox.ForeColor = new_color;
            CycleTimersInfoBox.ForeColor = new_color;
            DailyInfoBox.ForeColor = new_color;
            FissureInfoBox.ForeColor = new_color;
            EntratiInfoBox.ForeColor = new_color;
            WarframeAbilitiesTxt.ForeColor = new_color;
            #endregion

            #region ImageBoxes
            MWSlot0Img.ForeColor = new_color;
            MWSlot1Img.ForeColor = new_color;
            MWSlot2Img.ForeColor = new_color;
            MWSlot3Img.ForeColor = new_color;
            MWSlot4Img.ForeColor = new_color;
            PWFoundrySlot1Img.ForeColor = new_color;
            PWFoundrySlot2Img.ForeColor = new_color;
            PWFoundrySlot3Img.ForeColor = new_color;
            PWFoundrySlot4Img.ForeColor = new_color;
            PWFoundrySlot0Img.ForeColor = new_color;
            SWFoundrySlot0Img.ForeColor = new_color;
            SWSlot01Img.ForeColor = new_color;
            SWSlot02Img.ForeColor = new_color;
            SWSlot03Img.ForeColor = new_color;
            SWSlot04Img.ForeColor = new_color;
            #endregion
        }

        private void SwitchPlatformCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.platform = $"{SwitchPlatformComboBox.SelectedItem}";
            Properties.Settings.Default.Save();
        }

        private void ThemeBackgroundColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            UpdateBackgroundColor(colorDialog1.Color);
        }

        private void ThemeForegroundColorBtn_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            UpdateForeColor(colorDialog1.Color);
        }
        #endregion

        #region Inventory Code
        public void UpdateInventoryState(string item_name, bool owned)
        {
            if (!GlobalData.LocalInventory.ContainsKey(item_name))
            {
                GlobalData.LocalInventory.Add(item_name, owned);
            }
            else
            {
                GlobalData.LocalInventory[item_name] = owned;
            }

            SaveInventoryState(GlobalData.LocalInventory);
        }

        public void SaveInventoryState(Dictionary<String, Boolean> Save_Data)
        {
            if (!File.Exists(save_file))
            {
                FileStream FileMaker = File.Create(save_file); FileMaker.Close(); FileMaker.Dispose();
                var SerializedInventory = JsonConvert.SerializeObject(Save_Data);
                File.WriteAllText(SerializedInventory, save_file);
            }
            else
            {
                var SerializedInventory = JsonConvert.SerializeObject(Save_Data);
                File.WriteAllText(SerializedInventory, save_file);
            }
        }

        public void LoadInventoryState()
        {
            GlobalData.LocalInventory = JsonConvert.DeserializeObject<Dictionary<string, Boolean>>(save_file);
        }
        #endregion

        #region ContextMenu Code
        /// <summary>
        /// Open the orders form and display open orders for the input item and order type.
        /// </summary>
        /// <param name="item_name">Item/Frame Name</param>
        /// <param name="order_type">Order Type Parameter</param>
        /// <param name="tradeable">Unused boolean</param>
        private void FindOrderInformation(string item_name, string order_type, bool tradeable)
        {
            GlobalData.activeItemName = $"{item_name}";
            GlobalData.activeSearch = $"{order_type}";
            new OrderSheet().Show();
        }

        /// <summary>
        /// Generates the context menu for the orders
        /// </summary>
        /// <param name="item_name">Item name</param>
        /// <param name="order_name">Order type</param>
        private void GenerateOrderMenu(string item_name, string order_name)
        {
            switch (order_name)
            {
                case "Set":
                    ToolStripMenuItem SetOrderBtn = new ToolStripMenuItem();
                    SetOrderBtn.Text = $"{item_name} Set";
                    SetOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(SetOrderBtn);
                    break;
                case "Blueprint":
                    ToolStripMenuItem BluePrintOrderBtn = new ToolStripMenuItem();
                    BluePrintOrderBtn.Text = $"{item_name} Blueprint";
                    BluePrintOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(BluePrintOrderBtn);
                    break;
                case "Chassis":
                    ToolStripMenuItem ChassisOrderBtn = new ToolStripMenuItem();
                    ChassisOrderBtn.Text = $"{item_name} Chassis";
                    ChassisOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(ChassisOrderBtn);
                    break;
                case "Neuroptics":
                    ToolStripMenuItem NeuropticsOrderBtn = new ToolStripMenuItem();
                    NeuropticsOrderBtn.Text = $"{item_name} Neuroptics";
                    NeuropticsOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(NeuropticsOrderBtn);
                    break;
                case "Systems":
                    ToolStripMenuItem SystemsOrderBtn = new ToolStripMenuItem();
                    SystemsOrderBtn.Text = $"{item_name} Systems";
                    SystemsOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(SystemsOrderBtn);
                    break;
                case "Barrel":
                    ToolStripMenuItem BarrelOrderBtn = new ToolStripMenuItem();
                    BarrelOrderBtn.Text = $"{item_name} Barrel";
                    BarrelOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(BarrelOrderBtn);
                    break;
                case "Stock":
                    ToolStripMenuItem StockOrderBtn = new ToolStripMenuItem();
                    StockOrderBtn.Text = $"{item_name} Stock";
                    StockOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(StockOrderBtn);
                    break;
                case "Reciever":
                    ToolStripMenuItem RecieverOrderBtn = new ToolStripMenuItem();
                    RecieverOrderBtn.Text = $"{item_name} Reciever";
                    RecieverOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(RecieverOrderBtn);
                    break;
                case "Blade":
                    ToolStripMenuItem BladeOrderBtn = new ToolStripMenuItem();
                    BladeOrderBtn.Text = $"{item_name} Blade";
                    BladeOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(BladeOrderBtn);
                    break;
                case "Hilt":
                    ToolStripMenuItem HiltOrderBtn = new ToolStripMenuItem();
                    HiltOrderBtn.Text = $"{item_name} Hilt";
                    HiltOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(HiltOrderBtn);
                    break;
                case "Head":
                    ToolStripMenuItem HeadOrderBtn = new ToolStripMenuItem();
                    HeadOrderBtn.Text = $"{item_name} Head";
                    HeadOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(HeadOrderBtn);
                    break;
                case "Link":
                    ToolStripMenuItem LinkOrderBtn = new ToolStripMenuItem();
                    LinkOrderBtn.Text = $"{item_name} Link";
                    LinkOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(LinkOrderBtn);
                    break;
                case "Carapace":
                    ToolStripMenuItem CarapaceOrderBtn = new ToolStripMenuItem();
                    CarapaceOrderBtn.Text = $"{item_name} Carapace";
                    CarapaceOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(CarapaceOrderBtn);
                    break;
                case "Cerebrum":
                    ToolStripMenuItem CerebrumOrderBtn = new ToolStripMenuItem();
                    CerebrumOrderBtn.Text = $"{item_name} Cerebrum";
                    CerebrumOrderBtn.Click += GetContextMenuFunction;

                    WarframeMarketOptions.DropDownItems.Add(CerebrumOrderBtn);
                    break;
            }
        }

        /// <summary>
        /// Checks to see if a specific item is in the vaulted items data.
        /// </summary>
        /// <param name="item_name">Item Name</param>
        /// <returns></returns>
        private string GetVaultInformation(string item_name)
        {
            if (GlobalData.VaultData.Data != null)
            {
                for (int i = 0; i < GlobalData.VaultData.Data.Count; i++)
                {
                    if (GlobalData.VaultData.Data[i].Name == item_name && GlobalData.VaultData.Data[i].Vaulted)
                    {
                        return $"{item_name} was last vaulted on {GlobalData.VaultData.Data[i].VaultedDate} and was last released on {GlobalData.VaultData.Data[i].ReleaseDate}";
                    }
                }
            }
            else
            {
                FetchVaultData();

                for (int i = 0; i < GlobalData.VaultData.Data.Count; i++)
                {
                    if (GlobalData.VaultData.Data[i].Name == item_name && GlobalData.VaultData.Data[i].Vaulted)
                    {
                        return $"{item_name} was last vaulted on {GlobalData.VaultData.Data[i].VaultedDate} and was last released on {GlobalData.VaultData.Data[i].ReleaseDate}";
                    }
                }
            }

            return $"{item_name} is not currently vaulted";
        }

        /// <summary>
        /// Returns a list of prime relic drop info strings given an input item name.
        /// </summary>
        /// <param name="item_name"></param>
        /// <returns></returns>
        private List<string> SearchPrimeRelicItems(string item_name)
        {
            List<string> drop_info = new List<string>();

            try
            {
                if (GlobalData.DropsData.Relics != null)
                {
                    for (int i = 0; i < GlobalData.DropsData.Relics.Count; i++)
                    {
                        foreach (WarframeStats.DropData.Reward Reward in GlobalData.DropsData.Relics[i].Rewards)
                        {
                            if (Reward.ItemName.Contains(item_name))
                            {
                                drop_info.Add($"{Reward.ItemName} drops from {GlobalData.DropsData.Relics[i].Tier} {GlobalData.DropsData.Relics[i].RelicName} {GlobalData.DropsData.Relics[i].State} with a {Reward.Chance}% chance.");
                            }
                        }
                    }

                    return drop_info;
                }
                else
                {
                    FetchDropsData();

                    for (int i = 0; i < GlobalData.DropsData.Relics.Count; i++)
                    {
                        foreach (WarframeStats.DropData.Reward Reward in GlobalData.DropsData.Relics[i].Rewards)
                        {
                            if (Reward.ItemName.Contains(item_name))
                            {
                                drop_info.Add($"{Reward.ItemName} drops from {GlobalData.DropsData.Relics[i].Tier} {GlobalData.DropsData.Relics[i].RelicName} {GlobalData.DropsData.Relics[i].State} with a {Reward.Chance}% chance.");
                            }
                        }
                    }

                    return drop_info;
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Error searching for prime relic items. {Environment.NewLine}Stack Trace: {ex}");
                }

                return drop_info;
            }
        }

        private string GetDropData(string item_name)
        {
            if (GlobalData.DropsData.Relics != null)
            {

                return $"";
            }
            else
            {
                FetchDropsData();

                return $"";
            }
        }

        /// <summary>
        /// Returns the desired context menu function given the input order type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetContextMenuFunction(object sender, EventArgs e)
        {
            if (sender.ToString().Contains("Vault Status"))
            {
                MessageBox.Show(GetVaultInformation(GlobalData.activeItemName));
            }
            else if (sender.ToString().Contains("Set"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Set", true);
            }
            else if (sender.ToString().Contains("Nueroptics"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Nueroptics", true);
            }
            else if (sender.ToString().Contains("Chassis"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Chassis", true);
            }
            else if (sender.ToString().Contains("Systems"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Systems", true);
            }
            else if (sender.ToString().Contains("Blueprint"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Blueprint", true);
            }
            else if (sender.ToString().Contains("Barrel"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Barrel", true);
            }
            else if (sender.ToString().Contains("Stock"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Stock", true);
            }
            else if (sender.ToString().Contains("Reciever"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Reciever", true);
            }
            else if (sender.ToString().Contains("Blade"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Blade", true);
            }
            else if (sender.ToString().Contains("Hilt"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Hilt", true);
            }
            else if (sender.ToString().Contains("Head"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Head", true);
            }
            else if (sender.ToString().Contains("Link"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Link", true);
            }
            else if (sender.ToString().Contains("Carapace"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Carapace", true);
            }
            else if (sender.ToString().Contains("Cerebrum"))
            {
                FindOrderInformation(GlobalData.activeItemName, "Cerebrum", true);
            }
            else if (sender.ToString().Contains("Refresh"))
            {
                GenerateData();
            }
        }
        #endregion
    }

    public static class GlobalData
    {
        public static string activeItemName = String.Empty;
        public static string activeSearch = String.Empty;

        #region Item Databases
        public static Dictionary<String, Items.Warframes.Root> WarframeDatabase = new Dictionary<string, Items.Warframes.Root>();
        public static Dictionary<String, Items.PrimaryWeapons.Root> PrimaryWeaponDatabase = new Dictionary<string, Items.PrimaryWeapons.Root>();
        public static Dictionary<String, Items.SecondaryWeapons.Root> SecondaryWeaponDatabase = new Dictionary<string, Items.SecondaryWeapons.Root>();
        public static Dictionary<String, Items.Melee.Root> MeleeWeaponDatabase = new Dictionary<string, Items.Melee.Root>();
        public static Dictionary<String, Items.Sentinels.Root> SentinelsDatabase = new Dictionary<string, Items.Sentinels.Root>();
        public static Dictionary<String, Items.Pets.Root> PetsDatabase = new Dictionary<string, Items.Pets.Root>();
        public static Dictionary<String, Items.Archwing.Root> ArchwingDatabase = new Dictionary<string, Items.Archwing.Root>();
        public static Dictionary<String, Items.ArcGun.Root> ArcGunDatabase = new Dictionary<string, Items.ArcGun.Root>();
        public static Dictionary<String, Items.ArcMelee.Root> ArcMeleeDatabase = new Dictionary<string, Items.ArcMelee.Root>();
        public static Dictionary<String, Items.Arcanes.Root> ArcaneDatabase = new Dictionary<string, Items.Arcanes.Root>();
        public static Dictionary<String, Items.Mods.Root> ModDatabase = new Dictionary<string, Items.Mods.Root>();
        #endregion

        public static OGTech.ValutedItemData.Root VaultData = new OGTech.ValutedItemData.Root();
        public static WarframeStats.DropData.Root DropsData = new WarframeStats.DropData.Root();

        public static Dictionary<String, Boolean> LocalInventory = new Dictionary<String, Boolean>();
    }
}