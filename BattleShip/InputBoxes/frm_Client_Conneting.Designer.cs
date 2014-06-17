namespace InputBoxes
{
    partial class frm_Client_Conneting
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
            this.components = new System.ComponentModel.Container();
            this.cmd_Cancel = new System.Windows.Forms.Button();
            this.lb_Label1 = new System.Windows.Forms.Label();
            this.tm_Timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // cmd_Cancel
            // 
            this.cmd_Cancel.Location = new System.Drawing.Point(144, 12);
            this.cmd_Cancel.Name = "cmd_Cancel";
            this.cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.cmd_Cancel.TabIndex = 1;
            this.cmd_Cancel.Text = "Cancel";
            this.cmd_Cancel.UseVisualStyleBackColor = true;
            this.cmd_Cancel.Click += new System.EventHandler(this.cmd_Cancel_Click);
            // 
            // lb_Label1
            // 
            this.lb_Label1.AutoSize = true;
            this.lb_Label1.Location = new System.Drawing.Point(12, 12);
            this.lb_Label1.Name = "lb_Label1";
            this.lb_Label1.Size = new System.Drawing.Size(61, 13);
            this.lb_Label1.TabIndex = 2;
            this.lb_Label1.Text = "Connecting";
            // 
            // tm_Timer1
            // 
            this.tm_Timer1.Enabled = true;
            this.tm_Timer1.Interval = 1000;
            this.tm_Timer1.Tick += new System.EventHandler(this.tm_Timer_Tick);
            // 
            // frm_Client_Conneting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 39);
            this.ControlBox = false;
            this.Controls.Add(this.lb_Label1);
            this.Controls.Add(this.cmd_Cancel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Client_Conneting";
            this.Text = "Connecting to server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Cancel;
        private System.Windows.Forms.Label lb_Label1;
        private System.Windows.Forms.Timer tm_Timer1;
    }
}