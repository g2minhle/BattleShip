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
using ShipBuilder;
using PlayOnline;
using Player;



namespace InputBoxes
{
    public partial class frm_Client_Conneting : Form
    {
        Connector.Client client;
        string serverpass;
        string ipaddress;
        public frm_Client_Conneting(string serverpass, string ipaddress)
        {
            InitializeComponent();
            this.serverpass = serverpass;
            this.ipaddress = ipaddress;
        }
        public Connector.Client ClientConnector { get { return client; } }
        void client_Connected()
        {
            client.GotInfo += new Connector.MainConnector.GotInfoHandel(ClientConnector_GotInfo);

        }
        void ClientConnector_GotInfo(string info)
        {
            string[] tmp = info.Split(' ');
            frm_SetShip frm_Setship = new frm_SetShip(int.Parse(tmp[0]), int.Parse(tmp[1]));
            frm_Setship.ShowDialog();
            if (frm_Setship.Changed)
            {
                client.Send("d");
                Player.APlayer player = frm_Setship.Player;
                frm_Client frm_Client = new frm_Client(player, client);
                frm_Client.ShowDialog();
            }
            else
            {
                client.Send("n");
            }

            Application.Restart();
        }
        void client_CannotConnected()
        {
            MessageBox.Show("Wrong password", "Cannot connect", MessageBoxButtons.OK, MessageBoxIcon.Error);
            client = null;
            this.Close();
        }
        #region
        int point;
        void ChangeLB()
        {
            lb_Label1.Text = "Connecting ";
            point++;
            if (point > 5) point = 1;
            for (int i = 0; i < point; i++)
            {
                lb_Label1.Text += ". ";
            }
        }
        private void tm_Timer_Tick(object sender, EventArgs e)
        {
            ChangeLB();
        }
        #endregion

        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void frm_Client_Conneting_Shown(object sender, EventArgs e)
        {
            client = new Connector.Client(serverpass, ipaddress);
            client.CannotConnected += new Connector.Client.CannotConnectedHandel(client_CannotConnected);
            client.Connected += new Connector.Client.ConnectedHandel(client_Connected);
            point = 1;
        }
    }
}