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
    public class HumanFeild : WithFeild
    {
        public HumanFeild(int height, int width, Player.APlayer feild)
        {
            GetField(feild);
            showship = true;
        }
        public void DrawShips()
        { Redraw(); }
        public void Shooted(int i, int j)
        {
            FireTriggle();
            player.ShootAt(i, j);
        }
    }
}
