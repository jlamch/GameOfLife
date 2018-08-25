using JL.GameOfLife.Core;
using JL.GameOfLife.Core.Patterns;
using System;

namespace JL.GameOfLife.ConsoleDisplay
{
    public static class ChooseConfiguration
    {
        public static int ChooseDrawDelay()
        {
            int displayOffset = 0;
            Console.WriteLine("You can provide delay between each generation redrawing");
            string choosen = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(choosen))
            { displayOffset = Convert.ToInt32(choosen); }

            return displayOffset;
        }

        public static int ChooseVersion()
        {
            Console.WriteLine("Available game implementations:");
            Console.WriteLine("1: V1 version based on List");
            Console.WriteLine("2: V2 version based on Dictionary");
            Console.WriteLine("3: V3 version based on HashSet");

            int versionChoosen = 0;
            string choosen = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(choosen))
            { versionChoosen = Convert.ToInt32(choosen); }

            return versionChoosen;
        }

        public static IGameSimulation ChooseAndCreateVersion()
        {
            Console.WriteLine("Available game implementations:");
            Console.WriteLine("1: V1 version based on List");
            Console.WriteLine("2: V2 version based on Dictionary");
            Console.WriteLine("3: V3 version based on HashSet");

            string choosen = Console.ReadLine();
            int versionChoosen = 0;
            if (!string.IsNullOrWhiteSpace(choosen))
            { versionChoosen = Convert.ToInt32(choosen); }

            IGameSimulation gameSimulation;
            switch (versionChoosen)
            {
                case 1:
                    gameSimulation = new Core.V1.GameSimulation();
                    break;
                case 2:
                    gameSimulation = new Core.V2.GameSimulation();
                    break;
                case 3:
                    gameSimulation = new Core.V3.GameSimulation();
                    break;

                default:
                    gameSimulation = new Core.V3.GameSimulation();
                    break;
            }

            return gameSimulation;
        }

        public static ILifePattern ChoosePattern()
        {
            Console.WriteLine("Available pattern:");
            Console.WriteLine("0: GliderGun");
            Console.WriteLine("1: Acorn");
            Console.WriteLine("2: DieHard");
            Console.WriteLine("3: Pentadecathlon");
            Console.WriteLine("4: Pulsar");
            Console.WriteLine("5: Toad");
            Console.WriteLine("6: Beacon");
            Console.WriteLine("7: Blinker");
            Console.WriteLine("8: AcornDoubleMirror");
            Console.WriteLine("9: AcornMirror");
            string choosen = Console.ReadLine();
            int patternChoosen = 0;
            if (!string.IsNullOrWhiteSpace(choosen))
            { patternChoosen = Convert.ToInt32(choosen); }

            ILifePattern pattern;
            switch (patternChoosen)
            {
                case 0:
                    pattern = new GliderGun();
                    break;
                case 1:
                    pattern = new Acorn();
                    break;
                case 2:
                    pattern = new Diehard();
                    break;
                case 3:
                    pattern = new Pentadecathlon();
                    break;
                case 4:
                    pattern = new Pulsar();
                    break;
                case 5:
                    pattern = new Toad();
                    break;
                case 6:
                    pattern = new Beacon();
                    break;
                case 7:
                    pattern = new Blinker();
                    break;
                case 8:
                    pattern = new AcornDoubleMirror();
                    break;
                case 9:
                    pattern = new AcornMirror();
                    break;
                default:
                    pattern = new Acorn();
                    break;
            }

            return pattern;
        }
    }
}