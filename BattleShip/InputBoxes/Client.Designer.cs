namespace InputBoxes
{
    partial class Client
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
            this.pn_Client = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.client_cmd_Play = new System.Windows.Forms.Button();
            this.client_txt_ServerIP = new System.Windows.Forms.TextBox();
            this.client_txt_Pass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pn_Client.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_Client
            // 
            this.pn_Client.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pn_Client.Controls.Add(this.label7);
            this.pn_Client.Controls.Add(this.client_cmd_Play);
            this.pn_Client.Controls.Add(this.client_txt_ServerIP);
            this.pn_Client.Controls.Add(this.client_txt_Pass);
            this.pn_Client.Controls.Add(this.label2);
            this.pn_Client.Location = new System.Drawing.Point(3, 3);
            this.pn_Client.Name = "pn_Client";
            this.pn_Client.Size = new System.Drawing.Size(395, 78);
            this.pn_Client.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Password";
            // 
            // client_cmd_Play
            // 
            this.client_cmd_Play.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.client_cmd_Play.Location = new System.Drawing.Point(316, 18);
            this.client_cmd_Play.Name = "client_cmd_Play";
            this.client_cmd_Play.Size = new System.Drawing.Size(75, 23);
            this.client_cmd_Play.TabIndex = 3;
            this.client_cmd_Play.Text = "Play";
            this.client_cmd_Play.UseVisualStyleBackColor = true;
            this.client_cmd_Play.Click += new System.EventHandler(this.client_cmd_Play_Click);
            // 
            // client_txt_ServerIP
            // 
            this.client_txt_ServerIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.client_txt_ServerIP.Location = new System.Drawing.Point(7, 21);
            this.client_txt_ServerIP.Name = "client_txt_ServerIP";
            this.client_txt_ServerIP.Size = new System.Drawing.Size(303, 20);
            this.client_txt_ServerIP.TabIndex = 1;
            // 
            // client_txt_Pass
            // 
            this.client_txt_Pass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.client_txt_Pass.Location = new System.Drawing.Point(67, 47);
            this.client_txt_Pass.Name = "client_txt_Pass";
            this.client_txt_Pass.PasswordChar = '*';
            this.client_txt_Pass.Size = new System.Drawing.Size(325, 20);
            this.client_txt_Pass.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Enter server ip address:";
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pn_Client);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(403, 85);
            this.pn_Client.ResumeLayout(false);
            this.pn_Client.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pn_Client;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button client_cmd_Play;
        private System.Windows.Forms.TextBox client_txt_ServerIP;
        private System.Windows.Forms.TextBox client_txt_Pass;
        private System.Windows.Forms.Label label2;
    }
}
