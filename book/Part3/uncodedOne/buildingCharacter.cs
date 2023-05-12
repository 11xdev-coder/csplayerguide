namespace book.part3.uncodedOne.buildingCharacter;

public class buildingCharacter
{
    public static void Start()
    {
        Party heroes = new Party();
        heroes.characters.Add(new Skeleton());

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