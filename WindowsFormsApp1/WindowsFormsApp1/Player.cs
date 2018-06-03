using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Player
    {
        public PictureBox p { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public Player(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void MoveUp()
        {
            p.Location = new Point(p.Location.X, p.Location.Y - 100);
            y = p.Location.Y / 100;
        }

        public void MoveDown()
        {
            p.Location = new Point(p.Location.X, p.Location.Y + 100);
            y = p.Location.Y / 100;
        }

        public void MoveRight()
        {
            p.Location = new Point(p.Location.X + 100, p.Location.Y);
            x = p.Location.X / 100;
        }

        public void MoveLeft()
        {
            p.Location = new Point(p.Location.X - 100, p.Location.Y);
            x = p.Location.X / 100;
        }
    }
}
