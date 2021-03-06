﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace WindowsFormsApp1
{
    class Bullet
    {

        public int Y { get; set; }
        public int X { get; set; }
        public bool Player { get; set; }
        public PictureBox p { get; private set; } = new PictureBox();
        public Bullet(int x, int y, bool player)
        {

            X = x;
            Y = y;
            p.Location = new Point(X, Y);
            if (player == false)
            {
                this.p.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "ebullet.png";
            }
            else
            {
                this.p.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "bullet.png";
            }

            this.p.SizeMode = PictureBoxSizeMode.AutoSize;
            Player = player;
        }
        public void shoot(int x, int y)
        {
            p.Location = new Point(x, y);

        }

    }
}
