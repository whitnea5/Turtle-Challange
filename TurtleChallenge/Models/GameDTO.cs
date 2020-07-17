using System;
using System.Collections.Generic;
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

        public GameDTO()
        {
            _csvReader = new CsvReader();
            _gameSettings = _csvReader.GetGameSettings();
            _moves = _csvReader.GetMoves();
            _turtleStartPoint = _gameSettings.StartingPoint;
            _grid = new int[_gameSettings.BoardSize.Y, _gameSettings.BoardSize.X];
        }
    }
}
