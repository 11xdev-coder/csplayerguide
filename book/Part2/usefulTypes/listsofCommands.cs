namespace book.part2.usefulTypes.listOfCommands;

public class listsofCommands
{
    public static void startFunc()
    {
        Robot robot = new Robot();
        Main main = new Main();

        IRobotCommand input;
        Console.WriteLine("Enter commands for robot to execute (stop to exit)");
        while (true)
        {
            input = main.CommandsInput();
            if (input == null) break;
            robot.Commands.Add(input);
        }
        
        robot.Run();
        Console.ReadKey();
    }
}

public class Main
{
    private string input { get; set; }
    public IRobotCommand CommandsInput()
    {
        input = Console.ReadLine();
        if(input != "stop") return GetCommandByInput(input);

        return null;
    }

    public IRobotCommand GetCommandByInput(string input)
    {
        IRobotCommand command = input switch
        {
            "on" => new OnCommand(),
            "off" => new OffCommand(),
            "north" => new NorthCommand(),
            "west" => new WestCommand(),
            "east" => new EastCommand(),
            "south" => new SouthCommand(),
        };

        return command;
    }
}

public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    void Run(Robot robot);
}

public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y -= 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X -= 1;
    }
}

public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X += 1;
    }
}