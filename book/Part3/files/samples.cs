namespace book.part3.files.samples;

public class samples
{
    public static void Start()
    {
        string pathToFile = "..\\..\\..\\Part3\\files\\Message.txt";
        string pathToScoreFile = "..\\..\\..\\Part3\\files\\Scores.csv";
        
        if (File.Exists(pathToFile)) // checks if file exists
        {
            string previous = File.ReadAllText(pathToFile); // then we read all text that file had
            Console.WriteLine($"you said this: {previous}"); // and print it
        }
            Console.WriteLine("put some text here");
        string? message = Console.ReadLine();
        // every txt file is saving in projectname\\bin\\Debug\\net 6.0
        File.WriteAllText(pathToFile, message); // creates file in book\\Part3\\files
        
        
        
        List<Score> MakeDefaultScores()
        {
            return new List<Score>()
            {
                new Score("Durag", 12, 6),
                new Score("Gigani", 6920, 20),
                new Score("Clonk", 2, 60)
            };
        }
        // string manipulation
        void SaveScores(List<Score> scores)
        {
            List<string> scoreStrings = new List<string>(); // creating string collection

            foreach (Score score in scores)
                scoreStrings.Add($"{score.name}, {score.Points}, {score.Level}"); // adding every score into this collection
            
            File.WriteAllLines(pathToScoreFile, scoreStrings); // writes a collection of string in a file
        }

        List<Score> LoadScores()
        {
            string[] scoreStrings = File.ReadAllLines(pathToScoreFile);

            List<Score> scores = new List<Score>();

            foreach (string scoreString in scoreStrings)
            {
                string[] tokens = scoreString.Split(",");
                scores.Add(new Score(tokens[0], Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2])));
            }

            return scores;
        }
        
        SaveScores(MakeDefaultScores());
        foreach (Score score in LoadScores())
            Console.WriteLine($"{score.name}, {score.Points}, {score.Level}");
        
        // file system manipulation
        // File.Copy(fileToCopy, nameOfCopiedFile);
        // File.Move(file, path)
        // File.Delete(file)
        
        // The Directory class
        // Directory.Move(directory, path)
        // Directory.CreateDirectory(path)
        // Directory.Delete(path)
        // Directory.Delete(path, True) forces to delete everything inside the directory
        
        // The Path Class
        Console.WriteLine(Path.Combine("..\\..\\..\\", "Part3", "files"));
        Console.WriteLine(Path.GetFileName("..\\..\\..\\Part3\\files\\Message.txt"));
        Console.WriteLine(Path.GetFileNameWithoutExtension("..\\..\\..\\Part3\\files\\Message.txt"));
        Console.WriteLine(Path.GetExtension("..\\..\\..\\Part3\\files\\Message.txt"));
        Console.WriteLine(Path.GetFullPath("Scores.csv"));
        Console.WriteLine(Path.GetRelativePath(".", "C:/Users"));
    }
}

public record Score(string name, int Points, int Level);