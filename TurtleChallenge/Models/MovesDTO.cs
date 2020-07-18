using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class MovesDTO
    {
        public string[][] Moves { get; set; }

        public MovesDTO(int size)
        {
            Moves = new string[size][];
        }
    }
}
