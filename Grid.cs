using System;

namespace Minesweeper
{
    internal class Grid
    {
        public int Size { get; }
        private readonly Cell[,] cells;
        private Point cursorPos = new Point { X = 0, Y = 0 };

        public Grid(int size) {
            Size = size;
            cells = new Cell[size, size];

            initCells();
        }

        public void draw() {
            string result = "";

            Func<int, bool> isLastInRow = x => x == Size - 1;

            Func<Cell, string> iconFromState = cell => {
                return cell.IsMine ? "@" : "█";
            };

            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++) {
                    result += iconFromState(cells[x, y]);
                    if (isLastInRow(x)) {
                        result += "\n";
                    }
                }

            Console.WriteLine(result);
        }

        internal void ActivateCell(int x, int y) {
            cells[x, y].Activate();
        }

        private void initCells() {
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    cells[x, y] = new Cell() { X = x, Y = y };
        }
    }
}