using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
///////////////////////////////////////
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Connector;

namespace InputBoxes
{
    public partial class frm_Server_Conneting : Form
    {
        Connector.Server server;
        int height;
        int width;
        public frm_Server_Conneting(string serverpass,int height,int width)
        {
            InitializeComponent();
            server = new Connector.Server(serverpass);
            server.DoneListen += new Connector.Server.DoneListenHandel(server_DoneListen);
            this.height = height;
            this.width = width;
        }
        void server_DoneListen()
        {
            server.Send(height.ToString());
            server.Send(width.ToString());
            this.Close();
        }
        
        #region Animation
        int point;
        void ChangeLB()
        {
            lb_Label1.Text = "Listening ";
            point++;
            if (point > 5) point = 1;
            for (int i = 0; i < point; i++)
            {
                lb_Label1.Text += ". ";
            }
        }
        public Connector.Server ServerConnector { get { return server; } }
        private void tm_Timer_Tick(object sender, EventArgs e)
        {
            ChangeLB();
        }
        #endregion
        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}