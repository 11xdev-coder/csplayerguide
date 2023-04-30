using System.Runtime.CompilerServices;

namespace book.part3.patternMatching.thePotionMastersOfPattren;

public class thePotionMastersOfPattren
{
    public static void Start()
    {
        PotionType potion = PotionType.water;
        
        while (true)
        {
            Console.WriteLine($"Current potion is {potion}");
            
            Console.WriteLine("Do you want to continue making your potion?");
            string? input = Console.ReadLine();
            if (input == "no") break;
            
            Console.WriteLine("Available ingridients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");

            Ingridient ingridient = Console.ReadLine() switch
            {
                "stardust" => Ingridient.stardust,
                "snake venom" => Ingridient.snakeVenom,
                "dragon breath" => Ingridient.dragonBreath,
                "shadow glass" => Ingridient.shadowGlass,
                "eyeshine gem" => Ingridient.eyeshineGem
            };

            potion = (ingridient, potion) switch
            {
                (Ingridient.stardust, PotionType.water) => PotionType.elixir,
                (Ingridient.snakeVenom, PotionType.elixir) => PotionType.poison,
                (Ingridient.dragonBreath, PotionType.elixir) => PotionType.flying,
                (Ingridient.shadowGlass, PotionType.elixir) => PotionType.invisibility,
                (Ingridient.eyeshineGem, PotionType.elixir) => PotionType.nightSight,
                (Ingridient.shadowGlass, PotionType.nightSight) => PotionType.cloudy,
                (Ingridient.eyeshineGem, PotionType.invisibility) => PotionType.cloudy,
                (Ingridient.stardust, PotionType.cloudy) => PotionType.wraith,
                (_, _) => PotionType.ruined
            };
            
            if (potion == PotionType.ruined)
            {
                Console.WriteLine("your potion is ruined, start over nub!!!!!!11!");
                potion = PotionType.water;
            }
        }
    }
}

public enum PotionType { water, elixir, poison, flying, invisibility, nightSight, cloudy, wraith, ruined }
public enum Ingridient { stardust, snakeVenom, dragonBreath, shadowGlass, eyeshineGem }