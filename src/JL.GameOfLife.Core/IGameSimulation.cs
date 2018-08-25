namespace JL.GameOfLife.Core
{
    public interface IGameSimulation
    {
        void SimulateNextGeneration();

        void SetPattern(ILifePattern pattern);
    }
}