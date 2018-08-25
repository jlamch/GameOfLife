using JL.GameOfLife.ConsoleDisplay;

/// <summary>
/// JL: hashseet wymusza pojedynczosc a ze to dwuwymiary swiat to tez wymusza unikatowosc punktow temu ta zmiana znalazla duzo bledow o
/// ktorych nie pomyslalam majac listy ktore sa elastyczne i ogolnie maja gdzies co do nich pakujemy
/// </summary>
namespace JL.GameOfLifeConsole
{
    public class Program
    {
        private static void Main(string[] args)
        {
            GameRunner.ChooseAndRun();
        }
    }
}