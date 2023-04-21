namespace book.part3.exceptions.exeptisGame;

public class exeptisGame
{
    public static void Start()
    {
        Random _random = new Random();
        int initialNumber = _random.Next(0, 10); // between 0 and 9
        int userNumber;
        List<int> usedNumbers = new List<int>();
        
        while (true)
        {
            Console.WriteLine("Pick a number between 0 and 9");
            try
            {
                userNumber = Convert.ToInt32(Console.ReadLine());
                if (userNumber >= 0 & userNumber <= 9)
                {
                    if (!usedNumbers.Contains(userNumber))
                    {
                        if (userNumber == initialNumber) break;
                    }
                    else Console.WriteLine("That number was already inputed");
                    
                    usedNumbers.Add(userNumber);
                }
                else Console.WriteLine("Number wasnt in range");
            }
            catch
            {
                continue;
            }
        }
        
        Console.Write("Used Numbers: ");
        foreach (int number in usedNumbers)
        {
            Console.Write($"{number} ");
        }
    }
}