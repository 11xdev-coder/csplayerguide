namespace book.part2.usefulTypes.usefulTypes;

public class usefulTypes
{
    public static void Start()
    {
        /*
         Random generates random numbers
         DateTime gets the current time and stores time and date values
         TimeSpan represents a span of time
         Guid stores globally unique identifier
         List<T> generic collection more useful than arrays
         IEnumerable<T> is an interface for almost any collection type
         Dictionary<TKey, TValue> can look up one piece of information from another
         Nullable<T> is a struct that can express the concept of a missing value for value types
         ValueTuple is secret sauce behind tuples
         StringBuilder is a less memory-intensive way to build strings
         */

        Random random = new Random();
        Console.WriteLine(random.Next(6)); // 0, 1, 2, 3, 4, or 5, but not 6

        DateTime time1 = new DateTime(2022, 12, 31); // 31-Dec-22 00:00:00
        DateTime time2 = new DateTime(2022, 12, 31, 23, 59, 55); // 31-Dec-22 23:59:55
        Console.WriteLine(time1);
        Console.WriteLine(time2);
        
        DateTime timeLocal = DateTime.Now; // local time zone time
        DateTime timeUTC = DateTime.UtcNow; // time in Coordinated Universal Time
        Console.WriteLine(timeLocal);
        Console.WriteLine(timeUTC);

        TimeSpan timeLeft = new TimeSpan(1, 30, 0);
        Console.WriteLine(timeLeft);
    }
}