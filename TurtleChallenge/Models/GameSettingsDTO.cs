using System;
using System.Collections.Generic;
using System.Text;

namespace TurtleChallenge.Models
{
    class GameSettingsDTO
    {
        public PointDTO BoardSize { get; set; }
        public PointDTO StartingPoint { get; set; }
        public string Direction { get; set; }
        public PointDTO ExitPoint { get; set; }
        public List<PointDTO> MinePoints { get; set; } = new List<PointDTO>();
        
    }
}
