using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class PointDTO
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointDTO(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
