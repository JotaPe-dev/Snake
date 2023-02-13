using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class Snake{

        public int length { get; private set; }
        public Point[] location { get; private set; }


        public Snake()
        {

            location = new Point[28 * 28];
        }


        public void reset()
        {
            length = 5;
            for (int i = 0; i < length; i++)
            {
                location[i].X = 12;
                location[i].Y = 12;
            }
        }
        public void follow()
        {
            for (int i = length - 1; i > 0; i--)
            {
                location[i] = location[i - 1];
            }
        }
        public void Up()
        {
            follow();
            location[0].Y--;
            if (location[0].Y < 0)
            {
                location[0].Y += 28;
            }
        }
        public void Down()
        {
            follow();
            location[0].Y++;
            if (location[0].Y > 27)
            {
                location[0].Y -= 28;
            }
        }
        public void Left()
        {
            follow();
            location[0].X--;
            if (location[0].X < 0)
            {
                location[0].X += 28;
            }
        }
        public void Rigth()
        {
            follow();
            location[0].X++;
            if (location[0].X > 0)
            {
                location[0].X += 28;
            }
        }

        public void Eat()
        {
            length++;
        }
    }
}

