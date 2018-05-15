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
        List<Enemy> enemys = new List<Enemy>();
        int x = 0, y = 0;
        public int[,] position_player { get; private set; } = new int[10, 5];

        public Form1()
        {
            InitializeComponent();
        }
        private void MoveUp()
        {
            position_player[x, y] = 0;
            pictureBox_player.Location = new Point(pictureBox_player.Location.X, pictureBox_player.Location.Y - 100);
            y = pictureBox_player.Location.Y / 100;
            position_player[x, y] = 1;
        }

        private void MoveDown()
        {
            position_player[x, y] = 0;
            pictureBox_player.Location = new Point(pictureBox_player.Location.X, pictureBox_player.Location.Y + 100);
            y = pictureBox_player.Location.Y / 100;
            position_player[x, y] = 1;
        }

        private void MoveRight()
        {
            position_player[x, y] = 0;
            pictureBox_player.Location = new Point(pictureBox_player.Location.X + 100, pictureBox_player.Location.Y);
            x = pictureBox_player.Location.X / 100;
            position_player[x, y] = 1;
        }

        private void MoveLeft()
        {
            position_player[x, y] = 0;
            pictureBox_player.Location = new Point(pictureBox_player.Location.X - 100, pictureBox_player.Location.Y);
            x = pictureBox_player.Location.X / 100;
            position_player[x, y] = 1;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (pictureBox_player.Location.Y != 0)
                        MoveUp();
                    break;

                case Keys.Down:
                    if (pictureBox_player.Location.Y != 400)
                        MoveDown();
                    break;

                case Keys.Right:
                    if (pictureBox_player.Location.X != 900)
                        MoveRight();
                    break;

                case Keys.Left:
                    if (pictureBox_player.Location.X != 0)
                        MoveLeft();
                    break;

                case Keys.Space:
                    SpawnEnemy();
                    break;
            }
        }

        static Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_player.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "Spaceship.png";
            pictureBox_player.Location = new Point(0, 0);
            position_player[0, 0] = 1;
            SpawnEnemy();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DeleteEnemy();
            
            for (int i = 0; i < enemys.Count; i++)
            {
                enemys[i].EnemyMove();
            }
        }

        private void DeleteEnemy()
        {
            List<Enemy> removeenemy = new List<Enemy>();
            foreach (Enemy e in enemys)
            {
                if(e.p.Location != null)
                {
                    if (e.p.Location.X == 0)
                    {
                        removeenemy.Add(e);
                    }
                }
            }

            foreach(Enemy e in removeenemy)
            {
                enemys.Remove(e);
                panel1.Controls.Remove(e.p);
            }
        }

        private void SpawnEnemy()
        {
            Enemy e = new Enemy();
            enemys.Add(e);
            panel1.Controls.Add(e.p);
        }


    }
}
