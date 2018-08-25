using JL.GameOfLife.Core;
using System;
using System.Diagnostics;

namespace JL.GameOfLife.ConsoleDisplay
{
    public static class GameRunner
    {
        public static void ChooseAndRun()
        {
            Console.Clear();
            Console.CursorVisible = false; // Initialize the cursor to visible.

            var version = ChooseConfiguration.ChooseVersion();
            var pattern = ChooseConfiguration.ChoosePattern();
            int displayOffset = ChooseConfiguration.ChooseDrawDelay();

            switch (version)
            {
                case 1:
                    RunV1(pattern, displayOffset);
                    break;
                case 2:
                    RunV2(pattern, displayOffset);
                    break;
                default:
                    RunV3(pattern, displayOffset);
                    break;
            }
        }

        public static void RunV3(ILifePattern pattern, int displayOffset)
        {
            Console.Clear();
            int runs = 0;
            var sim = new Core.V3.GameSimulation();
            sim.SetPattern(pattern);

            var sw = new Stopwatch();
            sw.Start();
            while (runs++ < (pattern.MaxGeneration ?? (long.MaxValue - 1)))
            {
                GenerationDraw.DrawGame(pattern.Height, pattern.Width, sim.CurrentGeneration);
                // Give the user a chance to view the game in a more reasonable speed.
                if (displayOffset > 0)
                {
                    System.Threading.Thread.Sleep(displayOffset);
                }

                sim.SimulateGeneration();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void RunV2(ILifePattern pattern, int displayOffset)
        {
            Console.Clear();
            int runs = 0;
            var sim = new Core.V2.GameSimulation();
            sim.SetPattern(pattern);

            var sw = new Stopwatch();
            sw.Start();
            while (runs++ < (pattern.MaxGeneration ?? (long.MaxValue - 1)))
            {
                GenerationDraw.DrawGame(pattern.Height, pattern.Width, sim.CurrentGeneration);
                // Give the user a chance to view the game in a more reasonable speed.
                if (displayOffset > 0)
                {
                    System.Threading.Thread.Sleep(displayOffset);
                }

                sim.SimulateGeneration();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        public static void RunV1(ILifePattern pattern, int displayOffset)
        {
            Console.Clear();
            int runs = 0;
            var sim = new Core.V1.GameSimulation();
            sim.SetPattern(pattern);

            var sw = new Stopwatch();
            sw.Start();
            while (runs++ < (pattern.MaxGeneration ?? (long.MaxValue - 1)))
            {
                GenerationDraw.DrawGame(pattern.Height, pattern.Width, sim.CurrentGeneration);
                // Give the user a chance to view the game in a more reasonable speed.
                if (displayOffset > 0)
                {
                    System.Threading.Thread.Sleep(displayOffset);
                }

                sim.SimulateGeneration();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}