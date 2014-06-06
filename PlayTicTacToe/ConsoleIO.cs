using System;
using Tic_Tac_Toe;

namespace PlayTicTacToe
{
    public class ConsoleIO : ITicTacToeIO
    {
        
        public void PrintRules()
        {
            Console.Clear();
            Console.Title = "Tic-Tac-Toe";
            Console.WriteLine("Try to get 3 in a row.\n" +
                              "Have fun!!\n" +
                              "Press Enter to continue: ");
            Console.ReadLine();
        }

        public void PrintGameBoard(Board board)
        {
            Console.Clear();
            Console.WriteLine(board.GetSpecificPositionValue(0) + " | " + board.GetSpecificPositionValue(1) + " | " + board.GetSpecificPositionValue(2) + "\n" +
                              board.GetSpecificPositionValue(3) + " | " + board.GetSpecificPositionValue(4) + " | " + board.GetSpecificPositionValue(5) + "\n" +
                              board.GetSpecificPositionValue(6) + " | " + board.GetSpecificPositionValue(7) + " | " + board.GetSpecificPositionValue(8));
        }

        public void PrintLoseGame()
        {
            Console.WriteLine("No more open positions, Draw.");
        }

        public void PrintVictoryString(IPlayer winningPlayer)
        {
            Console.WriteLine(winningPlayer.Symbol + " WINS!!!");
        }

        public string GetRematchResponse()
        {
            Console.WriteLine("Would you like a rematch? (Y/N): ");
            var result = Console.ReadLine();
            while (result.ToUpper() != "Y" && result.ToUpper() != "N")
            {
                Console.WriteLine("Not a valid response, please try again: ");
                result = Console.ReadLine();
            }
            return result.ToUpper();
        }
    }
}
