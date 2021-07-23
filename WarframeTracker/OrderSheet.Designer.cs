
namespace WarframeTracker
{
    partial class OrderSheet
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.OfflineCheckbox = new System.Windows.Forms.CheckBox();
            this.OnlineCheckbox = new System.Windows.Forms.CheckBox();
            this.InGameCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 41);
            this.flowLayoutPanel1.MaximumSize = new System.Drawing.Size(688, 5000);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(688, 279);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(625, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(13, 326);
            this.flowLayoutPanel2.MaximumSize = new System.Drawing.Size(688, 5000);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(688, 279);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // OfflineCheckbox
            // 
            this.OfflineCheckbox.AutoSize = true;
            this.OfflineCheckbox.Location = new System.Drawing.Point(13, 15);
            this.OfflineCheckbox.Name = "OfflineCheckbox";
            this.OfflineCheckbox.Size = new System.Drawing.Size(105, 19);
            this.OfflineCheckbox.TabIndex = 4;
            this.OfflineCheckbox.Text = "Offline Listings";
            this.OfflineCheckbox.UseVisualStyleBackColor = true;
            // 
            // OnlineCheckbox
            // 
            this.OnlineCheckbox.AutoSize = true;
            this.OnlineCheckbox.Location = new System.Drawing.Point(124, 15);
            this.OnlineCheckbox.Name = "OnlineCheckbox";
            this.OnlineCheckbox.Size = new System.Drawing.Size(104, 19);
            this.OnlineCheckbox.TabIndex = 5;
            this.OnlineCheckbox.Text = "Online Listings";
            this.OnlineCheckbox.UseVisualStyleBackColor = true;
            // 
            // InGameCheckbox
            // 
            this.InGameCheckbox.AutoSize = true;
            this.InGameCheckbox.Checked = true;
            this.InGameCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.InGameCheckbox.Location = new System.Drawing.Point(234, 15);
            this.InGameCheckbox.Name = "InGameCheckbox";
            this.InGameCheckbox.Size = new System.Drawing.Size(153, 19);
            this.InGameCheckbox.TabIndex = 6;
            this.InGameCheckbox.Text = "Online In-Game Listings";
            this.InGameCheckbox.UseVisualStyleBackColor = true;
            // 
            // OrderSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(713, 618);
            this.Controls.Add(this.InGameCheckbox);
            this.Controls.Add(this.OnlineCheckbox);
            this.Controls.Add(this.OfflineCheckbox);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "OrderSheet";
            this.Text = "OrderSheet";
            this.Load += new System.EventHandler(this.OrderSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.CheckBox OfflineCheckbox;
        private System.Windows.Forms.CheckBox OnlineCheckbox;
        private System.Windows.Forms.CheckBox InGameCheckbox;
    }
}