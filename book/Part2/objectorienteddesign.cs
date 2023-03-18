namespace book.part2.ood;

public class objectorienteddesign
{
    public static void oodFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Object Oriented Design";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 23");
        AsteroidGame game = new AsteroidGame();
        game.RunGame();
    }
}
// class asteroid
public class Asteroid
{
    // assigning basic values
    public float PosX { get; private set; }
    public float PosY { get; private set; }
    public float VelX { get; private set; }
    public float VelY { get; private set; }
    // constructor
    public Asteroid(float posX, float posY, float velX, float velY)
    {
        PosX = posX;
        PosY = posY;
        VelX = velX;
        VelY = velY;
    }
    // giving asteroid ability to move
    public void Update()
    {
        PosX += VelX;
        PosY += VelY;
    }
}

public class AsteroidGame
{
    public Asteroid[] _asteroids;

    public AsteroidGame()
    {
        _asteroids = new Asteroid[5];
        _asteroids[0] = new Asteroid(-100, 200, -4, -2);
        _asteroids[1] = new Asteroid(-50, 100, -1, 3);
        _asteroids[2] = new Asteroid(0, 0, 2, 1);
        _asteroids[3] = new Asteroid(400, -100, -3, -1);
        _asteroids[4] = new Asteroid(200, -300, 0, -3);
    }

    public void RunGame()
    {
        while (true)
        {
            foreach (Asteroid asteroid in _asteroids)
            {
                asteroid.Update();
                Console.WriteLine(asteroid.PosX + ", " + asteroid.PosY);
            }
        }
    }
}