namespace book.part3.threads.theRepeatingStream;

public class theRepeatingStream
{
    public static void Start()
    {
        void StartNumbersGen(RecentNumbers? obj)
        {
            if (obj == null || obj is not RecentNumbers) return;
            
            RecentNumbers recentNumbers = (RecentNumbers)obj;
            Random random = new Random();
            while (true)
            {
                int nextNumber = random.Next(10);

                lock (recentNumbers)
                {
                    recentNumbers.recentNumber2 = recentNumbers.recentNumber1;
                    recentNumbers.recentNumber1 = nextNumber;
                }

                Console.WriteLine($"Number Generated: {nextNumber}");
                Thread.Sleep(1000);
            }
        }

        RecentNumbers recentNumbers = new RecentNumbers() { recentNumber1 = -1, recentNumber2 = -2 };
        Thread generatingThread = new Thread(() => StartNumbersGen(recentNumbers));
        generatingThread.Start();
        
        while (true)
        {
            Console.ReadKey(false);

            bool isDuplicate;
            lock(recentNumbers)
                isDuplicate = recentNumbers.recentNumber1 == recentNumbers.recentNumber2;
    
            if(isDuplicate) Console.WriteLine("You found a duplicate!");
            else Console.WriteLine("That is not a duplicate.");
        }
    }
}

public class RecentNumbers
{
    public int recentNumber1 { get; set; }
    public int recentNumber2 { get; set; }
}