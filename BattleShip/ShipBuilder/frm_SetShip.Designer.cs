namespace ShipBuilder
{
    partial class frm_SetShip
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
            this.pn_Sea = new System.Windows.Forms.Panel();
            this.cmd_Cancel = new System.Windows.Forms.Button();
            this.cmd_OK = new System.Windows.Forms.Button();
            this.gb_Ships = new System.Windows.Forms.GroupBox();
            this.cb_PlaySound = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // pn_Sea
            // 
            this.pn_Sea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Sea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_Sea.Location = new System.Drawing.Point(9, 98);
            this.pn_Sea.Name = "pn_Sea";
            this.pn_Sea.Size = new System.Drawing.Size(563, 270);
            this.pn_Sea.TabIndex = 0;
            // 
            // cmd_Cancel
            // 
            this.cmd_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_Cancel.Location = new System.Drawing.Point(473, 374);
            this.cmd_Cancel.Name = "cmd_Cancel";
            this.cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.cmd_Cancel.TabIndex = 6;
            this.cmd_Cancel.Text = "Cancel";
            this.cmd_Cancel.UseVisualStyleBackColor = true;
            this.cmd_Cancel.Click += new System.EventHandler(this.cmd_Cancel_Click);
            // 
            // cmd_OK
            // 
            this.cmd_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmd_OK.Location = new System.Drawing.Point(392, 374);
            this.cmd_OK.Name = "cmd_OK";
            this.cmd_OK.Size = new System.Drawing.Size(75, 23);
            this.cmd_OK.TabIndex = 7;
            this.cmd_OK.Text = "OK";
            this.cmd_OK.UseVisualStyleBackColor = true;
            this.cmd_OK.Click += new System.EventHandler(this.cmd_OK_Click);
            // 
            // gb_Ships
            // 
            this.gb_Ships.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gb_Ships.BackColor = System.Drawing.SystemColors.Control;
            this.gb_Ships.Location = new System.Drawing.Point(9, 12);
            this.gb_Ships.Name = "gb_Ships";
            this.gb_Ships.Size = new System.Drawing.Size(563, 80);
            this.gb_Ships.TabIndex = 0;
            this.gb_Ships.TabStop = false;
            this.gb_Ships.Text = "Ships";
            // 
            // cb_PlaySound
            // 
            this.cb_PlaySound.AutoSize = true;
            this.cb_PlaySound.Checked = true;
            this.cb_PlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PlaySound.Location = new System.Drawing.Point(308, 377);
            this.cb_PlaySound.Name = "cb_PlaySound";
            this.cb_PlaySound.Size = new System.Drawing.Size(78, 17);
            this.cb_PlaySound.TabIndex = 8;
            this.cb_PlaySound.Text = "Play sound";
            this.cb_PlaySound.UseVisualStyleBackColor = true;
            this.cb_PlaySound.CheckedChanged += new System.EventHandler(this.cb_PlaySound_CheckedChanged);
            // 
            // frm_SetShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 406);
            this.Controls.Add(this.cb_PlaySound);
            this.Controls.Add(this.gb_Ships);
            this.Controls.Add(this.cmd_OK);
            this.Controls.Add(this.cmd_Cancel);
            this.Controls.Add(this.pn_Sea);
            this.Name = "frm_SetShip";
            this.Text = "SetShip";
            this.Shown += new System.EventHandler(this.frm_SetShip_Shown);
            this.MouseEnter += new System.EventHandler(this.frm_SetShip_MouseEnter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_Sea;
        private System.Windows.Forms.Button cmd_Cancel;
        private System.Windows.Forms.Button cmd_OK;
        private System.Windows.Forms.GroupBox gb_Ships;
        private System.Windows.Forms.CheckBox cb_PlaySound;
    }
}