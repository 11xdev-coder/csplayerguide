namespace book.part2.inheritance;

public class inheritance
{
    public static void inheritanceFunc()
    {
        GameObject asteroid = new Asteroid(2, 3);
        Console.WriteLine(asteroid.PosX);
        Console.WriteLine(asteroid.PosY);
    }
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