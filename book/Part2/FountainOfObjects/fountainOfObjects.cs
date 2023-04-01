namespace book.part2.FountainOfObjects.fountainOfObjects;

public class fountainOfObjects
{
    public static void Start()
    {
        Player player = new Player();
        Console.WriteLine("help for list of actions");
        player.Start();
        while (!player.HasWon)
        {
            player.AskCommand();
        }
        
        Console.WriteLine("Congrats! You won!");
    }
}



public class Player
{
    public byte Row { get; set; }
    public byte Column { get; set; }
    public bool IsFountainEnabled { get; set; }
    public bool HasWon { get; set; }
    public Map map;

    public Player()
    {
        this.map = new Map();
        this.Row = 0;
        this.Column = 0;
        this.IsFountainEnabled = false;
    }

    public void Start()
    {
        map.AskForSize();
        map.GenerateRooms();
    }

    public void ExecuteCommand(string command)
    {
        if (command == "move north")
            if(Row > 0) Row -= 1;
            
        if (command == "move south")
            if(Row < map.RowLimit) Row += 1;
            
        if (command == "move west") 
            if(Column > 0) Column -= 1;
                
        if (command == "move east")
            if(Column < map.ColumnLimit) Column += 1;

        if (command == "enable fountain")
        {
            if(Row == map.fountainRoom.Row & Column == map.fountainRoom.Column) IsFountainEnabled = true;
            else Console.WriteLine("You are not in fountain room. Go find it!");
        }


        if (command == "disable fountain" & (Row == 0 & Column == 2))
        {
            if (Row == map.fountainRoom.Row & Column == map.fountainRoom.Column) IsFountainEnabled = false;
            else Console.WriteLine("You are not in fountain room. Go find it!");
        }

        if(command == "help") DisplayActions();
        
    }

    public void AskCommand()
    {
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row={Row}, Column={Column})");
        Sense();
        if (!HasWon)
        {
            Console.Write("What do you want to do? ");
            ExecuteCommand(Console.ReadLine());
        }
        
    }

    public bool IsInEntranceRoom()
    {
        if (Row == map.entranceRoom.Row & Column == map.entranceRoom.Column) return true;
        else return false;
    }

    public bool IsInFountainRoom()
    {
        if (Row == map.fountainRoom.Row & Column == map.fountainRoom.Column) return true;
        else return false;
    }

    public void Sense()
    {
        if (IsInEntranceRoom() & !IsFountainEnabled)
        {
            Console.Write("You see ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("light ");
            Console.ResetColor();
            Console.WriteLine("coming from the cavern entrance");
        }
        
        if (IsInEntranceRoom() & IsFountainEnabled)
        {
            Console.Write("The Fountain of Objects ", ConsoleColor.Cyan);
            Console.Write("has been reactivated, and you have ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("escaped ");
            Console.ResetColor();
            Console.Write("with your ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("life!");
            HasWon = true;
        }

        if (IsInFountainRoom() & !IsFountainEnabled)
        {
            Console.Write("You hear ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("water dripping ");
            Console.ResetColor();
            Console.Write("in this room. ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("The Fountain of Objects ");
            Console.ResetColor();
            Console.WriteLine("is here!");
        }
        
        if (IsInFountainRoom() & IsFountainEnabled)
        {
            Console.Write("You hear ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("the rushing waters ");
            Console.ResetColor();
            Console.Write("from ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("The Fountain of Objects. ");
            Console.ResetColor();
            Console.WriteLine("It has been reactivated!");
        }
    }

    public void DisplayActions()
    {
        Console.WriteLine("help - display this list");
        Console.WriteLine("move north - move -1 row");
        Console.WriteLine("move south - move 1 row");
        Console.WriteLine("move west - move -1 column");
        Console.WriteLine("move east - move 1 column");
        Console.WriteLine("enable fountain - enable fountain which is in special room");
        Console.WriteLine("disable fountain - disable fountain which is in special room");
    }
}

public class Map
{
    public byte RowLimit { get; set; }
    public byte ColumnLimit { get; set; }
    public string mapSize;
    public Room entranceRoom;
    public Room fountainRoom;

    public void AskForSize()
    {
        while (true)
        {
            Console.Write("Enter the map size (small, medium, large): ");
            mapSize = Console.ReadLine();
            if (mapSize == "small" | mapSize == "medium" | mapSize == "large") break;
        }
    }
    
    public void GenerateRooms()
    {
        entranceRoom = new Room(0, 0, RoomType.Entrance);
        if (mapSize == "small")
        {
            fountainRoom = new Room(0, 2, RoomType.Fountain);
            RowLimit = 3;
            ColumnLimit = 3;
        }
        if (mapSize == "medium")
        {
            fountainRoom = new Room(1, 3, RoomType.Fountain);
            RowLimit = 5;
            ColumnLimit = 5;
        }
        if (mapSize == "large")
        {
            fountainRoom = new Room(2, 4, RoomType.Fountain);
            RowLimit = 7;
            ColumnLimit = 7;
        }
    }
}

public class Room
{
    public byte Row { get; set; }
    public byte Column { get; set; }
    public RoomType Type { get; set; }

    public Room(byte Row, byte Column, RoomType Type)
    {
        this.Row = Row;
        this.Column = Column;
        this.Type = Type;
    }
}

public enum RoomType { Default, Entrance, Fountain }