using System.Collections.Generic;

namespace JL.GameOfLife.Core.V3
{
    public static class CellOperations
    {
        public static LifeResult KeepAlive(Cell current, HashSet<Cell> grid)
        {
            var neighbors = FindNeighbors(current, grid);
            if (neighbors == 2 || neighbors == 3)
            {
                return LifeResult.IsAlive;
            }
            else
            {
                return LifeResult.Dies;
            }
        }

        public static HashSet<Cell> ReproduceAll(IEnumerable<Cell> current, HashSet<Cell> grid)
        {
            var newLife = new HashSet<Cell>();

            foreach (var item in current)
            {
                var neighbors = FindNeighbors(item, grid);
                if (neighbors == 3)
                {
                    newLife.Add(item);
                }
            }

            return newLife;
        }

        /// <summary>
        /// Exactly the same as in V1
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public static List<Cell> PotentialReproducers(Cell current)
        {
            return V1.CellOperations.PotentialReproducers(current);
        }

        private static int FindNeighbors(Cell current, HashSet<Cell> grid)
        {
            int result = 0;
            result += grid.Contains(new Cell(current.X - 1, current.Y - 1)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X - 1, current.Y - 0)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X - 1, current.Y + 1)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X - 0, current.Y - 1)) ? 1 : 0;
            //result += grid.Contains(new Cell(current.X - 0, current.Y - 0)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X - 0, current.Y + 1)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X + 1, current.Y - 1)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X + 1, current.Y - 0)) ? 1 : 0;
            result += grid.Contains(new Cell(current.X + 1, current.Y + 1)) ? 1 : 0;

            return result;
        }
    }
}