using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarframeTracker
{
    public partial class WeaponSimulator : Form
    {
        readonly Debug.Debug Debugger = new Debug.Debug();

        public WeaponSimulator()
        {
            InitializeComponent();
        }

        private void WeaponSimulator_Load(object sender, EventArgs e)
        {
            try
            {
                foreach (Items.PrimaryWeapons.Root Weapon in GlobalData.PrimaryWeaponDatabase.Values)
                {
                    WeaponsComboBox.Items.Add(Weapon.Name);
                }

                foreach (Items.SecondaryWeapons.Root Weapon in GlobalData.SecondaryWeaponDatabase.Values)
                {
                    WeaponsComboBox.Items.Add(Weapon.Name);
                }

                foreach (Items.Melee.Root Weapon in GlobalData.MeleeWeaponDatabase.Values)
                {
                    WeaponsComboBox.Items.Add(Weapon.Name);
                }

                foreach (Items.Enemies.Root Enemy in GlobalData.EnemyDatabase.Values)
                {
                    EnemiesComboBox.Items.Add(Enemy.Name);
                }
            }
            catch (Exception ex)
            {
                if (Properties.Settings.Default.debug_mode)
                {
                    Debugger.Log($"Exception in WeaponSimulator->WeaponSimulator_Load{Environment.NewLine}Stack Trace: {ex}");
                }
            }
        }
    }
}
