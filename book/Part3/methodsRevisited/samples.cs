namespace book.part3.methodsRevisited.samples;

public class samples
{
    public static void Start()
    {
        // optional arguments
        Random _random = new Random();
        int RoolDie(int sides = 6) => _random.Next(sides) + 1;
        
        Console.WriteLine(RoolDie()); // default value of 6
        Console.WriteLine(RoolDie(20)); // 20 instead of default value 6
        
        // named arguments
        Math.Clamp(min: 50, max: 100, value: 20); 
        
        // variable number of parameters
        static double Average(params int[] numbers)
        {
            double total = 0;

            foreach (double number in numbers)
                total += number;

            return total / numbers.Length;
        }
        // if no params keyword then calling this method would be uglier
        // Average(new int[] {2, 3}) vs Average(2, 3)
        Console.WriteLine(Average(2, 3));
        
        // output parameters
        void Number(out int variable) => variable = 10;
        
        // practically same as return
        int x;
        Number(out x);
        Console.WriteLine(x);

        
    }
}

public static class blabla
{
    public static void SomeFunc(this string text)
    {
        // this is an extension method
        // bla bla bla
    }
}