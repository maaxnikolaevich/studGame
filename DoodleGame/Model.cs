using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DoodleGame
{
    public class Platform
    {
        public Transform transform;
        Image platform;
        public int sizeX;
        public int sizeY;
        public bool touchedPl;

        public Platform(PointF position)
        {
            platform = Properties.Resources.platform;
            sizeX = 100;
            sizeY = 15;
            transform = new Transform(position, new Size(sizeX, sizeY));
            touchedPl = false;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(platform, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
        }
    }

    public class Player
    {
        
        public Physics physics;
        public Image playerL;
        public Image playerR;
        public int currAnim;

        public Player()
        {
            playerL = Properties.Resources.player1;
            playerR = Properties.Resources.player2;
            physics = new Physics(new PointF(100, 350), new Size(40, 40));
        }


        public void DrawSprite(Graphics g)
        {
            if (currAnim == 1)
            {
                g.DrawImage(playerL, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
            }
            else g.DrawImage(playerR, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }

    }

    public class Coin
    {
        public Transform transform;
        Image coin;
        public int sizeX;
        public int sizeY;
        public bool touchedPlCoin = false;

        public Coin(PointF position)
        {
            coin = Properties.Resources.coin;
            sizeX = 40;
            sizeY = 50;
            transform = new Transform(position, new Size(sizeX, sizeY));
        }
        public void DrawSprite(Graphics g)
            {
                g.DrawImage(coin, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
            }
    }

    public class Enemy
    {

    }
}
