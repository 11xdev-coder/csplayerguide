namespace book.part3.dynamicObjects.uniterOfAdds;

public class uniterOfAdds
{
    public static void Start()
    {
        dynamic Add(dynamic a, dynamic b) => a + b;
        
        Console.WriteLine(Add(1, 2));
        Console.WriteLine(Add(1.1, 2.2));
        Console.WriteLine(Add("abc", "def"));
        Console.WriteLine(Add(DateTime.Now, TimeSpan.FromDays(1)));
    }
}