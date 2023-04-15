namespace SudokuGame
{
    partial class AddBudgetForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.budgetBox = new System.Windows.Forms.TextBox();
            this.infoText = new System.Windows.Forms.Label();
            this.addBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(161, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(476, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Add to your budget";
            // 
            // budgetBox
            // 
            this.budgetBox.Location = new System.Drawing.Point(359, 182);
            this.budgetBox.Name = "budgetBox";
            this.budgetBox.Size = new System.Drawing.Size(100, 23);
            this.budgetBox.TabIndex = 1;
            // 
            // infoText
            // 
            this.infoText.Location = new System.Drawing.Point(306, 208);
            this.infoText.Name = "infoText";
            this.infoText.Size = new System.Drawing.Size(206, 64);
            this.infoText.TabIndex = 2;
            this.infoText.Text = "Enter budget to add";
            this.infoText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(355, 299);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(111, 23);
            this.addBtn.TabIndex = 3;
            this.addBtn.Text = "Add Budget";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // AddBudgetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.infoText);
            this.Controls.Add(this.budgetBox);
            this.Controls.Add(this.label1);
            this.Name = "AddBudgetForm";
            this.Text = "Add Budget";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox budgetBox;
        private Label infoText;
        private Button addBtn;
    }
}