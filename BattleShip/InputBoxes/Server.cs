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
    public partial class Server : UserControl
    {
        public Server()
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
        private void server_cmd_Play_Click(object sender, EventArgs e)
        {
            /*int height = int.Parse(server_txt_Height.Text);
            int width = int.Parse(server_txt_Width.Text);
            if (height < 10 || height > 100)
            {
                MessageBox.Show("Height must be bigger than 10 and smaller then 100 !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (width < 10 || width > 100)
            {
                MessageBox.Show("Width must be bigger than 10 and smaller then 100 !", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (server_txt_Pass.Text == "" && server_txt_ConfirmPass.Text == "")
            {
                MessageBox.Show("You must type in the password", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (server_txt_Pass.Text != server_txt_ConfirmPass.Text)
            {
                MessageBox.Show("The password do not match", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }*/
            this.Parent.Parent.Hide();
            //frm_Server_Conneting frm_Serverconnecting = new frm_Server_Conneting(server_txt_Pass.Text, height, width);
            frm_Server_Conneting frm_Serverconnecting = new frm_Server_Conneting("123", 10, 10);
            frm_Serverconnecting.ShowDialog();
            //frm_Serverconnecting.ServerConnector.Send(height.ToString());
            //frm_Serverconnecting.ServerConnector.Send(width.ToString());
            frm_Serverconnecting.ServerConnector.Send("10");
            frm_Serverconnecting.ServerConnector.Send("10");
            //frm_SetShip frm_Setship = new frm_SetShip(height, width);
            //frm_Setship.ShowDialog();
            //if (frm_Setship.Changed == true)
            //{
            //  Player.APlayer player = frm_Setship.Player;
            Player.APlayer player = MakeCPUSea(10, 10);
            frm_Sever frm_Server = new frm_Sever(player, frm_Serverconnecting.ServerConnector);
            frm_Server.ShowDialog();
            //}
            Application.Restart();
        }

        private void server_txt_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (8 == (int)e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
        }

        private void server_txt_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (8 == (int)e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
