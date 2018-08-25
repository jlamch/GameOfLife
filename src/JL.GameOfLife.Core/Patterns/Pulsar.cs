using System.Collections.Generic;

namespace JL.GameOfLife.Core.Patterns
{
    public class Pulsar : ILifePattern
    {
        public long? MaxGeneration => 300;

        public int Width => 17;

        public int Height => 17;

        public List<Cell> StartingLife => new List<Cell> {
            new Cell(3,5 ),
            new Cell(3,6 ),
            new Cell(3,7 ),
            new Cell(3,11),
            new Cell(3,12),
            new Cell(3,13),

            new Cell(8,5 ),
            new Cell(8,6 ),
            new Cell(8,7 ),
            new Cell(8,11),
            new Cell(8,12),
            new Cell(8,13),

            new Cell(10,5 ),
            new Cell(10,6 ),
            new Cell(10,7 ),
            new Cell(10,11),
            new Cell(10,12),
            new Cell(10,13),

            new Cell(15,5 ),
            new Cell(15,6 ),
            new Cell(15,7 ),
            new Cell(15,11),
            new Cell(15,12),
            new Cell(15,13),

            new Cell(5 , 3),
            new Cell(5 , 8),
            new Cell(5 ,10),
            new Cell(5 ,15),

            new Cell(6 , 3),
            new Cell(6 , 8),
            new Cell(6 ,10),
            new Cell(6 ,15),

            new Cell(7 , 3),
            new Cell(7 , 8),
            new Cell(7 ,10),
            new Cell(7 ,15),

            new Cell(11, 3),
            new Cell(11, 8),
            new Cell(11,10),
            new Cell(11,15),

            new Cell(12, 3),
            new Cell(12, 8),
            new Cell(12,10),
            new Cell(12,15),

            new Cell(13, 3),
            new Cell(13, 8),
            new Cell(13,10),
            new Cell(13,15),
        };
    }
}