namespace _2048WinFormsApp
{
    public partial class mainForm : Form
    {
        private Label[,] labelsMap;
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
        private void GenerateNumber()
        {
            List<(int row, int col)> emptyCells = new List<(int, int)>(); //тут ии подсказал сделать Лист с 2мя переменными.
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

                var (targetRow, targetCol) = emptyCells[randomIndex]; // а вот тут магическая деконструкция кортежа
                labelsMap[targetRow, targetCol].Text = GenerateDigit();
            }
        }
        private string GenerateDigit()
        {
            int[] numbers = { 2, 4 };
            return numbers[random.Next(0, numbers.Length)].ToString();
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
                    // Выбираем ячейки в зависимости от нажатой клавиши
                    if (e.KeyCode == Keys.Right) line[j] = labelsMap[i, j];          // Строка i, слева направо
                    else if (e.KeyCode == Keys.Left) line[j] = labelsMap[i, 3 - j];  // Строка i, справо налево (реверс)
                    else if (e.KeyCode == Keys.Down) line[j] = labelsMap[j, i];      // Столбец i, сверху вниз
                    else if (e.KeyCode == Keys.Up) line[j] = labelsMap[3 - j, i];    // Столбец i, снизу вверх
                }

                // Если нажата одна из стрелок, обрабатываем "линию"
                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left ||
                    e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                {
                    ProcessLine(line);
                    moved = true;
                }
            }

            if (moved) GenerateNumber();
        }
        /*   if (e.KeyCode == Keys.Right)
           {
               for (int i = 0; i < mapSize; i++)
               {
                   for (int j = 0; j < mapSize; j++)
                   {
                       if (labelsMap[i, j].Text!= string.Empty)
                       {
                           for (int k = j - 1; k >= 0; k--)
                           {
                               if (labelsMap[i, k].Text != string.Empty)
                               {
                                   if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                   { 
                                       var number = int.Parse(labelsMap[i, j].Text);
                                       labelsMap[i, j].Text = (number*2).ToString();
                                       labelsMap[i, k].Text = string.Empty;
                                   }
                                   break;
                               }
                           } 
                       }
                   }
               }
               for (int i = 0; i < mapSize; i++)
               {
                   for (int j = 0; j < mapSize; j++)
                   {
                       if (labelsMap[i, j].Text == string.Empty)
                       {
                           for (int k = j - 1; k >= 0; k--)  
                           {
                               if (labelsMap[i, k].Text != string.Empty)
                               {

                                   labelsMap[i, j].Text = labelsMap[i, k].Text;
                                   labelsMap[i, k].Text = string.Empty;
                               }
                           }
                           break;
                       }
                   }
               }
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
           GenerateNumber();
        */
        }
    }
