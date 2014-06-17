namespace OffLine
{
    partial class frm_OffLine
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
            this.pn_Player = new System.Windows.Forms.Panel();
            this.pn_CPU = new System.Windows.Forms.Panel();
            this.cb_PlaySound = new System.Windows.Forms.CheckBox();
            this.cmd_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pn_Player
            // 
            this.pn_Player.Location = new System.Drawing.Point(13, 13);
            this.pn_Player.Name = "pn_Player";
            this.pn_Player.Size = new System.Drawing.Size(360, 350);
            this.pn_Player.TabIndex = 2;
            // 
            // pn_CPU
            // 
            this.pn_CPU.Location = new System.Drawing.Point(379, 13);
            this.pn_CPU.Name = "pn_CPU";
            this.pn_CPU.Size = new System.Drawing.Size(360, 350);
            this.pn_CPU.TabIndex = 3;
            // 
            // cb_PlaySound
            // 
            this.cb_PlaySound.AutoSize = true;
            this.cb_PlaySound.Checked = true;
            this.cb_PlaySound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_PlaySound.Location = new System.Drawing.Point(580, 369);
            this.cb_PlaySound.Name = "cb_PlaySound";
            this.cb_PlaySound.Size = new System.Drawing.Size(78, 17);
            this.cb_PlaySound.TabIndex = 4;
            this.cb_PlaySound.Text = "Play sound";
            this.cb_PlaySound.UseVisualStyleBackColor = true;
            this.cb_PlaySound.CheckedChanged += new System.EventHandler(this.cb_PlaySound_CheckedChanged);
            // 
            // cmd_Cancel
            // 
            this.cmd_Cancel.Location = new System.Drawing.Point(664, 365);
            this.cmd_Cancel.Name = "cmd_Cancel";
            this.cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.cmd_Cancel.TabIndex = 5;
            this.cmd_Cancel.Text = "Cancel";
            this.cmd_Cancel.UseVisualStyleBackColor = true;
            this.cmd_Cancel.Click += new System.EventHandler(this.cmd_Cancel_Click);
            // 
            // frm_OffLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 387);
            this.Controls.Add(this.cmd_Cancel);
            this.Controls.Add(this.cb_PlaySound);
            this.Controls.Add(this.pn_CPU);
            this.Controls.Add(this.pn_Player);
            this.MaximizeBox = false;
            this.Name = "frm_OffLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_OffLine";
            this.Shown += new System.EventHandler(this.frm_OffLine_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pn_Player;
        private System.Windows.Forms.Panel pn_CPU;
        private System.Windows.Forms.CheckBox cb_PlaySound;
        private System.Windows.Forms.Button cmd_Cancel;

    }
}