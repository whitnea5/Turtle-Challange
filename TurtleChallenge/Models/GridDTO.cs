using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class GridDTO
    {
        private int [][] _grid;
        public int width;
        public int height;

        public GridDTO(int x, int y)
        {
            width = y;
            height = x;

            _grid = new int [height][];
            for(int i = 0; i < width; i++)
            {
                _grid[i] = new int[width];
            }
        }
    }
}
