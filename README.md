# Sudoku Forms

## About the project

This is a Sudoku Game built with Windows Forms in C#, it was an assignment in Informatique 2.

## Main Features

- Creates a random sudoku board for the player to solve
- Features multiple levels of difficulty
- Keeps track of balance (depending on whether the player won or lost the game)
- Give out hints on request

### My Implementation

I created the sudoku logic at first, by creating a random sub-board, that i then solve using my Sudoku solver.
This way I generate a random board on each game.
The sudoku solver was implemented using a backtracking algorithm and using recursion.

I then ported the features to a WinForms application where I dynamically generate the board, depending on the level chosen by the user.
