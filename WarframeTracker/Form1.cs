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
    /// <summary> ACTIVE BUGS DIRECTORY
    /// [Identified] FLUCTUS Weapon has a empty page, need to look into what is going on. (no damage, components or drop data)
    /// [Identified] Necrophage frames dont have images yet.
    /// [Partial-Fixed] Necrophage frames dont contain components, components need to be reset between each changed frame.
    /// [Identified] Prisma Grinlock Primary Weapon page is mostly empty (No components, no drop data)
    /// [Identified] Relics expiry time is off in WorldSpace
    /// </summary>

    /// <summary> TODO List
    /// Build and finish Pets and Sentinels page.
    /// Come up with a plan for the build guides and crafting guides pages.
    /// Design and build the settings page and settings file for the application (Theme Control, Platform Control, Other Settings)
    /// Build a system that allows the user to save what frames/weapons/items they have by checking a box or something. (Inventory System)
    /// Rebuild the way drop data is looked at, using the new drop data api from warframestat.us
    /// Context menu check to see if item is vaulted.
    /// add riven disposition to weapons (OmegaAttenuation)
    /// 
    /// Future: Integrate apis into a discord bot so people can parse all of this data into their servers and their uses can run commands such as !drops or !vaulted
    /// </summary>
    

    public partial class Form1 : Form
    {
        #region Declare Local Variables
        WTWebClient WebManager = new WTWebClient();
        Debug.Debug Debugger = new Debug.Debug();
        public string local_Json_directory = Environment.CurrentDirectory.ToString() + "/data/json";
        public string local_media_directory = Environment.CurrentDirectory.ToString() + "/data/img/";
        public bool DebugMode = true;

        private List<Items.Warframes.Root> Warframes;
        private List<Items.PrimaryWeapons.Root> Primary_Weapons;
        private List<Items.SecondaryWeapons.Root> Secondary_Weapons;
        private List<Items.Melee.Root> Melee_Weapons;
        private List<Items.Sentinels.Root> Sentinel_List;
        private List<Items.Pets.Root> Pets_List;
        private List<Items.Archwing.Root> Archwings;
        private List<Items.ArcGun.Root> ArchGuns;
        private List<Items.ArcMelee.Root> ArcMelee;
        private List<Items.Arcanes.Root> Arcanes;
        private List<Items.Mods.Root> Mods;

        private ToolStripMenuItem WarframeMarketOptions = new ToolStripMenuItem();
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
        private void CheckVaultBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetVaultInformation(GlobalData.activeItemName));
        }

        private void WarframeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Resets
            FindOrdersMenu.Items.Clear();
            WarframeMarketOptions.DropDownItems.Clear();
            WarframeAbilityGroupbox1.Text = String.Empty;
            WarframeAbilityGroupbox2.Text = String.Empty;
            WarframeAbilityGroupbox3.Text = String.Empty;
            WarframeAbilityGroupbox4.Text = String.Empty;
            PassiveAbilityTextbox.Text = String.Empty;
            SelectedWarframeImageBox.BackgroundImage = null;
            BPComponentImgBox.BackgroundImage = null;
            ChassCompImgBox.BackgroundImage = null;
            SysCompImgBox.BackgroundImage = null;
            NueroCompImgBox.BackgroundImage = null;
            FrameBPTxtBox.Text = String.Empty;
            FrameChassTxtBox.Text = String.Empty;
            FrameNueroTxtBox.Text = String.Empty;
            FrameSysTxtBox.Text = String.Empty;
            #endregion

            try
            {
                #region Set Static Variables
                Items.Warframes.Root frame = GlobalData.WarframeDatabase[$"{WarframeComboBox.SelectedItem}"];
                GlobalData.activeItemName = frame.Name;
                #endregion

                #region Set Objct Image
                SelectedWarframeImageBox.BackgroundImage = WebManager.ServiceImage(frame.Name, frame.WikiaThumbnail);
                #endregion

                #region Set Abilities
                WarframeAbilityGroupbox1.Text = $"{frame.Abilities[0].Name}";
                WarframeAbilityTextBox1.Text = $"{frame.Abilities[0].Description}";
                WarframeAbilityGroupbox2.Text = $"{frame.Abilities[1].Name}";
                WarframeAbilityTextbox2.Text = $"{frame.Abilities[1].Description}";
                WarframeAbilityGroupbox3.Text = $"{frame.Abilities[2].Name}";
                WarframeAbilityTextbox3.Text = $"{frame.Abilities[2].Description}";
                WarframeAbilityGroupbox4.Text = $"{frame.Abilities[3].Name}";
                WarframeAbilityTextbox4.Text = $"{frame.Abilities[3].Description}";

                if (frame.PassiveDescription != null) { PassiveAbilityTextbox.Text = frame.PassiveDescription; }
                #endregion

                #region Set Warframe Componets, Drop Locations, Chances, Etc
                if (frame.Components != null)
                {
                    if (frame.Name.ToLower().Contains("prime"))
                    {
                        ToolStripMenuItem CheckVaultBtn = new ToolStripMenuItem();
                        CheckVaultBtn.Text = $"{frame.Name} Vault Status";
                        CheckVaultBtn.Click += CheckVaultBtn_Click;
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
                                FrameBPTxtBox.Text = WebManager.GetBlueprintInfo(frame.Name);

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Blueprint");
                                }
                                break;
                            case "Chassis":
                                ChassCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                FrameChassTxtBox.Text = "";

                                if (comp.Drops != null)
                                {
                                    FrameChassTxtBox.Text = $"{comp.Description} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}";
                                }
                                else
                                {
                                    FrameChassTxtBox.Text = "Information Missing, Coming Soon!";
                                }

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Chassis");
                                }
                                break;
                            case "Neuroptics":
                                NueroCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                FrameNueroTxtBox.Text = "";

                                if (comp.Drops != null)
                                {
                                    FrameNueroTxtBox.Text = $"{comp.Description} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}";
                                }
                                else
                                {
                                    FrameNueroTxtBox.Text = "Information Missing, Coming Soon!";
                                }

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Neuroptics");
                                }
                                break;
                            case "Systems":
                                SysCompImgBox.BackgroundImage = Image.FromFile(local_media_directory + comp.ImageName);
                                FrameSysTxtBox.Text = "";

                                if (comp.Drops != null)
                                {
                                    FrameSysTxtBox.Text = $"{comp.Description} Can be found on: {comp.Drops[0].Location} with a drop chance of {Math.Round((double)comp.Drops[0].Chance * (double)100)}% With a rarity class of {comp.Drops[0].Rarity}";
                                }
                                else
                                {
                                    FrameSysTxtBox.Text = "Information Missing, Coming Soon!";
                                }

                                if (frame.Name.ToLower().Contains("prime"))
                                {
                                    GenerateOrderMenu(frame.Name, "Systems");
                                }
                                break;
                            default:

                                break;
                        }
                    }
                }
                #endregion

                //Debug Info
                if (DebugMode)
                {
                    Debugger.Log($"Updated UI for {WarframeComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
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

                //Export Damage Ammounts
                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    PWDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
                }
                #endregion

                #region Component Data & Order Menu
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
                #endregion

                //Debug Info
                if (DebugMode)
                {
                    Debugger.Log($"Updated UI for {PrimaryWeaponComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
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

                            SWComponentDataTxt.Text += $"---------------------------------------------------------------------{Environment.NewLine}";
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

                //Export Damage Ammounts
                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    SWWeaponDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
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
                if (DebugMode)
                {
                    Debugger.Log($"Updated UI for {SecondaryWeaponsComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
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
                MWDataTxt.Text += $"-----------------------------------------------------";

                //Export Damage Ammounts
                for (int i = 0; i < Weapon.DamagePerShot.Count; i++)
                {
                    MWDataTxt.Text += GetDamageType(i, Weapon.DamagePerShot[i]);
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

                            MWWeaponCompDataTxt.Text += $"----------------------------------------------------------------------{Environment.NewLine}";
                        }
                    }
                }
                #endregion

                //Debug Info
                if (DebugMode)
                {
                    Debugger.Log($"Updated UI for {MeleeWeaponsComboBox.SelectedItem}");
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
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
                        if (DebugMode)
                        {
                            Debugger.Log($"Updated UI for {MeleeWeaponsComboBox.SelectedItem}");
                        }
                    }
                    #endregion
                }
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning, Data Directory Not Found! Please verify that the data folder exists in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.FileNotFoundException ex)
            {
                if (DebugMode)
                {
                    Debugger.Log($"Warning File Missing, Please verify that the data folder exists and has all of the correct files in the same directory as the exe file. {Environment.NewLine}Stack Trace: {ex}");
                }
            }
            catch (System.IO.IOException ex)
            {
                if (DebugMode)
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
                    return "Error";
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
            #endregion

            #region IO Operations
            try
            {
                Warframes = JsonConvert.DeserializeObject<List<Items.Warframes.Root>>(File.ReadAllText(local_Json_directory + "/Warframes.json"));
                Primary_Weapons = JsonConvert.DeserializeObject<List<Items.PrimaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Primary.json"));
                Secondary_Weapons = JsonConvert.DeserializeObject<List<Items.SecondaryWeapons.Root>>(File.ReadAllText(local_Json_directory + "/Secondary.json"));
                Melee_Weapons = JsonConvert.DeserializeObject<List<Items.Melee.Root>>(File.ReadAllText(local_Json_directory + "/Melee.json"));
                Sentinel_List = JsonConvert.DeserializeObject<List<Items.Sentinels.Root>>(File.ReadAllText(local_Json_directory + "/Sentinels.json"));
                Pets_List = JsonConvert.DeserializeObject<List<Items.Pets.Root>>(File.ReadAllText(local_Json_directory + "/Pets.json"));
                Archwings = JsonConvert.DeserializeObject<List<Items.Archwing.Root>>(File.ReadAllText(local_Json_directory + "/Archwing.json"));
                ArchGuns = JsonConvert.DeserializeObject<List<Items.ArcGun.Root>>(File.ReadAllText(local_Json_directory + "/Arch-Gun.json"));
                ArcMelee = JsonConvert.DeserializeObject<List<Items.ArcMelee.Root>>(File.ReadAllText(local_Json_directory + "/Arch-Melee.json"));
                Arcanes = JsonConvert.DeserializeObject<List<Items.Arcanes.Root>>(File.ReadAllText(local_Json_directory + "/Arcanes.json"));
                Mods = JsonConvert.DeserializeObject<List<Items.Mods.Root>>(File.ReadAllText(local_Json_directory + "/Mods.json"));
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
                    WarframeComboBox.Items.Add(frame.Name.ToString());
                    GlobalData.WarframeDatabase.Add(frame.Name, frame);
                }
            }
            
            if (Primary_Weapons.Count > 0)
            {
                foreach (Items.PrimaryWeapons.Root Primary_Weapon in Primary_Weapons)
                {
                    GlobalData.PrimaryWeaponDatabase.Add(Primary_Weapon.Name, Primary_Weapon);

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
                    GlobalData.SecondaryWeaponDatabase.Add(Secondary_Weapon.Name, Secondary_Weapon);

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
                    GlobalData.MeleeWeaponDatabase.Add(Melee_Weapon.Name, Melee_Weapon);
                    MeleeWeaponsComboBox.Items.Add(Melee_Weapon.Name.ToString());
                }
            }
            
            if (Pets_List.Count > 0)
            {
                foreach (Items.Pets.Root Pet in Pets_List)
                {
                    GlobalData.PetsDatabase.Add(Pet.Name, Pet);
                    CompanionsComboBox.Items.Add(Pet.Name);
                }
            }
            
            if (Pets_List.Count > 0)
            {
                foreach (Items.Sentinels.Root Sentinel in Sentinel_List)
                {
                    GlobalData.SentinelsDatabase.Add(Sentinel.Name, Sentinel);
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
                if (DebugMode)
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
                if (DebugMode)
                {
                    Debugger.Log($"Error fetching drops data.{Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }
        #endregion

        #region Settings Code

        #endregion

        #region Build Guides Code

        #endregion

        #region Crafting Guides Code

        #endregion

        #region ContextMenu Code
        private void FindOrderInformation(string item_name, string order_type, bool tradeable)
        {
            GlobalData.activeItemName = $"{item_name}";
            GlobalData.activeSearch = $"{order_type}";
            new OrderSheet().Show();
        }

        private void GenerateOrderMenu(string item_name, string order_name)
        {
            switch (order_name)
            {
                case "Set":
                    ToolStripMenuItem SetOrderBtn = new ToolStripMenuItem();
                    SetOrderBtn.Text = $"{item_name} Set";
                    SetOrderBtn.Click += FindSetOrdersMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(SetOrderBtn);
                    break;
                case "Blueprint":
                    ToolStripMenuItem BluePrintOrderBtn = new ToolStripMenuItem();
                    BluePrintOrderBtn.Text = $"{item_name} Blueprint";
                    BluePrintOrderBtn.Click += FindBlueprintMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(BluePrintOrderBtn);
                    break;
                case "Chassis":
                    ToolStripMenuItem ChassisOrderBtn = new ToolStripMenuItem();
                    ChassisOrderBtn.Text = $"{item_name} Chassis";
                    ChassisOrderBtn.Click += FindChassisMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(ChassisOrderBtn);
                    break;
                case "Neuroptics":
                    ToolStripMenuItem NeuropticsOrderBtn = new ToolStripMenuItem();
                    NeuropticsOrderBtn.Text = $"{item_name} Neuroptics";
                    NeuropticsOrderBtn.Click += FindNueropticsMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(NeuropticsOrderBtn);
                    break;
                case "Systems":
                    ToolStripMenuItem SystemsOrderBtn = new ToolStripMenuItem();
                    SystemsOrderBtn.Text = $"{item_name} Systems";
                    SystemsOrderBtn.Click += FindSystemsMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(SystemsOrderBtn);
                    break;
                case "Barrel":
                    ToolStripMenuItem BarrelOrderBtn = new ToolStripMenuItem();
                    BarrelOrderBtn.Text = $"{item_name} Barrel";
                    BarrelOrderBtn.Click += FindBarrelMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(BarrelOrderBtn);
                    break;
                case "Stock":
                    ToolStripMenuItem StockOrderBtn = new ToolStripMenuItem();
                    StockOrderBtn.Text = $"{item_name} Stock";
                    StockOrderBtn.Click += FindStockMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(StockOrderBtn);
                    break;
                case "Reciever":
                    ToolStripMenuItem RecieverOrderBtn = new ToolStripMenuItem();
                    RecieverOrderBtn.Text = $"{item_name} Reciever";
                    RecieverOrderBtn.Click += FindRecieverMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(RecieverOrderBtn);
                    break;
                case "Blade":
                    ToolStripMenuItem BladeOrderBtn = new ToolStripMenuItem();
                    BladeOrderBtn.Text = $"{item_name} Blade";
                    BladeOrderBtn.Click += FindBladeMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(BladeOrderBtn);
                    break;
                case "Hilt":
                    ToolStripMenuItem HiltOrderBtn = new ToolStripMenuItem();
                    HiltOrderBtn.Text = $"{item_name} Hilt";
                    HiltOrderBtn.Click += FindHiltMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(HiltOrderBtn);
                    break;
                case "Head":
                    ToolStripMenuItem HeadOrderBtn = new ToolStripMenuItem();
                    HeadOrderBtn.Text = $"{item_name} Head";
                    HeadOrderBtn.Click += FindHeadMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(HeadOrderBtn);
                    break;
                case "Link":
                    ToolStripMenuItem LinkOrderBtn = new ToolStripMenuItem();
                    LinkOrderBtn.Text = $"{item_name} Link";
                    LinkOrderBtn.Click += FindLinkMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(LinkOrderBtn);
                    break;
                case "Carapace":
                    ToolStripMenuItem CarapaceOrderBtn = new ToolStripMenuItem();
                    CarapaceOrderBtn.Text = $"{item_name} Carapace";
                    CarapaceOrderBtn.Click += FindCarapaceMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(CarapaceOrderBtn);
                    break;
                case "Cerebrum":
                    ToolStripMenuItem CerebrumOrderBtn = new ToolStripMenuItem();
                    CerebrumOrderBtn.Text = $"{item_name} Cerebrum";
                    CerebrumOrderBtn.Click += FindCerebrumMenuItem_Click;

                    WarframeMarketOptions.DropDownItems.Add(CerebrumOrderBtn);
                    break;
            }
        }

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

        private string GetDropData(string item_name)
        {
            string isVaulted = "drops";

            return $"";
        }

        #region Context Menu Commands
        private void FindSetOrdersMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Set", true);
        }

        private void FindNueropticsMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Nueroptics", true);
        }

        private void FindChassisMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Chassis", true);
        }

        private void FindSystemsMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Systems", true);
        }

        private void FindBlueprintMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Blueprint", true);
        }

        private void FindBarrelMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Barrel", true);
        }

        private void FindStockMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Stock", true);
        }

        private void FindRecieverMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Reciever", true);
        }

        private void FindBladeMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Blade", true);
        }

        private void FindHiltMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Hilt", true);
        }

        private void FindHeadMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Head", true);
        }

        private void FindLinkMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Link", true);
        }

        private void FindCarapaceMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Carapace", true);
        }

        private void FindCerebrumMenuItem_Click(object sender, EventArgs e)
        {
            FindOrderInformation(GlobalData.activeItemName, "Cerebrum", true);
        }

        private void RefreshDataMenuItem_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void GetVaultStatusMenuItem_Click(object sender, EventArgs e)
        {
            GetVaultInformation(GlobalData.activeItemName);
        }
        #endregion
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
    }
}