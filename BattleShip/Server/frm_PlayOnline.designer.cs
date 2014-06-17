namespace PlayOnline
{
    partial class frm_PlayOnline
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
            this.pn_CPU = new System.Windows.Forms.Panel();
            this.pn_Player = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pn_CPU
            // 
            this.pn_CPU.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_CPU.Location = new System.Drawing.Point(378, 12);
            this.pn_CPU.Name = "pn_CPU";
            this.pn_CPU.Size = new System.Drawing.Size(360, 390);
            this.pn_CPU.TabIndex = 5;
            // 
            // pn_Player
            // 
            this.pn_Player.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Player.Location = new System.Drawing.Point(12, 12);
            this.pn_Player.Name = "pn_Player";
            this.pn_Player.Size = new System.Drawing.Size(360, 390);
            this.pn_Player.TabIndex = 4;
            // 
            // frm_PlayOnline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 414);
            this.Controls.Add(this.pn_CPU);
            this.Controls.Add(this.pn_Player);
            this.Name = "frm_PlayOnline";
            this.Text = "frm_Server";
            this.Load += new System.EventHandler(this.frm_PlayOnline_Load);
            this.Shown += new System.EventHandler(this.frm_PlayOnline_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_CPU;
        private System.Windows.Forms.Panel pn_Player;
    }
}