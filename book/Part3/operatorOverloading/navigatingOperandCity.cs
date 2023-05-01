namespace book.part3.operatorOverloading.navigatingOperandCity;

public class navigatingOperandCity
{
    public static void Start()
    {
        BlockCoordinate a = new BlockCoordinate(5, 4);
        BlockOffset b = new BlockOffset(1, 1);
        BlockCoordinate c = a + b;
        Console.WriteLine($"Coordinate + offset: {c.row}, {c.column}");
        
        BlockCoordinate d = new BlockCoordinate(5, 4);
        Direction e = Direction.North;
        BlockCoordinate f = d + e;
        Console.WriteLine($"Coordinate + direction: {f.row}, {f.column}");
        
        Console.WriteLine($"Indexers: C: {c[0]}, {c[1]}. f: {f[0]}, {f[1]}");

        BlockOffset h = e;
        Console.WriteLine($"From direction to blockoffset: {h.rowOffset}, {h.columnOffset}");
    }
}

public record BlockCoordinate(int row, int column)
{
    public static BlockCoordinate operator +(BlockCoordinate coordinate, BlockOffset offset) =>
        new BlockCoordinate(coordinate.row + offset.rowOffset, coordinate.column + offset.columnOffset);

    public static BlockCoordinate operator +(BlockCoordinate coordinate, Direction direction)
    {
        BlockCoordinate newCoordinate = direction switch
        {
            Direction.North => new BlockCoordinate(coordinate.row + 1, coordinate.column),
            Direction.South => new BlockCoordinate(coordinate.row - 1, coordinate.column),
            Direction.East => new BlockCoordinate(coordinate.row, coordinate.column + 1),
            Direction.West => new BlockCoordinate(coordinate.row, coordinate.column - 1)
        };

        return newCoordinate;
    }

    public int this[int index]
    {
        get
        {
            if (index == 0) return row;
            else return column;
        }
    }
}

public record BlockOffset(int rowOffset, int columnOffset)
{
    public static implicit operator BlockOffset(Direction direction) // from direction to blockoffset
    {
        BlockOffset newOffset = direction switch
        {
            Direction.North => new BlockOffset(1, 0),
            Direction.South => new BlockOffset(-1, 0),
            Direction.East => new BlockOffset(0, 1),
            Direction.West => new BlockOffset(0, -1)
        };

        return newOffset;
    }
}
public enum Direction { North, East, South, West }
