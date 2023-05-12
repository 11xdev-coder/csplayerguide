namespace book.part3.uncodedOne.theTrueProgrammer;

public class theTrueProgrammer
{
    public static void Start()
    {
        string name = ColoredConsole.Prompt("What is your name?").ToUpper();
        
        Party heroes = new Party();
        heroes.characters.Add(new TrueProgrammer(name));

        Party monsters = new Party();
        monsters.characters.Add(new Skeleton());

        Game battle = new Game(heroes, monsters);
        battle.Run();
    }
}

public class Game
{
    public Party heroes;
    public Party monsters;

    public Game(Party heroes, Party monsters)
    {
        this.heroes = heroes;
        this.monsters = monsters;
    }

    public void Run()
    {
        while (true)
        {
            foreach (Party party in new[] { heroes, monsters })
            {
                foreach (Character character in party.characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    Thread.Sleep(500);
                    character.Turn();
                }
            }
        }
    }
}

public class Party
{
    public List<Character> characters { get; } = new List<Character>();
}

public abstract class Character
{
    public abstract string Name { get; }

    public void Turn()
    {
        Console.WriteLine($"{Name} did NOTHING.");
    }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
}

public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string name) => Name = name;
}

public static class ColoredConsole
{
    public static void WriteLine(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = previousColor;
    }

    public static void Write(string text, ConsoleColor color)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = previousColor;
    }

    public static string Prompt(string questionToAsk)
    {
        ConsoleColor previousColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Write(questionToAsk + " ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        string input = Console.ReadLine() ?? ""; // If we got null, use empty string instead.
        Console.ForegroundColor = previousColor;
        return input;
    }
}