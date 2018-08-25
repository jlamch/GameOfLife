using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Toad : ILifePattern
    {
        public long? MaxGeneration => 30;

        public int Width => 10;

        public int Height => 10;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(2,4),
            new Cell(3,3),
            new Cell(3,4),
            new Cell(4,3),
            new Cell(4,4),
            new Cell(5,3),
        };
    }
}