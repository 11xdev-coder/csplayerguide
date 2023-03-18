namespace book.part1.math;

class math
{
    public static void mathFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Math";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 7");

        // The triangle farmer
        // Write a program that lets you input the triangle's base size and height
        Console.WriteLine("Base size:");
        var baseSize = Console.ReadLine();
        Console.WriteLine("Height:");
        var height = Console.ReadLine();
        // Compute the area of triangle by turning the above equation into code
        // area = baseSize * height / 2
        double triangleArea = Convert.ToDouble(baseSize) * Convert.ToDouble(height) / 2f;
        // Write the result of the computation
        Console.WriteLine("Triangle's area is: " + triangleArea);
        // The four sisters and the duckbear
        // Create a program that lets the user enter the number of chocolate eggs gathered that day
        Console.WriteLine("Enter number of chocolate eggs gathered: ");
        int chocolateEggs = Convert.ToInt32(Console.ReadLine());
        // Using / and %, compute how many eggs each sister should get and how many are left over for the duckbear
        int forSisters = chocolateEggs / 4;
        int forDuckBear = chocolateEggs % 4;
        Console.WriteLine("Each sister get: " + forSisters + "\nDuckbear gets: " + forDuckBear);
        // The Dominion of Kings
        // Create a program that allows users to enter how many provinces, duchies, and estates they have
        Console.WriteLine("How many provinces will kings have?");
        int provinces = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many duchies will kings have?");
        int duchies = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("How many estates will kings have?");
        int estates = Convert.ToInt32(Console.ReadLine());
        // Add up the user's total score, giving 1 point per estate, 3 per duchy, and 6 per province
        int userTotalScore = estates + duchies * 3 + provinces * 6;
        // Display the point total to user
        Console.WriteLine("Your score is: " + userTotalScore);
        // Math.Pow(x, 2) is same as x * x
        // Math.Pow(x, 6) is same as x * x * x * x * x * x and etc.
        // Math.Abs(2) is 2
        // Math.Abs(-2) is 2
        // Math.Sqrt() makes square root (корень) 
        // Math.Min(0, 2) - return minimum number of 2
        // Math.Max(0, 2) - return maximum number of 2
        // Math.Clamp(var, 0, 100) - make variable in provided range
        // Math class is for doubles
        // MathF class is like Math, but for floats
    }
}