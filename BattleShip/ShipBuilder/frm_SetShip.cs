using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Player;
namespace ShipBuilder
{
    public partial class frm_SetShip : Form
    {
        class SetShipField : BattleField.BattleField
        {
            int curdirection;
            int curship;
            public ShipList shiplist;

            protected void RemoveShip(int id)
            {
                if (id != 0)
                {
                    pn_BattleField.Controls.RemoveByKey("pic_sea_" + id);
                    player.Remove(id);
                }
            }
            override protected void pic_MouseClick(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    curdirection++;
                    if (curdirection > 3) curdirection = 0;
                    RemoveShip(curship);
                }
                else
                    if (e.Button == MouseButtons.Left)
                    {
                        PictureBox sder = (PictureBox)sender;
                        if (curship != 0 && sder.Name == "pic_sea_" + curship)
                        {
                            int i = 0;
                            int j = 0;
                            Tools.Tools.GetPosOfLB(ref i, ref j, sder.Tag.ToString());
                            player.Push(i, j, curdirection, curship);
                            shiplist.Done(curship);
                            curdirection = 0;
                            curship = 0;
                        }
                    }
            }
            override protected void lb_MouseMove(object sender, MouseEventArgs e)
            {
                if (curship != 0)
                {
                    Label tmp = (Label)sender;
                    RemoveShip(curship);
                    int line = 0;
                    int col = 0;
                    Tools.Tools.GetPosOfLB(ref line, ref col, tmp.Name);
                    if (player.AbleToPutIn(line, col, curdirection, curship))
                    {
                        DrawShip(line, col, curdirection, curship);
                    }
                }
            }
            void shiplist_ShipSelected(int curship)
            {
                if (curship != 0)
                {
                    RemoveShip(curship);
                }
                this.curship = curship;
                curdirection = 0;
            }
            void NewShipList()
            {
                shiplist = new ShipList();
                shiplist.ShipSelected += new ShipList.ShipSel(shiplist_ShipSelected);
            }
            public SetShipField(int height, int width)
            {
                New(height, width);
                showship = true;
                NewShipList();
                #region Set even when leave the control
                pn_BattleField.MouseLeave += new EventHandler(pn_BattleField_MouseLeave);
                this.MouseLeave += new EventHandler(MakeField_MouseLeave);
                shiplist.MouseEnter += new EventHandler(shiplist_MouseEnter);
                #endregion
            }
            protected override void BattleField_ParentChanged(object sender, EventArgs e)
            {
                shiplist.SetControl();
                base.BattleField_ParentChanged(sender, e);
            }
            #region Del cur ship pic when leave the control
            public void RemoveCur()
            {
                RemoveShip(curship);
            }
            void shiplist_MouseEnter(object sender, EventArgs e)
            {
                RemoveShip(curship);
            }
            void MakeField_MouseLeave(object sender, EventArgs e)
            {
                RemoveShip(curship);
            }
            void pn_BattleField_MouseLeave(object sender, EventArgs e)
            {
                RemoveShip(curship);
            }
            #endregion

        }
        SetShipField field;
        public frm_SetShip(int height, int width)
        {
            InitializeComponent();
            field = new SetShipField(height, width);
        }
        bool changed;
        public bool Changed { get { return changed; } }
        #region Ok and cancel click
        private void cmd_OK_Click(object sender, EventArgs e)
        {
            if (field.shiplist.AllHaveBeenSetUp())
            {
                changed = true;
                this.Close();
            }
            else
                MessageBox.Show("You must set up all the ship", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        bool noexit;
        public bool NoExit
        { get { return noexit; } }
        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            changed = false;
            noexit = true;
            this.Close();
        }
        #endregion
        public APlayer Player { get { return field.Player; } }
        private void frm_SetShip_MouseEnter(object sender, EventArgs e)
        {
            field.RemoveCur();
        }
        private void frm_SetShip_Shown(object sender, EventArgs e)
        {
            gb_Ships.Controls.Add(field.shiplist);
            pn_Sea.Controls.Add(field);
        }

        private void cb_PlaySound_CheckedChanged(object sender, EventArgs e)
        {
            field.Sound = cb_PlaySound.Checked;
        }
    }
}