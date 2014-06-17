using System;
using System.Collections.Generic;
using System.Text;

namespace BattleField
{
    public class HumanField : WithField
    {
        public HumanField(int height, int width, Player.APlayer feild)
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
