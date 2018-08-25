using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Pentadecathlon : ILifePattern
    {
        public long? MaxGeneration => 100;

        public int Width => 11;

        public int Height => 18;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(5,7),
            new Cell(5,12),
            new Cell(6,5),
            new Cell(6,6),
            new Cell(6,8),
            new Cell(6,9),
            new Cell(6,10),
            new Cell(6,11),
            new Cell(6,13),
            new Cell(6,14),
            new Cell(7,7),
            new Cell(7,12),
        };
    }
}