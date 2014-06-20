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
            pic.Load(string.Format("Ship\\{0}\\{1}.wmf", +direction, id));
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
