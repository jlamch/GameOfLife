using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class AcornMirror : ILifePattern
    {
        public long? MaxGeneration => 5210;//2210;

        public int Width => 140;

        public int Height => 72;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(32,34),
            new Cell(33,34),
            new Cell(34,34),
            new Cell(35,33),
            new Cell(37,32),
            new Cell(37,34),
            new Cell(38,34),
        };
    }
}