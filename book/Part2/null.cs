namespace book.part2.nullReferences;

public class nullReferences {
    public static void nullFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Null References";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 22");
        string name = Console.ReadLine()!;
        // string? indicates that this variable  can contain string or contain null value
        // ? mark after every varibale type or function that returns value indicates that there is auto-null check
        // ?? (null coalescing operator) checks if value is null, if its null then sets varibale to value
        name ??= "null fallback";
        // ! is an "forgiving" operator
        Console.Write(name);
    }
}