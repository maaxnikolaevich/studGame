using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DoodleGame
{
    public static class Controller
    {
        public static Image spritesheet;

        public static void Init()
        {
            spritesheet = Properties.Resources.sprite;
        }
    }
}
