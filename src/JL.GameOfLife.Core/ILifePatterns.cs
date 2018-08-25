using System.Collections.Generic;

namespace JL.GameOfLife.Core
{
    public interface ILifePattern
    {
        long? MaxGeneration { get; }
        int Width { get; }
        int Height { get; }
        List<Cell> StartingLife { get; }
    }
}