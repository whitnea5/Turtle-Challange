using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace TurtleChallenge.Models
{
    class GameDTO
    {
        private PointDTO _turtleStartPoint;
        private CsvReader _csvReader;
        private GameSettingsDTO _gameSettings;
        private MovesDTO _moves;
        private GridDTO _grid;

        /// <summary>
        /// GameDTO initialise
        /// </summary>
        public GameDTO()
        {
            _csvReader = new CsvReader();
            _gameSettings = _csvReader.GetGameSettings();
            _moves = _csvReader.GetMoves();
            _turtleStartPoint = _gameSettings.StartingPoint;
            _grid = new GridDTO(_gameSettings.BoardSize.Y, _gameSettings.BoardSize.X);
            SetComponents();
        }

        public void StartGame()
        {
            string[][] sequences = _moves.Moves;
            TurtleDTO turtle = TurtleDTO.Instance(_gameSettings.StartingPoint);
            int i = 1;
            foreach(string[] moves in sequences)
            {
                Console.WriteLine("Sequence " + i);
                foreach (string move in moves)
                {
                    if (move == "r")
                    {
                        turtle.Rotate();
                    }
                    else if (move == "m")
                    {
                        turtle.Move();
                    }

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
            }
        }

        public GameState GetGameState(TurtleDTO turtle)
        {
            if (turtle.Position.X < 0 || turtle.Position.X >= _grid.height || turtle.Position.Y < 0 || turtle.Position.Y > _grid.width)
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
        /// <param name="Mines"></param>
        private void SetMines(List<PointDTO> Mines)
        {
            foreach(PointDTO mine in Mines)
            {
                try
                {
                    _grid.grid[mine.Y][mine.X] = (int)Components.Mine;
                } 
                catch(Exception e)
                {

                }
            }
        }

        /// <summary>
        /// Function to set turtle on board
        /// </summary>
        /// <param name="StartingPoint"></param>
        private void SetTurtle(PointDTO StartingPoint)
        {
            try
            {
                _grid.grid[StartingPoint.Y][StartingPoint.X] = (int)Components.Turtle;
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// Function to set exit point on board
        /// </summary>
        /// <param name="ExitPoint"></param>
        private void SetExitPoint(PointDTO ExitPoint)
        {
            try
            {
                _grid.grid[ExitPoint.Y][ExitPoint.X] = (int)Components.Exit;
            }
            catch(Exception e)
            {

            }
        }
    }
}
