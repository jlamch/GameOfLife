using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Beacon : ILifePattern
    {
        public long? MaxGeneration => 30;

        public int Width => 6;

        public int Height => 6;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(2,2),
            new Cell(2,3),
            new Cell(3,2),
            new Cell(3,3),
            new Cell(4,4),
            new Cell(4,5),
            new Cell(5,4),
            new Cell(5,5),
        };
    }
}