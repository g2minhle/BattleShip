namespace BattleShip
{
    partial class frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_HumanAsClient = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_CPU = new System.Windows.Forms.RadioButton();
            this.rb_HumanAsServer = new System.Windows.Forms.RadioButton();
            this.gb_InputBoxes = new System.Windows.Forms.GroupBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(68, 86);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(399, 67);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(473, 51);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(59, 102);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(92, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(355, 76);
            this.label1.TabIndex = 3;
            this.label1.Text = "Battle Ship";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 164);
            this.panel1.TabIndex = 4;
            // 
            // rb_HumanAsClient
            // 
            this.rb_HumanAsClient.AutoSize = true;
            this.rb_HumanAsClient.Location = new System.Drawing.Point(6, 19);
            this.rb_HumanAsClient.Name = "rb_HumanAsClient";
            this.rb_HumanAsClient.Size = new System.Drawing.Size(101, 17);
            this.rb_HumanAsClient.TabIndex = 5;
            this.rb_HumanAsClient.TabStop = true;
            this.rb_HumanAsClient.Text = "Human as client";
            this.rb_HumanAsClient.UseVisualStyleBackColor = true;
            this.rb_HumanAsClient.CheckedChanged += new System.EventHandler(this.rb_HumanAsClient_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_CPU);
            this.groupBox1.Controls.Add(this.rb_HumanAsServer);
            this.groupBox1.Controls.Add(this.rb_HumanAsClient);
            this.groupBox1.Location = new System.Drawing.Point(12, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(125, 143);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "You will play with";
            // 
            // rb_CPU
            // 
            this.rb_CPU.AutoSize = true;
            this.rb_CPU.Location = new System.Drawing.Point(6, 106);
            this.rb_CPU.Name = "rb_CPU";
            this.rb_CPU.Size = new System.Drawing.Size(70, 17);
            this.rb_CPU.TabIndex = 7;
            this.rb_CPU.TabStop = true;
            this.rb_CPU.Text = "Computer";
            this.rb_CPU.UseVisualStyleBackColor = true;
            this.rb_CPU.CheckedChanged += new System.EventHandler(this.rb_CPU_CheckedChanged);
            // 
            // rb_HumanAsServer
            // 
            this.rb_HumanAsServer.AutoSize = true;
            this.rb_HumanAsServer.Location = new System.Drawing.Point(6, 62);
            this.rb_HumanAsServer.Name = "rb_HumanAsServer";
            this.rb_HumanAsServer.Size = new System.Drawing.Size(105, 17);
            this.rb_HumanAsServer.TabIndex = 6;
            this.rb_HumanAsServer.TabStop = true;
            this.rb_HumanAsServer.Text = "Human as server";
            this.rb_HumanAsServer.UseVisualStyleBackColor = true;
            this.rb_HumanAsServer.CheckedChanged += new System.EventHandler(this.rb_HumanAsServer_CheckedChanged);
            // 
            // gb_InputBoxes
            // 
            this.gb_InputBoxes.Location = new System.Drawing.Point(143, 182);
            this.gb_InputBoxes.Name = "gb_InputBoxes";
            this.gb_InputBoxes.Size = new System.Drawing.Size(411, 143);
            this.gb_InputBoxes.TabIndex = 7;
            this.gb_InputBoxes.TabStop = false;
            this.gb_InputBoxes.Text = "Setting";
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = "D:\\Coding4Fun\\Lib\\Control\\Skin\\Skinpack\\Skins\\Steel\\SteelBlue.ssk";
            this.skinEngine1.SkinStreamMain = ((System.IO.Stream)(resources.GetObject("skinEngine1.SkinStreamMain")));
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 334);
            this.Controls.Add(this.gb_InputBoxes);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Battel Ship";
            this.Load += new System.EventHandler(this.frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_HumanAsClient;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_CPU;
        private System.Windows.Forms.RadioButton rb_HumanAsServer;
        private System.Windows.Forms.GroupBox gb_InputBoxes;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
    }
}

