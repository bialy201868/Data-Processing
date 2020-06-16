using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace treehause
{
    class PlayerComparer : IComparer<Player>
    {
        public int Compare([AllowNull] Player x, [AllowNull] Player y)
        {
         return y.points_per_game.CompareTo(x.points_per_game);
        }
    }
}
