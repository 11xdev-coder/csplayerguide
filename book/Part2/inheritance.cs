namespace book.part2.inheritance;

public class inheritance
{
    public static void inheritanceFunc()
    {
        // GameObject asteroid = new Asteroid(2, 3);
        // Console.WriteLine(asteroid.PosX);
        // Console.WriteLine(asteroid.PosY);
        Pack pack = new Pack(12, 10, 7);

        while (true)
        {
            pack.AddItem(AskForItem(Convert.ToInt32(Console.ReadLine())));
            Console.WriteLine(pack.ReportInfo());
        }
        
        
        
        
        
        
        
        Item AskForItem(int choice)
        {
            Console.WriteLine("Select an item: \n" +
                              "1 => Arrow \n" +
                              "2 => Bow \n" +
                              "3 => Rope \n" +
                              "4 => Water \n" +
                              "5 => Food \n" +
                              "6 => Sword \n");
            
            Item item = choice switch
            {
                1 => new Arrow(),
                2 => new Bow(),
                3 => new Rope(),
                4 => new Water(),
                5 => new Food(),
                6 => new Sword(),
            };

            return item;
        }
    }
}

public class Item
{
    public float weight { get; }
    public float volume { get; }

    public Item(float weight, float volume)
    {
        this.weight = weight;
        this.volume = volume;
    }
}

public class Arrow : Item
{
    public Arrow() : base(0.1f, 0.05f)
    {
        
    }
}

public class Bow : Item
{
    public Bow() : base(1f, 4f)
    {
        
    }
}

public class Rope : Item
{
    public Rope() : base(1f, 1.5f)
    {
        
    }
}

public class Water : Item
{
    public Water() : base(2f, 3f)
    {
        
    }
}
public class Food : Item
{
    public Food() : base(1f, 0.5f)
    {
        
    }
}

public class Sword : Item
{
    public Sword() : base(5f, 3f)
    {
        
    }
}

public class Pack
{
    public Item[] _items;
    
    public int currentItems;
    public float currentWeight;
    public float currentVolume;
    
    public int maxItems;
    public float maxWeight;
    public float maxVolume;

    public Pack(int maxItems, float maxWeight, float maxVolume)
    {
        this.maxItems = maxItems;
        this.maxWeight = maxWeight;
        this.maxVolume = maxVolume;
    }

    public bool AddItem(Item item)
    {
        if (currentItems + 1 <= maxItems && currentWeight + item.weight <= maxWeight && currentVolume + item.volume <= maxVolume)
        {
            currentItems += 1;
            currentWeight += item.weight;
            currentVolume += item.volume;
            
            return true;
        }
        
        return false;
    }

    public string ReportInfo() => $"Items: {currentItems} \nWeight: {currentWeight} \nVolume: {currentVolume} " +
                                  $"\nItems limit: {maxItems} \nWeight limit: {maxWeight} \nVolume limit: {maxVolume}";
}

public class GameObject
{
    public float PosX { get; set; }
    public float PosY { get; set; }

    public GameObject()
    {
        this.PosX = 0;
        this.PosY = 0;
    }
    
    public GameObject(float PosX, float PosY)
    {
        this.PosX = PosX;
        this.PosY = PosY;
    }
}

public class Asteroid : GameObject // includes GameObject's variables
{
    public float Size { get; set; }

    public Asteroid(float PosX, float PosY) : base(PosX, PosY)
    {
        
    }
}