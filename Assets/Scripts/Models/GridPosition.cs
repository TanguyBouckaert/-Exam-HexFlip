using System.Collections;
using System.Collections.Generic;

namespace HexFlip.Model
{
    public class GridPosition
    {
        public int R { get; set; } //Represents the row in the hexgrid
        public int Q { get; set; } //Represents the kolom in the hexgrid
        public int S { get; set; } //Represents the the diagonal row in the hexgrid, also s = -q-r

        public GridPosition(int r, int q, int s)
        {
            R = r;
            Q = q;
            S = s;
        }

        public override string ToString()
        {
            return $"GridPosition (row: {R}, kolom: {Q}, diagonal: {S})";
        }

        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return a.Equals(b) ;
        }

        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !(a == b);
        }
    }
}


