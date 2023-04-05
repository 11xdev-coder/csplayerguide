namespace book.part2.usefulTypes.robotpilot;

public class robotpilot
{
    public static void Start()
    {
        Random random = new Random();
        byte distance;
        distance = Convert.ToByte(random.Next(1, 101));
        // display stats
        byte round = 1;
        sbyte cityHealth = 15;
        sbyte manticoreHealth = 10;
        byte cannonRange;

        string defineShotText(byte cannonRange, byte distance)
        {
            string text;
            if (cannonRange < distance) text = "That round was FELL SHORT of the target";
            else if (cannonRange > distance) text = "That round was OVERSHOT the target";
            else text = "That round was a DIRECT HIT!";
            return text;
        }

        sbyte getCannonDamage(byte round)
        {
            sbyte cannonDamage;
            if (round % 3 == 0 && round % 5 == 0) cannonDamage = 10;
            else if (round % 3 == 0 || round % 5 == 0) cannonDamage = 3;
            else cannonDamage = 1;
            return cannonDamage;
        }

        bool didManticoreGetShot(byte cannonRange, byte distance)
        {
            bool didGetShot;
            if (cannonRange == distance) didGetShot = true;
            else didGetShot = false;
            return didGetShot;
        }
        
        while (true)
        {
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"STATUS: Round: {round} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");
            Console.WriteLine($"The cannon is expected to deal {getCannonDamage(round)} this round");
            Console.Write("Enter desired cannon range: ");
            cannonRange = Convert.ToByte(Console.ReadLine());
            Console.WriteLine(defineShotText(cannonRange, distance));
            if(didManticoreGetShot(cannonRange, distance)) manticoreHealth -= getCannonDamage(round);
            round += 1;
            cityHealth -= 1;

            if (manticoreHealth <= 0)
            {
                Console.WriteLine("congrats, win, wow");
                break;
            }
            else if (cityHealth <= 0)
            {
                Console.WriteLine("u lost lol");
                break;
            }
            else continue;
        }
    }
}