namespace book.part2.records.warPreparations;

public class warPreparations
{
    public static void Start()
    {
        Sword basicSword = new Sword(SwordMaterial.iron, GemStone.None, 25f, 1.5f);
        Sword sword1 = basicSword with { gemstone = GemStone.amber };
        Sword sword2 = basicSword with { material = SwordMaterial.bronze, length = 60f };
        Console.WriteLine($"basic sword: {basicSword.ToString()} sword1: {sword1} sword2: {sword2}");
    }
}

public record Sword(SwordMaterial material, GemStone gemstone, float length, float crossguardWidth);

public enum SwordMaterial { wood, bronze, iron, steel, binarium }
public enum GemStone { None, emerald, amber, sapphire, diamond, bitstone }