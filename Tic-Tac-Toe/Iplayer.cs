using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public interface IPlayer
    {
        List<int> Positions { get; }
        string Symbol { get; set; }
        void AddPosition(int position);
        int MakeMove(Board board, int turnNumber, IPlayer turnPlayer);
    }
}
