namespace InputBoxes
{
    partial class Server
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
            this.pn_Server = new System.Windows.Forms.Panel();
            this.server_txt_Height = new System.Windows.Forms.TextBox();
            this.server_txt_Width = new System.Windows.Forms.TextBox();
            this.server_cmd_Play = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.server_txt_ConfirmPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.server_txt_Pass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pn_Server.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Server
            // 
            this.pn_Server.Controls.Add(this.server_txt_Height);
            this.pn_Server.Controls.Add(this.server_txt_Width);
            this.pn_Server.Controls.Add(this.server_cmd_Play);
            this.pn_Server.Controls.Add(this.label6);
            this.pn_Server.Controls.Add(this.server_txt_ConfirmPass);
            this.pn_Server.Controls.Add(this.label5);
            this.pn_Server.Controls.Add(this.server_txt_Pass);
            this.pn_Server.Controls.Add(this.label4);
            this.pn_Server.Controls.Add(this.label3);
            this.pn_Server.Location = new System.Drawing.Point(3, 3);
            this.pn_Server.Name = "pn_Server";
            this.pn_Server.Size = new System.Drawing.Size(392, 115);
            this.pn_Server.TabIndex = 9;
            // 
            // server_txt_Height
            // 
            this.server_txt_Height.Location = new System.Drawing.Point(104, 8);
            this.server_txt_Height.Name = "server_txt_Height";
            this.server_txt_Height.Size = new System.Drawing.Size(100, 20);
            this.server_txt_Height.TabIndex = 1;
            this.server_txt_Height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.server_txt_Height_KeyPress);
            // 
            // server_txt_Width
            // 
            this.server_txt_Width.Location = new System.Drawing.Point(104, 34);
            this.server_txt_Width.Name = "server_txt_Width";
            this.server_txt_Width.Size = new System.Drawing.Size(100, 20);
            this.server_txt_Width.TabIndex = 2;
            this.server_txt_Width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.server_txt_Width_KeyPress);
            // 
            // server_cmd_Play
            // 
            this.server_cmd_Play.Location = new System.Drawing.Point(209, 8);
            this.server_cmd_Play.Name = "server_cmd_Play";
            this.server_cmd_Play.Size = new System.Drawing.Size(164, 46);
            this.server_cmd_Play.TabIndex = 5;
            this.server_cmd_Play.Text = "Play";
            this.server_cmd_Play.UseVisualStyleBackColor = true;
            this.server_cmd_Play.Click += new System.EventHandler(this.server_cmd_Play_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Confirm password";
            // 
            // server_txt_ConfirmPass
            // 
            this.server_txt_ConfirmPass.Location = new System.Drawing.Point(104, 86);
            this.server_txt_ConfirmPass.Name = "server_txt_ConfirmPass";
            this.server_txt_ConfirmPass.PasswordChar = '*';
            this.server_txt_ConfirmPass.Size = new System.Drawing.Size(269, 20);
            this.server_txt_ConfirmPass.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // server_txt_Pass
            // 
            this.server_txt_Pass.Location = new System.Drawing.Point(104, 60);
            this.server_txt_Pass.Name = "server_txt_Pass";
            this.server_txt_Pass.PasswordChar = '*';
            this.server_txt_Pass.Size = new System.Drawing.Size(269, 20);
            this.server_txt_Pass.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Height";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Server);
            this.Name = "Server";
            this.Size = new System.Drawing.Size(398, 121);
            this.pn_Server.ResumeLayout(false);
            this.pn_Server.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Server;
        private System.Windows.Forms.Button server_cmd_Play;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox server_txt_ConfirmPass;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox server_txt_Pass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox server_txt_Height;
        private System.Windows.Forms.TextBox server_txt_Width;
    }
}
