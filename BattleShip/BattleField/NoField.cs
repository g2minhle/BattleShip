using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Media;
namespace BattleField
{
    public class NoField : BattleField
    {
        public NoField() { }
        public NoField(int height, int width)
        {
            New(height, width);
        }
        public void HittedAt(int i, int j) { PartHitted(i, j); }
        public void MissedAt(int i, int j) { Missed(i, j, lbinfo.height, lbinfo.width); }
        public void DestroyedShip(int number, Player.Point head, int direction) { DrawShip(head.I, head.J, direction, number - 1); }
        public delegate void ShootedHandel(int i, int j);
        public event ShootedHandel ShootAt;
        protected override void lb_MouseClick(object sender, MouseEventArgs e)
        {
            Label tmp = (Label)sender;
            int i = 0, j = 0;
            Tools.Tools.GetPosOfLB(ref i, ref j, tmp.Name);
            FireTriggle();
            ShootAt(i, j);
        }
    }
}
