namespace book.part3.uncodedOne.gameStatus;

public class gameStatus
{
    public static void Start()
    {
        // some functions
        #region party funcs
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
        Party monsterParty3(IPlayer player)
        {
            Party monsters = new Party(player);
            monsters.characters.Add(new Skeleton());
            monsters.characters.Add(new Skeleton());
            monsters.characters.Add(new UncodedOne());
            return monsters;
        }
        #endregion
        
        Console.WriteLine("geme made slektion:");
        Console.WriteLine("1 - human being vs alien");
        Console.WriteLine("2 - alien vs alien");
        Console.WriteLine("3 - human being vs human being");
        string choice = ColoredConsole.Prompt("now pick");

        IPlayer heroPlayer;
        IPlayer monsterPlayer;
        
        if (choice == "1") { heroPlayer = new HumanPlayer(); monsterPlayer = new ComputerPlayer(); }
        else if (choice == "2") { heroPlayer = new ComputerPlayer(); monsterPlayer = new ComputerPlayer(); }
        else { heroPlayer = new HumanPlayer(); monsterPlayer = new HumanPlayer(); }

        
        string name = ColoredConsole.Prompt("whacha name?").ToUpper();
        
        
        
        Party heroes = new Party(heroPlayer);
        heroes.characters.Add(new TrueProgrammer(name));

        List<Party> monsterParties = new List<Party> { monsterParty1(monsterPlayer), monsterParty2(monsterPlayer), monsterParty3(monsterPlayer) };

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
    
    public void Status(Game game, Character activeCharacter)
    {
        
        ColoredConsole.WriteLine($"===================================================== game ====================================================", ConsoleColor.White);

        
        foreach (Character character in game.heroes.characters)
        {
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.WriteLine($"{character.Name} ({character.HP}/{character.MaxHP})", color);
        }
        
        ColoredConsole.WriteLine("------------------------------------------------------ vs -------------------------------------------------------", ConsoleColor.White);

        
        foreach (Character character in game.monsters.characters)
        {
            ConsoleColor color = character == activeCharacter ? ConsoleColor.Yellow : ConsoleColor.Gray;
            ColoredConsole.WriteLine($"                                                          {character.Name} ({character.HP,3}/{character.MaxHP})", color);
        }

        
        ColoredConsole.WriteLine("=================================================================================================================", ConsoleColor.White);
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
                    Status(this, character);
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

public class HumanPlayer : IPlayer
{
    public IAction ChooseAction(Game game, Character character)
    {
        List<MenuChoice> menuChoices = CreateMenuOptions(game, character);

        for (int index = 0; index < menuChoices.Count; index++)
            ColoredConsole.WriteLine($"{index + 1} - {menuChoices[index].Description}", menuChoices[index].Enabled ? ConsoleColor.Gray : ConsoleColor.DarkGray);

        string choice = ColoredConsole.Prompt("whacha wanna do?");
        int menuIndex = Convert.ToInt32(choice) - 1;

        if (menuChoices[menuIndex].Enabled) return menuChoices[menuIndex].Action!; // Checking if it is enabled is as good as a null check.

        return new DoNothingAction();
    }

    private List<MenuChoice> CreateMenuOptions(Game game, Character character)
    {
        Party currentParty = game.GetPartyFor(character);
        Party otherParty = game.GetEnemyPartyFor(character);

        List<MenuChoice> menuChoices = new List<MenuChoice>();

        if (otherParty.characters.Count > 0)
            menuChoices.Add(new MenuChoice($"standard Attack ({character.StandardAttack.Name})", new AttackAction(character.StandardAttack, otherParty.characters[0])));
        else
            menuChoices.Add(new MenuChoice($"standard Attack ({character.StandardAttack.Name})", null));


        menuChoices.Add(new MenuChoice("nothing", new DoNothingAction()));

        return menuChoices;
    }
}

public record MenuChoice(string Description, IAction? Action)
{
    public bool Enabled => Action != null;
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

public class UncodedOne : Character
{
    public override string Name => "THE UNCODED ONE";

    public UncodedOne() : base(15) { }
    
    public override IAttack StandardAttack { get; } = new UnravelingAttack();
}

// attacks
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

public class UnravelingAttack : IAttack
{
    private static readonly Random _random = new Random();

    public string Name => "UNRAVELING ATTACK";
    public AttackData Create() => new AttackData(_random.Next(3));
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