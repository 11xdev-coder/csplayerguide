namespace book.part2.records.records;

public class records
{
    public static void Start()
    {
        // records are compact alternative for defining data-centric class or struct
        // the compiler automatically generetas a constuctor and properties
        
        // Records automatically override ToString method
        Console.WriteLine(new Point(2, 3).ToString()); // Point { x = 2, y = 3 }
        
        // Value Semantics
        Point a = new Point(2, 3);
        Point b = new Point(2, 3);
        Console.WriteLine(a == b); // true
        // Though a and b refer to different instances and use separate memory locations, this will be true
        
        // Deconstruction
        Point p = new Point(2, 3);
        (float x, float y) = p;
        Console.WriteLine($"{x} {y}");
        
        // with Statements
        // records give you extra form of a with statement
        Point p1 = new Point(-2, 5);
        Point p2 = p1 with {x = 0};
        Console.WriteLine($"{p1.ToString()} {p2.ToString()}"); // Point { x = -2, y = 5 } Point { x = 0, y = 5 }
        // replace one value of record
    }
}

public record Point(float x, float y); // thats all

// additional members
public record Rectangle(float width, float height)
{
    public float Area => width * height;
}

