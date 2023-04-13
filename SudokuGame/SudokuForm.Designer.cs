namespace SudokuGame
{
    partial class SudokuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.welcomeTitle = new System.Windows.Forms.Label();
            this.createGameText = new System.Windows.Forms.Label();
            this.easyGame = new System.Windows.Forms.Button();
            this.mediumGame = new System.Windows.Forms.Button();
            this.hardGame = new System.Windows.Forms.Button();
            this.currentBudget = new System.Windows.Forms.Label();
            this.addToBudget = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeTitle
            // 
            this.welcomeTitle.AutoSize = true;
            this.welcomeTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.welcomeTitle.Location = new System.Drawing.Point(142, 36);
            this.welcomeTitle.Name = "welcomeTitle";
            this.welcomeTitle.Size = new System.Drawing.Size(498, 65);
            this.welcomeTitle.TabIndex = 0;
            this.welcomeTitle.Text = "Welcome to Sudoku!";
            // 
            // createGameText
            // 
            this.createGameText.AutoSize = true;
            this.createGameText.Font = new System.Drawing.Font("Segoe UI Semibold", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createGameText.Location = new System.Drawing.Point(241, 121);
            this.createGameText.Name = "createGameText";
            this.createGameText.Size = new System.Drawing.Size(300, 45);
            this.createGameText.TabIndex = 1;
            this.createGameText.Text = "Create a new game";
            // 
            // easyGame
            // 
            this.easyGame.Location = new System.Drawing.Point(241, 209);
            this.easyGame.Name = "easyGame";
            this.easyGame.Size = new System.Drawing.Size(75, 23);
            this.easyGame.TabIndex = 2;
            this.easyGame.Text = "Easy";
            this.easyGame.UseVisualStyleBackColor = true;
            this.easyGame.Click += new System.EventHandler(this.easyGame_Click);
            // 
            // mediumGame
            // 
            this.mediumGame.Location = new System.Drawing.Point(355, 209);
            this.mediumGame.Name = "mediumGame";
            this.mediumGame.Size = new System.Drawing.Size(75, 23);
            this.mediumGame.TabIndex = 3;
            this.mediumGame.Text = "Medium";
            this.mediumGame.UseVisualStyleBackColor = true;
            this.mediumGame.Click += new System.EventHandler(this.mediumGame_Click);
            // 
            // hardGame
            // 
            this.hardGame.Location = new System.Drawing.Point(466, 209);
            this.hardGame.Name = "hardGame";
            this.hardGame.Size = new System.Drawing.Size(75, 23);
            this.hardGame.TabIndex = 4;
            this.hardGame.Text = "Hard";
            this.hardGame.UseVisualStyleBackColor = true;
            this.hardGame.Click += new System.EventHandler(this.hardGame_Click);
            // 
            // currentBudget
            // 
            this.currentBudget.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentBudget.Location = new System.Drawing.Point(241, 284);
            this.currentBudget.Name = "currentBudget";
            this.currentBudget.Size = new System.Drawing.Size(300, 61);
            this.currentBudget.TabIndex = 5;
            this.currentBudget.Text = "Current Budget";
            this.currentBudget.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addToBudget
            // 
            this.addToBudget.Location = new System.Drawing.Point(334, 368);
            this.addToBudget.Name = "addToBudget";
            this.addToBudget.Size = new System.Drawing.Size(113, 23);
            this.addToBudget.TabIndex = 6;
            this.addToBudget.Text = "Add to budget";
            this.addToBudget.UseVisualStyleBackColor = true;
            this.addToBudget.Click += new System.EventHandler(this.addToBudget_Click);
            // 
            // SudokuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addToBudget);
            this.Controls.Add(this.currentBudget);
            this.Controls.Add(this.hardGame);
            this.Controls.Add(this.mediumGame);
            this.Controls.Add(this.easyGame);
            this.Controls.Add(this.createGameText);
            this.Controls.Add(this.welcomeTitle);
            this.Name = "SudokuForm";
            this.Text = "Sudoku Game";
            this.Load += new System.EventHandler(this.SudokuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label welcomeTitle;
        private Label createGameText;
        private Button easyGame;
        private Button mediumGame;
        private Button hardGame;
        private Label currentBudget;
        private Button addToBudget;
    }
}