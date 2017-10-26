using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAModule
{
    class Input
    {
        public Keys Up;
        public Keys Down;
        public Keys Left;
        public Keys Right;

        public Input(Keys up, Keys down, Keys left, Keys right)
        {
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }
}
