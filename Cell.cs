using System;

namespace Minesweeper
{
    internal class CellEventArgs : EventArgs
    {
        public bool bombTriggered;
    }

    internal partial class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsHidden { get; set; }
        public bool IsMine { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsQuestioned { get; set; }

        public Cell() {
            IsHidden = true;

            var rnd = new Random();
            IsMine = rnd.Next(100) < 15;
        }

        internal void Activate() {
            if (IsHidden)
                Reveal();
        }

        internal event EventHandler<CellEventArgs> CellRevealed;

        private void Reveal() {
            IsHidden = false;
            OnCellRevealed(IsMine);
        }

        protected virtual void OnCellRevealed(bool triggered) {
            CellRevealed?.Invoke(this, new CellEventArgs() { bombTriggered = triggered });
        }
    }
}