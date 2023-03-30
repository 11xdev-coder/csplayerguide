namespace book.part2.structs.roomCoordinates;

public class roomCoordinates
{
    public static void Start()
    {
        Coordinate coordinate1 = new Coordinate(3, 6);
        Coordinate coordinate2 = new Coordinate(2, 6);
        Coordinate coordinate3 = new Coordinate(3, 7);
        
        Console.WriteLine(coordinate1.IsAdjacent(coordinate2)); // true
        Console.WriteLine(coordinate1.IsAdjacent(coordinate3)); // true
        Console.WriteLine(coordinate2.IsAdjacent(coordinate3)); // false
        Console.WriteLine(coordinate3.IsAdjacent(coordinate1)); // true
    }
}

public struct Coordinate
{
    public int row { get; }
    public int column { get; }

    public bool IsAdjacent(Coordinate matchingCoordinate)
    {
        if (this.row == matchingCoordinate.row) return true;
        if (this.column == matchingCoordinate.column) return true;
        return false;
    }

    public Coordinate(int row, int column)
    {
        this.row = row;
        this.column = column;
    }
}