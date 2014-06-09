using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class AIMakeMove : IDetermineMove
    {
        private string _turnPlayerSymbol;
        private string _nonTurnPlayerSymbol;


        private readonly Dictionary<int, List<List<int>>> _moves = new Dictionary<int, List<List<int>>>
        {
            {0, new List<List<int>>{new List<int>{1, 2}, new List<int>{3, 6}, new List<int>{4, 8}}},
            {1, new List<List<int>>{new List<int>{0, 2}, new List<int>{4, 7},}},
            {2, new List<List<int>>{new List<int>{0, 1}, new List<int>{4, 6}, new List<int>{5, 8}}},
            {3, new List<List<int>>{new List<int>{0, 6}, new List<int>{4, 5},}},
            {4, new List<List<int>>{new List<int>{1, 7}, new List<int>{2, 6}, new List<int>{3, 5}, new List<int>{0, 8}}},
            {5, new List<List<int>>{new List<int>{3, 4}, new List<int>{2, 6}, new List<int>{2, 8}}},
            {6, new List<List<int>>{new List<int>{0, 3}, new List<int>{2, 4}, new List<int>{7, 8}}},
            {7, new List<List<int>>{new List<int>{1, 4}, new List<int>{6, 8}}},
            {8, new List<List<int>>{new List<int>{0, 4}, new List<int>{2, 5}, new List<int>{6, 7}}} 
        };

        private readonly Dictionary<int, List<List<int>>> _setupMoves = new Dictionary<int, List<List<int>>>
        {
            {0, new List<List<int>>{new List<int>{1, 3}}},
            {1, new List<List<int>>{new List<int>{2, 3},new List<int>{5, 0}}},
            {2, new List<List<int>>{new List<int>{1, 5}}},
            {3, new List<List<int>>{new List<int>{0, 7},new List<int>{6, 1},new List<int>{0, 8}}},
            {5, new List<List<int>>{new List<int>{1, 8},new List<int>{2, 7}}},
            {6, new List<List<int>>{new List<int>{3, 7}}},
            {7, new List<List<int>>{new List<int>{3, 8},new List<int>{6, 8}}}, 
            {8, new List<List<int>>{new List<int>{5, 7}}}
        };


        public int GetPlayerMove(Board board, int turnNumber, IPlayer turnPlayer)
        {
            _turnPlayerSymbol = turnPlayer.Symbol;
            SetNonTurnPlayerSymbol(_turnPlayerSymbol);
            if (turnNumber == 1)
                return PlayFirstTurn();
            if (turnNumber == 2)
                return PlayTurn2(board);
            if (turnNumber > 2 && turnNumber < 6)
                return PlayTurns2Through5(board);
            return PlayTurns6AndAbove(board);
        }

        private void SetNonTurnPlayerSymbol(string turnPlayerSymbol)
        {
            if (turnPlayerSymbol == "X")
                _nonTurnPlayerSymbol = "O";
            else
            {
                _nonTurnPlayerSymbol = "X";
            }
        }

        private int PlayFirstTurn()
        {
            var corners = new List<int>{0,2,6,8};
            var rnd = new Random();
            var selection = corners[rnd.Next(4)];
            return selection;
        }

        private int PlayTurn2(Board board)
        {
            if (board.GetSpecificPositionValue(4) != _nonTurnPlayerSymbol)
                return 4;
            return PlayFirstTurn();
        }

        private int PlayTurns2Through5(Board board)
        {
            var move = CheckForWinningMove(board);
            if (IsLegalMove(move))
                return move;
            move = CheckForBlockingMove(board);
            if (IsLegalMove(move))
                return move;
            move = CheckForBlockingSetupMove(board);
            if (IsLegalMove(move))
                return move;
            move = CheckForSetUpMove(board);
            if (IsLegalMove(move))
                return move;
            return MakeNextBestMove(board);
        }

        private int PlayTurns6AndAbove(Board board)
        {
            var move = CheckForWinningMove(board);
            if (IsLegalMove(move))
                return move;
            move = CheckForBlockingMove(board);
            if (IsLegalMove(move))
                return move;
            return MakeNextBestMove(board);
        }

        private int CheckForWinningMove(Board board)
        {
            return FindBestMove(board, _moves, _turnPlayerSymbol);
        }

        private int CheckForBlockingMove(Board board)
        {
            return FindBestMove(board, _moves, _nonTurnPlayerSymbol);
        }

        private int CheckForBlockingSetupMove(Board board)
        {
            return FindBestMove(board, _setupMoves, _nonTurnPlayerSymbol);
        }

        private int CheckForSetUpMove(Board board)
        {
            return FindBestMove(board, _setupMoves, _turnPlayerSymbol);
        }

        private int FindBestMove(Board board, Dictionary<int, List<List<int>>> movesDictionary, string symbol)
        {
            foreach (KeyValuePair<int, List<List<int>>> move in movesDictionary)
            {
                var givenPositions = move.Value;
                var possibleMove = move.Key;

                foreach (var possibleBlock in givenPositions)
                {
                    if (IsBestMove(board, possibleBlock, possibleMove, symbol))
                        return possibleMove;
                }
            }
            return 9;
        }

        private bool IsBestMove(Board board, List<int> possibleBlock, int possibleMove, string symbol)
        {
            return board.GetSpecificPositionValue(possibleBlock[0]) == symbol
                && board.GetSpecificPositionValue(possibleBlock[1]) == symbol
                && board.GetSpecificPositionValue(possibleMove) == Convert.ToString(possibleMove + 1);
        }

        private bool IsLegalMove(int move)
        {
            return move < 9;
        }

        private int MakeNextBestMove(Board board)
        {
            var sides = new List<int> { 0, 2, 6, 8 };
            foreach (var position in sides)
            {
                if (IsBoardPositionOpen(board, position) )
                    return position;
            }
            return 9;
        }

        private bool IsBoardPositionOpen(Board board, int position)
        {
            return board.GetSpecificPositionValue(position) != _turnPlayerSymbol 
                && board.GetSpecificPositionValue(position) != _nonTurnPlayerSymbol;
        }
    }
}
