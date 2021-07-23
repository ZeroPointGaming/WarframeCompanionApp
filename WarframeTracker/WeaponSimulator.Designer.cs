
namespace WarframeTracker
{
    partial class WeaponSimulator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WeaponsComboBox = new System.Windows.Forms.ComboBox();
            this.EnemiesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // WeaponsComboBox
            // 
            this.WeaponsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WeaponsComboBox.FormattingEnabled = true;
            this.WeaponsComboBox.Location = new System.Drawing.Point(12, 29);
            this.WeaponsComboBox.Name = "WeaponsComboBox";
            this.WeaponsComboBox.Size = new System.Drawing.Size(190, 23);
            this.WeaponsComboBox.TabIndex = 0;
            // 
            // EnemiesComboBox
            // 
            this.EnemiesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EnemiesComboBox.FormattingEnabled = true;
            this.EnemiesComboBox.Location = new System.Drawing.Point(208, 29);
            this.EnemiesComboBox.Name = "EnemiesComboBox";
            this.EnemiesComboBox.Size = new System.Drawing.Size(190, 23);
            this.EnemiesComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Weapon";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(208, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enemy";
            // 
            // WeaponSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EnemiesComboBox);
            this.Controls.Add(this.WeaponsComboBox);
            this.Name = "WeaponSimulator";
            this.Text = "WeaponSimulator";
            this.Load += new System.EventHandler(this.WeaponSimulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox WeaponsComboBox;
        private System.Windows.Forms.ComboBox EnemiesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}