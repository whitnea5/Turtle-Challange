using System;
using System.IO;
using TurtleChallenge.Models;

namespace TurtleChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CsvReader csv = new CsvReader();
            GameSettingsDTO settings = csv.GetGameSettings();
        }
    }
}
