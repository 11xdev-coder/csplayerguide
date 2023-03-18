namespace book.part1.arrays;

class Arrays
{
    public static void ArraysFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Arrays";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 12");
        // The Replicator of D'To
        // asking numbers
        int[] numberArray = new int[5];
        Console.Write("1st number to put in array? ");
        numberArray[0] = Convert.ToInt32(Console.ReadLine());
        Console.Write("2nd number to put in array? ");
        numberArray[1] = Convert.ToInt32(Console.ReadLine());
        Console.Write("3rd number to put in array? ");
        numberArray[2] = Convert.ToInt32(Console.ReadLine());
        Console.Write("4th number to put in array? ");
        numberArray[3] = Convert.ToInt32(Console.ReadLine());
        Console.Write("5th number to put in array? ");
        numberArray[4] = Convert.ToInt32(Console.ReadLine());
        // copying
        int[] replicatedArray = new int[5];
        for (int i = 0; i < numberArray.Length; i++)
            replicatedArray[i] = numberArray[i];
        
        // loops to print numbers
        foreach (int number in numberArray)
            Console.Write($"{number} ");
        
        Console.WriteLine("- original array");
        foreach (int number in replicatedArray)
            Console.Write($"{number} ");
        
        Console.WriteLine("- replicated array");
        // The Laws of Freach
        // modify code from book and use foreach loops instead of for
        int[] array = new [] {4, 51, -7, 13, -99, 15, -8, 45, 90};
        int currentMinimum = int.MaxValue; // Start higher than anything in the array. 

        foreach(int value in array)
        {
            if (value < currentMinimum)
                currentMinimum = value;
        }

        Console.WriteLine($"{currentMinimum} - smallest number from array");

        int total = 0;
        foreach (int value in array)
        {
            total += value;
        }
        float average = (float) total / array.Length;
        Console.WriteLine($"{average} - average of all numbers in array");
    }
}