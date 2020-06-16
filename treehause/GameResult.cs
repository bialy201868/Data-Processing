using System;
using System.Collections.Generic;
using System.Text;

namespace treehause
{
   public class GameResult
    {
        public DateTime GameDate {get;set;}
        public string TeamName { get; set; }
        public HomeOrAway homeOrAway { get; set; }

        public enum HomeOrAway
        {
            Home,
            Away
        }
    }
}
