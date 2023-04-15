using System;

namespace SudokuGame
{
    public partial class AddBudgetForm : Form
    {
        private Player player;
        private SudokuForm mainScreen;
        public AddBudgetForm(Player player, SudokuForm sudokuForm)
        {
            this.player = player;
            this.mainScreen = sudokuForm;
            InitializeComponent();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double budget;

                bool valid = double.TryParse(budgetBox.Text, out budget);
                if (!valid)
                {
                    throw new Exception("Please enter a valid number");
                }
                else
                {
                    if (budget <= 0)
                    {
                        throw new Exception("Please enter a positive number");
                    }
                    else
                    {
                        this.player.UpdateBalance(budget);
                        mainScreen.UpdateBalance();

                        infoText.ForeColor = Color.Green;
                        infoText.Text = $"Added {Math.Round(budget, 2)}$ to your balance!";
                    }
                }
            }
            catch (Exception ex)
            {
                infoText.ForeColor = Color.Red;
                infoText.Text = $"{ex.Message}";
            }
        }
    }
}
