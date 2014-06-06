using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    public class FakeConsoleIO : ITicTacToeIO
    {
        public void PrintRules()
        {
            
        }

        public string GetUserName()
        {
            return "TestPlayer";
        }

        public string GetUserSymbol()
        {
            return "X";
        }

        public void PrintGameBoard(Board board)
        {
            
        }

        public int GetUserMove()
        {
            return 8;
        }

        public void PrintLoseGame()
        {
            
        }

        public void PrintVictoryString(IPlayer winningPlayer)
        {
            
        }

        public string GetRematchResponse()
        {
            return "N";
        }
    }
}
