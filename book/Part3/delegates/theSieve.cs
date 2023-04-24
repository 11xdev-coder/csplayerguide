namespace book.part3.delegates.theSieve;

public class theSieve
{
    public static void Start()
    {
        Sieve sieve = new Sieve();
        string userInput;
        int userNumber;

        while (true)
        {
            Console.WriteLine("Enter filter(Even, Positive, Multiplies 10)");
            userInput = Console.ReadLine();

            if (userInput == "Even")
            {
                sieve.filter = FilterType.Even;
                break;
            }
            else if (userInput == "Positive")
            {
                sieve.filter = FilterType.Positive;
                break;
            }
            else if (userInput == "Multiplies 10")
            {
                sieve.filter = FilterType.Multiplies10;
                break;
            }
            else continue;
        }
        
        while (true)
        {
            Console.WriteLine("Enter da number");
            userInput = Console.ReadLine();
            if (!int.TryParse(userInput, out userNumber))
            {
                Console.WriteLine("Cannot parse user input");
                continue;
            }
            
            Console.WriteLine(sieve.IsGood(userNumber));
        }
    }
}

public class Sieve
{
    public FilterType filter { get; set; }

    public bool IsGood(int number)
    {
        if (filter == FilterType.Even)
            if (number % 2 == 0)
                return true;
        
        if (filter == FilterType.Positive)
            if (number > 0)
                return true;
        
        if (filter == FilterType.Multiplies10)
            if (number % 10 == 0)
                return true;

        return false;
    }
}

public enum FilterType { Even, Positive, Multiplies10 }