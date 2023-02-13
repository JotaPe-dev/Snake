using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Food{
        public Point location { get; private set; }

        public void CreateFood()
        {
            Random rdn = new Random();
            location = new Point(rdn.Next(0, 27), rdn.Next(0, 27));
        }
    }
}
