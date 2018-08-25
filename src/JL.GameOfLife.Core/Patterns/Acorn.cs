using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Acorn : ILifePattern
    {
        public long? MaxGeneration => 5210;

        public int Width => 140;

        public int Height => 72;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(92,44),
            new Cell(93,44),
            new Cell(93,42),
            new Cell(95,43),
            new Cell(96,44),
            new Cell(97,44),
            new Cell(98,44),
        };
    }
}