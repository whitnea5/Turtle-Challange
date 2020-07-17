using System;
using System.Collections.Generic;
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

        }

        /// <summary>
        /// Function to set the various components on the board
        /// </summary>
        private void SetComponents()
        {

        }

        /// <summary>
        /// Function to set mines on board
        /// </summary>
        /// <param name="Mines"></param>
        private void SetMines(List<PointDTO> Mines)
        {

        }

        /// <summary>
        /// Function to set turtle on board
        /// </summary>
        /// <param name="StartingPoint"></param>
        private void SetTurtle(PointDTO StartingPoint)
        {

        }

        /// <summary>
        /// Function to set exit point on board
        /// </summary>
        /// <param name="ExitPoint"></param>
        private void SetExitPoint(PointDTO ExitPoint)
        {

        }
    }
}
