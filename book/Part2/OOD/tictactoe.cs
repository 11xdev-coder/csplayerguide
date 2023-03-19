namespace book.part2.ood.tictactoe;

public class tictactoe
{
    public static void tttFunc()
    {
        Board board = new Board();
        BoardRenderer boardRenderer = new BoardRenderer(board);
        Game game = new Game(board, boardRenderer);

        while (game.turnNumber < 9)
        {
            game.AskForMove();

            if (game.HasWon(board, Cell.X))
            {
                boardRenderer.RenderBoard();
                Console.WriteLine("X's won!");
                return;
            }
            else if (game.HasWon(board, Cell.O))
            {
                boardRenderer.RenderBoard();
                Console.WriteLine("O's won!");
                return;
            }
        }
        
        boardRenderer.RenderBoard();
        Console.WriteLine("Draw!");
        
    }
}

class Game
{
    public Cell move;
    public Board board;
    public BoardRenderer boardRenderer;
    private int key { get; set; }
    private Square pickedSquare { get; set; }
    public int turnNumber = 0;

    public Game(Board board, BoardRenderer boardRenderer)
    {
        this.board = board;
        move = Cell.X;
        this.boardRenderer = boardRenderer;
    }

    public Square PickSquare(int input)
    {
        Square choice = input switch
        {
            7 => new Square(0, 0),
            8 => new Square(0, 1),
            9 => new Square(0, 2),
            4 => new Square(1, 0),
            5 => new Square(1, 1),
            6 => new Square(1, 2),
            1 => new Square(2, 0),
            2 => new Square(2, 1),
            3 => new Square(2, 2)
        };

        if (board.IsEmpty(choice.Row, choice.Column)) return choice;
        else Console.WriteLine("This cell is already taken!!!!");
        return null;
    }
    
    public void AskForMove()
    {
        Console.WriteLine($"It's {move}'s turn");
        boardRenderer.RenderBoard();
        Console.Write("Enter the cell you would like to go to: ");
        key = Convert.ToInt32(Console.ReadLine());
        pickedSquare = PickSquare(key);
        if (pickedSquare != null)
        {
            board.FillCell(pickedSquare.Row, pickedSquare.Column, move);
            if (move == Cell.X) move = Cell.O;
            else move = Cell.X;
        }

        turnNumber += 1;
    }

    public bool HasWon(Board board, Cell value)
    {
        // Check rows.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(0, 1) == value && board.ContentsOf(0, 2) == value) return true;
        if (board.ContentsOf(1, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(1, 2) == value) return true;
        if (board.ContentsOf(2, 0) == value && board.ContentsOf(2, 1) == value && board.ContentsOf(2, 2) == value) return true;

        // Check columns.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 0) == value && board.ContentsOf(2, 0) == value) return true;
        if (board.ContentsOf(0, 1) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 1) == value) return true;
        if (board.ContentsOf(0, 2) == value && board.ContentsOf(1, 2) == value && board.ContentsOf(2, 2) == value) return true;

        // Check diagonals.
        if (board.ContentsOf(0, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(2, 2) == value) return true;
        if (board.ContentsOf(2, 0) == value && board.ContentsOf(1, 1) == value && board.ContentsOf(0, 2) == value) return true;

        return false;
    }
}

class Board 
{
    public Cell[,] cells = new Cell[3, 3];

    public void FillCell(int row, int collumn, Cell value) => cells[row, collumn] = value;
    public bool IsEmpty(int row, int column) => cells[row, column] == Cell.nil;
    public Cell ContentsOf(int row, int column) => cells[row, column];
}

class BoardRenderer
{
    public Board board;

    public BoardRenderer(Board board)
    {
        this.board = board;
    }
    
    public void RenderBoard()
    {
        Console.WriteLine($"{GetCharacterFor(board.cells[0,0])} | {GetCharacterFor(board.cells[0,1])} | {GetCharacterFor(board.cells[0,2])}");
        Console.WriteLine("----------");
        Console.WriteLine($"{GetCharacterFor(board.cells[1,0])} | {GetCharacterFor(board.cells[1,1])} | {GetCharacterFor(board.cells[1,2])}");
        Console.WriteLine("----------");
        Console.WriteLine($"{GetCharacterFor(board.cells[2,0])} | {GetCharacterFor(board.cells[2,1])} | {GetCharacterFor(board.cells[2,2])}");
    }
    
    public char GetCharacterFor(Cell cell) => cell switch { Cell.X => 'X', Cell.O => 'O', Cell.nil => ' ' };
    
}

public class Square
{
    public int Row { get; }
    public int Column { get; }

    public Square(int row, int column)
    {
        Row = row;
        Column = column;
    }
}

enum Cell { nil, X, O }

