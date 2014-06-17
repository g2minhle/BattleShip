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


namespace InputBoxes
{
    public partial class frm_Client_Conneting : Form
    {
        Connector.Client client;
        public frm_Client_Conneting(string serverpass, string ipaddress)
        {
            InitializeComponent();
            client = new Connector.Client(serverpass, ipaddress);
            client.CannotConnected += new Connector.Client.CannotConnectedHandel(client_CannotConnected);
            client.Connected += new Connector.Client.ConnectedHandel (client_Connected);
            point = 1;
        }
        public Connector.Client ClientConnector { get { return client; } }
        void client_Connected()
        {
            this.Close();
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
    }
}