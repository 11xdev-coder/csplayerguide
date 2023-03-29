namespace book.part2.interfaces.interfaces;

public class interfaces
{
    public static void Start()
    {
        // explicit implementations are detached from their containing classes
        ExplodingBalloon explodingBalloon = new ExplodingBalloon();
        // explodingBalloon.BlowUp(); // COMPILER ERROR!!

        IBomb bomb = explodingBalloon;
        bomb.BlowUp();

        IBalloon balloon = explodingBalloon;
        balloon.BlowUp();

    }
}

// each level is 2d grid of terrain types
public class Level
{
    public int Width { get; }
    public int Height { get; }
    public TerrainType TerrainType { get; }

    public Level(int Width, int Height, TerrainType TerrainType)
    {
        this.Width = Width;
        this.Height = Height;
        this.TerrainType = TerrainType;
    }
}
// to preserve as much flexibility as possible we are defining interface to build levels for player to play
public interface ILevelBuilder
{
    Level BuildLevel(int levelNumber);
}
// implementing interfaces
public class FixedLevelBuilder : ILevelBuilder
{
    public Level BuildLevel(int levelNumber)
    {
        Level level = new Level(10, 10, TerrainType.Forest);

        //level.SetTerrainAt(2, 4, TerrainType.Mountains);
        //level.SetTerrainAt(2, 5, TerrainType.Mountains);
        //level.SetTerrainAt(6, 1, TerrainType.Desert);

        return level;
    }
}

// explicit interface implementations
public interface IBomb
{
    void BlowUp();
}

public interface IBalloon
{
    void BlowUp();
}

public class ExplodingBalloon : IBomb, IBalloon
{
    void IBomb.BlowUp() { Console.WriteLine("Kaboom!"); }
    void IBalloon.BlowUp() { Console.WriteLine("Whoosh!"); }
}



public enum TerrainType { Desert, Forest, Mountains, Pastures, Fields, Hills }