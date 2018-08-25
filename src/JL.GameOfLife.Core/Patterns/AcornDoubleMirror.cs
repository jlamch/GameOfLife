using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class AcornDoubleMirror : ILifePattern
    {
        public long? MaxGeneration => 5210;

        public int Width => 140;

        public int Height => 72;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(22,42),
            new Cell(23,42),
            new Cell(24,42),
            new Cell(25,43),
            new Cell(27,42),
            new Cell(28,42),
            new Cell(27,44),
        };
    }
}