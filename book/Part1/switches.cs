namespace book.part1.switches;

class switches
{
    public static void switchesFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Switches";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 10");
        Console.Write("Gimme 1 or 2 nerdie ");
        int caseNumber = Convert.ToInt32(Console.ReadLine());
        // default  everyone knows that haha
        switch (caseNumber)
        {
            // case 1: and after it case 2: are like || operator in if statements
            case 1:
            case 2:
                Console.WriteLine("Nice haha");
                break;
            default:
                Console.WriteLine("u nerd wrng");
                break;
        }
        Console.Write("choice number between 1-4 ");
        // switch expression with writing data in variable
        int choice = Convert.ToInt32(Console.ReadLine());
        string response;
        response = choice switch
        {
            1 => "good number",
            2 => "nerd?",
            3 => "boomer?",
            4 => "oj gang?",
            _ => "u nerd i said between 1-4 u nerd nerd nerdie"
        };
        Console.WriteLine(response);
        
        Console.WriteLine("The following items are available:");
        Console.WriteLine("1 - Rope");
        Console.WriteLine("2 - Torches");
        Console.WriteLine("3 - Climbing Equipment");
        Console.WriteLine("4 - Clean Water");
        Console.WriteLine("5 - Machete");
        Console.WriteLine("6 - Canoe");
        Console.WriteLine("7 - Food Supplies");
        Console.Write("What number do you want to see the price of? ");
        
        int itemNumber = Convert.ToInt32(Console.ReadLine());

        string item = itemNumber switch
        {
            1 => "Rope",
            2 => "Torches",
            3 => "Climbing Equipment",
            4 => "Clean Water",
            5 => "Machete",
            6 => "Canoe",
            7 => "Food Supplies"
        };

        int price = item switch
        {
            "Rope" => 10,
            "Torches" => 15,
            "Climbing Equipment" => 25,
            "Clean Water" => 1,
            "Machete" => 20,
            "Canoe" => 200,
            "Food Supplies" => 1
        };

        Console.Write("What is your name? ");
        string name = Console.ReadLine();

        if (name == "Matvey") price /= 2;

        Console.WriteLine($"{item} costs {price} gold.");

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }
}