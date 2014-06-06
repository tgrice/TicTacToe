using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class FakeAiPlayer : IPlayer
    {
        private List<int> fakePositions;

        public FakeAiPlayer(List<int> positions)
        {
            fakePositions = positions;
        }

        public List<int> Positions
        {
            get { return fakePositions; }
        }

        public string Name
        {
            get { return "Computer"; }
            set
            {

            }
        }

        public string Symbol
        {
            get { return "O"; }
            set { }
        }

        public void AddPosition(int position)
        {

        }

        public int MakeMove(Board board, int turnNumber, IPlayer turnPlayer)
        {
            return 7;
        }
    }
}
