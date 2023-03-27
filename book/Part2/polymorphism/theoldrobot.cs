namespace book.part2.polymorphism.theoldrobot;

public class theoldrobot
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
    public RobotCommand CommandsInput() => GetCommandByInput(Console.ReadLine());

    public RobotCommand GetCommandByInput(string input)
    {
        RobotCommand command = input switch
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
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

public class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

public class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.Y -= 1;
    }
}

public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X -= 1;
    }
}

public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if(robot.IsPowered) robot.X += 1;
    }
}