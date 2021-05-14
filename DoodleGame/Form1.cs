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
    public partial class Form1 : Form
    {
        bool goLeft, goRight, jumping, isGameOver;

        int jumpSpeed;
        int force;
        int score = 0;
        int playerSpeed = 7;

        int horizontalSpeed = 5;
        int verticalSpeed = 3;

        int enemyOneSpeed = 5;
        int enemyTwoSpeed = 3;

        private void KeyIsUp(object sender, KeyEventArgs e)
        {

        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
