namespace book.part3.asyncProgramming.samples;

public class samples
{
    public static void Start()
    {
        void AddOnEurope(int a, int b, Action<int> callback)
        {
            Thread thread = new Thread(() =>
            {
                Thread.Sleep(3000);
                int result = a + b;
                callback(result);
            });
            thread.Start();
        }

        AddOnEurope(2, 3, result => Console.WriteLine(result)); // callback
    }
}