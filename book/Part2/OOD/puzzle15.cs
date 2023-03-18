namespace book.part2.ood.puzzle15;

public class puzzle15
{
    public static void puzzleFunc()
    {
        Random random = new Random();
        Game game = new Game();
        game.RandomGenerate(random);
        
        game.PrintGrid();
        Console.WriteLine("Puzzle is generated, please do your move (left, right, up, down)");
        string? command = Console.ReadLine();
    }
}

class Game
{
    public int[,] slots = new int[4, 4];

    public void RandomGenerate(Random random)
    {
        for (int indexX = 0; indexX < slots.GetLength(0); indexX++)
        {
            for (int indexY = 0; indexY < slots.GetLength(1); indexY++) {
                slots[indexX, indexY] = random.Next(1, 15);
            }
            Console.WriteLine();
        }
    }

    public void PrintGrid()
    {
        for (int indexX = 0; indexX < slots.GetLength(0); indexX++)
        {
            for (int indexY = 0; indexY < slots.GetLength(1); indexY++) {
                Console.Write($"{slots[indexX, indexY]} ");
            }
            Console.WriteLine();
        }
    }
}