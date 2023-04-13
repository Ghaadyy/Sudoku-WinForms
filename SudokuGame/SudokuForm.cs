using System;

namespace SudokuGame
{
    public partial class SudokuForm : Form
    {
        public Player player = new Player();

        public SudokuForm()
        {
            InitializeComponent();
        }

        private void easyGame_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(0, player, this);
            form.Show();
        }

        private void mediumGame_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(1, player, this);
            form.Show();
        }

        private void hardGame_Click(object sender, EventArgs e)
        {
            GameForm form = new GameForm(2, player, this);
            form.Show();
        }

        private void SudokuForm_Load(object sender, EventArgs e)
        {
            currentBudget.ForeColor = Color.Green;
            currentBudget.Text = $"{Math.Round(player.balance, 2)}$";
        }

        public void UpdateBalance()
        {
            currentBudget.Text = $"{Math.Round(player.balance, 2)}$";
        }

        private void addToBudget_Click(object sender, EventArgs e)
        {
            AddBudgetForm form = new AddBudgetForm(player, this);
            form.Show();
        }
    }
}
