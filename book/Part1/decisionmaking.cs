namespace book.part1.decisionmaking;

class decisionMaking
{
    public static void decisionMakingFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Decision making";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 9");

        // Repairing the Clocktower
        // Take a number as input from the console
        Console.Write("Enter number to make tick tock ");
        int tickTockNumber = Convert.ToInt32(Console.ReadLine());
        // Display the word "Tick" if number is even. Display work "Tock" if number is odd
        if (tickTockNumber % 2 == 0)
        {
            Console.WriteLine("Tick");
        }
        else
        {
            Console.WriteLine("Tock");
        }
        // and again cuz i like that
        Console.Write("Enter number to make tick tock ");
        tickTockNumber = Convert.ToInt32(Console.ReadLine());
        if (tickTockNumber % 2 == 0)
        {
            Console.WriteLine("Tick");
        }
        else
        {
            Console.WriteLine("Tock");
        }
        // Watchtower
        // Ask the user for an x value and a y value. These are coordinates of the enemy relative to the watchtower's location
        Console.Write("Enter x position of enemy ");
        int enemyX = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter y position of enemy ");
        int enemyY = Convert.ToInt32(Console.ReadLine());
        // Using if statements, and relational operators, display a message what about what direction the enemy is
        if (enemyY > 0 && enemyX < 0) Console.WriteLine("The enemy is to the north west!");
        if (enemyY > 0 && enemyX == 0) Console.WriteLine("The enemy is to the north!");
        if (enemyY > 0 && enemyX > 0) Console.WriteLine("The enemy is to the north east!");
        if (enemyY == 0 && enemyX < 0) Console.WriteLine("The enemy is to the west!");
        if (enemyY == 0 && enemyX == 0) Console.WriteLine("The enemy is here!");
        if (enemyY == 0 && enemyX > 0) Console.WriteLine("The enemy is to the east!");
        if (enemyY < 0 && enemyX < 0) Console.WriteLine("The enemy is to the south west!");
        if (enemyY < 0 && enemyX == 0) Console.WriteLine("The enemy is to the south!");
        if (enemyY < 0 && enemyX > 0) Console.WriteLine("The enemy is to the south east!");
    }
}