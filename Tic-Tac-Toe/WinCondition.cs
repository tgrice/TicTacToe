using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class WinCondition : IWinCondition
    {
        private readonly List<List<int>> _winPositions = new List<List<int>>
        {
            {new List<int> {0, 1, 2}},
            {new List<int> {3, 4, 5}},
            {new List<int> {6, 7, 8}},
            {new List<int> {0, 3, 6}},
            {new List<int> {1, 4, 7}},
            {new List<int> {2, 5, 8}},
            {new List<int> {0, 4, 8}},
            {new List<int> {2, 4, 6}},
        };

        public bool IsWin(List<int> positions)
        {
            foreach (var win in _winPositions)
            {
                if (IsWinningCombination(positions, win)) return true;
            }
            return false;
        }

        private static bool IsWinningCombination(List<int> positions, List<int> win)
        {
            var winningPositions = ComparePositions(positions, win);
            if (winningPositions == win.Count)
                return true;
            return false;
        }

        private static int ComparePositions(List<int> positions, List<int> win)
        {
            var winningPositions = 0;
            for (var i = 0; i < win.Count; i++)
            {
                if (positions.Contains(win[i]))
                    winningPositions ++;
            }
            return winningPositions;
        }
    }
}
