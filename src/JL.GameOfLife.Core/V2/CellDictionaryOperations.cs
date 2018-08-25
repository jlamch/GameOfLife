using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.Core.V2
{
    public static class CellOperations
    {
        public static LifeResult KeepAlive(Cell current, Dictionary<Cell, Cell> grid)
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

        public static Dictionary<Cell, Cell> ReproduceAllFromList(Dictionary<Cell, Cell> current, Dictionary<Cell, Cell> grid)
        {
            var newLife = new Dictionary<Cell, Cell>();

            foreach (var item in current)
            {
                var neighbors = FindNeighbors(item.Key, grid);
                if (neighbors == 3)
                {
                    newLife.Add(item.Key, item.Value);
                }
            }

            return newLife;
        }

        public static List<Cell> ReproduceAll(IEnumerable<Cell> current, Dictionary<Cell, Cell> grid)
        {
            var potentials = current.Distinct().ToList();
            var newLife = new List<Cell>();

            foreach (var item in potentials)
            {
                var neighbors = FindNeighbors(item, grid);
                if (neighbors == 3)
                {
                    newLife.Add(item);
                }
            }

            potentials.Clear();
            potentials = null;
            return newLife.Distinct().ToList();
        }

        public static List<Cell> PotentialReproducers(this KeyValuePair<Cell, Cell> current)
        {
            var result = new List<Cell>();
            result.Add(new Cell { X = current.Key.X - 1, Y = current.Key.Y - 1 });
            result.Add(new Cell { X = current.Key.X - 1, Y = current.Key.Y - 0 });
            result.Add(new Cell { X = current.Key.X - 1, Y = current.Key.Y + 1 });
            result.Add(new Cell { X = current.Key.X - 0, Y = current.Key.Y - 1 });
            //result.Add( new Cell { X = current.Key.X - 0, Y = current.Key.X - 0 });
            result.Add(new Cell { X = current.Key.X - 0, Y = current.Key.Y + 1 });
            result.Add(new Cell { X = current.Key.X + 1, Y = current.Key.Y - 1 });
            result.Add(new Cell { X = current.Key.X + 1, Y = current.Key.Y - 0 });
            result.Add(new Cell { X = current.Key.X + 1, Y = current.Key.Y + 1 });
            return result;
        }

        private static int FindNeighbors(Cell current, Dictionary<Cell, Cell> grid)
        {
            int result = 0;
            result += grid.ContainsKey(new Cell(current.X - 1, current.Y - 1)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X - 1, current.Y - 0)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X - 1, current.Y + 1)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X - 0, current.Y - 1)) ? 1 : 0;
            //result += grid.ContainsKey(new Cell(current.X - 0, current.Y - 0)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X - 0, current.Y + 1)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X + 1, current.Y - 1)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X + 1, current.Y - 0)) ? 1 : 0;
            result += grid.ContainsKey(new Cell(current.X + 1, current.Y + 1)) ? 1 : 0;

            return result;
        }
    }
}