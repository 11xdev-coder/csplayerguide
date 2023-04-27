namespace book.part3.lambdas.theLambdaSieve;

public class theLambdaSieve
{
    
    
    public static void Start()
    {
        string userInput;
        int userNumber;
        Sieve sieve;

        while (true)
        {
            Console.WriteLine("Enter filter(1 = Even, 2 = Positive, 3 = MultipleOfTen)");
            userInput = Console.ReadLine();
            try
            {
                sieve = userInput switch
                {
                    "1" => new Sieve(IsEven),
                    "2" => new Sieve(IsPositive),
                    "3" => new Sieve(MultipleOfTen)
                };
            }
            catch
            {
                continue;
            }

            break;
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
        
        bool IsEven(int number) => number % 2 == 0;
        bool IsPositive(int number) => number >= 0;
        bool MultipleOfTen(int number) => number % 10 == 0;
    }
}

public class Sieve
{
    private Func<int, bool> _desicionFunc;

    public Sieve(Func<int, bool> _desicionFunc)
    {
        this._desicionFunc = _desicionFunc;
    }

    public bool IsGood(int number) => _desicionFunc(number);
}