using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class AIPlayer : IPlayer
    {
        private IDetermineMove _determineMove;

        public AIPlayer(IDetermineMove determineMove)
        {
            _determineMove = determineMove;
        }

        private List<int> _positions = new List<int>();
        private string _symbol;

        public string Symbol { set { _symbol = value; } get { return _symbol; } }

        public List<int> Positions { get { return _positions; } }

        public bool IsHuman { get { return false; } }

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

