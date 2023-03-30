namespace book.part2.structs.structs;

public class structs
{
    public static void Start()
    {
        // structs are short for structure or data structure
        // critical diference is tht structs are value types instead of reference types
        // reference types store references to their data in their objects
        // value types directly contain their data

        Point p = new Point(2, 2);
        Console.WriteLine($"{p.x} {p.y}"); // same as class but struct yes?

        PairOfInts pair;
        pair.A = 3; pair.B = 6;
        Console.WriteLine($"{pair.A} {pair.B}"); // see constructor not always needed
        
        //  classes vs structs
        // classes are referemce types while structs are value types
        // structs cannot take null value
        // structs dont support inheritance
        
        // structs are better choice for small and data-focused types
        
        /* rules to follow when making structs:
         1. keep them small
         2. make structs immutable (make variables readonly or dont put setter)
         3. try to not make constructors
        */
        
        // classes and structs share same base class: object
        // class derive from object directly, while structs derive from special System.ValueType class which is derived from object
        object thing = 3;
        int number = (int) thing;
        Console.WriteLine(number);
        // thats a sample of Boxing and Unboxing
        /*
         when a struct value is assigned to a variable that stores references, like this first line
         the data is pushed to another location - a box
         a reference to the box is stored in the thing variable
         this is called boxing conversion
         */
        
        /*
         on the second line inverse happens, extracting box's content - an unboxing conversion
         and copied into number variable
         */
    }
}
// you should make structs small and immutable
public struct Point
{
    public float x { get; }
    public float y { get; }

    public Point(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}

// invoking constructor is not always necessary
public struct PairOfInts
{
    public int A;
    public int B;
}
// structs always have a public parameterless constructor
