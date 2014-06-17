using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InputBoxes;

namespace BattleShip
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }
        private void rb_HumanAsClient_CheckedChanged(object sender, EventArgs e)
        {
            gb_InputBoxes.Controls.Clear();
            Client control = new Client();
            gb_InputBoxes.Controls.Add((UserControl)control);
            control.Top = 20;
            control.Left = 5;
            control.Width = control.Width - 10;
        }
        private void rb_HumanAsServer_CheckedChanged(object sender, EventArgs e)
        {
            gb_InputBoxes.Controls.Clear();
            Server control = new Server();
            gb_InputBoxes.Controls.Add((UserControl)control);
            control.Top = 20;
            control.Left = 10;
        }
        private void rb_CPU_CheckedChanged(object sender, EventArgs e)
        {
            gb_InputBoxes.Controls.Clear();
            OffLine control = new OffLine();
            gb_InputBoxes.Controls.Add((UserControl)control);
            control.Top = 20;
            control.Left = 10;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            rb_HumanAsClient.Select();
        }
    }
}