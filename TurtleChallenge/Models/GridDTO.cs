using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class GridDTO
    {
        public int [][] grid;
        public int width;
        public int height;

        public GridDTO(int x, int y)
        {
            width = y;
            height = x;

            //initialise grid
            grid = new int [height][];
            for(int i = 0; i <= width; i++)
            {
                grid[i] = new int[width];
            }
        }
    }
}
