using System.Collections.Generic;

namespace JL.GameOfLife.Core
{
    public class CellComparer : EqualityComparer<Cell>
    {
        public override bool Equals(Cell a, Cell b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public override int GetHashCode(Cell obj)
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + obj.X.GetHashCode();
            hashCode = hashCode * -1521134295 + obj.Y.GetHashCode();
            return hashCode;
        }
    }
}