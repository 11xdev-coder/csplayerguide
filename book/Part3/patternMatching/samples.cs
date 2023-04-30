namespace book.part3.patternMatching.samples;

public class samples
{
    public static void Start()
    {
        // the monster scoring problem
        int ScoreFor(Monster monster)
        {
            // type pattern
            return monster switch
            {
                // and, or, not keywords are allowed on patterns
                Snake s1 when s1.length >= 3 => 7, // case guard, put always on top
                Snake s => (int)(s.length * 2), // declaration pattern
                Dragon { phase: LifePhase.Ancient} => 100, // property pattern, you can add multiple properties
                Dragon => 50,
                Orc { sword: { type: SwordType.WoodenStick} } => 2, // nested pattern
                Orc { sword.type: SwordType.Longsword} => 15, // nested pattern
                _ => 5
            };
        }
    }
}

public abstract record Monster;

public record Skeleton() : Monster;

public record Snake(double length) : Monster;

public record Dragon(DragonType type, LifePhase phase) : Monster;

public record Orc(Sword sword) : Monster;
public record Sword(SwordType type);

public enum DragonType { Black, Green, Red, Blue, Gold }
public enum LifePhase { Wyrmling, Young, Adult, Ancient }
public enum SwordType { WoodenStick, ArmingSword, Longsword }