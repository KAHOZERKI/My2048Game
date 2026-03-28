namespace _2048WinFormsApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            totalScore = new Label();
            scoreLabel = new Label();
            menu = new MenuStrip();
            менюToolStripMenuItem = new ToolStripMenuItem();
            начатьЗановоToolStripMenuItem = new ToolStripMenuItem();
            выйтиToolStripMenuItem = new ToolStripMenuItem();
            правилаИгрыToolStripMenuItem = new ToolStripMenuItem();
            labelResult = new Label();
            bestResultScoreLabel = new Label();
            menu.SuspendLayout();
            SuspendLayout();
            // 
            // totalScore
            // 
            totalScore.AutoSize = true;
            totalScore.Location = new Point(72, 24);
            totalScore.Name = "totalScore";
            totalScore.Size = new Size(33, 15);
            totalScore.TabIndex = 0;
            totalScore.Text = "Счёт";
            totalScore.UseMnemonic = false;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(131, 24);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(13, 15);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "0";
            // 
            // menu
            // 
            menu.Items.AddRange(new ToolStripItem[] { менюToolStripMenuItem });
            menu.Location = new Point(0, 0);
            menu.Name = "menu";
            menu.Size = new Size(800, 24);
            menu.TabIndex = 2;
            menu.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            менюToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { начатьЗановоToolStripMenuItem, выйтиToolStripMenuItem, правилаИгрыToolStripMenuItem });
            менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            менюToolStripMenuItem.Size = new Size(53, 20);
            менюToolStripMenuItem.Text = "Меню";
            // 
            // начатьЗановоToolStripMenuItem
            // 
            начатьЗановоToolStripMenuItem.Name = "начатьЗановоToolStripMenuItem";
            начатьЗановоToolStripMenuItem.Size = new Size(154, 22);
            начатьЗановоToolStripMenuItem.Text = "Начать заново";
            начатьЗановоToolStripMenuItem.Click += начатьЗановоToolStripMenuItem_Click;
            // 
            // выйтиToolStripMenuItem
            // 
            выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            выйтиToolStripMenuItem.Size = new Size(154, 22);
            выйтиToolStripMenuItem.Text = "Выйти";
            выйтиToolStripMenuItem.Click += выйтиToolStripMenuItem_Click;
            // 
            // правилаИгрыToolStripMenuItem
            // 
            правилаИгрыToolStripMenuItem.Name = "правилаИгрыToolStripMenuItem";
            правилаИгрыToolStripMenuItem.Size = new Size(154, 22);
            правилаИгрыToolStripMenuItem.Text = "Правила игры";
            правилаИгрыToolStripMenuItem.Click += правилаИгрыToolStripMenuItem_Click;
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(164, 22);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(109, 15);
            labelResult.TabIndex = 4;
            labelResult.Text = "Лучший Результат";
            // 
            // bestResultScoreLabel
            // 
            bestResultScoreLabel.AutoSize = true;
            bestResultScoreLabel.Location = new Point(299, 23);
            bestResultScoreLabel.Name = "bestResultScoreLabel";
            bestResultScoreLabel.Size = new Size(13, 15);
            bestResultScoreLabel.TabIndex = 5;
            bestResultScoreLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(bestResultScoreLabel);
            Controls.Add(labelResult);
            Controls.Add(scoreLabel);
            Controls.Add(totalScore);
            Controls.Add(menu);
            MainMenuStrip = menu;
            Name = "MainForm";
            Text = "2048";
            Load += Form1_Load;
            KeyDown += mainForm_KeyDown;
            menu.ResumeLayout(false);
            menu.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label totalScore;
        private Label scoreLabel;
        private MenuStrip menu;
        private ToolStripMenuItem менюToolStripMenuItem;
        private ToolStripMenuItem начатьЗановоToolStripMenuItem;
        private ToolStripMenuItem выйтиToolStripMenuItem;
        private ToolStripMenuItem правилаИгрыToolStripMenuItem;
        private Label labelResult;
        private Label bestResultScoreLabel;
    }
}
