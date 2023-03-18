// This script was made by me for remembering all that i've read from book
// and i was completing book's tasks there
// Book name : C# Player's Guide Fifth Edition
namespace book.part1.basics;

class Basics
{
    public static void basicsFunc()
    {
        Console.BackgroundColor = ConsoleColor.DarkGray;
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Title = "Basics";
        Console.Beep(2000, 250);

        Console.WriteLine("nerds im reading a book");
        Console.WriteLine("nerds are you oj gangs?????");
        Console.WriteLine("if yes, you are probably worst kids ever");
        Console.WriteLine("program can have infinity statements, isn't it?");
        Console.WriteLine("whacha name nerdie");
        var name = Console.ReadLine();
        Console.WriteLine("omg " + name);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    public static void Main(string[] args)
    {
        basicsFunc();
    }
}