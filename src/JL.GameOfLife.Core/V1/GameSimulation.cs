using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.Core.V1
{
    public class GameSimulation : IGameSimulation
    {
        private int Height;
        private int Width;
        private long MaxGeneration;
        private int currentGenerationIndex;
        public List<Cell> CurrentGeneration { get; set; }

        public void SetPattern(ILifePattern pattern)
        {
            Height = pattern.Height;
            Width = pattern.Width;
            MaxGeneration = pattern.MaxGeneration ?? long.MaxValue;
            CurrentGeneration = pattern.StartingLife;
        }

        //object IGameSimulation.CurrentGeneration { get => CurrentGeneration; }

        void IGameSimulation.SimulateNextGeneration() => SimulateGeneration();

        public (List<Cell> newLife, List<Cell> deadOnes) SimulateGeneration()
        {
            List<Cell> newLife = null;
            List<Cell> deadOnes = null;
            if (currentGenerationIndex++ > MaxGeneration)
            {
                return (newLife, deadOnes);
            }

            var newGeneration = new List<Cell>();
            newLife = new List<Cell>();
            deadOnes = new List<Cell>();
            foreach (var item in CurrentGeneration)
            {
                switch (CellOperations.KeepAlive(item, CurrentGeneration))
                {
                    case LifeResult.IsAlive:
                        newGeneration.Add(item);
                        break;
                    case LifeResult.Dies:
                        deadOnes.Add(item);
                        break;
                }
            }

            var potentials = CurrentGeneration.SelectMany(cg => CellOperations.PotentialReproducers(cg));
            newLife = CellOperations.ReproduceAll(potentials, CurrentGeneration).Distinct().ToList();

            if (deadOnes.Count == 0)
            { deadOnes = null; }

            if (newLife.Count == 0)
            {
                newLife = null;
            }
            else
            {
                newGeneration.AddRange(newLife);
            }

            ////check boundries
            //newGeneration = newGeneration.Except(newGeneration.Where(n => n.X < 0 || n.X > Width)).ToList();
            //newGeneration = newGeneration.Except(newGeneration.Where(n => n.Y < 0 || n.Y > Height)).ToList();

            CurrentGeneration.Clear();
            CurrentGeneration = null;
            ////problem with this algoritm is that with a loooot of cells (about 3K) it's getting realy slow.
            //CurrentGeneration = newGeneration.ToList();
            //// fix is to not repeate cells. but it's still the same problem with bigger dashboards.
            CurrentGeneration = newGeneration.Distinct().ToList();
            return (newLife, deadOnes);
        }
    }
}