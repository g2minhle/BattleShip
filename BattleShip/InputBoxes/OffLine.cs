using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ShipBuilder;
using OffLine;
namespace BattleShip
{
    public partial class OffLine : UserControl
    {
        public OffLine()
        {
            InitializeComponent();
        }
        private void offline_cmd_Play_Click(object sender, EventArgs e)
        {
            int height = int.Parse(offline_txt_Height.Text);
            int width = int.Parse(offline_txt_Width.Text);
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
            frm_SetShip frm_Setship = new frm_SetShip(height, width);
            this.Parent.Parent.Hide();
            frm_Setship.ShowDialog();
            if (frm_Setship.Changed)
            {
                frm_OffLine frmOffLine = new frm_OffLine(frm_Setship.Player);
                frm_Setship.Dispose();
                frmOffLine.ShowDialog();
                if (frmOffLine.NoExit)
                    Application.Restart();
                else
                    Application.Exit();
            }
            else
            {
                if (frm_Setship.NoExit)
                    Application.Restart();
                else
                    Application.Exit();
            }

        }

        private void offline_txt_Height_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (8 == (int)e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
        }

        private void offline_txt_Width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (8 == (int)e.KeyChar))
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
