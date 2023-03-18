namespace book.part2.catacombs.color;

public class color
{
    public static void colorFunc()
    {
        Color random = new Color(125, 125, 125);
        Color fixedcolor = Color.Black;
        
        Console.WriteLine($"R {random.R} G {random.G} B {random.B}");
        Console.WriteLine($"R {fixedcolor.R} G {fixedcolor.G} B {fixedcolor.B}");
    }
}

class Color
{
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }

    public Color(byte r, byte g, byte b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color White { get; } = new Color(255, 255, 255);
    public static Color Black { get; } = new Color(0, 0, 0);
    public static Color Red { get; } = new Color(255, 0, 0);
    public static Color Orange { get; } = new Color(255, 165, 0);
    public static Color Yellow { get; } = new Color(255, 255, 0);
    public static Color Green { get; } = new Color(0, 128, 0);
    public static Color Blue { get; } = new Color(0, 0, 255);
    public static Color Purple { get; } = new Color(128, 0, 128);
}