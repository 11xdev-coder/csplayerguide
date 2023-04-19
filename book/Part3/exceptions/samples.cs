namespace book.part3.exceptions.samples;

public class samples
{
    public static void Start()
    {
        // handling exceptions
        string response = Console.ReadLine();
        int number;
        Exception a;
        try
        {
            number = Convert.ToInt32(response);
        }
        catch (Exception) // you can change Exception to any type of expetion (like FormatExeption or Overflow expeption)
        {
            number = -1;
            Console.WriteLine("Dont be dumb, please");
        }
        
        // using the exception object
        try
        {
            number = Convert.ToInt32(response);
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message); // printing error's message, pretty cool
        }
        
        // throw exception
        // throw new Exception();
        if (number == 6900)
        {
            a = new NotImplementedException();
            Console.WriteLine(a.Message);
        }
        
        // finally block
        // finally runs when we exit from try block or catch block
        
        
        // avoid throwing exceptions when possible!!!!
    }
}