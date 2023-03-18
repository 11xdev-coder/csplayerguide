namespace book.part1.console2;

class console2
{
    public static void console2Func()
    {
        int userTotalScore = Int32.MaxValue;
        double avogadrosNumber = 6.022e23;
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Console 2.0";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 8");

        Console.Write("This text won't jump to next line when it ends");
        Console.WriteLine("haha double quote \"");
        Console.WriteLine(@"haha some symbols $@#%@#%(*$@&^&@$*&%@$%@||%@$|@|$%""""""""""""""\\\");
        Console.WriteLine($"avogadros number is {avogadrosNumber}");
        Console.WriteLine($"some allign {userTotalScore,40}");
        Console.WriteLine($"some pi but scuffed {Math.PI:0.00}");
        Console.WriteLine($"some var but with procents {Math.PI:0.00%}");
        // The Defense of Consolas
        // Change the window title to "Defense of Consolas
        Console.Title = "Defense of Consolas";
        // Ask the user for the target row and column
        Console.Write("Target Row? ");
        int row = Convert.ToInt32(Console.ReadLine());
        Console.Write("Target Column? ");
        int column = Convert.ToInt32(Console.ReadLine());
        // Compute the neightboring rows and columns of where to deploy the squad
        // Display the deployment instructions in a different color of your choosing
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Deploy to:");
        Console.WriteLine($"({row}, {column - 1})");
        Console.WriteLine($"({row - 1}, {column})");
        Console.WriteLine($"({row}, {column + 1})");
        Console.WriteLine($"({row + 1}, {column})");
        // Play a sound with Console.Beep when the results have been computed and displayed
        Console.Beep(2000, 250);
    }
}