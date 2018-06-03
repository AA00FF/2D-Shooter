using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    class Enemy
    {
        static Random rnd = new Random();
        public PictureBox p { get; private set; } = new PictureBox();

        public Enemy()
        {
            int y = rnd.Next(0, 5) * 100;
            this.p.Location = new Point(900, y);
            this.p.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "Enemy.png";
            this.p.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        int direction;
        int PickDirection { get { return direction = rnd.Next(0, 3); } }

        public void EnemyMove()
        {
            if (direction == 0 && p.Location.X != 0)
            {
                p.Location = new Point(p.Location.X - 100, p.Location.Y);
                

            }
        }
    }
}
