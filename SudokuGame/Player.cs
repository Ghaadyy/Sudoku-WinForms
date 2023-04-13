using System;

namespace SudokuGame
{
    public class Player
    {
        public double balance = 100;

        public void UpdateBalance(double balanceToAdd)
        {
            this.balance += balanceToAdd;
        }

        public void DeduceBalance(double balanceToDeduce)
        {
            this.balance -= balanceToDeduce;
        }
    }
}
