namespace book.part3.methodsRevisited.betterRandom;

public class betterRandom
{
    public static void Start()
    {
        Random _rand = new Random();
        
        Console.WriteLine(_rand.NextDouble(23.3));
        Console.WriteLine(_rand.RandomString("up", "down", "left", "right"));
        Console.WriteLine(_rand.CoinFlip());
        Console.WriteLine(_rand.CoinFlip(0.75));
    }
}

public static class RandomExtension
{
    public static double NextDouble(this Random _random, double maxNumber) =>
        _random.NextDouble() * maxNumber;

    public static string RandomString(this Random _random, params string[] strings) =>
        strings[_random.Next(strings.Length)];

    public static bool CoinFlip(this Random _random, double winChance = 0.5) => _random.NextDouble() < winChance;
}