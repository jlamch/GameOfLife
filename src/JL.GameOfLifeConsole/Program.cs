using System;

namespace JL.GameOfLifeConsole
{
    public class LifeSimulation
    {
        private readonly int Heigth;
        private readonly int Width;
        private readonly bool[,] cells;

        /// <summary>
        /// Initializes a new Game of Life.
        /// </summary>
        /// <param name="Heigth">Heigth of the cell field.</param>
        /// <param name="Width">Width of the cell field.</param>

        public LifeSimulation(int Heigth, int Width)
        {
            this.Heigth = Heigth;
            this.Width = Width;
            cells = new bool[Heigth, Width];
            GenerateField();
        }

        /// <summary>
        /// Advances the game by one generation and prints the current state to console.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Advances the game by one generation according to GoL's ruleset.
        /// </summary>

        private void Grow()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);

                    if (cells[i, j])
                    {
                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = false;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = false;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks how many alive neighbors are in the vicinity of a cell.
        /// </summary>
        /// <param name="x">X-coordinate of the cell.</param>
        /// <param name="y">Y-coordinate of the cell.</param>
        /// <returns>The number of alive neighbors.</returns>

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= Heigth || j >= Width)))
                    {
                        if (cells[i, j] == true)
                        {
                            NumOfAliveNeighbors++;
                        }
                    }
                }
            }
            return NumOfAliveNeighbors;
        }

        /// <summary>
        /// Draws the game to the console.
        /// </summary>

        private void DrawGame()
        {
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write(cells[i, j] ? "■" : " ");
                    if (j == Width - 1)
                    {
                        Console.WriteLine("\r");
                    }
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Initializes the field with random boolean values.
        /// </summary>

        private void GenerateField()
        {
            Random generator = new Random();
            int number;
            for (int i = 0; i < Heigth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? false : true);
                }
            }
        }
    }

    internal class Program
    {
        // Constants for the game rules.
        private const int Heigth = 11;

        private const int Width = 38;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            Console.Clear();
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Give the user a chance to view the game in a more reasonable speed.
                System.Threading.Thread.Sleep(200);
            }
        }
    }
}