using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Player;
using BattleField;
using System.Media;

namespace OffLine
{
    public partial class frm_OffLine : Form
    {
        APlayer CPU;
        APlayer human;
        public frm_OffLine(APlayer human)
        {
            InitializeComponent();
            this.human = human;
            MakeCPUSea();
        }
        private void MakeCPUSea()
        {
            CPU = new APlayer(human.Height, human.Width);
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                while (!CPU.Push(rnd.Next(0, human.Height - 1)
                    , rnd.Next(0, human.Width - 1)
                    , rnd.Next(0, 3), i + 1)) ;
        }

        CPUFeild enemy;
        BattleField.HumanFeild mine;
        void mine_Lose()
        {
            SoundPlayer sp = new SoundPlayer(Const.Const.LoseSound);
            sp.PlayLooping();
            MessageBox.Show("YOU LOSE !!!!!!!!!!!!!!!!");
            sp.Stop();
            this.Close();
        }
        void enemy_Lose()
        {
            SoundPlayer sp = new SoundPlayer(Const.Const.WinSound);
            sp.PlayLooping();
            MessageBox.Show("YOU WIN !!!!!!!!!!!!!!!!!!");
            sp.Stop();
            this.Close();
        }

        void enemy_Shooted()
        {
            CPUShoot();
        }
        #region Cpu shoot
        void mine_Destroyed(int number, Player.Point head, Player.Point tail, int direction)
        {
            for (int i = hittedpoint.Count - 1; i > -1; i--)
                if (AShip.BelongToThis(number, direction, head, hittedpoint[i]))
                    hittedpoint.RemoveAt(i);

            postohit.Clear();

            for (int i = 0; i < hittedpoint.Count; i++)
                SavePointToHit(hittedpoint[i]);
        }
        bool BelongToHitted(int i, int j)
        {
            for (int k = 0; k < hittedpoint.Count; k++)
                if ((i == hittedpoint[k].I) && (j == hittedpoint[k].J)) return true;
            return false;
        }
        void mine_Hitted(int i, int j)
        {
            Player.Point pt = new Player.Point(i, j);
            hittedpoint.Add(pt);
            SavePointToHit(new Player.Point(i, j));
            //look for hitted part around => make sequence
            for (int k = 0; k < 4; k++)
            {
                Player.Point tmp = new Player.Point(0, 0);
                tmp.J = j + Const.Const.loancot[k];
                tmp.I = i + Const.Const.loandong[k];
                if (BelongToHitted(tmp.I, tmp.J))
                {
                    Player.Point newpos = new Player.Point(i + (i - tmp.I), j + (j - tmp.J));
                    postohit.Push(newpos);
                    return;
                }
            }
        }
        Stack<Player.Point> postohit;
        List<Player.Point> hittedpoint;
        bool HitAble(int line, int col)
        {
            if (line < 0 || line >= mine.Player.Height) return false;
            if (col < 0 || col >= mine.Player.Width) return false;
            if ((mine.Player.Sea[line][col] == Const.Const.Water)
                || (mine.Player.Sea[line][col] == Const.Const.ShipPart))
                return false;
            return true;
        }
        bool GoodRndPosToShoot(int line, int col)
        {
            if (HitAble(line, col))
            {
                if ((line % 2 == 0) && (col % 2 == 0)) return true;
                if ((line % 2 == 1) && (col % 2 == 1)) return true;
            }
            return false;
        }
        void SavePointToHit(Player.Point p)
        {
            for (int i = 0; i < 4; i++)
            {
                Player.Point tmp = new Player.Point(0, 0);
                tmp.J = p.J + Const.Const.loancot[i];
                tmp.I = p.I + Const.Const.loandong[i];
                postohit.Push(tmp);
            }
        }

        private Player.Point GetNewShootPoint()
        {
            Random rnd = new Random();
            Player.Point p = new Player.Point(0, 0);
            do
            {
                p.I = rnd.Next(0, mine.Player.Height - 1);
                p.J = rnd.Next(0, mine.Player.Width - 1);
            } while (!GoodRndPosToShoot(p.I, p.J));
            return p;
        }
        void CPUShoot()
        {
            Player.Point shootpoint;
            if (postohit.Count > 0)
            {
                shootpoint = postohit.Pop();
                while (!HitAble(shootpoint.I, shootpoint.J))
                    shootpoint = postohit.Pop();
            }
            else shootpoint = GetNewShootPoint();
            mine.Shooted(shootpoint.I, shootpoint.J);
        }
        #endregion

        private void cb_PlaySound_CheckedChanged(object sender, EventArgs e)
        {
            enemy.Sound = cb_PlaySound.Checked;
            mine.Sound = cb_PlaySound.Checked;
        }

        private void frm_OffLine_Shown(object sender, EventArgs e)
        {
            enemy = new CPUFeild(CPU.Height, CPU.Width, CPU);
            enemy.Shooted += new CPUFeild.ShootedHandel(enemy_Shooted);
            enemy.Lose += new CPUFeild.LoseHandel(enemy_Lose);
            mine = new HumanFeild(human.Height, human.Width, human);
            mine.Lose += new HumanFeild.LoseHandel(mine_Lose);
            mine.Hitted += new HumanFeild.HittedHandel(mine_Hitted);
            mine.Destroyed += new HumanFeild.ShipDestroyedHandel(mine_Destroyed);
            pn_CPU.Controls.Add(enemy);
            pn_Player.Controls.Add(mine);
            mine.DrawShips();
            hittedpoint = new List<Player.Point>();
            postohit = new Stack<Player.Point>();
        }
        bool noexit;
        public bool NoExit
        { get { return noexit; } }
        private void cmd_Cancel_Click(object sender, EventArgs e)
        {
            noexit = true;
            Close();
        }

    }
    public class CPUFeild : BattleField.WithFeild
    {
        public CPUFeild(int height, int width, APlayer feild)
        {
            GetField(feild);
            showship = false;
        }
        public delegate void ShootedHandel();
        public event ShootedHandel Shooted;
        protected override void lb_MouseClick(object sender, MouseEventArgs e)
        {
            Label tmp = (Label)sender;
            int i = 0, j = 0;
            Tools.Tools.GetPosOfLB(ref i, ref j, tmp.Name);
            FireTriggle();
            ShootAt(i, j);
            Shooted();
        }
        public void ShootAt(int i, int j)
        {
            player.ShootAt(i, j);
        }
 
        protected override void player_Destroyed(int number, Player.Point head, Player.Point tail, int direction)
        {
            DrawShip(number);
        }
    }
    
}