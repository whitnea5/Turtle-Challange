using System;
using System.IO;
using TurtleChallenge.Models;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            GameDTO game = new GameDTO();
            game.StartGame();
        }
    }
}
