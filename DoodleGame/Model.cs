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
            sizeX = 80;
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
        public Image player;
        public Player()
        {
            player = Properties.Resources.player1;
            physics = new Physics(new PointF(100, 350), new Size(40, 40));
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(player, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
            
        }
    }

    public class Enemy
    {

    }
}
