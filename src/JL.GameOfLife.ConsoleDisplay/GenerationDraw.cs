using JL.GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JL.GameOfLife.ConsoleDisplay
{
    public class GenerationDraw
    {
        public static void DrawGame(int height, int width, object cells)
        {
            switch (cells)
            {
                case List<Cell> c:
                    DrawGame(height, width, c);
                    break;
                case Dictionary<Cell, Cell> d:
                    DrawGame(height, width, d);
                    break;
                case HashSet<Cell> h:
                    DrawGame(height, width, h);
                    break;
            }
        }

        public static void DrawGame(int height, int width, List<Cell> cells)

        {
            var celld = new HashSet<Cell>();
            celld.UnionWith(cells.Distinct());

            DrawGame(height, width, celld);
        }

        public static void DrawGame(int height, int width, Dictionary<Cell, Cell> cells)
        {
            for (int j = 1; j <= height; j++)
            {
                string write = string.Empty;
                for (int i = 1; i <= width; i++)
                {
                    write += (cells.ContainsKey(new Cell(i, j)) ? "■" : " ");
                }

                Console.WriteLine(write);
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }

        public static void DrawGame(int height, int width, HashSet<Cell> cells)
        {
            for (int j = 1; j <= height; j++)
            {
                string write = string.Empty;
                for (int i = 1; i <= width; i++)
                {
                    write += (cells.Contains(new Cell(i, j)) ? "■" : " ");
                }

                Console.WriteLine(write);
            }

            Console.SetCursorPosition(0, Console.WindowTop);
        }
    }
}