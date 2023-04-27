using System.Globalization;

namespace book.part3.lambdas.samples;

public class samples
{
    public static int Count(int[] input, Func<int, bool> countFunction)
    {
        int count = 0;

        foreach (int number in input)
            if (countFunction(number))
                count++;

        return count;
    }
    
    public static void Start()
    {
        // basic sample how lambdas work
        // they are basically small functions
        // in parantheses () you write arguments
        // in {} you write function code
        // then you can call it by its name
        var hello = () => { Console.WriteLine("hello"); };
        hello();
        var sum = (int x, int y) => { Console.WriteLine($"{x} + {y} = {x + y}"); };
        sum(1, 2);

        int[] numbers = new[] {2, 3, 4, 5};
        int count = Count(numbers, n => n % 2 == 0); // mini function that defines number is even or no
        Console.WriteLine(count);
    }
}