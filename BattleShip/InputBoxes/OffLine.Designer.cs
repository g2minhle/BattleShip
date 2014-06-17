namespace BattleShip
{
    partial class OffLine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pn_OffLine = new System.Windows.Forms.Panel();
            this.offline_txt_Width = new System.Windows.Forms.TextBox();
            this.offline_txt_Height = new System.Windows.Forms.TextBox();
            this.offline_cmd_Play = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pn_OffLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_OffLine
            // 
            this.pn_OffLine.Controls.Add(this.offline_txt_Width);
            this.pn_OffLine.Controls.Add(this.offline_txt_Height);
            this.pn_OffLine.Controls.Add(this.offline_cmd_Play);
            this.pn_OffLine.Controls.Add(this.label9);
            this.pn_OffLine.Controls.Add(this.label10);
            this.pn_OffLine.Location = new System.Drawing.Point(0, 3);
            this.pn_OffLine.Name = "pn_OffLine";
            this.pn_OffLine.Size = new System.Drawing.Size(272, 65);
            this.pn_OffLine.TabIndex = 10;
            // 
            // offline_txt_Width
            // 
            this.offline_txt_Width.Location = new System.Drawing.Point(52, 34);
            this.offline_txt_Width.Name = "offline_txt_Width";
            this.offline_txt_Width.Size = new System.Drawing.Size(127, 20);
            this.offline_txt_Width.TabIndex = 2;
            this.offline_txt_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.offline_txt_Width_KeyPress);
            // 
            // offline_txt_Height
            // 
            this.offline_txt_Height.Location = new System.Drawing.Point(52, 8);
            this.offline_txt_Height.Name = "offline_txt_Height";
            this.offline_txt_Height.Size = new System.Drawing.Size(127, 20);
            this.offline_txt_Height.TabIndex = 1;
            this.offline_txt_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.offline_txt_Height_KeyPress);
            // 
            // offline_cmd_Play
            // 
            this.offline_cmd_Play.Location = new System.Drawing.Point(185, 8);
            this.offline_cmd_Play.Name = "offline_cmd_Play";
            this.offline_cmd_Play.Size = new System.Drawing.Size(75, 46);
            this.offline_cmd_Play.TabIndex = 3;
            this.offline_cmd_Play.Text = "Play";
            this.offline_cmd_Play.UseVisualStyleBackColor = true;
            this.offline_cmd_Play.Click += new System.EventHandler(this.offline_cmd_Play_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Width";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Height";
            // 
            // OffLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_OffLine);
            this.Name = "OffLine";
            this.Size = new System.Drawing.Size(276, 73);
            this.pn_OffLine.ResumeLayout(false);
            this.pn_OffLine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_OffLine;
        private System.Windows.Forms.Button offline_cmd_Play;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox offline_txt_Width;
        private System.Windows.Forms.TextBox offline_txt_Height;
    }
}
