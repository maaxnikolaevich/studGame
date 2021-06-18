using System.Drawing;

namespace DoodleGame
{
    public class Transform
    {
        public PointF position;
        public Size size;

        public Transform(PointF pos, Size size)
        {
            this.position = pos;
            this.size = size;
        }
    }
}