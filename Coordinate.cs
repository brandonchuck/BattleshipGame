using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate() { }
        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
