using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[,,,] game = new int[5, 10, 2, 2];

        public Form1()
        {
            InitializeComponent();
        }
        public void shoot(object sender, KeyEventArgs e)
        {
            Bullet b = new Bullet(pictureBox_player.Location.X, pictureBox_player.Location.Y,true);
            switch (e.KeyCode)
            {
                case Keys.Space:
                    {
                        for (int i = 0; i < 100&& b.X != INSERT.X && b.Y != INSERT.Y; i++)
                        {
                            b.X++;
                        }
                        break;
                    }
            }

        }
    }
}
