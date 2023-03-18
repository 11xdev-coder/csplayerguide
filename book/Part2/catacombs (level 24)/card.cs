namespace book.part2.catacombs.card;

public class card
{
    public static void cardFunc()
    {
        Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };
        Rank[] ranks = new Rank[]
        {
            Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine,
            Rank.Ten, Rank.DollarSign, Rank.Percent, Rank.Carret, Rank.Ampersand
        };

        foreach (Color color in colors)
        {
            foreach (Rank rank in ranks)
            {
                Card card = new Card(color, rank);
                Console.WriteLine($"The {card.CardColor} {card.CardRank}");
            }
        }
    }
}

class Card
{
    public Color CardColor { get; set; }
    public Rank CardRank { get; set; }

    public Card(Color color, Rank rank)
    {
        CardColor = color;
        CardRank = rank;
    }

    public bool IsSymbol => CardRank == Rank.DollarSign | CardRank == Rank.Percent | CardRank == Rank.Carret |
                            CardRank == Rank.Ampersand;

    public bool IsNumber => !IsSymbol;
}

public enum Color { Red, Green, Blue, Yellow }
public enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Carret, Ampersand }