namespace SudokuGame
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.quitGame = new System.Windows.Forms.Button();
            this.timeRemaining = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.submitGrid = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.startNew = new System.Windows.Forms.Button();
            this.addBudget = new System.Windows.Forms.Button();
            this.requestHint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quitGame
            // 
            this.quitGame.Location = new System.Drawing.Point(16, 395);
            this.quitGame.Name = "quitGame";
            this.quitGame.Size = new System.Drawing.Size(75, 23);
            this.quitGame.TabIndex = 0;
            this.quitGame.Text = "Quit Game";
            this.quitGame.UseVisualStyleBackColor = true;
            this.quitGame.Click += new System.EventHandler(this.quitGame_Click);
            // 
            // timeRemaining
            // 
            this.timeRemaining.AutoSize = true;
            this.timeRemaining.Location = new System.Drawing.Point(720, 20);
            this.timeRemaining.Name = "timeRemaining";
            this.timeRemaining.Size = new System.Drawing.Size(38, 15);
            this.timeRemaining.TabIndex = 1;
            this.timeRemaining.Text = "label1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // submitGrid
            // 
            this.submitGrid.Location = new System.Drawing.Point(343, 395);
            this.submitGrid.Name = "submitGrid";
            this.submitGrid.Size = new System.Drawing.Size(117, 23);
            this.submitGrid.TabIndex = 2;
            this.submitGrid.Text = "Submit my Grid";
            this.submitGrid.UseVisualStyleBackColor = true;
            this.submitGrid.Click += new System.EventHandler(this.submitGrid_Click);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(16, 16);
            this.title.Name = "title";
            this.title.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.title.Size = new System.Drawing.Size(108, 325);
            this.title.TabIndex = 3;
            this.title.Text = "Sudoku";
            // 
            // startNew
            // 
            this.startNew.Location = new System.Drawing.Point(97, 395);
            this.startNew.Name = "startNew";
            this.startNew.Size = new System.Drawing.Size(114, 23);
            this.startNew.TabIndex = 4;
            this.startNew.Text = "Start New Game";
            this.startNew.UseVisualStyleBackColor = true;
            this.startNew.Click += new System.EventHandler(this.startNew_Click);
            // 
            // addBudget
            // 
            this.addBudget.Location = new System.Drawing.Point(654, 395);
            this.addBudget.Name = "addBudget";
            this.addBudget.Size = new System.Drawing.Size(104, 23);
            this.addBudget.TabIndex = 5;
            this.addBudget.Text = "Add to budget";
            this.addBudget.UseVisualStyleBackColor = true;
            this.addBudget.Click += new System.EventHandler(this.addBudget_Click);
            // 
            // requestHint
            // 
            this.requestHint.Location = new System.Drawing.Point(525, 395);
            this.requestHint.Name = "requestHint";
            this.requestHint.Size = new System.Drawing.Size(123, 23);
            this.requestHint.TabIndex = 6;
            this.requestHint.Text = "Get Hint ($0.1)";
            this.requestHint.UseVisualStyleBackColor = true;
            this.requestHint.Click += new System.EventHandler(this.requestHint_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.requestHint);
            this.Controls.Add(this.addBudget);
            this.Controls.Add(this.startNew);
            this.Controls.Add(this.title);
            this.Controls.Add(this.submitGrid);
            this.Controls.Add(this.timeRemaining);
            this.Controls.Add(this.quitGame);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "GameForm";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button quitGame;
        private Label timeRemaining;
        private System.Windows.Forms.Timer timer1;
        private Button submitGrid;
        private Label title;
        private Button startNew;
        private Button addBudget;
        private Button requestHint;
    }
}