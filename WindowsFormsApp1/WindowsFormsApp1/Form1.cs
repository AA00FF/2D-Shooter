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
        List<Bullet> bullet = new List<Bullet>();
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
                case Keys.X:
                    Bullet b = new Bullet(pictureBox_player.Location.X,pictureBox_player.Location.Y, true);
                    bullet.Add(b);
                    panel1.Controls.Add(b.p);
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
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DeleteEnemy();

            for (int i = 0; i < enemys.Count; i++)
            {
                foreach (Bullet b in bullet)
                {
                    if (b.p.Location.X == enemys[i].p.Location.X && b.p.Location.Y == enemys[i].p.Location.Y)
                    {
                        DeleteEnemy();
                    }
                }
                enemys[i].EnemyMove();
            }
        }

        private void DeleteEnemy()
        {
            List<Enemy> removeenemy = new List<Enemy>();
            foreach (Enemy e in enemys)
            {
                if (e.p.Location != null)
                {
                    if (e.p.Location.X == 0)
                    {
                        removeenemy.Add(e);
                    }
                }
            }

            foreach (Enemy e in removeenemy)
            {
                enemys.Remove(e);
                panel1.Controls.Remove(e.p);
            }
        }
        private void hit()
        {
            List<Enemy> removeenemy = new List<Enemy>();
            List<Bullet> removeb = new List<Bullet>();
            foreach (Enemy e in enemys)
            {
                if (e.p.Location != null)
                {
                    foreach (Bullet b in bullet)
                    {
                        if (e.p.Location.X == b.p.Location.X && e.p.Location.Y == b.p.Location.Y)
                        {
                            removeb.Add(b);
                            removeenemy.Add(e);
                        }
                    }
                    
                }
                
            }

            foreach (Enemy e in removeenemy)
            {
                enemys.Remove(e);
                panel1.Controls.Remove(e.p);
            }
            foreach(Bullet a in removeb)
            {
                bullet.Remove(a);
                panel1.Controls.Remove(a.p);
            }
        }
        private void DeleteBullet(Bullet c)
        {
            List<Bullet> removebullet = new List<Bullet>();
            removebullet.Add(c);
            foreach (Bullet b in bullet)
            {
                if (b.p.Location != null)
                {
                    if (b.p.Location.X == 900)
                    {
                        
                        removebullet.Add(b);
                    }
                }
            }
            bullet.Remove(c);
            panel1.Controls.Remove(c.p);
            foreach (Bullet b in removebullet)
            {
                
                bullet.Remove(b);
                panel1.Controls.Remove(b.p);
            }
        }
        private void pictureBox_player_Click(object sender, EventArgs e)
        {

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            foreach (Bullet b in bullet)
            {
                if (b.Player == true)
                {

                    b.shoot(b.p.Location.X + 100, b.p.Location.Y);
                    
                }
                else
                {
                    b.shoot(b.X-100, b.Y);
                    
                }
            }
            hit();
        }

        private void SpawnEnemy()
        {
            Enemy e = new Enemy();
            enemys.Add(e);
            panel1.Controls.Add(e.p);
        }


    }
}
