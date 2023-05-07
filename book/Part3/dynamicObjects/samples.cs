using System.Dynamic;

namespace book.part3.dynamicObjects.samples;

public class samples
{
    public static void Start()
    {
        dynamic mystery = "Hello";
        Console.WriteLine(mystery);
        mystery = 2; // dynamic can change their types
        mystery += 2;
        Console.WriteLine(mystery);
        
        // emulating dynamic objects with dictionaries
        Dictionary<string, object> flexible = new Dictionary<string, object>();
        flexible["Name"] = "Bob"; // assigning a name
        flexible["Age"] = 6; // age
        flexible["HaveABirthday"] = new Action(() => flexible["Age"] = (int)flexible["Age"] + 1); // creating HaveABirthday method
        
        // expando
        dynamic expando = new ExpandoObject();
        expando.Name = "Bob";
        expando.Age = 6;
        expando.HaveABirthday = new Action(() => expando.Age++);

        expando.HaveABirthday(); // much cleaner
    }
}