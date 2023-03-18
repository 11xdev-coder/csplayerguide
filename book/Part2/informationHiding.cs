namespace book.part2.informationHiding;

class InfoHiding
{
    public static void InfoHidingFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Information Hiding";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 19");
        // replace public with private
        // look level 18(classes)
    }
}