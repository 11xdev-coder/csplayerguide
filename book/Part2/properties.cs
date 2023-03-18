namespace book.part2.properties;

class Properties
{
    public static void PropertiesFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Properties";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 20");
        Rectangle nerdRectangle = new Rectangle(2, 3);
        nerdRectangle.Width = 3;
        Console.WriteLine($"A {nerdRectangle.Width}x{nerdRectangle.Height} rectangle has an area of {nerdRectangle.Area}");
        // modify arrow class to use properties instead of GetX and SetX methods
    }
}

public class Rectangle
{
    // auto properties
    public float Width { get; set; }
    public float Height { get; set; }
    
    // get-only value
    public float Area => Width * Height;
    
    // Constructor
    public Rectangle(float width, float height)
    {
        Width = width; 
        Height = height;
    }
}