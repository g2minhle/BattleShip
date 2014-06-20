using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Const
{
    public class Const
    {
        #region Stt
        public static int Unknow { get { return 0; } }
        public static int Water { get { return -1; } }
        public static int ShipPart { get { return -2; } }
        #endregion
        public static int Lose { get { return 6; } }

        public static int[] loandong ={ -1, 0, 1, 0 };
        public static int[] loancot ={ 0, 1, 0, -1 };

        public static Color Unselected { get { return Color.Coral; } }
        public static Color Selected { get { return Color.Lime; } }
        public static Color Selecting { get { return Color.Aqua; } }
        public static Color WaterColor { get { return Color.Aquamarine; } }
        public static Color ShootedWaterColor { get { return Color.Blue; } }

        public static string TheFire { get { return "Resources\\fire.bmp"; } }

        public static string MissedSound { get { return "Resources\\Sound\\IntoWater.wav"; } }
        public static string SeaSound { get { return "Resources\\Sound\\Sea.wav"; } }
        public static string BumSound { get { return "Resources\\Sound\\Destroyed.wav"; } }
        public static string FireSound { get { return "Resources\\Sound\\Fire.wav"; } }
        public static string GunSound1 { get { return "Resources\\Sound\\GunFire1.wav"; } }
        public static string GunSound2 { get { return "Resources\\Sound\\GunFire2.wav"; } }
        public static string WinSound { get { return "Resources\\Sound\\Win.wav"; } }
        public static string LoseSound { get { return "Resources\\Sound\\Lose.wav"; } } 
        
    }
}
