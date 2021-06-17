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
        Player player;
        Timer gameTimer;
        public MainForm()
        {
            InitializeComponent();
            Init();
            gameTimer = new Timer();
            gameTimer.Interval = 10;
            gameTimer.Tick += new EventHandler(Update);
            gameTimer.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.BackgroundImage = Properties.Resources.back;
            this.Height = 600;
            this.Width = 330;
            this.Paint += new PaintEventHandler(OnRepaint);
        }

        public void Init()
        {
            Controller.platforms = new System.Collections.Generic.List<Platform>();
            Controller.AddPlatform(new System.Drawing.PointF(100, 400));
            Controller.startPlatformPosY = 400;
            Controller.score = 0;
            Controller.GenerateStartSequence();
            player = new Player();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    player.physics.dx = 10;
                    player.CurrAnim = 2;
                    break;
                case "Left":
                    player.physics.dx = -10;
                    player.CurrAnim = 1;
                    break;
            }
        }

        private void Update(object sender, EventArgs e)
        {
            this.Text = "Счет: " + Controller.score;

            if (player.physics.transform.position.Y >= Controller.platforms[0].transform.position.Y + 200)
                Init();

            player.physics.ApplyPhysics();
            FollowPlayer();

            Invalidate();
        }

        public void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;
            for (int i = 0; i < Controller.platforms.Count; i++)
            {
                var platform = Controller.platforms[i];
                platform.transform.position.Y += offset;
            }
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Controller.platforms.Count > 0)
            {
                for (int i = 0; i < Controller.platforms.Count; i++)
                    Controller.platforms[i].DrawSprite(g);
            }
            player.DrawSprite(g);
        }
    }
}
