using System;
using System.Collections.Generic;

namespace TurtleChallenge.Models
{
    class Game
    {
        private readonly GameSettings _gameSettings;
        private readonly Moves _moves;
        private readonly Grid _grid;

        /// <summary>
        /// GameDTO initialise
        /// </summary>
        public Game()
        {
            CsvReader csvReader = new CsvReader();
            _gameSettings = csvReader.GetGameSettings();
            _moves = csvReader.GetMoves();
            _grid = new Grid(_gameSettings.BoardSize.Y, _gameSettings.BoardSize.X);
            SetComponents();
        }

        /// <summary>
        /// Function to start game
        /// </summary>
        public void StartGame()
        {

            string[][] sequences = _moves.Sequences;
            // initialise turtle
            Turtle turtle = Turtle.Instance(_gameSettings);
            int i = 1;
            // Loop through sequences of moves
            foreach(string[] moves in sequences)
            {
                Console.WriteLine("Sequence " + i);
                foreach (string move in moves)
                {
                    //make relevant move
                    if (move == "r")
                    {
                        turtle.Rotate();
                    }
                    else if (move == "m")
                    {
                        turtle.Move();
                    }
                    else if (move == "")
                    {
                        break;
                    }

                    // check the current state of the game
                    GameState state = GetGameState(turtle);
                    if (state == GameState.Exit)
                    {
                        Console.WriteLine("Success!");
                        break;
                    }
                    else if (state == GameState.Mine)
                    {
                        Console.WriteLine("Mine hit!");
                        break;
                    }
                    else if (state == GameState.OutOfBounds)
                    {
                        Console.WriteLine("Turtle is out of bounds");
                        break;
                    }
                }
                i++;
                //Reset turtle after each sequence
                turtle.ResetTurtle(_gameSettings);
            }
        }

        /// <summary>
        /// Get current state of game
        /// </summary>
        /// <param name="turtle"></param>
        /// <returns></returns>
        public GameState GetGameState(Turtle turtle)
        {
            if (turtle.Position.X < 0 || turtle.Position.X >= _grid.Width || turtle.Position.Y < 0 || turtle.Position.Y > _grid.Height)
            {
                return GameState.OutOfBounds;
            }
            else if(_grid.grid[turtle.Position.Y][turtle.Position.X] == (int)Components.Mine)
            {
                return GameState.Mine;
            }
            else if (_grid.grid[turtle.Position.Y][turtle.Position.X] == (int)Components.Exit)
            {
                return GameState.Exit;
            }
            return GameState.Normal;
        }

        /// <summary>
        /// Function to set the various components on the board
        /// </summary>
        private void SetComponents()
        {
            SetMines(_gameSettings.MinePoints);
            SetTurtle(_gameSettings.StartingPoint);
            SetExitPoint(_gameSettings.ExitPoint);
        }

        /// <summary>
        /// Function to set mines on board
        /// </summary>
        /// <param name="mines"></param>
        private void SetMines(List<Point> mines)
        {
            foreach(Point mine in mines)
            {
                try
                {
                    _grid.grid[mine.Y][mine.X] = (int)Components.Mine;
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Function to set turtle on board
        /// </summary>
        /// <param name="startingPoint"></param>
        private void SetTurtle(Point startingPoint)
        {
            try
            {
                _grid.grid[startingPoint.Y][startingPoint.X] = (int)Components.Turtle;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Function to set exit point on board
        /// </summary>
        /// <param name="exitPoint"></param>
        private void SetExitPoint(Point exitPoint)
        {
            try
            {
                _grid.grid[exitPoint.Y][exitPoint.X] = (int)Components.Exit;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
