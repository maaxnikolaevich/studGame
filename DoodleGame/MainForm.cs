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
        Timer gameTimer;

        public bool goLeft, goRight, jumping, isGameOver;

        public int jumpSpeed = 10;
        public int force = 8;
        public int score = 0;
        public int playerSpeed = 7;

        public int horizontalSpeed = 5;
        public int verticalSpeed = 3;

        public int monster1Speed = 2;
        public int monster2Speed = 2;
        public int monster3Speed = 2;
        public int monster4Speed = 2;
        public int monster5Speed = 2;

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
            this.Paint += new PaintEventHandler(DrawGame);
            //player = new Bitmap("C:\\Users\\Макс\\Documents\\GitHub\\studGame\\DoodleGame\\Resources\\sp.png");
            //gameTimer.Interval = 100;
            //gameTimer.Tick += new EventHandler(Update);
            //gameTimer.Start();
            //this.KeyDown += new KeyEventHandler(keyboard);
        }
       
        //private void MainGameTimer(object sender, EventArgs e)
        //{
        //    //textScore.Text = "Ваш счет: " + score;

        //    playerImg.Top += jumpSpeed;

        //    if(goLeft==true)
        //    {
        //        playerImg.Left -= playerSpeed;
        //    }

        //    if(goRight==true)
        //    {
        //        playerImg.Left += playerSpeed;
        //    }

        //    if(jumping==true && force<0)
        //    {
        //        jumping = false;
        //    }

        //    if(jumping==true)
        //    {
        //        jumpSpeed = -8;
        //        force -= 1;
        //    }

        //    else
        //    {
        //        jumpSpeed = 10;
        //    }

        //    foreach(Control x in this.Controls)
        //    {
        //        if(x is PictureBox)
        //        {
        //            if((string)x.Tag=="platform")
        //            {
        //                if(playerImg.Bounds.IntersectsWith(x.Bounds))
        //                {
        //                    force = 8;
        //                    playerImg.Top = x.Top - playerImg.Height;
        //                }
        //                x.BringToFront();
        //            }
        //        }

        //        if((string)x.Tag=="coin")
        //        {
        //            if(playerImg.Bounds.IntersectsWith(x.Bounds)&&x.Visible==true)
        //            {
        //                x.Visible = false;
        //                score++;
        //            }
        //        }

        //        if((string)x.Tag=="enemy")
        //        {
        //            if(playerImg.Bounds.IntersectsWith(x.Bounds))
        //            {
        //                gameTimer.Stop();
        //                isGameOver = true;
        //                textScore.Text = "Ваш счет: " + score + Environment.NewLine + "Вы погибли!";
        //            }
        //        }
        //    }


        //    platform3.Left -= horizontalSpeed;

        //    if(platform3.Left<0||platform3.Left+platform3.Width>this.ClientSize.Width)
        //    {
        //        horizontalSpeed = -horizontalSpeed;
        //    }

            
        //    platform12.Left -= horizontalSpeed;

        //    if (platform12.Left < 0 || platform12.Left + platform12.Width > this.ClientSize.Width)
        //    {
        //        horizontalSpeed = -horizontalSpeed;
        //    }
            
            
        //    platform7.Top += verticalSpeed;

        //    if (platform7.Top < 220 || platform7.Top > 434)
        //    {
        //        verticalSpeed = -verticalSpeed;
        //    }

        //    monster1.Left -= monster1Speed;

        //    if (monster1.Left < platform2.Left || monster1.Left + monster1.Width > platform2.Left + platform2.Width)
        //    {
        //        monster1Speed = -monster1Speed;
        //    }

            
        //    monster3.Left -= monster3Speed;
        //    if (monster3.Left < platform5.Left || monster3.Left + monster3.Width > platform5.Left + platform5.Width)
        //    {
        //        monster3Speed = -monster3Speed;
        //    }

            
        //    monster4.Left += monster4Speed;
        //    if (monster4.Left < platform8.Left || monster4.Left + monster4.Width > platform8.Left + platform8.Width)
        //    {
        //        monster4Speed = -monster4Speed;
        //    }
            
        //    monster5.Left -= monster5Speed;
        //    if (monster5.Left < platform11.Left || monster5.Left + monster5.Width > platform11.Left + platform11.Width)
        //    {
        //        monster5Speed = -monster5Speed;
        //    }

        //    monster2.Left -= monster2Speed;
        //    if (monster2.Left < platform4.Left || monster2.Left + monster2.Width > platform4.Left + platform4.Width)
        //    {
        //        monster2Speed = -monster2Speed;
        //    }

            

        //} 
        private void RestartGame()
        {
            jumping = false;
            goLeft = false;
            goRight = false;
            isGameOver = false;
            score = 0;
            //textScore.Text = "Ваш счет: " + score;

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
            //        break;    2Ё1АВЧ
            //}
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DrawGame(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            player.DrawSprite(g);
            GameController.DrawObjets(g);
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
