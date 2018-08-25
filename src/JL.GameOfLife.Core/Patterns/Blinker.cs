using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Blinker : ILifePattern
    {
        public long? MaxGeneration => 30;

        public int Width => 5;

        public int Height => 5;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(3,2),
            new Cell(3,3),
            new Cell(3,4),
        };
    }
}