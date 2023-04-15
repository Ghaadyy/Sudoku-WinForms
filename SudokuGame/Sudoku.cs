using System;

namespace SudokuGame
{
    public class Sudoku
    {
        public int[,] board = new int[9, 9];

        public Sudoku(int[,] board)
        {
            if (Sudoku.IsValidSudoku(board))
            {
                this.board = CopyBoard(board);
            }
            else
            {
                throw new Exception("Invalid Sudoku board, please check your input");
            }
        }

        public static int[,] generateSudoku(int boxesToReveal)
        {
            Random r = new Random();
            int[,] board = new int[9, 9];

            // Fill diagonals randomly beacause no need to check for validity between rowws and columns
            // Just generate each 3x3 using a possibilities list which will generate a valid 3x3
            // The board will be valid so we can solve it using the sudoku solver
            // Then we will have a valid solved board, and we can remove x random elements from the board
            // to have a final board to solve for the user

            for (int x = 0; x < 9; x += 3)
            {
                List<int> possibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = x; j < x + 3; j++)
                    {
                        int randIndex = r.Next(0, possibilities.Count);
                        board[i, j] = possibilities[randIndex];
                        possibilities.Remove(possibilities[randIndex]);
                    }
                }
            }

            Sudoku solver = new Sudoku(board);

            solver.solveSudoku();

            board = CopyBoard(solver.board);

            int boxesToRemove = 81 - boxesToReveal;
            int boxesRemoved = 0;

            while (boxesRemoved < boxesToRemove)
            {
                int randX, randY;

                do
                {
                    randX = r.Next(board.GetLength(0)); randY = r.Next(board.GetLength(1));
                } while (board[randX, randY] == 0);

                board[randX, randY] = 0;
                boxesRemoved++;
            }

            return board;
        }

        public bool solveSudoku()
        {
            /*
             * The function treats the board intialized inside the constructor
             * thus the board must be valid.
             * 
             * Go to the first next empty cell, and try to fill it with a valid number
             * With the new board, call solveSudoku() again on the new updated board
             * 
             * If we go down the recursion tree and finally get a return true, means we solved the board.
             * 
             * Keep going until all possibilities run out and the list becomes empty.
             * If the number is valid, then recursivly solve the new board with the valid number.
             * If the recursion ends up somewhere that doesn't have a solution, it returns false.
             * then the corresponding (i,j) value gets reset, thus we backtrack our way up to choose
             * a new value for (i,j).
             * If all recursion calls lead to all possibilities being invalid and for all 
             */
            // Console.WriteLine("Trying to solve sudoku");

            Random r = new Random();

            bool isEmptyCell = false;

            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    if (this.board[i, j] == 0)
                    {
                        List<int> possibilities = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                        while (possibilities.Count != 0)
                        {
                            int number = possibilities[r.Next(possibilities.Count)];
                            possibilities.Remove(number);

                            if (IsValidNumber(number, i, j))
                            {
                                this.board[i, j] = number;

                                if (solveSudoku()) // We solved one cell, now we solve the solved board as a new one
                                {
                                    return true;
                                }
                                else // If the board wasn't solved in the recursive function then we reset this cell
                                {
                                    this.board[i, j] = 0;
                                }
                            }
                        }

                        isEmptyCell = true;
                        j = this.board.GetLength(1);
                    }
                }
                if (isEmptyCell)
                {
                    i = this.board.GetLength(0);
                }
            }

            if (!isEmptyCell) // There are no empty cells left, the board is full that, means we have solved the problem
            {
                return true;
            }

            return false; // If we tried every solution possible, we return false with the board unsolved.
        }

        private bool IsValidNumber(int number, int x, int y)
        {
            Tuple<int, int> initPosition = GetInitialPosition(x, y);

            int initX = initPosition.Item1, initY = initPosition.Item2;

            for (int i = 0; i < this.board.GetLength(0); i++) // Check the column
            {
                if (this.board[i, y] == number)
                {
                    return false;
                }
            }

            for (int i = 0; i < this.board.GetLength(1); i++) // Check the row
            {
                if (this.board[x, i] == number)
                {
                    return false;
                }
            }

            for (int i = initX; i < initX + 3; i++) // Check the 3x3 grid
            {
                for (int j = initY; j < initY + 3; j++)
                {
                    if (this.board[i, j] == number)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static Tuple<int, int> GetInitialPosition(int x, int y)
        {
            int initX, initY;

            if (x == 2 || x == 5 || x == 8)
            {
                initX = x - 2;
            }
            else if (x == 1 || x == 4 || x == 7)
            {
                initX = x - 1;
            }
            else
            {
                initX = x;
            }

            if (y == 2 || y == 5 || y == 8)
            {
                initY = y - 2;
            }
            else if (y == 1 || y == 4 || y == 7)
            {
                initY = y - 1;
            }
            else
            {
                initY = y;
            }

            return Tuple.Create(initX, initY);
        }

        public void PrintBoard()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < this.board.GetLength(0); i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("| ");
                Console.ForegroundColor = ConsoleColor.White;

                for (int j = 0; j < this.board.GetLength(1); j++)
                {
                    string text = board[i, j] == 0 ? " " : board[i, j].ToString();
                    Console.Write($"{text}");
                    if ((j + 1) % 3 == 0)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
                if ((i + 1) % 3 == 0)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static int[,] CopyBoard(int[,] board)
        {
            int[,] newBoard = new int[board.GetLength(0), board.GetLength(1)];

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    newBoard[i, j] = board[i, j];
                }
            }

            return newBoard;
        }

        public static bool IsValidSudoku(int[,] board)
        {
            int boxes = 0;

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0)
                    {
                        boxes++;
                    }
                }
            }

            if (boxes <= 16) // The minimum amount of given boxes should be at least 17 or higher
            {
                return false;
            }

            for (int i = 0; i < board.GetLength(0); i++) // Check rows
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] != 0)
                    {
                        if (numCount.ContainsKey(board[i, j]))
                            numCount[board[i, j]]++;
                        else
                            numCount[board[i, j]] = 1;
                    }
                }

                if (numCount.ContainsValue(2))
                    return false;
            }

            for (int j = 0; j < board.GetLength(1); j++) // Check columns
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                for (int i = 0; i < board.GetLength(0); i++)
                {
                    if (board[i, j] != 0)
                    {
                        if (numCount.ContainsKey(board[i, j]))
                            numCount[board[i, j]]++;
                        else
                            numCount[board[i, j]] = 1;
                    }
                }

                if (numCount.ContainsValue(2))
                    return false;
            }

            for (int x = 0; x < 9; x += 3) // Check diagonals from left to right
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                for (int i = x; i < x + 3; i++)
                {
                    for (int j = x; j < x + 3; j++)
                    {
                        if (board[i, j] != 0)
                        {
                            if (numCount.ContainsKey(board[i, j]))
                                numCount[board[i, j]]++;
                            else
                                numCount[board[i, j]] = 1;
                        }
                    }
                }

                if (numCount.ContainsValue(2))
                    return false;
            }

            for (int x = 0; x < 9; x += 3) // Check diagonals from right to left
            {
                Dictionary<int, int> numCount = new Dictionary<int, int>();

                for (int j = 6 - x; j < 9 - x; j++)
                {
                    for (int i = x; i < 3 + x; i++)
                    {
                        if (board[i, j] != 0)
                        {
                            if (numCount.ContainsKey(board[i, j]))
                                numCount[board[i, j]]++;
                            else
                                numCount[board[i, j]] = 1;
                        }
                    }
                }

                if (numCount.ContainsValue(2))
                    return false;
            }

            return true;
        }
    }
}
