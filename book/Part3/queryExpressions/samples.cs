namespace book.part3.queryExpressions.samples;

public class samples
{
    public static void Start()
    {
        void PrintFromQuery<T>(IEnumerable<T> enumerable)
        {
            foreach (var text in enumerable)
                Console.WriteLine(text);
        }
        // query expressions are a special type of statement that allows you to extract specific pieces from data
        // query expressions are made of multiple clauses

        List<GameObject> objects = new List<GameObject>();
        objects.Add(new Ship {ID = 1, x=0, y=0, HP=50, MaxHP=100});
        objects.Add(new Ship {ID = 2, x=4, y=2, HP=75, MaxHP=100});
        objects.Add(new Ship {ID = 3, x=9, y=3, HP=0, MaxHP=100});

        // from identifies the collection that is being queried
        // select identifies data to be produced
        IEnumerable<string> healthTexts = from o in objects select $"{o.HP}/{o.MaxHP}"; // creates object "o", selecting data
                                                                        // collection and extracting information
                                                                        // we need from object "o"
        PrintFromQuery(healthTexts); // queries are IEnumerable<type>
        
        // filtering
        Console.WriteLine("ID's of alive ships:");
        var aliveObjects = from o in objects where o.HP > 0 select o.ID; // creating object o in objects, 
                                                                         // sorting out their hp,
                                                                         // and extracting ids of ships hp > 0
                                                                         // there can be more than 1 where's at a time!
        PrintFromQuery(aliveObjects);
        // sorting
        Console.WriteLine("Every ship's hp sorted from smaller to bigger:");
        var weakierObjects = from o in objects orderby o.HP select o.ID; // there can be more params to sort
        PrintFromQuery(weakierObjects);
        Console.WriteLine("Every ship's hp sorted from bigger to smaller:");
        var healthierObjects = from o in objects 
            orderby o.HP descending 
            select o.ID; // there can be more params to sort
        PrintFromQuery(healthierObjects);
        
        // method syntax
        Console.WriteLine("Alive ships sortered by hp(method syntax):");
        var results = objects
            .Where(o => o.HP > 0)
            .OrderBy(o => o.HP)
            .Select(o => o.HP);
        PrintFromQuery(results);
    }
}

public class GameObject
{
    public int ID { get; set; }
    public double x { get; set; }
    public double y { get; set; }
    public int MaxHP { get; set; }
    public int HP { get; set; }
}

public class Ship : GameObject
{
    
}