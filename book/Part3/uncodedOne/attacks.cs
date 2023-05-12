namespace book.part3.uncodedOne.attacks;

public class attacks
{
    public static void Start()
    {
        string name = ColoredConsole.Prompt("What is your name?").ToUpper();
        
        Party heroes = new Party(new ComputerPlayer());
        heroes.characters.Add(new TrueProgrammer(name));

        Party monsters = new Party(new ComputerPlayer());
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
                    party.Player.ChooseAction(this, character).Run(this, character);
                }
            }
        }
    }
    
    public Party GetEnemyPartyFor(Character character) => heroes.characters.Contains(character) ? monsters : heroes;
    public Party GetPartyFor(Character character) => heroes.characters.Contains(character) ? heroes : monsters;
}

public interface IPlayer
{
    IAction ChooseAction(Game game, Character character);
}

public interface IAction
{
    void Run(Game game, Character doer);
}

public class DoNothingAction : IAction
{
    public void Run(Game game, Character doer)
    {
        Console.WriteLine($"{doer.Name} did NOTHING.");
    }
}

public interface IAttack
{
    string Name { get; }
}

public class AttackAction : IAction
{
    private readonly IAttack attack;
    private readonly Character target;

    public AttackAction(IAttack attack, Character target)
    {
        this.attack = attack;
        this.target = target;
    }

    public void Run(Game game, Character doer)
    {
        Console.WriteLine($"{doer.Name} used {attack.Name} on {target.Name}.");
    }
}

public class ComputerPlayer : IPlayer
{
    public IAction ChooseAction(Game game, Character character)
    {
        Thread.Sleep(500);
        return new AttackAction(character.StandardAttack, game.GetEnemyPartyFor(character).characters[0]);
    }
}

public class Party
{
    public IPlayer Player { get; }
    public List<Character> characters { get; } = new List<Character>();

    public Party(IPlayer player)
    {
        Player = player;
    }
}

public abstract class Character
{
    public abstract string Name { get; }
    public abstract IAttack StandardAttack { get; }

    public void Turn()
    {
        Console.WriteLine($"{Name} did NOTHING.");
    }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();
}

public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string name) => Name = name;
    
    public override IAttack StandardAttack { get; } = new Punch();
}

public class Punch : IAttack
{
    public string Name => "PUNCH";
}

public class BoneCrunch : IAttack
{
    public string Name => "BONE CRUNCH";
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