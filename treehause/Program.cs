using System;
using System.Collections.Generic;
using System.IO;
using static treehause.GameResult;
using Newtonsoft.Json;
using System.Diagnostics.Tracing;

namespace treehause
{
    class Program
    {
        static void Main(string[] args)
        {
         

             string currentDirectory = Directory.GetCurrentDirectory();
             DirectoryInfo directory = new DirectoryInfo(currentDirectory);
             var  fileName = Path.Combine(directory.FullName, "soccer.csv");
             var fileContents = ReadSoccer(fileName);
             fileName = Path.Combine(directory.FullName, "players.json");
             var players = DeserializePlayers(fileName);
             var topTenPlayers = GetTopPlayers(players);
             foreach (var p  in topTenPlayers)
             {
                Console.WriteLine("Name: "+p.second_name + "PPG " + p.points_per_game);
             }




        }

        public static void SerializePlayersToFile(List<Player> players, string fileName)
        {

        }

        public static string ReadFile(string fileName)
        {
            using(var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }
        public static List<GameResult> ReadSoccer(string fileName)
        {
            var soccerReults = new List<GameResult>();
            using (var reader = new StreamReader(fileName))
            {
                string line = "";
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    var gameResult = new GameResult();
                    string[] values = line.Split(',');

                    DateTime gameDate;
                    if(DateTime.TryParse(values[0], out gameDate))
                    {
                        gameResult.GameDate = gameDate;
                    }
                    gameResult.TeamName = values[1];

                    HomeOrAway homeOrAway;
                    if (Enum.TryParse(values[2], out homeOrAway))
                    {
                        gameResult.homeOrAway = homeOrAway;
                    }

                    soccerReults.Add(gameResult);

                }
            }
                return soccerReults;
        }

        public static List<Player> DeserializePlayers(string fileName)
        {
            var players = new List<Player>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
               players = serializer.Deserialize<List<Player>>(jsonReader);

            }
                
            return players;
        }


        public static List<Player> GetTopPlayers(List<Player> players)
        {
            var topTenPlayers = new List<Player>();

            players.Sort(new PlayerComparer());

            int counter = 0;

            foreach (var player in players)
            {
                topTenPlayers.Add(player);
                counter++;
                if (counter == 10)
                {
                    break;
                }
            }

            return topTenPlayers;
        }
        
    }
}
