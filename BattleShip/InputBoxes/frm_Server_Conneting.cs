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
using ShipBuilder;
using PlayOnline;
using Player;


namespace InputBoxes
{
    public partial class frm_Server_Conneting : Form
    {
        Connector.Server server;
        int height;
        int width;
        string serverpass;
        public frm_Server_Conneting(string serverpass, int height, int width)
        {
            InitializeComponent();
            this.serverpass = serverpass;
            this.height = height;
            this.width = width;
        }
        void server_DoneListen()
        {
            server.Send(height.ToString() + " " + width.ToString());
            frm_SetShip frm_Setship = new frm_SetShip(height, width);
            frm_Setship.ShowDialog();
            if (frm_Setship.Changed)
            {
                server.Send("d");
                Player.APlayer player = frm_Setship.Player;
                frm_Sever frm_Server = new frm_Sever(player, server);
                frm_Server.ShowDialog();
            }
            else
            {
                server.Send("n");
            }
            Application.Restart();
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

        private void frm_Server_Conneting_Shown(object sender, EventArgs e)
        {
            server = new Connector.Server(serverpass);
            server.DoneListen += new Connector.Server.DoneListenHandel(server_DoneListen);

        }
    }
}