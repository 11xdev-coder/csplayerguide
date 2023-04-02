namespace book.part2.FountainOfObjects.fountainOfObjects;

public class fountainOfObjects
{
    public static void Start()
    {
        Player player = new Player();
        ConsoleHelper.WriteLine("help for list of actions");
        player.Start();
        for (int i = 0; i < player.map.pitRooms.Count; i++)
        {
            ConsoleHelper.WriteLine($"Pit room {i} row={player.map.pitRooms[i].Row} column={player.map.pitRooms[i].Column}");
        }
        while (!player.HasWon & !player.HasLose)
        {
            player.CurrentRoomCheck();
            player.AskCommand();
        }
        
        if(player.HasWon) ConsoleHelper.WriteLine("Congrats! You won!");
        else ConsoleHelper.WriteLine("You lose! Better luck next time!");
    }
}



public class Player
{
    public byte Row { get; set; }
    public byte Column { get; set; }
    public bool IsFountainEnabled { get; set; }
    public bool HasWon { get; set; }
    public bool HasLose { get; set; }
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
            else ConsoleHelper.WriteLine("You are not in fountain room. Go find it!");
        }


        if (command == "disable fountain" & (Row == 0 & Column == 2))
        {
            if (Row == map.fountainRoom.Row & Column == map.fountainRoom.Column) IsFountainEnabled = false;
            else ConsoleHelper.WriteLine("You are not in fountain room. Go find it!");
        }

        if(command == "help") DisplayActions();
        
    }

    public void AskCommand()
    {
        if (!HasWon & !HasLose)
        {
            ConsoleHelper.WriteLine("-------------------------------------------------------");
            ConsoleHelper.WriteLine($"You are in the room at (Row={Row}, Column={Column})");
        }
        Sense();
        if (!HasWon & !HasLose)
        {
            Console.Write("What do you want to do? ");
            ExecuteCommand(Console.ReadLine());
        }
    }

    public void CurrentRoomCheck()
    {
        foreach (Room room in map.pitRooms)
        {
            if (room.Row == Row & room.Column == Column)
            {
                ConsoleHelper.Write("Whoa! You fell into ");
                ConsoleHelper.WriteLine("a bottomless pit! ", ConsoleColor.Yellow);
                HasLose = true;
            }
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
    
    public bool IsPitRoomNeighbouring()
    {
        foreach (Room room in map.pitRooms)
        {
            if ((room.Row == Row &  room.Column - 1 == Column) | (room.Row - 1 == Row & room.Column == Column) |
                (room.Row == Row &  room.Column + 1 == Column) | (room.Row + 1 == Row & room.Column == Column)) 
                return true;
        }
        
        return false;
    }

    public void Sense()
    {
        // entrance room checks
        if (IsInEntranceRoom() & !IsFountainEnabled)
        {
            ConsoleHelper.Write("You see ");
            ConsoleHelper.Write("light ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine("coming from the cavern entrance");
        }
        if (IsInEntranceRoom() & IsFountainEnabled)
        {
            ConsoleHelper.Write("The Fountain of Objects ", ConsoleColor.Cyan);
            ConsoleHelper.Write("has been reactivated, and you have ");
            ConsoleHelper.Write("escaped ", ConsoleColor.Yellow);
            ConsoleHelper.Write("with your ");
            ConsoleHelper.WriteLine("life!", ConsoleColor.Yellow);
            HasWon = true;
        }
        // fountain room checks
        if (IsInFountainRoom() & !IsFountainEnabled)
        {
            ConsoleHelper.Write("You hear ");
            ConsoleHelper.Write("water dripping ", ConsoleColor.Cyan);
            ConsoleHelper.Write("in this room. ");
            ConsoleHelper.Write("The Fountain of Objects ", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("is here!");
        }
        if (IsInFountainRoom() & IsFountainEnabled)
        {
            ConsoleHelper.Write("You hear ");
            ConsoleHelper.Write("the rushing waters ", ConsoleColor.Cyan);
            ConsoleHelper.Write("from ");
            ConsoleHelper.Write("The Fountain of Objects. ", ConsoleColor.Cyan);
            ConsoleHelper.WriteLine("It has been reactivated!");
        }
        // pit room check
        if (IsPitRoomNeighbouring())
        {
            ConsoleHelper.Write("You feel ");
            ConsoleHelper.Write("a draft. ", ConsoleColor.Yellow);
            ConsoleHelper.Write("There is ");
            ConsoleHelper.Write("a pit ");
            ConsoleHelper.WriteLine("in a nearby room.");
        }
    }

    public void DisplayActions()
    {
        ConsoleHelper.WriteLine("help - display this list");
        ConsoleHelper.WriteLine("move north - move -1 row");
        ConsoleHelper.WriteLine("move south - move 1 row");
        ConsoleHelper.WriteLine("move west - move -1 column");
        ConsoleHelper.WriteLine("move east - move 1 column");
        ConsoleHelper.WriteLine("enable fountain - enable fountain which is in special room");
        ConsoleHelper.WriteLine("disable fountain - disable fountain which is in special room");
    }
}

public class Map
{
    public byte RowLimit { get; set; }
    public byte ColumnLimit { get; set; }
    public string mapSize;
    public Room entranceRoom;
    public Room fountainRoom;
    public List<Room> pitRooms = new List<Room>();
    public Random rnd = new Random();

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
        // entrance room everytime generates at 0, 0
        entranceRoom = new Room(0, 0, RoomType.Entrance);
        if (mapSize == "small")
        {
            fountainRoom = new Room(0, 2, RoomType.Fountain);
            RowLimit = 3;
            ColumnLimit = 3;
            GeneratePitRoom();
        }
        if (mapSize == "medium")
        {
            fountainRoom = new Room(1, 3, RoomType.Fountain);
            RowLimit = 5;
            ColumnLimit = 5;
            GeneratePitRoom(); GeneratePitRoom();
        }
        if (mapSize == "large")
        {
            fountainRoom = new Room(2, 4, RoomType.Fountain);
            RowLimit = 7;
            ColumnLimit = 7;
            GeneratePitRoom(); GeneratePitRoom(); GeneratePitRoom();
        }
    }

    public void GeneratePitRoom()
    {
        // saving random coordinates
        byte requestedRow = Convert.ToByte(rnd.Next(0, RowLimit));
        byte requestedColumn = Convert.ToByte(rnd.Next(0, ColumnLimit));
        // checking if room is free
        if (IsRoomFree(requestedRow, requestedColumn))
            pitRooms.Add(new Room(requestedRow, requestedColumn, RoomType.Pit));
        // else trying again
        else
            GeneratePitRoom();
    }

    public bool IsRoomFree(byte Row, byte Column)
    {
        if ((entranceRoom.Row != Row | entranceRoom.Column != Column)
            & (fountainRoom.Row != Row | fountainRoom.Column != Column))
        {
            return true;
        }

        return false;
    }

   
}

public class ConsoleHelper
{
    public static void Write(string value, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.Write(value);
    }
    
    public static void WriteLine(string value, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(value);
    }
}

public record Room(byte Row, byte Column, RoomType Type);

public enum RoomType { Default, Entrance, Fountain, Pit }