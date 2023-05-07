using System.Dynamic;

namespace book.part3.dynamicObjects.theRobotFactory;

public class theRobotFactory
{
    public static void Start()
    {
        dynamic robot = new ExpandoObject();
        robot.ID = 1;
        while (true)
        {
            Console.WriteLine($"You are producing robot #{robot.ID}");
            // name
            Console.WriteLine("Would you like to name this robot?");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("What is its name?");
                robot.Name = Console.ReadLine();
            }
            // size
            Console.WriteLine("Does this robot have a specific size?");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Width?");
                robot.Width = Console.ReadLine();
                Console.WriteLine("Height?");
                robot.Height = Console.ReadLine();
            }
            // color
            Console.WriteLine("Does this robot need to be a specific color?");
            if (Console.ReadLine() == "yes")
            {
                Console.WriteLine("Color?");
                robot.Color = Console.ReadLine();
            }
            
            foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
                Console.WriteLine($"{property.Key}: {property.Value}");

            robot.ID++;
        }
        
    }
}