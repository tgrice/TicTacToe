using System;
using Tic_Tac_Toe;

namespace PlayTicTacToe
{
    public class TicTacToe
    {
        static void Main()
        {
            GameController GameCon;
            var hcmm = new HumanConsoleMakeMove();
            var aimm = new AIMakeMove();
            var play = true;
            while (play)
            {
                Console.Title = "Tic-Tac-Toe";
                Console.Clear();
                Console.WriteLine("Please enter the number of players (0-2): ");
                var numberOfPlayers = Console.ReadLine();
                int x;
                while (!Int32.TryParse(numberOfPlayers, out x) || numberOfPlayers == null)
                {
                    Console.WriteLine("Not a valid Number, Please Try Again: ");
                    numberOfPlayers = Console.ReadLine();
                }
                while (Convert.ToInt32(numberOfPlayers) > 2 || Convert.ToInt32(numberOfPlayers) < 0)
                {
                    Console.WriteLine("Not a valid response, please try again: ");
                    numberOfPlayers = Console.ReadLine();
                }
            
                if (numberOfPlayers == "0")
                {
                    GameCon = new GameController(
                        new WinCondition(),
                        new AIPlayer(aimm), 
                        new AIPlayer(aimm), 
                        new ConsoleIO());
                }
                else if (numberOfPlayers == "1")
                {
                    GameCon = new GameController(
                        new WinCondition(),
                        new HumanPlayer(hcmm),
                        new AIPlayer(aimm),
                        new ConsoleIO());
                }
                else
                {
                    GameCon = new GameController(
                        new WinCondition(),
                        new HumanPlayer(hcmm),
                        new HumanPlayer(hcmm),
                        new ConsoleIO());
                }
                play = GameCon.Run();
            }
        }
    }
}
