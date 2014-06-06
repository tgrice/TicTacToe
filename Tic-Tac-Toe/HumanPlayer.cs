using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class HumanPlayer : IPlayer
    {
        private IDetermineMove _determineMove;

        public HumanPlayer(IDetermineMove determineMove)
        {
            _determineMove = determineMove;
        }

        private string _symbol;
        private List<int> _positions = new List<int>();
        public string Symbol { get { return _symbol; } set { _symbol = value; } }

        public List<int> Positions { get { return _positions; } }

        public void AddPosition(int position)
        {
            _positions.Add(position);
        }

        public int MakeMove(Board board, int turnNumber, IPlayer turnPlayer)
        {
            return _determineMove.GetPlayerMove(board, turnNumber, turnPlayer);
        }
    }
}
