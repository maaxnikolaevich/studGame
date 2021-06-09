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

        public Platform(PointF pos, Size size)
        {
            transform = new Transform(pos, size);
        }

        public void DrawSprite(Graphics g)
        {
            g.DrawImage(Controller.spritesheet, new Rectangle(new Point((int)transform.position.X, (int)transform.position.Y), new Size(transform.size.Width, transform.size.Height)), 2300, 112, 100, 17, GraphicsUnit.Pixel);
        }
    }

    public class Enemy
    {

    }

    public class Map
    {

    }
}
