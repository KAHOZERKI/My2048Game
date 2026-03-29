using Microsoft.VisualBasic;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] labelsMap;
        private int mapSize = 4;
        private static Random random = new Random();
        private int score = 0;
        private User user;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetUserName();
           this.mapSize= GetMapSize();
            InitMap();
            GenerateNumber();
            ShowScore();
            bestResultScoreLabel.Text = ScoreStorage.GetGlobalBestScore().ToString();
            this.Focus();
        }
        private void ShowScore()
        {
            scoreLabel.Text = score.ToString();
        }
        public void GetUserName()
        {
            string name = Interaction.InputBox("Пожалуйста, введите ваше имя", "Вход в игру 2048", "Игрок 1");

            if (string.IsNullOrWhiteSpace(name))
            {
                Application.Exit(); 
            }
            else
            {
                user = new User();
                user.Name = name;
            }
        }
        private int GetMapSize()
        {
            while (true)
            {
                string input = Interaction.InputBox("Введите целое число больше 1", "Размер карты");

                if (string.IsNullOrEmpty(input)) return 4;

                if (int.TryParse(input, out int result) && result > 1)
                {
                    return result;
                }

                MessageBox.Show("Ошибка! Пожалуйста, введите корректное число.");
            }
        }
        private void InitMap()
        {
            labelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;

                }
            }
        }
        public Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.AppWorkspace;
            label.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);

            label.Name = "digitLabel";
            label.Size = new Size(70, 70);
            int x = 10 + indexColumn * (70 + 6);
            int y = 70 + indexRow * (70 + 6);
            label.Location = new Point(x, y);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }
        private void UpdateMapColors()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Label label = labelsMap[i, j];
                    switch (label.Text)
                    {
                        case "": label.BackColor = Color.Silver; break;
                        case "2": label.BackColor = Color.White; break;
                        case "4": label.BackColor = Color.LemonChiffon; break;
                        case "8": label.BackColor = Color.Orange; break;
                        case "16": label.BackColor = Color.Coral; break;
                        case "32": label.BackColor = Color.Tomato; break;
                        case "64": label.BackColor = Color.OrangeRed; break;
                        case "128": label.BackColor = Color.Gold; break;
                        case "256": label.BackColor = Color.Yellow; break;
                        default: label.BackColor = Color.Red; break; 
                    }
                }
            }
        }
        private void GenerateNumber()
        {
            List<(int row, int col)> emptyCells = new List<(int, int)>(); 
            for (int r = 0; r < mapSize; r++)
            {
                for (int c = 0; c < mapSize; c++)
                {
                    if (labelsMap[r, c].Text == string.Empty)
                    {
                        emptyCells.Add((r, c));
                    }
                }
            }
            if (emptyCells.Count > 0)
            {
                int randomIndex = random.Next(0, emptyCells.Count);

                var (targetRow, targetCol) = emptyCells[randomIndex]; 
                labelsMap[targetRow, targetCol].Text = GenerateDigit();
                
            }
        }
        private string GenerateDigit()
        {            
            int chance = random.Next(1, 101);

            if (chance <= 75)
            {
                return "2";
            }
            else
            {
                return "4";
            }
        }
        private void ProcessLine(Label[] line)
        {
            for (int j = mapSize - 1; j >= 0; j--)
            {
                if (line[j].Text != string.Empty)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (line[k].Text != string.Empty)
                        {
                            if (line[j].Text == line[k].Text)
                            {
                                var number = int.Parse(line[j].Text);
                                score += number * 2;
                                line[j].Text = (number * 2).ToString();
                                line[k].Text = string.Empty;
                            }
                            break;
                        }
                    }
                }
            }
            for (int j = mapSize - 1; j >= 0; j--)
            {
                if (line[j].Text == string.Empty)
                {
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (line[k].Text != string.Empty)
                        {
                            line[j].Text = line[k].Text;
                            line[k].Text = string.Empty;
                            break;
                        }
                    }
                }
            }
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e) 
        {
            bool moved = false;

            for (int i = 0; i < mapSize; i++)
            {
                Label[] line = new Label[mapSize];

                for (int j = 0; j < mapSize; j++)
                {
                    if (e.KeyCode == Keys.Right) line[j] = labelsMap[i, j];
                    else if (e.KeyCode == Keys.Left) line[j] = labelsMap[i, mapSize-1 - j];
                    else if (e.KeyCode == Keys.Down) line[j] = labelsMap[j, i];
                    else if (e.KeyCode == Keys.Up) line[j] = labelsMap[mapSize - 1 - j, i];
                }
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left ||
                    e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    ProcessLine(line);
                    moved = true;
                }
            }
            if (moved)
            {
                GenerateNumber();
                ShowScore();
                UpdateMapColors();
                if (IsWin())
                {
                    MessageBox.Show($"Поздравляем, {user.Name}! Вы собрали 2048!");
                    bestResultScoreLabel.Text = ScoreStorage.GetGlobalBestScore().ToString();
                    ResetGame();
                }
                else if (IsGameOver())
                {
                    user.Score=score;
                    ScoreStorage.AddRecord(user);
                    bestResultScoreLabel.Text = ScoreStorage.GetGlobalBestScore().ToString();
                    MessageBox.Show($"Игра окончена, {user.Name}! Ваши очки: {user.Score}");
                    ResetGame();
                }
            }

            }
        private bool IsGameOver()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                        return false; 
                }
            }
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize - 1; j++)
                {
                    if (labelsMap[i, j].Text == labelsMap[i, j + 1].Text)
                        return false; 
                }
            }
            for (int j = 0; j < mapSize; j++)
            {
                for (int i = 0; i < mapSize - 1; i++)
                {
                    if (labelsMap[i, j].Text == labelsMap[i + 1, j].Text)
                        return false; 
                }
            }
            return true;
        }
        private bool IsWin()
        {
            foreach (var label in labelsMap)
            {
                if (label.Text == "2048") return true;
            }
            return false;
        }
        private void ResetGame()
        {
            score = 0;
            ShowScore();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    labelsMap[i, j].Text = string.Empty;
                    labelsMap[i, j].BackColor = SystemColors.AppWorkspace; 
                }
            }
            GenerateNumber();
        }
        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RulsStorage.Load();
            string message = string.Join("\n", RulsStorage.Rules);
            MessageBox.Show(message, "Правила игры 2048", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void начатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
