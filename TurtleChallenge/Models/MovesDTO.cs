using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class MovesDTO
    {
        public string[][] Sequences { get; set; }

        public MovesDTO(int size)
        {
            Sequences = new string[size][];
        }
    }
}
