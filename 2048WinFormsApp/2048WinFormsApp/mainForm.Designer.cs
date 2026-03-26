namespace _2048WinFormsApp
{
    partial class mainForm
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
            SuspendLayout();
            // 
            // totalScore
            // 
            totalScore.AutoSize = true;
            totalScore.Location = new Point(79, 20);
            totalScore.Name = "totalScore";
            totalScore.Size = new Size(33, 15);
            totalScore.TabIndex = 0;
            totalScore.Text = "Счёт";
            totalScore.UseMnemonic = false;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(123, 19);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(13, 15);
            scoreLabel.TabIndex = 1;
            scoreLabel.Text = "0";
            // 
            // mainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(scoreLabel);
            Controls.Add(totalScore);
            Name = "mainForm";
            Text = "2048";
            Load += Form1_Load;
            KeyDown += mainForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label totalScore;
        private Label scoreLabel;
    }
}
