namespace book.part2.ood.RockPaperScissors;

public class RPS
{
    public static void RPSFunc()
    {
        Game game = new Game();

        game.AskForChoice();
        game.DetermineWinner();
        Console.Write($"Winner is {game.winner}");
    }
}

class Game
{
    public string player1;
    public string player2;

    public string winner;

    public void AskForChoice()
    {
        Console.WriteLine("Player 1 and player 2, please enter your choice(rock, paper, scissors)");

        Console.Write("Player 1: ");
        this.player1 = Console.ReadLine();

        Console.Write("Player 2: ");
        this.player2 = Console.ReadLine();
    }

    public void DetermineWinner()
    {
        // player 1
        if (this.player1 == "rock" & this.player2 == "scissors") winner = "player 1";
        else if (this.player1 == "scissors" & this.player2 == "paper") winner = "player 1";
        else if (this.player1 == "paper" & this.player2 == "rock") winner = "player 1";
        else if (this.player1 == this.player2) winner = "draw";
        else winner = "player 2";
    }
}