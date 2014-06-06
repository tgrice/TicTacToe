using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe;

namespace TestTicTacToe
{
    [TestClass]
    public class WinConditionTest
    {
        private WinCondition _winCon;

        [TestInitialize]
        public void Setup()
        {
            _winCon = new WinCondition();
        }

        [TestMethod]
        public void CanWinHorizontal()
        {
            Assert.AreEqual(true, _winCon.IsWin(new List<int>{1, 0, 2, 3}));
        }

        [TestMethod]
        public void CanWinVertical()
        {
            Assert.AreEqual(true, _winCon.IsWin(new List<int> {1, 4, 5, 7}));
        }

        [TestMethod]
        public void CanWinDiagonal()
        {
            Assert.AreEqual(true, _winCon.IsWin(new List<int>{1,2,4,6}));
        }
    }
}
