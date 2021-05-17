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
            if (jumping)
            {
                jumping = false;
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
            player = new Bitmap("C:\\Users\\Макс\\Documents\\GitHub\\studGame\\DoodleGame\\Resources\\player.png");
            timer1.Interval = 100;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(keyboard);

        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            
        }

        private void Update(object sender, EventArgs e)
        {
            PlayAnimation();
            if (currFrame == 11)
                currFrame = 2;
            currFrame++;
        }
        private void PlayAnimation()
        {
            if (currAnimation !=0)
            {
                Image part = new Bitmap(90, 159);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(player, 0, 0, new Rectangle(new Point(90 * currFrame,0), new Size(90, 170)), GraphicsUnit.Pixel);
                playerImg.Size = new Size(90, 159);
                playerImg.Image = part;
            }
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
