using System.Text.Json;

namespace _2048WinFormsApp
{
    public static class RulsStorage
    {
        private const string FilePath = "rules.json";

        // Список строк, где каждая строка — отдельное правило
        public static List<string> Rules { get; set; } = new List<string>();

        // Загрузка списка из JSON
        public static void Load()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                Rules = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
            }
            else
            {
                Rules = GetRuls();
            }
        }
       static List<string> GetRuls()
        {
            return new List <string> {
                "Цель игры — собрать плитку 2048",
                "Используйте стрелки для перемещения",
                "Плитки с одинаковыми числами соединяются в одну."
            }
            ;
        }
    }
}
