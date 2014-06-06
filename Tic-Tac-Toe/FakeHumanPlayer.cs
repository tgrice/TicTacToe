using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class FakeHumanPlayer : IPlayer
    {
        private List<int> fakePositions; 

        public FakeHumanPlayer(List<int> positions)
        {
            fakePositions = positions;
        }

        public List<int> Positions
        {
            get { return fakePositions; }
        }

        public string Name
        {
            get { return "TestPlayer1"; }
            set
            {
                
            }
        }

        public string Symbol
        {
            get { return "X"; }
            set { }
        }

        public void AddPosition(int position)
        {
            
        }


        public int MakeMove(Board board, int turnNumber, IPlayer turnPlayer)
        {
            return 0;
        }
    }
}
