namespace book.part2.usefulTypes.timeInCavern;

public class timeInCavern
{
    public static void Start()
    {
        Player player = new Player();
        ConsoleHelper.WriteLine("help for list of actions");
        player.Start();
        DateTime timeStarted = DateTime.Now;
        while (!player.HasWon & !player.HasLose)
        {
            player.CurrentRoomCheck();
            player.AskCommand();
        }
        
        if(player.HasWon) ConsoleHelper.WriteLine("Congrats! You won!");
        else ConsoleHelper.WriteLine("You lose! Better luck next time!");
        
        DateTime timeEnded = DateTime.Now;
        TimeSpan timeSpent = timeEnded - timeStarted;
        ConsoleHelper.WriteLine($"Time spent: {timeSpent.Hours}h {timeSpent.Minutes}min {timeSpent.Seconds}sec");
    }
}

public class Player
{
    public byte Row { get; set; }
    public byte Column { get; set; }
    public bool IsFountainEnabled { get; set; }
    public bool HasWon { get; set; }
    public bool HasLose { get; set; }
    public byte ArrowCount { get; set; }
    public Map map;

    public Player()
    {
        this.map = new Map();
        this.Row = 0;
        this.Column = 0;
        this.IsFountainEnabled = false;
        this.ArrowCount = 5;
    }

    public void Start()
    {
        map.AskForSize();
        map.GenerateRooms();
    }

    #region Command thingies

    public void ExecuteCommand(string command)
    {
        if (command == "move north") if(Row > 0) Row -= 1;
            
        if (command == "move south") if(Row < map.RowLimit) Row += 1;
            
        if (command == "move west") if(Column > 0) Column -= 1;
                
        if (command == "move east") if(Column < map.ColumnLimit) Column += 1;
        
        if(command == "shoot north") Shoot("north");
        
        if(command == "shoot south") Shoot("south");
        
        if(command == "shoot west") Shoot("west");
        
        if(command == "shoot east") Shoot("east");

        if (command == "enable fountain")
        {
            if(IsInFountainRoom()) IsFountainEnabled = true;
            else ConsoleHelper.WriteLine("You are not in fountain room. Go find it!");
        }

        if (command == "disable fountain" & (Row == 0 & Column == 2))
        {
            if (IsInFountainRoom()) IsFountainEnabled = false;
            else ConsoleHelper.WriteLine("You are not in fountain room. Go find it!");
        }

        if(command == "help") About();
        
    }

    public void AskCommand()
    {
        if (!HasWon & !HasLose)
        {
            ConsoleHelper.WriteLine("-------------------------------------------------------");
            ConsoleHelper.WriteLine($"You are in the room at (Row={Row}, Column={Column})");
            ConsoleHelper.WriteLine($"You have {ArrowCount} arrows");
        }
        Sense();
        if (!HasWon & !HasLose)
        {
            Console.Write("What do you want to do? ");
            ExecuteCommand(Console.ReadLine());
        }
    }
    #endregion

    #region room checks
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

        foreach (Room room in map.maelstormRooms)
        {
            if (room.Row == Row & room.Column == Column)
            {
                ConsoleHelper.Write("Whoosh!! You've been ");
                ConsoleHelper.Write("swept ", ConsoleColor.Yellow);
                ConsoleHelper.WriteLine("into another room!(-1 row and +2 column)");
                Whoosh();
            }
        }
        
