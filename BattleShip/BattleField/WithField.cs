﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BattleField
{
    public class WithField : BattleField
    {
        public WithField()
        { }
        public delegate void HittedHandel(int i, int j);
        public event HittedHandel Hitted;
        public delegate void MissedHandel(int i, int j);
        public event MissedHandel Missed;
        public delegate void ShipDestroyedHandel(int number, Player.Point head, Player.Point tail, int direction);
        public event ShipDestroyedHandel Destroyed;
        protected void GetField(Player.APlayer field)
        {
            base.New(field.Height, field.Width);
            player = field;
            CreatePlayerEvent();
        }
        protected override void player_Destroyed(int number, Player.Point head, Player.Point tail, int direction)
        {
            try
            {
                Destroyed(number, head, tail, direction);
            }
            catch { }
        }
        protected override void player_Hitted(int i, int j)
        {
            try
            {
                base.player_Hitted(i, j);
                Hitted(i, j);
            }
            catch { }
        }
    }
}
