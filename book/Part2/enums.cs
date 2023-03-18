namespace book.part2.enums;

class Enums
{
    public static void EnumsFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Enumerations";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 16");
        
        chestState currentChestState = chestState.locked;
        Console.Write("The chest is locked. wa do ya wanna do? ");
        var userCommand = Console.ReadLine();
        
        while (true)
        {
            if (currentChestState == chestState.open)
            {
                if (userCommand == "close")
                {
                    currentChestState = chestState.closed;
                    
                    Console.Write("The chest is closed. wa do ya wanna do? ");
                    userCommand = Console.ReadLine();
                    
                    continue;
                }
                else
                {
                    Console.Write("error: you kinda cant do that ");
                    userCommand = Console.ReadLine();
                
                    continue;
                }
            }
            else if (currentChestState == chestState.closed)
            {
                if (userCommand == "lock")
                {
                    currentChestState = chestState.locked;
                    
                    Console.Write("The chest is locked. wa do ya wanna do? ");
                    userCommand = Console.ReadLine();
                    
                    continue;
                }
                else if (userCommand == "open")
                {
                    currentChestState = chestState.open;
                    
                    Console.Write("The chest is open. wa do ya wanna do? ");
                    userCommand = Console.ReadLine();
                    
                    continue;
                }
                else
                {
                    Console.Write("error: you kinda cant do that ");
                    userCommand = Console.ReadLine();
                
                    continue;
                }
            }
            else if (currentChestState == chestState.locked)
            {
                if (userCommand == "unlock")
                {
                    currentChestState = chestState.closed;
                    
                    Console.Write("The chest is unlocked. wa do ya wanna do? ");
                    userCommand = Console.ReadLine();
                    
                    continue;
                }
                else
                {
                    Console.Write("error: you kinda cant do that ");
                    userCommand = Console.ReadLine();
                
                    continue;
                }
            }
            
            else
            {
                Console.Write("error: not a command ");
                userCommand = Console.ReadLine();
                
                continue;
            }
        }
    }
}
enum chestState
{
      open,
      closed,
      locked
}