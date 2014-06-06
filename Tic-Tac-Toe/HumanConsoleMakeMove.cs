using System;

namespace Tic_Tac_Toe
{
    public class HumanConsoleMakeMove : IDetermineMove
    {
        public int GetPlayerMove(Board board, int turnNumber, IPlayer turnPlayer)
        {
            Console.WriteLine("Please select an open position: ");
            var guess = GetUserInputAsInt();
            GetValidResponse(guess);
            GetOpenPositionResponse(board, guess);
            return guess -1;
        }

        private int GetUserInputAsInt()
        {
            var result = Console.ReadLine();
            int x;
            while (!Int32.TryParse(result, out x) || result == null)
            {
                Console.WriteLine("Not a valid Number, Please Try Again: ");
                result = Console.ReadLine();
            }
            return Convert.ToInt32(result);
        }

        private void GetValidResponse(int guess)
        {
            while (guess > 9 || guess < 0)
            {
                Console.WriteLine("Not a valid response, please try again: ");
                guess = GetUserInputAsInt();
            }
        }

        private void GetOpenPositionResponse(Board board, int guess)
        {
            while (!IsOpenMove(board, guess - 1))
            {
                Console.WriteLine("Position is already taken, Please try again:: ");
                guess = GetUserInputAsInt();
                GetValidResponse(guess);
            }
        }

        private bool IsOpenMove(Board board, int guess)
        {
            return board.IsBoardPositionOpen(guess);
        }
    }
}
