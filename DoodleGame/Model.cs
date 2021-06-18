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
        Image sprite;
        public int sizeX;
        public int sizeY;
        public bool touchedPl;

        public Platform(PointF position)
        {
            sprite = Properties.Resources.platform;
            sizeX = 120;
            sizeY = 18;
            transform = new Transform(position, new Size(sizeX, sizeY));
            touchedPl = false;
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, transform.position.X, transform.position.Y, transform.size.Width, transform.size.Height);
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

    public  class Enemy 
    {
        public Physics physics;
        public Image sprite;
        public Enemy(PointF pos, int type)
        {
            switch (type)
            {
                case 1:
                    sprite = Properties.Resources.monster1;
                    physics = new Physics(pos, new Size(40, 40));
                    break;
                case 2:
                    sprite = Properties.Resources.monster2;
                    physics = new Physics(pos, new Size(40, 40));
                    break;
                case 3:
                    sprite = Properties.Resources.monster3;
                    physics = new Physics(pos, new Size(40, 40));
                    break;
            }
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
