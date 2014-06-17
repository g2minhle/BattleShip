using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace Tools
{
    public class Tools
    {
        public static void LoadShip(ref PictureBox pic, int id, int direction)
        {
            pic.Load("Ship\\" + direction + "\\" + id + ".wmf");
        }
        public static void GetPosOfLB(ref int i, ref int j, string s)
        {
            string[] tmp = s.Split('.');
            i = int.Parse(tmp[0]);
            j = int.Parse(tmp[1]);
        }
    }
    public struct MySize
    {
        public int height;
        public int width;
    }
}
