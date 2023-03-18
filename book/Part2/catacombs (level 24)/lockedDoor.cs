namespace book.part2.catacombs.lockedDoor;

public class lockedDoor
{
    public static void lockedDoorFunc()
    {
        print("Enter doors initial password");
        int _passcode = Convert.ToInt32(Console.ReadLine());
        Door door = new Door(_passcode);
        while (true)
        {
            print($"The door is {door.doorState}. What do you want to do? (open, close, lock, unlock, change password) ");
            string? command = Console.ReadLine();
            switch (command)
            {
                case "open":
                    door.Open();
                    break;
                case "close":
                    door.Close();
                    break;
                case "lock":
                    door.Lock();
                    break;
                case "unlock":
                    print("Doors password?");
                    int guess = Convert.ToInt32(Console.ReadLine());
                    door.Unlock(guess);
                    break;
                case "change password":
                    print("Whats the password");
                    int currentCode = Convert.ToInt32(Console.ReadLine());
                    print("New password?");
                    int newCode = Convert.ToInt32(Console.ReadLine());
                    door.ChangeCode(currentCode, newCode);
                    break;
            }
        }
        
        void print(string text)
        {
            Console.WriteLine(text);
        }
    }
}

class Door
{
    public DoorState doorState { get; set; }
    public int _passcode { get; set; }

    public Door(int passcode)
    {
        _passcode = passcode;
        doorState = DoorState.closed;
    }

    public void Open()
    {
        if (doorState == DoorState.closed) doorState = DoorState.open;
        else Console.WriteLine("Cant");
    }

    public void Close()
    {
        if (doorState == DoorState.open) doorState = DoorState.closed;
        else Console.WriteLine("Cant");
    }

    public void Lock()
    {
        if (doorState == DoorState.closed)
        {
            doorState = DoorState.locked;

        }
        else Console.WriteLine("Cant");
    }

    public void Unlock(int guessedCode)
    {
        if (doorState == DoorState.locked)
        {
            if (guessedCode == _passcode)
            {
                doorState = DoorState.closed;
                Console.WriteLine("Unlocked");
            }
            else
            {
                Console.WriteLine("Wrong code!");
            }
        }
        else Console.WriteLine("Cant");
        
    }

    public void ChangeCode(int guessedCode, int newCode)
    {
        if (guessedCode == _passcode)
        {
            _passcode = newCode;
            Console.WriteLine("Changed Pass");
        }
        else Console.WriteLine("Could not change pass");
    }
}



enum DoorState { locked, open, closed }