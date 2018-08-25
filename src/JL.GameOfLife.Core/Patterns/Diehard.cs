using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Diehard : ILifePattern
    {
        public long? MaxGeneration => 135;

        public int Width => 35;

        public int Height => 35;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(12,13),
            new Cell(13,13),
            new Cell(13,14),
            new Cell(18,12),
            new Cell(17,14),
            new Cell(18,14),
            new Cell(19,14),
        };
    }
}