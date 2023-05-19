namespace book.part3.uncodedOne.battleSeries;

public class battleSeries
{
    public static void Start()
    {
        Party monsterParty1(IPlayer player)
        {
            Party monsters = new Party(player);
            monsters.characters.Add(new Skeleton());
            return monsters;
        }
        Party monsterParty2(IPlayer player)
        {
            Party monsters = new Party(player);
            monsters.characters.Add(new Skeleton());
            monsters.characters.Add(new Skeleton());
            return monsters;
        }
        
        string name = ColoredConsole.Prompt("whacha name?").ToUpper();
        
        Party heroes = new Party(new ComputerPlayer());
        heroes.characters.Add(new TrueProgrammer(name));
        
        IPlayer player1 = new ComputerPlayer();
        IPlayer player2 = new ComputerPlayer();
        
        List<Party> monsterParties = new List<Party> { monsterParty1(player2), monsterParty2(player2) };

        for (int gameNumber = 0; gameNumber < monsterParties.Count; gameNumber++) // getting through every party
        {
            Party monsters = monsterParties[gameNumber]; // setting monster party to current party index
            Game game = new Game(heroes, monsters); // new game
            game.Run();

            if (heroes.characters.Count == 0) break;
        }
        
        // run dis when while loop ends
        if (heroes.characters.Count > 0) ColoredConsole.WriteLine("wowie you won cool uncoded one go bye bye", ConsoleColor.Green);
        else ColoredConsole.WriteLine("aaaa you nubs uncoded one kil you", ConsoleColor.Red);
    }
}

public class Game
{
    public Party heroes;
    public Party monsters;
    
    // da constructor
    public Game(Party heroes, Party monsters)
    {
        this.heroes = heroes;
        this.monsters = monsters;
    }

    public void Run()
    {
        // until game ends
        while (!GameEnd)
        {
            // getting a total party from these 2
            foreach (Party party in new[] { heroes, monsters })
            {
                // getting every character
                foreach (Character character in party.characters)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{character.Name} is taking a turn...");
                    party.Player.ChooseAction(this, character).Run(this, character);
                }

                if (GameEnd) break;
            }

            if (GameEnd) break;
        }
    }
    // game enda checka
    public bool GameEnd => heroes.characters.Count <= 0 || monsters.characters.Count <= 0;
    
    // useful fucnscscscc
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

public record AttackData(int Damage);

public interface IAttack
{
    string Name { get; }
    AttackData Create();
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

        AttackData data = attack.Create();
        target.HP -= data.Damage;

        Console.WriteLine($"{attack.Name} dealt {data.Damage} damage to {target.Name}.");
        Console.WriteLine($"{target.Name} is now at {target.HP}/{target.MaxHP} HP.");
        if (!target.IsAlive)
        {
            game.GetPartyFor(target).characters.Remove(target);
            Console.WriteLine($"{target.Name} has rekt gg wp");
        }
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
    
    private int _hp;
    public int HP
    {
        get => _hp;
        set => _hp = Math.Clamp(value, 0, MaxHP);
    }

    public int MaxHP { get; }

    public bool IsAlive => HP > 0;

    public Character(int hp)
    {
        MaxHP = hp;
        HP = hp;
    }
}

public class Skeleton : Character
{
    public override string Name => "SKELETON";
    public override IAttack StandardAttack { get; } = new BoneCrunch();
    
    public Skeleton() : base(5) { }
}

public class TrueProgrammer : Character
{
    public override string Name { get; }

    public TrueProgrammer(string name) : base(25) => Name = name;
    
    public override IAttack StandardAttack { get; } = new Punch();
}

public class Punch : IAttack
{
    public string Name => "PUNCH";

    public AttackData Create() => new AttackData(1);
}

public class BoneCrunch : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "BONE CRUNCH";
    public AttackData Create() => new AttackData(_random.Next(2));
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
        string input = Console.ReadLine() ?? ""; // empty string instead of null
        Console.ForegroundColor = previousColor;
        return input;
    }
}