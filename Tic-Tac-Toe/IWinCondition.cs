using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public interface IWinCondition
    {
        bool IsWin(List<int> positions);
    }
}