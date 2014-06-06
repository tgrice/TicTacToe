using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe;

namespace TestTicTacToe
{
    [TestClass]
    public class PlayerTest
    {
        private HumanPlayer _p;

        [TestInitialize]
        public void Setup()
        {
            var hmm = new HumanConsoleMakeMove();
            _p = new HumanPlayer(hmm);
        }

        [TestMethod]
        public void CanAddPosition()
        {
            _p.AddPosition(5);
            CollectionAssert.AreEqual(new List<int>{5}, _p.Positions);
        }
    }
}
