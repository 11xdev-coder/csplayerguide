namespace book.part1.looping;

class Looping
{
    public static void LoopingFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Looping";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 11");
        // The Prototype
        short numberToGuess;
        short guessedNumber;
        while (true)
        {
            Console.Write("User 1, enter number between 0 and 100: ");
            numberToGuess = Convert.ToInt16(Console.ReadLine());

            if (numberToGuess <= 0 || numberToGuess >= 100)
            {
                continue;
            }
            else
            {
                break;
            }
        }
        Console.Clear();
        Console.WriteLine("User 2, guess the number.");
        do
        {
            Console.Write("What is your next guess? ");
            guessedNumber = Convert.ToInt16(Console.ReadLine());
            if (guessedNumber > numberToGuess)
            {
                Console.WriteLine($"{guessedNumber} is too high");
                continue;
            }
            else if (guessedNumber == numberToGuess)
            {
                Console.WriteLine("Guessed. Good Job guys. You can go home");
                break;
            }
            else if (guessedNumber < numberToGuess)
            {
                Console.WriteLine($"{guessedNumber} is too low");
                continue;
            }
        } while (true);
        // The Magic Cannon
        short magicNumber;
        for (magicNumber = 0; magicNumber <= 100; magicNumber++)
        {
            if (magicNumber % 3 == 0 && magicNumber % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"{magicNumber}: Combined");
            }
            else if (magicNumber % 5 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{magicNumber}: Electric");
            }
            else if (magicNumber % 3 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{magicNumber}: Fire");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine($"{magicNumber}: Normal");
            }
        }
    }
}