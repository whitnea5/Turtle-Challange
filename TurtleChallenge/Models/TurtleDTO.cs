using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TurtleChallenge.Models
{
    class TurtleDTO
    {
        //Singleton implementation of turtle class to ensure just one instance at a time
        public PointDTO Position;
        private static TurtleDTO _turtle;
        private TurtleDTO(PointDTO pos)
        {
            Position = pos;
        }

        public static TurtleDTO Instance(PointDTO pos)
        {
            if(_turtle == null)
            {
                _turtle = new TurtleDTO(pos);
            }
            return _turtle;
        }

        public Directions Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.North:
                    _turtle.Position = new PointDTO(_turtle.Position.X - 1, _turtle.Position.Y);
                    break;
                case Directions.East:
                    _turtle.Position = new PointDTO(_turtle.Position.X, _turtle.Position.Y + 1);
                    break;
                case Directions.South:
                    _turtle.Position = new PointDTO(_turtle.Position.X + 1, _turtle.Position.Y);
                    break;
                case Directions.West:
                    _turtle.Position = new PointDTO(_turtle.Position.X, _turtle.Position.Y - 1);
                    break;
            }
        }

        public void Rotate()
        {
            switch (Direction)
            {
                case Directions.North:
                    Direction = Directions.East;
                    break;
                case Directions.East:
                    Direction = Directions.South;
                    break;
                case Directions.South:
                    Direction = Directions.West;
                    break;
                case Directions.West:
                    Direction = Directions.North;
                    break;
            }
        }

        /// <summary>
        /// Reset turtle back to starting position
        /// </summary>
        /// <param name="startPoint"></param>
        public void ResetTurtle(PointDTO startPoint)
        {
            _turtle.Position = startPoint;
        }
    }
}
