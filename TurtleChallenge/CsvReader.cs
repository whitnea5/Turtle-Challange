using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using TurtleChallenge.Models;

namespace TurtleChallenge
{
    class CsvReader
    {
        public CsvReader() { }

        //function to read in game settings from settings.csv
        public GameSettingsDTO GetGameSettings()
        {
            GameSettingsDTO settings = new GameSettingsDTO();

            DataTable dt = ConvertCSVtoDataTable("../../../settings/settings.csv");
            int i = 0;

            //populate game settings with information from the csv file.
            foreach(DataRow row in dt.Rows)
            {
                if(i == 0)
                {
                    settings.BoardSize = new PointDTO(int.Parse(row["BoardSize X"].ToString()), int.Parse(row["BoardSize Y"].ToString()));
                    settings.StartingPoint = new PointDTO(int.Parse(row["StartingPoint X"].ToString()), int.Parse(row["StartingPoint Y"].ToString()));
                    settings.Direction = row["Direction"].ToString();
                    settings.ExitPoint = new PointDTO(int.Parse(row["ExitPoint X"].ToString()), int.Parse(row["ExitPoint Y"].ToString()));
                }
                settings.MinePoints.Add(new PointDTO(int.Parse(row["Mine X"].ToString()), int.Parse(row["Mine Y"].ToString())));
                i++;
            }

            return settings;
        }

        //function to read in moves from moves.csv
        public MovesDTO GetMoves()
        {
            MovesDTO moves = new MovesDTO();
            var moveNoEnd = File.ReadAllText("moves.csv");
            moves.Moves = moveNoEnd.Split(',');
            return moves;
        }

        //function to convert csv to datatable
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
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
