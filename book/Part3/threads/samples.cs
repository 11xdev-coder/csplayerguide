namespace book.part3.threads.samples;

public class samples
{
    public static void Start()
    {
        // creating threads allows your program to do more than one thing at a  time:
        // Thread thread = new Thread(MethodName); thread.Start();
        // pass something to a thread:
        // thread.Start(ObjectName);
        // wait for a thread to finish:
        // thread.Join();

        void Count()
        {
            for (int index = 0; index < 25; index++)
                Console.WriteLine(index);
        }
        Thread thread = new Thread(Count);
        thread.Start();
        thread.Join();
        Console.WriteLine("Thread dun");
        
        Thread.Sleep(1000); // 1 second
    }
}