using System;
using System.Collections.Generic;
using System.Text;

namespace battleship
{
    public class Grid
    {
        // number of trys user has
        private int _lifePoints = 2;

        public int LifePoints
        {
            get { return _lifePoints; }
            set
            {
                _lifePoints = value;
            }
        }

        // null constructor
        public Grid()
        {

        }

        // create 10x10 grid in a list
        public List<Coordinate> createGrid()
        {
            List<Coordinate> grid = new List<Coordinate>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Coordinate c = new Coordinate(i, j);
                }
            }
            return grid;
        }

    }
}
