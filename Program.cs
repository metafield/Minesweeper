using System;

namespace Minesweeper
{
    internal class Program
    {
        private static void Main(string[] args) {
            var gridSize = 10;
            var grid = new Grid(gridSize);

            do {
                while (!Console.KeyAvailable) {
                    Console.Clear();
                    Console.WriteLine("Press ESC to stop");
                    grid.draw();
                    var test = Console.ReadKey(true).Key == ConsoleKey.W;
                    if (test)
                        grid.ActivateCell(4, 5);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}