using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Bullet
    {
        
        public int Y { get; set; }
        public int X { get; set; }
        public bool Player { get; set; }
        public Bullet( int y ,int x, bool player)
        {
            X = x;
            Y = y;
            Player = player;
        }
        
       
    }
}
