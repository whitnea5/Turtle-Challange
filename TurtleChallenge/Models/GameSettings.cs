using System.Collections.Generic;

namespace TurtleChallenge.Models
{
    class GameSettings
    {
        public Point BoardSize { get; set; }
        public Point StartingPoint { get; set; }
        public string Direction { get; set; }
        public Point ExitPoint { get; set; }
        public List<Point> MinePoints { get; set; } = new List<Point>();
        
    }
}
