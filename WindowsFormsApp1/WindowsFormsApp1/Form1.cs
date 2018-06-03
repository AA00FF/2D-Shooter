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
        bool pause = false;
        List<Enemy> enemys = new List<Enemy>();
        List<Bullet> bullet = new List<Bullet>();
        int x = 0, y = 0;
        Player sp = new Player(0, 0);
        

        public Form1()
        {
            InitializeComponent();
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                if (!pause)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    pause = !pause;
                    label6.Visible = true;
                }
                else
                {
                    timer1.Start();
                    timer2.Start();
                    timer3.Start();
                    pause = !pause;
                    label6.Visible = false;
                }
            }
            if (!dieded && !pause)
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        if (sp.p.Location.Y != 0)
                            sp.MoveUp();
                        break;

                    case Keys.Down:
                        if (sp.p.Location.Y != 400)
                            sp.MoveDown();
                        break;

                    case Keys.Right:
                        if (sp.p.Location.X != 900)
                            sp.MoveRight();
                        break;

                    case Keys.Left:
                        if (sp.p.Location.X != 0)
                            sp.MoveLeft();
                        break;

                    case Keys.X:
                        Bullet b = new Bullet(sp.p.Location.X, sp.p.Location.Y, true);
                        bullet.Add(b);
                        panel1.Controls.Add(b.p);
                        break;
                }
        }

        public void Init()
        {
            panel1.Controls.Clear();
            sp.p = pictureBox_player;
            sp.p.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "Spaceship.png";
            sp.p.Location = new Point(0, 0);
            sp.p.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(sp.p);
            SpawnEnemy();
            dieded = false;
            label1.Text = "Points: 0";
            Punkte = 0;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy();
            }
        }

        static Random rnd = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Visible = false;
            label1.Text = "Points: 0";
            dieded = false;
            timer4.Start();
        }
        private bool dieded;
        private void eshoot()
        {
            int z;
            foreach (Enemy e in enemys)
            {
                z = rnd.Next(0, 101);
                if (z < 5)
                {
                    Bullet b = new Bullet(e.p.Location.X, e.p.Location.Y, false);
                    bullet.Add(b);
                    panel1.Controls.Add(b.p);
                }

            }
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
                if (enemys[i].p.Location.X == sp.p.Location.X && enemys[i].p.Location.Y == sp.p.Location.Y)
                {
                    GameEnd();
                }
            }
        }
        private void GameEnd()
        {
            panel1.Controls.Clear();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            PictureBox over = new PictureBox();
            over.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "gameover.png";
            over.Location = new Point(450, 200);
            over.SizeMode = PictureBoxSizeMode.AutoSize;
            panel1.Controls.Add(over);
            button_restart.Visible = true;
            button_restart.Enabled = true;
            bullet.Clear();
            enemys.Clear();
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
        private int Punkte { get; set; }
        private void hit()
        {
            List<Enemy> removeenemy = new List<Enemy>();
            List<Bullet> removeb = new List<Bullet>();
            try
            {
                foreach (Enemy e in enemys)
                {
                    if (e.p.Location != null)
                    {
                        foreach (Bullet b in bullet)
                        {
                            if (pictureBox_player != null)
                            {
                                if (e.p.Location.X == b.p.Location.X && e.p.Location.Y == b.p.Location.Y && b.Player == true)
                                {
                                    Punkte = Punkte + 100;
                                    removeb.Add(b);
                                    removeenemy.Add(e);
                                    label1.Text = "Points: " + Punkte.ToString();
                                }
                                if (sp.p.Location.X == b.p.Location.X && sp.p.Location.Y == b.p.Location.Y && b.Player == false)
                                {
                                    dieded = true;
                                    GameEnd();
                                }
                            }
                        }


                    }

                }
            }
            catch (Exception)
            {

            }


            foreach (Enemy e in removeenemy)
            {
                enemys.Remove(e);
                panel1.Controls.Remove(e.p);
            }
            foreach (Bullet a in removeb)
            {
                bullet.Remove(a);
                panel1.Controls.Remove(a.p);
            }
        }

        private void DeleteBullet()
        {

            List<Bullet> removebullet = new List<Bullet>();

            foreach (Bullet b in bullet)
            {
                if (b.p.Location != null)
                {
                    if (b.p.Location.X > 900 || b.p.Location.X < 0)
                    {

                        removebullet.Add(b);
                    }
                }
            }

            foreach (Bullet b in removebullet)
            {

                bullet.Remove(b);
                panel1.Controls.Remove(b.p);
            }
        }
        private void pictureBox_player_Click(object sender, EventArgs e)
        {
            //pictureBox_player.ImageLocation = AppDomain.CurrentDomain.BaseDirectory + "pepe.jpg";
            //vllt ein secret char
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            eshoot();
            DeleteBullet();
            foreach (Bullet b in bullet)
            {
                if (b.Player == true)
                {

                    b.shoot(b.p.Location.X + 100, b.p.Location.Y);

                }
                else
                {
                    b.shoot(b.p.Location.X - 100, b.p.Location.Y);

                }
            }
            hit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            SpawnEnemy();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Init();
            button_start.Visible = false;
            button_start.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_restart_Click(object sender, EventArgs e)
        {
            button_restart.Visible = false;
            button_restart.Enabled = false;
            pause = false;
            label6.Visible = false;
            Init();

        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void SpawnEnemy()
        {
            Enemy e = new Enemy();
            enemys.Add(e);
            panel1.Controls.Add(e.p);


        }


    }
}
