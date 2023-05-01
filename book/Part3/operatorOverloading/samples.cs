namespace book.part3.operatorOverloading.samples;

public class samples
{
    public static void Start()
    {
        // result
        Point a = new Point(2, 8);
        Point b = new Point(5, 2);

        Point result = a + b;
        Console.WriteLine($"{result.X}, {result.Y}");
        
        // indexers
        Pair pair = new Pair();
        pair[0] = 1;
        pair[1] = 4; // same
        Pair pair2 = new Pair()
        {
            [0] = 1,
            [1] = 4,
        }; // same
        
        Console.WriteLine($"{pair[0]}, {pair[1]}");
        Console.WriteLine($"{pair2[0]}, {pair2[1]}");

        Point2 c = new Point2(1, 2);
        Point3 d = c; // implicit

        Point3 e = new Point3(1, 2, 3);
        Point2 f = (Point2)e; // explicit

        int g = 0;
        long h = g; // implicit
        int j = (int)h; // explicit
    }
}

public record Point(double X, double Y)
{
    // defining an operator overload
    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
    // they must be marked with public static
}
// example of indexer
public class Pair
{
    public int first { get; set; }
    public int second { get; set; }

    public int this[int index]
    {
        get
        {
            if (index == 0) return first;
            else return second;
        }
        set
        {
            if (index == 0) first = value;
            else second = value;
        }
    }
}

public record Point2(int X, int Y)
{
    public static explicit operator Point2(Point3 p) => new Point2(p.X, p.Y); // conversion from point3 to point2
}

public record Point3(int X, int Y, int Z)
{
    public static implicit operator Point3(Point2 p) => new Point3(p.X, p.Y, 0); // conversion from point2 to point3
}