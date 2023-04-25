namespace book.part3.events.charberryTrees;

public class charberryTrees
{
    public static void Start()
    {
        CharberryTree tree = new CharberryTree();
        Notifier notifier = new Notifier(tree);
        Harvester harvester = new Harvester(tree);
        
        while(true)
            tree.MaybeGrow();
    }
}

public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }

    public event Action TreeRipened;

    public void MaybeGrow()
    {
        // only a tiny chance of ripening
        if (_random.NextDouble() < 0.00000001 && !Ripe)
        {
            Ripe = true;
            TreeRipened?.Invoke();
        }
    }
}

public class Notifier
{
    public Notifier(CharberryTree tree)
    {
        tree.TreeRipened += OnFruitRipe;
    }

    public void OnFruitRipe() => Console.WriteLine("A charberry fruit has ripened!");
}

public class Harvester
{
    private CharberryTree tree;
    
    public Harvester(CharberryTree tree)
    {
        this.tree = tree;
        this.tree.TreeRipened += Harvest;
    }

    public void Harvest()
    {
        this.tree.Ripe = false;
        Console.WriteLine("Tree has been harvested");
    }
}