using JL.GameOfLife.Core;
using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.Core.V1
{
    public static class CellOperations
    {
        public static LifeResult KeepAlive(Cell current, List<Cell> grid)
        {
            var neighbors = FindNeighbors(current, grid);
            if (neighbors.Count == 2 || neighbors.Count == 3)
            {
                return LifeResult.IsAlive;
            }
            else
            {
                return LifeResult.Dies;
            }
        }

        public static List<Cell> Reproduce(Cell current, List<Cell> grid)
        {
            var potentials = PotentialReproducers(current).Distinct().ToList();
            var newLife = new List<Cell>();

            foreach (var item in potentials)
            {
                var neighbors = FindNeighbors(item, grid);
                if (neighbors.Count == 3)
                {
                    newLife.Add(item);
                }
            }

            potentials.Clear();
            potentials = null;
            return newLife;
        }

        public static List<Cell> ReproduceAll(IEnumerable<Cell> current, List<Cell> grid)
        {
            var potentials = current.Distinct().ToList();
            var newLife = new List<Cell>();

            foreach (var item in potentials)
            {
                var neighbors = FindNeighbors(item, grid);
                if (neighbors.Count == 3)
                {
                    newLife.Add(item);
                }
            }

            potentials.Clear();
            potentials = null;
            return newLife.Distinct().ToList();
        }

        public static List<Cell> PotentialReproducers(Cell current)
        {
            var result = new List<Cell>();
            result.Add(new Cell { X = current.X - 1, Y = current.Y - 1 });
            result.Add(new Cell { X = current.X - 1, Y = current.Y - 0 });
            result.Add(new Cell { X = current.X - 1, Y = current.Y + 1 });
            result.Add(new Cell { X = current.X - 0, Y = current.Y - 1 });
            //result.Add(new Cell { X = current.X - 0, Y = current.X - 0 });
            result.Add(new Cell { X = current.X - 0, Y = current.Y + 1 });
            result.Add(new Cell { X = current.X + 1, Y = current.Y - 1 });
            result.Add(new Cell { X = current.X + 1, Y = current.Y - 0 });
            result.Add(new Cell { X = current.X + 1, Y = current.Y + 1 });
            return result;
        }

        private static List<Cell> FindNeighbors(Cell current, List<Cell> grid)
        {
            var neighbors =
            grid.Where(g =>
                    (current.X - 1 == g.X && current.Y - 1 == g.Y) ||
                    (current.X - 1 == g.X && current.Y - 0 == g.Y) ||
                    (current.X - 1 == g.X && current.Y + 1 == g.Y) ||
                    (current.X - 0 == g.X && current.Y - 1 == g.Y) ||
                    //(current.X-0 == g.X && current.Y -0 == g.Y) ||
                    (current.X - 0 == g.X && current.Y + 1 == g.Y) ||
                    (current.X + 1 == g.X && current.Y - 1 == g.Y) ||
                    (current.X + 1 == g.X && current.Y - 0 == g.Y) ||
                    (current.X + 1 == g.X && current.Y + 1 == g.Y)
                    ).ToList();
            return neighbors.Distinct().ToList();
        }
    }
}