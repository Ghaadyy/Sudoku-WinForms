﻿using System;


namespace SudokuGame
{
    public partial class GameForm : Form
    {
        private SudokuGame game;
        private Player player;
        private SudokuForm mainScreen;

        private int[,]? solvedBoard;
        private int level;

        private int[] boxesToReveal = { 37, 32, 26 };
        private int[] maxTime = { 10, 15, 20 };
        private int[] maxHints = { 3, 5, 11 };
        private double[] hintCost = { 0.5, 1, 4 };
        private int[] gameCost = { 1, 2, 3 };
        private int[] prize = { 10, 15, 20 };

        private int allowedHints;

        private int remainingTime;
        private bool allowedHint = false;

        public GameForm(int level, Player player, SudokuForm sudokuForm)
        {
            this.level = level;
            this.player = player;
            this.mainScreen = sudokuForm;
            game = new SudokuGame(boxesToReveal[level]);

            player.DeduceBalance(gameCost[level]);
            mainScreen.UpdateBalance();

            Sudoku solver = new Sudoku(game.board);

            if (solver.solveSudoku())
            {
                solvedBoard = Sudoku.CopyBoard(solver.board);
            }

            this.remainingTime = this.maxTime[level] * 60;
            this.allowedHints = this.maxHints[level];

            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            requestHint.Enabled = false;
            requestHint.Text = $"Get Hint (${hintCost[level]})";
            int x = 210, y = 74;

            int size = 31;

            int counter = 1;
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    TextBox text = new TextBox();

                    text.Location = new Point(x, y);
                    text.Text = game.board[i, j] == 0 ? "" : $"{game.board[i, j]}";
                    text.Name = "box" + counter;
                    text.TextChanged += new EventHandler(textChanged);
                    text.KeyPress += keyPressHandler;
                    counter++;
                    if (game.board[i, j] == 0)
                    {
                        text.ForeColor = Color.Black;
                    }
                    else
                    {
                        text.BackColor = Color.White;
                        text.ForeColor = Color.Blue;
                        text.ReadOnly = true;
                    }
                    text.Size = new Size(size, size);

                    this.Controls.Add(text);

                    if ((j + 1) % 3 == 0)
                        x += 50;
                    else
                        x += 40;
                }

                if ((i + 1) % 3 == 0)
                    y += 40;
                else
                    y += 30;

                x = 210;
            }

            timeRemaining.Text = $"{this.maxTime[level].ToString("00")}:{0.ToString("00")}";
            timer1.Start();
        }

        private void quitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.remainingTime--;
            TimeSpan ts = TimeSpan.FromSeconds(this.remainingTime);
            timeRemaining.Text = $"{ts.Minutes.ToString("00")}:{ts.Seconds.ToString("00")}";

            if (this.remainingTime == 0)
            {
                timer1.Stop();
            }
        }

        private void submitGrid_Click(object sender, EventArgs e)
        {
            if (remainingTime == 0)
            {
                if (CheckWin())
                {
                    title.Text = "Your time has expired, and you won, you only win the game cost back";
                    player.UpdateBalance(gameCost[level]);
                    mainScreen.UpdateBalance();
                }
                else
                {
                    title.Text = "Sorry, you lost :(";
                }
            }
            else
            {
                if (CheckWin())
                {
                    title.Text = "Congrats, you won!";
                    player.UpdateBalance(prize[level]);
                    mainScreen.UpdateBalance();
                }
                else
                {
                    title.Text = "Sorry, you lost :(";
                }
            }

            timer1.Stop();
        }

        private bool CheckWin()
        {
            if (solvedBoard != null)
            {
                int counter = 1;
                for (int i = 0; i < solvedBoard.GetLength(0); i++)
                {
                    for (int j = 0; j < solvedBoard.GetLength(1); j++)
                    {
                        TextBox box = (TextBox)this.Controls[$"box{counter}"];
                        if (solvedBoard[i, j].ToString() != box.Text)
                        {
                            return false;
                        }
                        counter++;
                    }
                }
            }
            return true;
        }

        private void startNew_Click(object sender, EventArgs e)
        {
            player.DeduceBalance(gameCost[level] * 0.5);
            mainScreen.UpdateBalance();
            this.Close();
            GameForm form = new GameForm(level, player, mainScreen);
            form.Show();
        }

        private void addBudget_Click(object sender, EventArgs e)
        {
            AddBudgetForm form = new AddBudgetForm(player, mainScreen);
            form.Show();
        }

        private void requestHint_Click(object sender, EventArgs e)
        {
            if (this.allowedHints > 0 && this.allowedHint)
            {
                GetHint();
                player.DeduceBalance(hintCost[level]);
                mainScreen.UpdateBalance();
                this.allowedHints--;
                this.allowedHint = false;
                requestHint.Enabled = false;
            }

            if (this.allowedHints <= 0)
            {
                title.Text += "\nMaxium allowed number of hints reached!";
                requestHint.Enabled = false;
            }
        }

        private void keyPressHandler(object? sender, KeyPressEventArgs e)
        {
            TextBox? box = (TextBox?)sender;

            if ((!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) || (box?.Text.Length >= 1 && !char.IsControl(e.KeyChar)) || (e.KeyChar == '0'))
            {
                e.Handled = true;
                return;
            }
        }

        private void textChanged(object? sender, EventArgs? e)
        {
            if (this.allowedHints > 0)
            {
                this.allowedHint = true;
                requestHint.Enabled = true;
            }
        }

        private void GetHint()
        {
            int x = -1, y = -1;

            int counter = 1;
            for (int i = 0; i < game.board.GetLength(0); i++)
            {
                for (int j = 0; j < game.board.GetLength(1); j++)
                {
                    TextBox box = (TextBox)this.Controls[$"box{counter}"];
                    if (game.board[i, j] == 0 && box.Text == "")
                    {
                        x = i; y = j;
                        j = game.board.GetLength(1);
                        i = game.board.GetLength(0);
                    }

                    if (i != game.board.GetLength(0) && j != game.board.GetLength(1))
                    {
                        counter++;
                    }
                }
            }

            if (x != -1 && y != -1 && solvedBoard != null)
            {
                TextBox box = (TextBox)this.Controls[$"box{counter}"];
                box.Text = solvedBoard[x, y].ToString();
                game.board[x, y] = solvedBoard[x, y];
                box.ForeColor = Color.Green;
                box.BackColor = Color.White;
                box.ReadOnly = true;
            }
        }
    }
}
