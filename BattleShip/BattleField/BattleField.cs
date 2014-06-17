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
    public abstract class BattleField : UserControl
    {
        #region Construct
        public BattleField() { }
        #endregion
        #region Variable
        protected List<SoundPlayer> sp;
        public bool showship;
        protected Tools.MySize lbinfo;
        protected Tools.MySize totalsize;
        protected Player.APlayer player;
        #endregion
        #region Label
        private void CreatePnBattle()
        {
            this.Controls.Remove(pn_BattleField);
            pn_BattleField.Controls.Clear();
            this.pn_BattleField.Location = new System.Drawing.Point(3, 3);
            this.pn_BattleField.Name = "pn_BattleField";
            this.pn_BattleField.Size = this.Size;
        }
        protected void MakeLabel(ref Label lb, int i, int j, int lbheight, int lbwidth)
        {
            lb.Name = i.ToString() + "." + j.ToString();
            #region Set size
            lb.Width = lbwidth;
            lb.Height = lbheight;
            lb.Top = i * lbheight;
            lb.Left = j * lbwidth;
            #endregion
            lb.BorderStyle = BorderStyle.FixedSingle;
            if (player.Sea[i][j] == Const.Const.Water)
                lb.BackColor = Const.Const.ShootedWaterColor;
            else
                lb.BackColor = Const.Const.WaterColor;
        }
        protected void AddLabels(int height, int width)
        {
            SuspendLayout();
            CreatePnBattle();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Label lb = new Label();
                    MakeLabel(ref lb, i, j, lbinfo.height, lbinfo.width);
                    lb.MouseMove += new MouseEventHandler(lb_MouseMove);
                    lb.MouseClick += new MouseEventHandler(lb_MouseClick);
                    pn_BattleField.Controls.Add(lb);
                }
            }
            this.Controls.Add(pn_BattleField);
            ResumeLayout();
        }
        #endregion
        #region Info Gate
        public Player.APlayer Player { get { return player; } }
        #endregion
        #region Event
        public delegate void LoseHandel();
        public event LoseHandel Lose;
        #endregion
        #region Player event
        protected void CreatePlayerEvent()
        {
            player.Hitted += new Player.APlayer.HittedHandel(player_Hitted);
            player.Lose += new Player.APlayer.LoseHandel(player_Lose);
            player.Missed += new Player.APlayer.MissedHandel(player_Missed);
            player.Destroyed += new Player.APlayer.ShipDestroyedHandel(player_Destroyed);
        }
        protected virtual void player_Destroyed(int number, Player.Point head, Player.Point tail, int direction) { }
        protected virtual void player_Lose() { Lose(); }
        protected virtual void player_Hitted(int i, int j) { PartHitted(i, j); }
        protected virtual void player_Missed(int i, int j) { Missed(i, j, lbinfo.height, lbinfo.width); }
        protected virtual void PartHitted(int i, int j)
        {
            AddFire(i, j, lbinfo.height, lbinfo.width);
            SoundPlay(Const.Const.BumSound);
        }
        #endregion
        #region Fire
        protected void FireTriggle()
        {
            Random rnd = new Random();
            if (rnd.Next() % 2 == 1)
                SoundPlay(Const.Const.GunSound1);
            else
                SoundPlay(Const.Const.GunSound2);
        }
        private void LoadLabel(int i, int j, int height, int width, ref PictureBox tmp)
        {
            tmp.BackColor = Const.Const.ShootedWaterColor;
            tmp.Height = height;
            tmp.Width = width;
            tmp.Top = i * height;
            tmp.Left = j * width;
            tmp.SizeMode = PictureBoxSizeMode.StretchImage;
            pn_BattleField.Controls.Add(tmp);
            tmp.BringToFront();
        }
        protected void Missed(int i, int j, Label sder)
        {
            Missed(i, j, sder.Height, sder.Width);
        }
        private void SoundPlay(string path)
        {
            if (playsound)
            {
                SoundPlayer spt = new SoundPlayer(path);
                spt.PlaySync();
            }
        }
        private void SoundLoop(string path)
        {
            if (playsound)
            {
                SoundPlayer spt = new SoundPlayer(path);
                sp.Add(spt);
                spt.PlayLooping();
            }
            else
            {
                SoundPlayer spt = new SoundPlayer(path);
                sp.Add(spt);
            }
        }
        protected void Missed(int i, int j, int height, int width)
        {
            PictureBox tmp = new PictureBox();
            LoadLabel(i, j, height, width, ref tmp);
            SoundPlay(Const.Const.MissedSound);
            this.Refresh();
        }
        protected void AddFire(int i, int j, Label sder)
        {
            AddFire(i, j, sder.Height, sder.Width);
        }
        bool playsound;
        public bool Sound
        {
            get { return playsound; }
            set
            {
                playsound = value;
                if (playsound)
                    foreach (SoundPlayer player in sp)
                        player.PlayLooping();
                else
                    foreach (SoundPlayer player in sp)
                        player.Stop();
            }
        }
        protected void AddFire(int i, int j, int height, int width)
        {
            PictureBox tmp = new PictureBox();
            LoadLabel(i, j, height, width, ref tmp);
            tmp.Load("fire.bmp");
            tmp.Name = "fire_" + i.ToString() + "." + j.ToString();
            SoundLoop(Const.Const.FireSound);
            this.Refresh();
        }
        #endregion
        #region Draw ship
        protected void DrawShip(int number)
        {
            DrawShip(player.Ship[number - 1].Head.I, player.Ship[number - 1].Head.J, player.Ship[number - 1].direction, number);
        }
        /// <summary>
        /// Draw a ship
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="direction"></param>
        /// <param name="id"></param>
        protected void DrawShip(int i, int j, int direction, int index)
        {
            PictureBox pic = new PictureBox();
            MakePictureBox(ref pic, i, j, direction, index, lbinfo.height, lbinfo.width);
            pic.MouseClick += new MouseEventHandler(pic_MouseClick);
            this.pn_BattleField.Controls.Add(pic);
            pic.BringToFront();
        }
        /// <summary>
        /// Set pic info
        /// </summary>
        /// <param name="lb"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="lbheight"></param>
        /// <param name="lbwidth"></param>
        protected void MakePictureBox(ref PictureBox tmp
       , int i, int j, int direction, int id
       , int lbheight, int lbwidth)
        {
            tmp.Name = "pic_sea_" + id;
            Tools.Tools.LoadShip(ref tmp, id, direction);
            #region Draw the ship
            switch (direction)
            {
                case 0:
                    tmp.Top = (i * lbheight) - lbheight * id;
                    tmp.Left = j * lbwidth;
                    tmp.Height = lbheight * (id + 1);
                    tmp.Width = lbwidth;
                    break;
                case 1:
                    tmp.Top = i * lbheight;
                    tmp.Left = j * lbwidth;
                    tmp.Height = lbheight;
                    tmp.Width = lbwidth * (id + 1);
                    break;
                case 2:
                    tmp.Top = i * lbheight;
                    tmp.Left = j * lbwidth;
                    tmp.Height = lbheight * (id + 1);
                    tmp.Width = lbwidth;
                    break;
                case 3:
                    tmp.Top = i * lbheight;
                    tmp.Left = (j * lbwidth) - lbwidth * (id);
                    tmp.Height = lbheight;
                    tmp.Width = lbwidth * (id + 1);
                    break;
            }
            #endregion
            tmp.SizeMode = PictureBoxSizeMode.StretchImage;
            tmp.BackColor = Color.Transparent;
            tmp.Tag = i.ToString() + '.' + j.ToString();
        }
        #endregion
        #region Virtual void
        protected virtual void lb_MouseClick(object sender, MouseEventArgs e) { }
        protected virtual void lb_MouseMove(object sender, MouseEventArgs e) { }
        protected virtual void pic_MouseClick(object sender, MouseEventArgs e) { }
        #endregion
        protected void SetAll(int height, int width)
        {

            totalsize.height = height;
            totalsize.width = width;

            lbinfo.height = this.pn_BattleField.Height / height;
            lbinfo.width = this.pn_BattleField.Width / width;

            AddLabels(totalsize.height, totalsize.width);
        }
        protected virtual void New(int height, int width)
        {
            InitializeComponent();
            playsound = true;
            player = new Player.APlayer(height, width);
            sp = new List<SoundPlayer>();
            SoundLoop(Const.Const.SeaSound);
        }
        private void ClearSound()
        {
            for (int i = 0; i < sp.Count; i++)
            {
                sp[i].Stop();
                sp[i].Dispose();
            }
        }
        void BattleField_Disposed(object sender, System.EventArgs e)
        {
            ClearSound();
        }
        protected void Redraw()
        {
            SuspendLayout();
            ClearSound();
            if (showship)
                for (int i = 0; i < 5; i++)
                    if (player.Ship[i].SetIn)
                        DrawShip(i + 1);


            for (int i = 0; i < totalsize.height; i++)
                for (int j = 0; j < totalsize.width; j++)
                    if (player.Sea[i][j] == Const.Const.ShipPart)
                        AddFire(i, j, lbinfo.height, lbinfo.width);
                    else if (player.Sea[i][j] == Const.Const.Water)
                        Missed(i, j, lbinfo.height, lbinfo.width);

            SoundLoop(Const.Const.SeaSound);
            ResumeLayout();
        }
        #region See value in debug mode
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            for (int i = 0; i < player.Height; i++)
            {
                for (int j = 0; j < player.Width; j++)
                {
                    richTextBox1.Text += player.Sea[i][j].ToString() + ' ';
                }
                richTextBox1.Text += (char)10;
            }
        }
        #endregion
        protected virtual void BattleField_ParentChanged(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Height = this.Parent.Height;
            this.Width = this.Parent.Width;
            this.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        }
        private void BattleField_Resize(object sender, EventArgs e)
        {
            SetAll(totalsize.height, totalsize.width);
            Redraw();
        }
        private void BattleField_Load(object sender, EventArgs e)
        {
            SetAll(player.Height, player.Width);
            this.Resize += new System.EventHandler(this.BattleField_Resize);
        }
    }
}