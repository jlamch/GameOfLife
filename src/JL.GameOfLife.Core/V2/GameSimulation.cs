using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.Core.V2
{
    public class GameSimulation : IGameSimulation
    {
        private int Height;
        private int Width;
        private long MaxGeneration;
        private int currentGenerationIndex;

        public Dictionary<Cell, Cell> CurrentGeneration { get; set; }

        public void SetPattern(ILifePattern pattern)
        {
            Height = pattern.Height;
            Width = pattern.Width;
            MaxGeneration = pattern.MaxGeneration ?? long.MaxValue;
            CurrentGeneration = pattern.StartingLife.ToDictionary(sf => sf);
        }

        //object IGameSimulation.CurrentGeneration { get => CurrentGeneration; }

        void IGameSimulation.SimulateNextGeneration() => SimulateGeneration();

        public (Dictionary<Cell, Cell> newLife, Dictionary<Cell, Cell> deadOnes) SimulateGeneration()
        {
            Dictionary<Cell, Cell> newLife = null;
            Dictionary<Cell, Cell> deadOnes = null;
            if (currentGenerationIndex++ > MaxGeneration)
            {
                return (newLife, deadOnes);
            }

            var newGeneration = new Dictionary<Cell, Cell>();
            newLife = new Dictionary<Cell, Cell>();
            deadOnes = new Dictionary<Cell, Cell>();
            foreach (var item in CurrentGeneration)
            {
                switch (CellOperations.KeepAlive(item.Key, CurrentGeneration))
                {
                    case LifeResult.IsAlive:
                        newGeneration.Add(item.Key, item.Value);
                        break;
                    case LifeResult.Dies:
                        deadOnes.Add(item.Key, item.Value);
                        break;
                }
            }

            var potentials = CurrentGeneration.SelectMany(cg => CellOperations.PotentialReproducers(cg));
            newLife = CellOperations.ReproduceAll(potentials, CurrentGeneration).ToDictionary(a => a);

            if (deadOnes.Count == 0)
            { deadOnes = null; }

            if (newLife.Count == 0)
            {
                newLife = null;
            }
            else
            {
                newGeneration = newGeneration.Concat(newLife).Distinct().ToDictionary(n => n.Key, n => n.Value);
            }

            //check boundries
            //newGeneration = newGeneration.Except(newGeneration.Where(n => n.Key.X < 0 || n.Key.X > Width)).ToDictionary(n => n.Key, n => n.Value);
            //newGeneration = newGeneration.Except(newGeneration.Where(n => n.Key.Y < 0 || n.Key.Y > Height)).ToDictionary(n => n.Key, n => n.Value);

            CurrentGeneration.Clear();
            CurrentGeneration = null;
            CurrentGeneration = newGeneration;
            return (newLife, deadOnes);
        }
    }
}