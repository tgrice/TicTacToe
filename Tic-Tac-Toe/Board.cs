using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class Board
    {

        private List<string> _boardState;
        private string player1Symbol = "X";
        private string player2Symbol = "O";

        public Board()
        {
            _boardState = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9"};
        }

        public Board(List<string> board)
        {
            _boardState = board;
        }

        public string GetSpecificPositionValue(int position)
        {
            return _boardState[position];
        }

        public void UpdateBoard(int position, string symbol)
        {
            _boardState[position] = symbol; 
        }

        public bool IsBoardPositionOpen(int position)
        {
            if (_boardState[position] == player1Symbol || _boardState[position] == player2Symbol)
            {
                return false;
            }
            return true;
        }
    }
}