        foreach (Room room in map.amarokRooms)
        {
            if (room.Row == Row & room.Column == Column)
            {
                ConsoleHelper.Write("Nom nom nom! You were eaten by ");
                ConsoleHelper.WriteLine("an amarok!", ConsoleColor.Yellow);
                HasLose = true;
            }
        }
    }
    #endregion
    
    public void Whoosh()
    {
        if(Row > 0) Row -= 1;
        if(Column < map.ColumnLimit - 1) Column += 2;
    }

    public void Shoot(string Direction)
    {
        if (Direction == "north")
        {
            foreach (Room room in map.amarokRooms.ToList())
            {
                if (room.Row == Row - 1)
                    map.amarokRooms.Remove(room);
            }
        }
        if (Direction == "south")
        {
            foreach (Room room in map.amarokRooms.ToList())
            {
                if (room.Row == Row + 1)
                    map.amarokRooms.Remove(room);
            }
        }
        if (Direction == "west")
        {
            foreach (Room room in map.amarokRooms.ToList())
            {
                if (room.Column == Column - 1)
                    map.amarokRooms.Remove(room);
            }
        }
        if (Direction == "east")
        {
            foreach (Room room in map.amarokRooms.ToList())
            {
                if (room.Column == Column + 1)
                    map.amarokRooms.Remove(room);
            }
        }
        ArrowCount -= 1;
    }
    
    #region position checks
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
    #endregion
    
    #region Neighbouring checks
    
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
    
    public bool IsMaelstormRoomNeighbouring()
    {
        foreach (Room room in map.maelstormRooms)
        {
            if ((room.Row == Row &  room.Column - 1 == Column) | (room.Row - 1 == Row & room.Column == Column) |
                (room.Row == Row &  room.Column + 1 == Column) | (room.Row + 1 == Row & room.Column == Column)) 
                return true;
        }
        
        return false;
    }
    
    public bool IsAmarokRoomNeighbouring()
    {
        foreach (Room room in map.amarokRooms)
        {
            if ((room.Row == Row &  room.Column - 1 == Column) | (room.Row - 1 == Row & room.Column == Column) |
                (room.Row == Row &  room.Column + 1 == Column) | (room.Row + 1 == Row & room.Column == Column)) 
                return true;
        }
        
        return false;
    }
    #endregion

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
            ConsoleHelper.Write("a pit ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine("in a nearby room.");
        }
        if (IsMaelstormRoomNeighbouring())
        {
            ConsoleHelper.Write("You hear ");
            ConsoleHelper.Write("the growling ", ConsoleColor.Yellow);
            ConsoleHelper.Write("and ");
            ConsoleHelper.Write("groaning ", ConsoleColor.Yellow);
            ConsoleHelper.Write("of a ");
            ConsoleHelper.Write("maelstorm  ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine("nearby.");
        }
        if (IsAmarokRoomNeighbouring())
        {
            ConsoleHelper.Write("You can smell ");
            ConsoleHelper.Write("the rotten stench ", ConsoleColor.Yellow);
            ConsoleHelper.Write("of an ");
            ConsoleHelper.Write("amarok ", ConsoleColor.Yellow);
            ConsoleHelper.WriteLine("in a nearby room ");
        }
    }

    public void About()
    {
        ConsoleHelper.WriteLine("help - display this list");
        ConsoleHelper.WriteLine("move north - move -1 row");
        ConsoleHelper.WriteLine("move south - move 1 row");
        ConsoleHelper.WriteLine("move west - move -1 column");
        ConsoleHelper.WriteLine("move east - move 1 column");
        ConsoleHelper.WriteLine("enable fountain - enable fountain which is in special room");
        ConsoleHelper.WriteLine("disable fountain - disable fountain which is in special room");
        ConsoleHelper.WriteLine("shoot north/south/west/east - shoots an arrow into a room in entered direction, kills amarok");
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
    public List<Room> maelstormRooms = new List<Room>();
    public List<Room> amarokRooms = new List<Room>();
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
            GenerateMaelstormRoom();
            GenerateAmarokRoom();
        }
        if (mapSize == "medium")
        {
            fountainRoom = new Room(1, 3, RoomType.Fountain);
            RowLimit = 5;
            ColumnLimit = 5;
            GeneratePitRoom(); GeneratePitRoom();
            GenerateMaelstormRoom(); GenerateMaelstormRoom();
            GenerateAmarokRoom(); GenerateAmarokRoom();
        }
        if (mapSize == "large")
        {
            fountainRoom = new Room(2, 4, RoomType.Fountain);
            RowLimit = 7;
            ColumnLimit = 7;
            GeneratePitRoom(); GeneratePitRoom(); GeneratePitRoom();
            GenerateMaelstormRoom(); GenerateMaelstormRoom(); GenerateMaelstormRoom();
            GenerateAmarokRoom(); GenerateAmarokRoom(); GenerateAmarokRoom();
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

    public void GenerateMaelstormRoom()
    {
        // saving random coordinates
        byte requestedRow = Convert.ToByte(rnd.Next(0, RowLimit));
        byte requestedColumn = Convert.ToByte(rnd.Next(0, ColumnLimit));
        // checking if room is free
        if (IsRoomFree(requestedRow, requestedColumn))
            maelstormRooms.Add(new Room(requestedRow, requestedColumn, RoomType.Maelstorm));
        // else trying again
        else
            GenerateMaelstormRoom();
    }

    public void GenerateAmarokRoom()
    {
        // saving random coordinates
        byte requestedRow = Convert.ToByte(rnd.Next(0, RowLimit));
        byte requestedColumn = Convert.ToByte(rnd.Next(0, ColumnLimit));
        // checking if room is free
        if (IsRoomFree(requestedRow, requestedColumn))
            amarokRooms.Add(new Room(requestedRow, requestedColumn, RoomType.Amarok));
        // else trying again
        else
            GenerateAmarokRoom();
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

public enum RoomType { Default, Entrance, Fountain, Pit, Maelstorm, Amarok }