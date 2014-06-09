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
                var numberOfHumanPlayers = GetCorrectNumberOfPlayers();


                if (numberOfHumanPlayers == 0)
                {
                    GameCon = new GameController(
                        new WinCondition(),
                        new AIPlayer(aimm), 
                        new AIPlayer(aimm), 
                        new ConsoleIO());
                }
                else if (numberOfHumanPlayers == 1)
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

        private static string GetUserInputAsInt()
        {
            var result = Console.ReadLine();
            int x;
            while (!Int32.TryParse(result, out x) || result == null)
            {
                Console.WriteLine("Not a valid Number, Please Try Again: ");
                result = Console.ReadLine();
            }
            return result;
        }

        private static int GetCorrectNumberOfPlayers()
        {
            var numberOfPlayers = Convert.ToInt32(GetUserInputAsInt());
            while (numberOfPlayers < 0 || numberOfPlayers > 2)
            {
                Console.WriteLine("Invalid number of players, please try again: ");
                numberOfPlayers = Convert.ToInt32(GetUserInputAsInt());
            }
            return numberOfPlayers;
        }

       
    }
}
