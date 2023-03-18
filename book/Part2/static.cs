namespace book.part2.statics;

class Static
{
    public static void StaticFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Static";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 21");
        // modify arrow class so you can choose arrow styles
    }
}