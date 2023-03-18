using System.Runtime.InteropServices.ComTypes;

namespace book.part2.classes;

class Classes
{
    public static void ClassesFunc()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
        Console.Title = "Classes";
        Console.Beep(2000, 250);
        Console.WriteLine("LEVEL 18");


        Arrow nerdiesArrow = GetStyle();
        if (nerdiesArrow == null)
        {
            nerdiesArrow = new Arrow(GetArrowHead(), GetArrowFletching(), GetArrowLength());
        }
        Console.WriteLine(nerdiesArrow.Cost);
    }

    public static Arrow GetStyle()
    {
        Console.Write("pick an arrow style \n" +
                      "1 - Elite Arrow  \n" +
                      "2 - Beginner Arrow \n" +
                      "3 - Marksman Arrow  \n" +
                      "4 - Custom \n" +
                      "ur choice: ");
        int choicedStyle = Convert.ToInt32(Console.ReadLine());
        return choicedStyle switch
        {
            1 => CreateEliteArrow(),
            2 => CreateBeginnerArrow(),
            3 => CreateMarksmanArrow(),
            4 => null
        };
    }
    
    public static arrowhead GetArrowHead()
    {
        Console.Write("pick an arrow head \n" +
                      "1 - steel, 10 gold  \n" +
                      "2 - wood , 3 gold \n" +
                      "3 - obsidian, 5 gold  \n" +
                      "ur choice: ");
        int choicedArrowHead = Convert.ToInt32(Console.ReadLine());
        
        return choicedArrowHead switch
        {
            1 => arrowhead.steel,
            2 => arrowhead.wood,
            3 => arrowhead.obsidian
        };
    }
    
    public static fletching GetArrowFletching()
    {
        Console.Write("pick an arrow fletching \n" +
                      "1 - plastic, 10 gold  \n" +
                      "2 - turkey feathers, 5 gold  \n" +
                      "3 - goose feathers, 3 gold  \n" +
                      "ur choice: ");
        int choicedArrowFletching = Convert.ToInt32(Console.ReadLine());
        
        return choicedArrowFletching switch
        {
            1 => fletching.plastic,
            2 => fletching.turkeyFeathers,
            3 => fletching.gooseFeathers
        };
    }

    public static int GetArrowLength()
    {
        Console.Write("pick an arrow shaft \n" +
                      "between 60 and 100, 0.05 per cm\n" + 
                      "ur choice: ");
        int finalArrowLength = Convert.ToInt32(Console.ReadLine());
        return Clamp(finalArrowLength, 60, 100);
    }

    public static Arrow CreateEliteArrow() => new Arrow(arrowhead.steel, fletching.plastic, 95);
    public static Arrow CreateBeginnerArrow() => new Arrow(arrowhead.wood, fletching.gooseFeathers, 75);
    public static Arrow CreateMarksmanArrow() => new Arrow(arrowhead.steel, fletching.gooseFeathers, 65);
    
    
    public static int Clamp(int value, int min, int max) => (value < min) ? min : (value > max) ? max : value;
}
class Arrow
{
    public arrowhead ArrowHead { get; }
    public fletching ArrowFletching { get; }
    public int ArrowLength { get; }

    public Arrow(arrowhead arrowHead, fletching arrowFletching, int arrowShaft)
    {
        this.ArrowHead = arrowHead;
        this.ArrowFletching = arrowFletching;
        this.ArrowLength = arrowShaft;
    }

    public float Cost
    {
        get
        {
            float ArrowHeadCost = ArrowHead switch
            {
                arrowhead.steel => 10,
                arrowhead.wood => 3,
                arrowhead.obsidian => 5
            };

            float ArrowFletchingCost = ArrowFletching switch
            {
                fletching.plastic => 10,
                fletching.turkeyFeathers => 5,
                fletching.gooseFeathers => 3
            };

            float ArrowShaftCost = ArrowLength * 0.05f;

            return ArrowHeadCost + ArrowFletchingCost + ArrowShaftCost;
        }
    }
}

enum arrowhead
{
    steel,
    wood,
    obsidian
}
enum fletching
{
    plastic,
    turkeyFeathers,
    gooseFeathers
}