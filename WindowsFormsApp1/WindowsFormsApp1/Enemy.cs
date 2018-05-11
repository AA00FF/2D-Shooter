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
        int direction;
        int PickDirection { get { return direction = rnd.Next(0, 3); } }

        public Point EnemyMove(PictureBox p)
        {
            if(direction == 0 && p.Location.X != 0)
            {
                return new Point(p.Location.X - 100, p.Location.Y);
            }
            if(direction == 1 && p.Location.Y != 400)
            {
                return new Point(p.Location.X, p.Location.Y + 100);
            }
            if(direction == 2 && p.Location.Y != 0)
            {
                return new Point(p.Location.X, p.Location.Y - 100);
            }

            return new Point();
        }
    }
}
