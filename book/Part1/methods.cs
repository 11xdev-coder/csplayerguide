namespace book.part1.methods;

class Methods
{
    public static void MethodsFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Methods";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 13");
        // Taking a number
        int result = AskForNumber("some smort text");
        
        int AskForNumber(string text)
        {
            Console.Write($"{text} ");
            int number = Convert.ToInt32(Console.ReadLine());
            return number;
        }

        int AskForNumberInRange(string text, int min, int max)
        {
            while (true)
            {
                int number = AskForNumber(text);
                if (number >= min && number <= max)
                    return number;
            }
        }

        result = AskForNumberInRange("some smort text again but enter number in range of 3 and 5", 3, 5);
        
        // Countdown
        void CountDown(int countTo, int min)
        {
            Console.WriteLine(countTo);
            if (countTo > min) CountDown(countTo - 1, min);
        }
        
        CountDown(10, 1);
    }
}