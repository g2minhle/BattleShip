using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
// index=number-1
// length=number+1
namespace Player
{
    public class Point
    {
        int j, i;
        public int J { get { return j; } set { j = value; } }
        public int I { get { return i; } set { i = value; } }
        public Point(int i, int j)
        {
            this.j = j;
            this.i = i;
        }
    }
    class ShipTools
    {
        public static Point GetTail(Point head, int direction, int id)
        {
            Point tail = new Point(head.I + (Const.Const.RowSpread[direction] * (id))
                , head.J + (Const.Const.ColSpread[direction] * (id)));
            return tail;
        }
        public static void GetTail(Point head, ref Point tail, int direction, int id)
        {
            tail = new Point(head.I + (Const.Const.RowSpread[direction] * (id))
                , head.J + (Const.Const.ColSpread[direction] * (id)));
        }
    }
    public class AShip
    {
        #region Inumber
        int number;
        public int Number { get { return number; } }
        #endregion
        bool setin;
        public delegate void BeDestroyed(int number, Point head, Point tail, int direction);
        public event BeDestroyed Destroyed;
        int curlen;
        public int direction;
        private Point poshead;
        private Point postail;
        public static bool BelongToThis(int number, int direction, Point head, Point p)
        {
            Point tail = ShipTools.GetTail(head, direction, number);
            switch (direction)
            {
                case 0:
                    if ((p.J == head.J) && (p.I <= head.I) && (p.I >= tail.I)) return true;
                    break;
                case 1:
                    if ((p.I == head.I) && (p.J >= head.J) && (p.J <= tail.J)) return true;
                    break;
                case 2:
                    if ((p.J == head.J) && (p.I >= head.I) && (p.I <= tail.I)) return true;
                    break;
                case 3:
                    if ((p.I == head.I) && (p.J <= head.J) && (p.J >= tail.J)) return true;
                    break;
            }
            return false;
        }
        public bool SetIn { get { return setin; } set { setin = value; } }
        public Point Head { get { return poshead; } }
        public Point Tail { get { return postail; } }
        public bool Alive { get { if (curlen == 0) return false; else return true; } }
        public AShip(int number)
        {
            this.curlen = number + 1;
            this.number = number;
            setin = false;
        }

        public void PutShipIn(int i, int j, int direction)
        {
            poshead = new Point(i, j);
            ShipTools.GetTail(poshead, ref postail, direction, number);
            this.direction = direction;
            setin = true;
        }
        public void BeShooted()
        {
            curlen--;
            if (curlen == 0)
            {
                Destroyed(number, poshead, postail, direction);
            }
        }
    }

    public class APlayer
    {
        int[][] sea;
        Tools.MySize size;
        List<AShip> ships;
        int totalship;
        #region Size
        public int Width { get { return size.width; } }
        public int Height { get { return size.height; } }
        #endregion

        public APlayer(int height, int width)
        {
            size.height = height;
            size.width = width;

            sea = new int[height][];
            for (int i = 0; i < height; i++)
            {
                sea[i] = new int[width];
            }

            ships = new List<AShip>();
            for (int i = 1; i < 6; i++)
            {
                AShip tmp = new AShip(i);
                tmp.Destroyed += new AShip.BeDestroyed(tmp_Destroyed);
                ships.Add(tmp);
            }
            totalship = 5;
        }

        void tmp_Destroyed(int number, Point head, Point tail, int direction)
        {
            totalship--;
            if (totalship == 0)
                Lose();
            else
                Destroyed(number, head, tail, direction);
        }
        public List<AShip> Ship { get { return ships; } set { ships = value; } }
        public int[][] Sea { get { return sea; } set { sea = value; } }
        public delegate void ShipDestroyedHandel(int number, Point head, Point tail, int direction);
        public event ShipDestroyedHandel Destroyed;
        public delegate void LoseHandel();
        public event LoseHandel Lose;
        public delegate void MissedHandel(int i, int j);
        public event MissedHandel Missed;
        public delegate void HittedHandel(int i, int j);
        public event HittedHandel Hitted;
        public void ShootAt(int i, int j)
        {
            int value = sea[i][j];
            if (value > 0)
            {
                sea[i][j] = Const.Const.ShipPart;
                Hitted(i, j);
                ships[value - 1].BeShooted();
            }
            else
            {
                sea[i][j] = Const.Const.Water;
                Missed(i, j);
            }
        }

        public bool AbleToPutIn(int i, int j, int direction, int id)
        {
            Point head = new Point(i, j);
            Point tail = new Point(0, 0);
            ShipTools.GetTail(head, ref tail, direction, id);

            if ((tail.J < 0) || (tail.J >= size.width)) return false;
            if ((tail.I < 0) || (tail.I >= size.height)) return false;

            if (direction == 1 || direction == 3)
            {
                for (int k = 0; k < id + 1; k++)
                {
                    if (sea[i][j + (k * Const.Const.ColSpread[direction])] != Const.Const.Unknow) return false;
                }
            }
            else
            {
                for (int k = 0; k < id + 1; k++)
                {
                    if (sea[i + (k * Const.Const.RowSpread[direction])][j] != Const.Const.Unknow) return false;
                }
            }
            return true;
        }


        void PutInValue(int i, int j, int direction, int length, int value)
        {
            if (direction == 1 || direction == 3)
            {
                for (int k = 0; k < length; k++)
                {
                    sea[i][j + (k * Const.Const.ColSpread[direction])] = value;
                }
            }
            else
            {
                for (int k = 0; k < length; k++)
                {
                    sea[i + (k * Const.Const.RowSpread[direction])][j] = value;
                }
            }
        }
        public bool Push(int i, int j, int direction, int id)
        {
            if (AbleToPutIn(i, j, direction, id))
            {
                PutInValue(i, j, direction, id + 1, id);
                ships[id - 1].PutShipIn(i, j, direction);
                return true;
            }
            return false;
        }
        public void Remove(int id)
        {
            if (ships[id - 1].SetIn == false) return;
            int index = id - 1;

            int direction = ships[index].direction;
            int i = ships[index].Head.I;
            int j = ships[index].Head.J;

            PutInValue(i, j, direction, id + 1, Const.Const.Unknow);

            ships[id - 1].SetIn = false;
        }
    }
}
