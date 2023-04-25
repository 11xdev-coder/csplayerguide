using book.part2.records.records;

namespace book.part3.events.samples;

public class samples
{
    public static void Start()
    {
        
    }
}

public class Ship
{
    // defining an event
    public event Action? shipExploded;
    
    // evemts with parameters
    public event Action<Point>? shipExplodedWithLocation;
    
    public int Health { get; set; }
    public Point Location { get; set; } = new Point(0, 0);

    public void TakeDamage(int amount)
    {
        Health -= amount;
        // call an event
        if (Health <= 0)
        {
            shipExploded(); // or shipExploded.Invoke();
            shipExplodedWithLocation(Location);
            
            // null events
            shipExploded?.Invoke();
        }
        
    }
}

public class SoundEffectManager
{
    public SoundEffectManager(Ship ship)
    {
        ship.shipExplodedWithLocation += OnShipExplode; // this attaches or subscribes the OnShipExplode method to the event
        // unsubscribing or detaching is like this:
        // ship.shipExploded -= OnShipExplode;
    }
    
    public void OnShipExplode(Point location) => PlaySound("Explosion", CalculateVolume(location));

    public float CalculateVolume(Point location) => (location.x + location.y) / 2;
    public void PlaySound(string name, float volume) { Console.WriteLine(name); }
}