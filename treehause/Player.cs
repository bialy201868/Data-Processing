using System;
using System.Collections.Generic;
using System.Text;

namespace treehause
{

    public class RootObject
    {
        public Player[] Player { get; set; }
    }

    public class Player
    {    
        public string first_name { get; set; }
      
        public double points_per_game { get; set; }
       
        public string second_name { get; set; }
   
    }

}
