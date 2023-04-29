namespace book.part3.files.theLongGame;

public class theLongGame
{
    public static void Start()
    {
        string pathToFile = "..\\..\\..\\Part3\\files";
        
        Console.Write("Enter ya name: ");
        string? userName = Console.ReadLine();
        
        string totalPath = $"{pathToFile}\\{userName}.txt";
        int score = 0;
        
        if (File.Exists(totalPath))
            score = LoadScore(totalPath);
        
        while (true)
        {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                SaveFile(totalPath, score);
                break;
            }
            else
            {
                Console.WriteLine("");
                score++;
                Console.WriteLine($"Your current score is {score}");
            }
        }

        void SaveFile(string path, int score)
        {
            File.WriteAllText(path, Convert.ToString(score));
        }

        int LoadScore(string path)
        {
            return Convert.ToInt32(File.ReadAllText(path));
        }
    }
}