using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public interface ITicTacToeIO
    {
        void PrintRules();
        void PrintGameBoard(Board board);
        void PrintLoseGame();
        void PrintVictoryString(IPlayer winningPlayer);
        string GetRematchResponse();
    }
}
