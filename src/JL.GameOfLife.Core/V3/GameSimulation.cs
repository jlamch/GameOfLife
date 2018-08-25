using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.Core.V3
{
    public class GameSimulation : IGameSimulation
    {
        private int Height;
        private int Width;
        private long MaxGeneration;
        private int currentGenerationIndex;

        public HashSet<Cell> CurrentGeneration { get; set; }

        public void SetPattern(ILifePattern pattern)
        {
            Height = pattern.Height;
            Width = pattern.Width;
            MaxGeneration = pattern.MaxGeneration ?? long.MaxValue;
            CurrentGeneration = new HashSet<Cell>();
            CurrentGeneration.UnionWith(pattern.StartingLife.Distinct());
        }

        //object IGameSimulation.CurrentGeneration { get => CurrentGeneration; }

        void IGameSimulation.SimulateNextGeneration() => SimulateGeneration();

        public (HashSet<Cell> newLife, HashSet<Cell> deadOnes) SimulateGeneration()
        {
            HashSet<Cell> newLife = null;
            HashSet<Cell> deadOnes = null;
            if (currentGenerationIndex++ > MaxGeneration)
            {
                return (newLife, deadOnes);
            }

            var newGeneration = new HashSet<Cell>();
            newLife = new HashSet<Cell>();
            deadOnes = new HashSet<Cell>();
            foreach (var item in CurrentGeneration)
            {
                switch (CellOperations.KeepAlive(item, CurrentGeneration))
                {
                    case LifeResult.IsAlive:
                        newGeneration.Add(item);
                        break;
                    case LifeResult.Dies:
                        if (!deadOnes.Contains(item))
                        { deadOnes.Add(item); }
                        break;
                }
            }

            var potentials = CurrentGeneration.SelectMany(cg => CellOperations.PotentialReproducers(cg)).Distinct();
            newLife = CellOperations.ReproduceAll(potentials, CurrentGeneration);

            if (deadOnes.Count == 0)
            { deadOnes = null; }

            if (newLife.Count == 0)
            {
                newLife = null;
            }
            else
            {
                newGeneration.UnionWith(newLife);
            }

            //check boundries
            //newGeneration.ExceptWith(newGeneration.Where(n => n.X < 0 || n.X > Width));
            //newGeneration.ExceptWith(newGeneration.Where(n => n.Y < 0 || n.Y > Height));

            CurrentGeneration.Clear();
            CurrentGeneration = null;
            CurrentGeneration = newGeneration;
            return (newLife, deadOnes);
        }
    }
}