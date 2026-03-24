namespace _2048WinFormsApp
{
    public partial class mainForm : Form
    {
        private Label[,] LabelsMap;
        private const int mapSize = 4;
        private static Random random = new Random();
        public mainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initMap();
            GenerateNumber();
        }
        private void initMap()
        {
            LabelsMap = new Label[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    LabelsMap[i, j] = newLabel;

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
        private void GenerateNumber()
        {
            List<(int row, int col)> emptyCells = new List<(int, int)>(); //тут ии подсказал сделать Лист с 2мя переменными.
            for (int r = 0; r < mapSize; r++)
            {
                for (int c = 0; c < mapSize; c++)
                {
                    if (LabelsMap[r, c].Text == string.Empty)
                    {
                        emptyCells.Add((r, c));
                    }
                }
            }
            if (emptyCells.Count > 0)
            {
                int randomIndex = random.Next(0, emptyCells.Count);

                var (targetRow, targetCol) = emptyCells[randomIndex]; // а вот тут магическая деконструкция кортежа
                LabelsMap[targetRow, targetCol].Text = GenerateDigit();
            }
        }
        private string GenerateDigit()
        {
            int[] numbers = { 2, 4 };
            return numbers[random.Next(0, numbers.Length)].ToString();
        }

        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                MessageBox.Show("Правая стрелка нажата");
            }
            if (e.KeyCode == Keys.Left)
            {
                MessageBox.Show("левая стрелка нажата");
            }
            if (e.KeyCode == Keys.Up)
            {
                MessageBox.Show("Верхняя стрелка нажата");
            }
            if (e.KeyCode == Keys.Down)
            {
                MessageBox.Show("Нижняя стрелка нажата");
            }

        }
    }
}
