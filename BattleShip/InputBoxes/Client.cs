using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ShipBuilder;
using PlayOnline;
using Player;
namespace InputBoxes
{
    public partial class Client : UserControl
    {
        public Client()
        {
            InitializeComponent();
        }
        private APlayer MakeCPUSea(int height, int width)
        {
            APlayer CPU = new APlayer(height, width);
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                while (!CPU.Push(rnd.Next(0, height - 1)
                    , rnd.Next(0, width - 1)
                    , rnd.Next(0, 3), i + 1)) ;
            return CPU;
        }
        private void client_cmd_Play_Click(object sender, EventArgs e)
        {
            #region Check server ip and password are typed
            /*if (client_txt_ServerIP.Text == "")
            {
                MessageBox.Show("You must type in the server ip address", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (client_txt_Pass.Text == "")
            {
                MessageBox.Show("You must type in the password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!(Connector.MainConnector.RightIP(client_txt_ServerIP.Text)))
            {
                MessageBox.Show("Wrong IP address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
            #endregion
            this.Parent.Parent.Hide();
            //frm_Client_Conneting frmClient = new frm_Client_Conneting(client_txt_Pass.Text, client_txt_ServerIP.Text);
            frm_Client_Conneting frmClient = new frm_Client_Conneting("123","127.0.0.1");
            frmClient.ShowDialog();
            if (frmClient.ClientConnector == null) Application.Restart();
            while (frmClient.ClientConnector.Q.Count == 0) ;
            //frm_SetShip frm_Setship = new frm_SetShip(int.Parse(frmClient.ClientConnector.GetInfo()), int.Parse(frmClient.ClientConnector.GetInfo()));
            //frm_Setship.ShowDialog();
            //if (frm_Setship.Changed == true)
            //{
            //Player.APlayer player = frm_Setship.Player;
            Player.APlayer player = MakeCPUSea(int.Parse(frmClient.ClientConnector.GetInfo()), int.Parse(frmClient.ClientConnector.GetInfo()));
            frm_Client frm_Client = new frm_Client(player, frmClient.ClientConnector);
            frm_Client.ShowDialog();
            //}
            Application.Restart();
        }
    }
}
