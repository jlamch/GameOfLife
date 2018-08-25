using System.Diagnostics;

namespace JL.GameOfLife.Core
{
    [DebuggerDisplay("X={X},Y={Y}")]
    public class Cell
    {
        public Cell()
        { }

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            var cell = (Cell)obj;
            return cell != null &&
                   X == cell.X &&
                   Y == cell.Y;
        }

        //public override bool Equals(object obj)
        //{
        //    return obj.GetHashCode().Equals(GetHashCode());
        //}

        public override int GetHashCode()
        {
            var hashCode = 1861411795;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}