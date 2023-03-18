namespace book.part2.catacombs.point;

class Point
{
    public static void pointFunc()
    {
        point point1 = new point(2, 3);
        point point2 = new point(-4, 0);
        point point3 = new point();
        
        Console.WriteLine(point1.PosX + ", " + point1.PosY);
        Console.WriteLine(point2.PosX + ", " + point2.PosY);
        Console.WriteLine(point3.PosX + ", " + point3.PosY);
    }
}

public class point
{
    public float PosX { get; set; }
    public float PosY { get; set; }

    public point(float posX, float posY)
    {
        PosX = posX;
        PosY = posY;
    }

    public point()
    {
        PosX = 0;
        PosY = 0;
    }
}