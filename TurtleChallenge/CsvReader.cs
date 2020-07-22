using System;
using System.Data;
using System.IO;
using TurtleChallenge.Models;

namespace TurtleChallenge
{
    class CsvReader
    {

        //function to read in game settings from settings.csv
        public GameSettings GetGameSettings()
        {
            GameSettings settings = new GameSettings();

            DataTable dt = ConvertCsvtoDataTable("../../../settings/settings.csv");
            int i = 0;

            //populate game settings with information from the csv file.
            foreach(DataRow row in dt.Rows)
            {
                if(i == 0)
                {
                    int.TryParse(row["BoardSize X"].ToString(), out int bsX);
                    int.TryParse(row["BoardSize Y"].ToString(), out int bsY);
                    int.TryParse(row["StartingPoint X"].ToString(), out int spX);
                    int.TryParse(row["StartingPoint Y"].ToString(), out int spY);
                    int.TryParse(row["ExitPoint X"].ToString(), out int epX);
                    int.TryParse(row["ExitPoint Y"].ToString(), out int epY);
                    settings.BoardSize = new Point(bsX, bsY);
                    settings.StartingPoint = new Point(spX, spY);
                    settings.Direction = row["Direction"].ToString();
                    settings.ExitPoint = new Point(epX, epY);
                }

                int.TryParse(row["Mine X"].ToString(), out int mpX);
                int.TryParse(row["Mine Y"].ToString(), out int mpY);
                settings.MinePoints.Add(new Point(mpX, mpY));
                i++;
            }

            return settings;
        }

        //function to read in moves from moves.csv
        public Moves GetMoves()
        {
            
            var move = File.ReadAllLines("../../../settings/moves.csv");
            Moves moves = new Moves(move.Length);
            for (int i = 0; i < move.Length; i++)
            {
                var test = move[i].Split(',');
                moves.Sequences[i] = new string[test.Length];
                moves.Sequences[i] = test;
            }
            return moves;
        }

        //function to convert csv to DataTable
        public static DataTable ConvertCsvtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }

            while (!sr.EndOfStream)
            {
                string[] rows = sr.ReadLine().Split(',');
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
