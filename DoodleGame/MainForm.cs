using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoodleGame
{
    public partial class MainForm : Form
    {
        public bool goLeft, goRight, jumping, isGameOver;

        public int jumpSpeed = 10;
        public int force = 8;
        public int score = 0;
        public int playerSpeed = 7;

        public int horizontalSpeed = 5;
        public int verticalSpeed = 3;

        public int enemyOneSpeed = 5;
        public int enemyTwoSpeed = 3;

        Image player;

        private int currAnimation = 0;
        private int currFrame = 2;

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (jumping == true)
            {
                jumping = false;
            }

            if(e.KeyCode == Keys.Enter&&isGameOver==true)
            {
                RestartGame();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Space && jumping == false)
            {
                jumping = true;
            }
        }
   
        public MainForm()
        {
            InitializeComponent();

            //player = new Bitmap("C:\\Users\\Макс\\Documents\\GitHub\\studGame\\DoodleGame\\Resources\\sp.png");
            //gameTimer.Interval = 100;
            //gameTimer.Tick += new EventHandler(Update);
            //gameTimer.Start();
            //this.KeyDown += new KeyEventHandler(keyboard);
        }

        private void MainGameTimer(object sender, EventArgs e)
        {
            textScore.Text = "Ваш счет: " + score;

            playerImg.Top += jumpSpeed;

            if(goLeft==true)
            {
                playerImg.Left -= playerSpeed;
            }

            if(goRight==true)
            {
                playerImg.Left += playerSpeed;
            }

            if(jumping==true && force<0)
            {
                jumping = false;
            }

            if(jumping==true)
            {
                jumpSpeed = -8;
                force -= 1;
            }

            else
            {
                jumpSpeed = 10;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox)
                {
                    if((string)x.Tag=="platform")
                    {
                        if(playerImg.Bounds.IntersectsWith(x.Bounds))
                        {
                            force = 8;
                            playerImg.Top = x.Top - playerImg.Height;
                        }
                        x.BringToFront();
                    }
                       
                }

                if((string)x.Tag=="coin")
                {
                    if(playerImg.Bounds.IntersectsWith(x.Bounds)&&x.Visible==true)
                    {
                        x.Visible = false;
                        score++;
                    }
                }

                if((string)x.Tag=="enemy")
                {
                    if(playerImg.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        isGameOver = true;
                        textScore.Text = "Ваш счет: " + score + Environment.NewLine + "Вы погибли!";
                    }
                }
            }


            platform3.Left -= horizontalSpeed;

            if(platform3.Left<0||platform3.Left+platform3.Width>this.ClientSize.Width)
            {
                horizontalSpeed = -horizontalSpeed;
            }


        }
        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;
            textScore.Text = "Ваш счет: " + score;

            foreach (Control x in this.Controls)
            {
                if(x is PictureBox && x.Visible == false)
                {
                    x.Visible = true;
                }
            }
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            //switch (e.KeyCode.ToString())
            //{
            //    case "D":
            //        currAnimation = 1;
            //        break;
            //    case "A":
            //        currAnimation = 4;
            //        break;
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Update(object sender, EventArgs e)
        {
            //PlayAnimation();
            //if (currFrame == 10)
            //    currFrame = 0;
            //currFrame++;
        }
        private void PlayAnimation()
        {
            //if (currAnimation !=0)
            //{
            //Image part = new Bitmap(50, 86);
            //Graphics g = Graphics.FromImage(part);
            //g.DrawImage(player, 0, 0, new Rectangle(new Point(50 * currFrame, 0 ), new Size(50, 86)), GraphicsUnit.Pixel);
            //playerImg.Size = new Size(50, 86);
            //playerImg.Image = part;
            //}
        }
    }
}
