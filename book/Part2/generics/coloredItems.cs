namespace book.part2.generics.coloredItems;

public class coloredItems
{
    public static void Start()
    {
        ColoredItem<Sword> sword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
        ColoredItem<Bow> bow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
        ColoredItem<Axe> axe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);

        sword.Display();
        bow.Display();
        axe.Display();
    }
}

public class ColoredItem<T>
{
    public T Item { get; }
    public ConsoleColor Color { get; }

    public ColoredItem(T Item, ConsoleColor Color)
    {
        this.Item = Item;
        this.Color = Color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
    }
}

public class Sword
{
    public override string ToString() => "Sword";
}

public class Bow
{
    public override string ToString() => "Bow";
}

public class Axe
{
    public override string ToString() => "Axe";
}