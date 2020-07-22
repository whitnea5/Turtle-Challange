using System;

namespace TurtleChallenge.Models
{
    class Turtle
    {
        //Singleton implementation of turtle class to ensure just one instance at a time
        public Point Position;
        private static Turtle _turtle;
        private Turtle(GameSettings gameSettings)
        {
            Position = gameSettings.StartingPoint;
            Direction = (Directions)Enum.Parse(typeof(Directions), gameSettings.Direction);
        }

        public static Turtle Instance(GameSettings gameSettings)
        {
            //compound assignment of turtle
            return _turtle ??= new Turtle(gameSettings);
        }

        public Directions Direction { get; set; }

        public void Move()
        {
            switch (Direction)
            {
                case Directions.North:
                    _turtle.Position = new Point(_turtle.Position.X - 1, _turtle.Position.Y);
                    break;
                case Directions.East:
                    _turtle.Position = new Point(_turtle.Position.X, _turtle.Position.Y + 1);
                    break;
                case Directions.South:
                    _turtle.Position = new Point(_turtle.Position.X + 1, _turtle.Position.Y);
                    break;
                case Directions.West:
                    _turtle.Position = new Point(_turtle.Position.X, _turtle.Position.Y - 1);
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
        /// Reset turtle back to starting position and direction
        /// </summary>
        /// <param name="gameSettings"></param>
        public void ResetTurtle(GameSettings gameSettings)
        {
            _turtle.Position = gameSettings.StartingPoint;
            _turtle.Direction = (Directions)Enum.Parse(typeof(Directions), gameSettings.Direction);
        }
    }
}
