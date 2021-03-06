using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Player;
using Connector;
using BattleField;
using System.Media;
namespace PlayOnline
{
    public partial class frm_PlayOnline : Form
    {
        protected APlayer player;
        protected Connector.MainConnector con;
        protected HumanFeild mine;
        protected NoField enemy;
        protected void New(APlayer player, Connector.MainConnector con)
        {
            InitializeComponent();
            this.con = con;
            this.player = player;
            this.con.Q.Clear();
        }
        public frm_PlayOnline() { }

        protected virtual void frm_PlayOnline_Load(object sender, EventArgs e)
        {
            con.Send("done");
            Enabled = false;
            while (con.Q.Count == 0) ;
            string s = con.GetInfo();
            con.Send("done");
            Enabled = true;
        }
        protected virtual void frm_PlayOnline_Shown(object sender, EventArgs e)
        {
            con.Q.Clear();
            mine = new HumanFeild(player.Height, player.Width, player);
            mine.Lose += new BattleField.BattleField.LoseHandel(mine_Lose);
            mine.Hitted += new WithFeild.HittedHandel(mine_Hitted);
            mine.Destroyed += new WithFeild.ShipDestroyedHandel(mine_Destroyed);
            mine.Missed += new WithFeild.MissedHandel(mine_Missed);
            enemy = new NoField(player.Height, player.Width);
            enemy.ShootAt += new NoField.ShootedHandel(enemy_ShootAt);
            pn_Player.Controls.Add(mine);
            pn_CPU.Controls.Add(enemy);
            mine.DrawShips();
        }
        void WaitShoot()
        {
            while (con.Q.Count == 0) ;
            string s1 = con.GetInfo();
            con.Q.Clear();
            string[] s = s1.Split('.');
            mine.Shooted(int.Parse(s[0]), int.Parse(s[1]));
            enemy.Enabled = true;
        }
        void WaitResult()
        {
            pn_CPU.Enabled = false;
            while (con.Q.Count == 0) ;
            
            string s1 = con.GetInfo();
            con.Q.Clear();
            string[] s = s1.Split('.');
            int value = int.Parse(s[0]);
                
            if (value == Const.Const.Water)
                enemy.MissedAt(int.Parse(s[1]), int.Parse(s[2]));
            else if (value == Const.Const.ShipPart)
                enemy.HittedAt(int.Parse(s[1]), int.Parse(s[2]));
            else if (value == Const.Const.Lose)
            {
                SoundPlayer sp = new SoundPlayer(Const.Const.WinSound);
                sp.PlayLooping();
                MessageBox.Show("YOU WIN !!!!!!!!!!!!!!!!");
                sp.Stop();
                this.Close();
            }
            else
            {
                Player.Point p = new Player.Point(int.Parse(s[1]), int.Parse(s[2]));
                enemy.DestroyedShip(value, p, int.Parse(s[3]));
            }
            StartWaitShoot();
        }
        Thread waitforresult;
        Thread waitforshoot;
        protected void StartWaitShoot()
        {
            waitforshoot = new Thread(WaitShoot);
            waitforshoot.IsBackground = true;
            waitforshoot.Start();
        }
        protected void StartWaitResult()
        {
            waitforresult = new Thread(WaitResult);
            waitforresult.IsBackground = true;
            waitforresult.Start();
        }
        void enemy_ShootAt(int i, int j)
        {
            con.Send(i.ToString() + "." + j.ToString());

            StartWaitResult();
        }
        void mine_Lose()
        {
            SoundPlayer sp = new SoundPlayer(Const.Const.LoseSound);
            sp.PlayLooping();
            MessageBox.Show("YOU LOSE !!!!!!!!!!!!!!!!");
            sp.Stop();
            this.Close();
            con.Send(Const.Const.Lose.ToString());
        }

        void mine_Hitted(int i, int j)
        {
           con.Send(Const.Const.ShipPart.ToString());
        }

        void mine_Destroyed(int number, Player.Point head, Player.Point tail, int direction)
        {
            con.Send(number.ToString() + "." + head.I.ToString() + "." + head.J.ToString() + "." + direction.ToString());
        }

        void mine_Missed(int i, int j)
        {
            con.Send(Const.Const.Water.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Send("1.1");
        }
    }

    public partial class frm_Sever : frm_PlayOnline
    {
        public frm_Sever() { }
        public frm_Sever(APlayer player, Connector.MainConnector con)
        { New(player, con); this.Text = "S"; }

    }
    public partial class frm_Client : frm_PlayOnline
    {
        public frm_Client() { }
        public frm_Client(APlayer player, Connector.MainConnector con)
        { New(player, con); this.Text = "C"; }
        protected override void frm_PlayOnline_Shown(object sender, EventArgs e)
        {
            base.frm_PlayOnline_Shown(sender, e);
            enemy.Enabled = false;
            StartWaitShoot();
        }
    }

}