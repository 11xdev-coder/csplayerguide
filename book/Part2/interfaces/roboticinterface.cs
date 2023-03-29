namespace book.part2.interfaces.roboticinterface;

public class roboticinterface
{
    public static void startFunc()
    {
        Robot robot = new Robot();
        Main main = new Main();
        
        Console.WriteLine("Enter 3 commands for robot to execute");
        for (int index = 0; index < robot.Commands.Length; index++)
        {
            robot.Commands[index] = main.CommandsInput();
        }
        
        robot.Run();
    }
}

public class Main
{
    public IRobotCommand CommandsInput() => GetCommandByInput(Console.ReadLine());

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
    public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];

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