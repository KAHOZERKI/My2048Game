using Microsoft.VisualBasic;
using System.Text.Json;

namespace _2048WinFormsApp
{
    public class ScoreStorage
    {
        private const string FilePath = "score.json";
        public static List<User> HighScores { get; set; } = new List<User>();
        static ScoreStorage() //статистический конструктор я создал,чтобы он вызваля при первом обращении к классу,
                              //чтобы не прописывать это в mainform load

        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                HighScores = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
            }
            else
            {
                HighScores = new List<User>();
            }
        }
        public static void Save()
        {
            var sortedScores = HighScores.OrderByDescending(u => u.Score).ToList();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(sortedScores, options);
            File.WriteAllText(FilePath, json);
        }
        public static void AddRecord(User user)
        {
            HighScores.Add(user);
            Save();
        }

        public static int GetGlobalBestScore()
        {
            if (HighScores == null || !HighScores.Any())
                return 0;

            return HighScores.Max(u => u.Score);
        }

    }
}
