using System;

namespace SudokuGame
{
    public class SudokuGame
    {
        public int[,] board;
        public int boxesToReveal;

        public SudokuGame(int boxesToReveal)
        {
            this.board = Sudoku.generateSudoku(boxesToReveal);
            this.boxesToReveal = boxesToReveal;
        }
    }
}
