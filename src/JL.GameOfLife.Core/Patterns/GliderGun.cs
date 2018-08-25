using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class GliderGun : ILifePattern
    {
        public long? MaxGeneration => 40000;

        public int Width => 50;

        public int Height => 40;

        public List<Cell> StartingLife => new List<Cell>
        {
            new Cell(2,6),
            new Cell(2,7),
            new Cell(3,6),
            new Cell(3,7),
            new Cell(12,6),
            new Cell(12,7),
            new Cell(12,8),
            new Cell(13,5),
            new Cell(13,9),
            new Cell(14,4),
            new Cell(14,10),
            new Cell(15,4),
            new Cell(15,10),
            new Cell(16,7),
            new Cell(17,5),
            new Cell(17,9),
            new Cell(18,6),
            new Cell(18,7),
            new Cell(18,8),
            new Cell(19,7),
            new Cell(22,4),
            new Cell(22,5),
            new Cell(22,6),
            new Cell(23,4),
            new Cell(23,5),
            new Cell(23,6),
            new Cell(24,3),
            new Cell(24,7),
            new Cell(26,2),
            new Cell(26,3),
            new Cell(26,7),
            new Cell(26,8),
            new Cell(36,4),
            new Cell(36,5),
            new Cell(37,4),
            new Cell(37,5),
        };
    }
}