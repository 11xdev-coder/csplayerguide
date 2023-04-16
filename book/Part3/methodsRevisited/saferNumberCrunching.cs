namespace book.part3.methodsRevisited.saferNumberCrunching;

public class saferNumberCrunching
{
    public static void Start()
    {
        string stringValue;
        int intValue;
        double doubleValue;
        bool boolValue;
        while (true)
        {
            Console.Write("Enter int value: ");
            stringValue = Console.ReadLine();

            if (int.TryParse(stringValue, out intValue)) break;
        }
        Console.WriteLine(intValue);
        
        while (true)
        {
            Console.Write("Enter double value: ");
            stringValue = Console.ReadLine();

            if (double.TryParse(stringValue, out doubleValue)) break;
        }
        Console.WriteLine(doubleValue);
        
        while (true)
        {
            Console.Write("Enter bool value: ");
            stringValue = Console.ReadLine();

            if (bool.TryParse(stringValue, out boolValue)) break;
        }
        Console.WriteLine(boolValue);
    }
}