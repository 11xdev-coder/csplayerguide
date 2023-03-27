namespace book.part2.polymorphism.labelinginventory;

public class labelinginventory
{
    public static void polymorphismFunc()
    {
        // virtual means that method can be overrided
        // override means that method overriding another method

        Pack pack = new Pack(12, 10, 7);

        while (true)
        {
            pack.AddItem(AskForItem(Convert.ToInt32(Console.ReadLine())));
            Console.WriteLine(pack.ReportInfo());
            Console.WriteLine($"Pack contains: {pack.ToString()}");
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

    public override string ToString() => "Arrow";
}

public class Bow : Item
{
    public Bow() : base(1f, 4f)
    {
        
    }
    
    public override string ToString() => "Bow";
}

public class Rope : Item
{
    public Rope() : base(1f, 1.5f)
    {
        
    }
    
    public override string ToString() => "Rope";
}

public class Water : Item
{
    public Water() : base(2f, 3f)
    {
        
    }
    
    public override string ToString() => "Water";
}

public class Food : Item
{
    public Food() : base(1f, 0.5f)
    {
        
    }
    
    public override string ToString() => "Food";
}

public class Sword : Item
{
    public Sword() : base(5f, 3f)
    {
        
    }
    
    public override string ToString() => "Sword";
}

public class Pack
{
    public List<Item> _items = new List<Item>();
    
    public int currentItems;
    public float currentWeight;
    public float currentVolume;
    
    public int maxItems;
    public float maxWeight;
    public float maxVolume;
    
    public string totalItemsString;

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
            _items.Add(item);
            
            return true;
        }
        
        return false;
    }

    public string ReportInfo() => $"Items: {currentItems} \nWeight: {currentWeight} \nVolume: {currentVolume} " +
                                  $"\nItems limit: {maxItems} \nWeight limit: {maxWeight} \nVolume limit: {maxVolume}";

    public override string ToString()
    {
        totalItemsString = " ";
        foreach (Item item in _items)
        {
            totalItemsString = totalItemsString + " " + item.ToString() + " ";
        }

        return totalItemsString;
    }
}