using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
namespace ShipBuilder
{
    public partial class ShipList : UserControl
    {
        public ShipList()
        {
            InitializeComponent();
        }
        public bool AllHaveBeenSetUp()
        {
            for (int i = 0; i < 5; i++)
            {
                if (mark[i] == 0) return false;
            }
            return true;
        }
        private void ShipList_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 6; i++)                                                
            {
                PictureBox tmp = (PictureBox)this.Controls["pic_" + i];
                Tools.Tools.LoadShip(ref tmp, i, 3);
                this.Controls.RemoveByKey("pic_" + i);
                tmp.Click += new EventHandler(tmp_Click);
                this.Controls.Add(tmp);
            }
        }
        public delegate void ShipSel(int curship);
        public event ShipSel ShipSelected;
        void tmp_Click(object sender, EventArgs e)
        {
            PicLicked(sender);
        }
        private void PicLicked(object sender)
        {
            UnSeclectAll();
            PictureBox tmp = (PictureBox)sender;
            tmp.BackColor = Const.Const.Selecting;
            int curship = int.Parse(tmp.Name[tmp.Name.Length - 1].ToString());
            ShipSelected(curship);   
            if (mark[curship - 1] == 1)
            {
                mark[curship - 1] = 0;
            }
        }
        public void SetControl()
        {
            this.Top = 15;
            this.Left = 10;
            this.Height = this.Parent.Height-20;
            this.Width = this.Parent.Width-20;
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
        int[] mark ={ 0, 0, 0, 0, 0 };
        public void UnSeclectAll()
        {
            for (int i = 0; i < 5; i++)
            {
                int j = i + 1;
                PictureBox tmp = (PictureBox)this.Controls["pic_" + j];
                if (mark[i] == 0) tmp.BackColor = Const.Const.Unselected;
                else
                    if (mark[i] == 1) tmp.BackColor = Const.Const.Selected;
                this.Controls.RemoveByKey("pic_" + j);
                this.Controls.Add(tmp);
            }
        }
        public void Done(int index)
        {
            mark[index - 1] = 1;
            UnSeclectAll();
        }
    }
}
