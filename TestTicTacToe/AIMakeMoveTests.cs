using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe;

namespace TestTicTacToe
{
    [TestClass]
    public class AIMakeMoveTests
    {
        private AIMakeMove _computer;
        private AIPlayer aiP;


        
        [TestInitialize]
        public void Setup()
        {
            _computer = new AIMakeMove();
            aiP = new AIPlayer(_computer);
            aiP.Symbol = "O";
        }

        [TestMethod]
        public void CanGoFirst()
        {
            Assert.AreEqual(0, _computer.GetPlayerMove(new Board(), 1, aiP));
        }

        [TestMethod]
        public void CanGoSecondWithMiddleOpen()
        {
            Assert.AreEqual(4, _computer.GetPlayerMove(new Board(new List<string> { "X", "2", "3", "4", "5", "6", "7", "8", "9" }), 2, aiP));
        }

        [TestMethod]
        public void CanGoSecondWithMiddleTaken()
        {
            var corners = new List<int> {0, 2, 6, 8};
            Assert.IsTrue(corners.Contains(_computer.GetPlayerMove(new Board(new List<string> { "1", "2", "3", "4", "X", "6", "7", "8", "9" }), 2, aiP)));
        }

        [TestMethod]
        public void CanBlockHorizontal()
        {
            Assert.AreEqual(3, _computer.GetPlayerMove(new Board(new List<string> { "O", "2", "3", "4", "X", "X", "7", "8", "9" }), 4, aiP));
        }

        [TestMethod]
        public void CanBlockVertical()
        {
            Assert.AreEqual(1, _computer.GetPlayerMove(new Board(new List<string> { "O", "2", "3", "4", "X", "6", "7", "X", "9" }), 3, aiP));
        }

        [TestMethod]
        public void CanBlockDiaganol()
        {
            Assert.AreEqual(6, _computer.GetPlayerMove(new Board(new List<string> { "O", "2", "X", "4", "X", "6", "7", "8", "9" }), 4, aiP));
        }

        [TestMethod]
        public void CanBlockMultipleTimes()
        {
            Assert.AreEqual(7, _computer.GetPlayerMove(new Board(new List<string> { "O", "2", "3", "X", "O", "6", "X", "8", "X" }), 6, aiP));
        }

        [TestMethod]
        public void CanBlockCorner()
        {
            Assert.AreEqual(6, _computer.GetPlayerMove(new Board(new List<string> { "1", "2", "3", "X", "O", "6", "7", "X", "9" }), 4, aiP));
        }

        [TestMethod]
        public void CanPremtivelyBlock()
        {
            Assert.AreEqual(5, _computer.GetPlayerMove(new Board(new List<string> { "1", "2", "X", "4", "O", "6", "7", "X", "9" }), 4, aiP));
        }

        [TestMethod]
        public void CanStopCheating()
        {
            Assert.AreEqual(7, _computer.GetPlayerMove(new Board(new List<string> { "1", "X", "O", "O", "O", "X", "X", "8", "X" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlockInCorrectOrder()
        {
            Assert.AreEqual(7, _computer.GetPlayerMove(new Board(new List<string> { "O", "X", "O", "4", "X", "6", "X", "8", "9" }), 6, aiP));
        }

        [TestMethod]
        public void CanForceBlock()
        {
            Assert.AreEqual(2, _computer.GetPlayerMove(new Board(new List<string> { "O", "2", "3", "4", "X", "6", "7", "8", "X" }), 4, aiP));
        }

        [TestMethod]
        public void CanBlockOppositeCorners()
        {
            Assert.AreEqual(3, _computer.GetPlayerMove(new Board(new List<string> { "X", "2", "3", "4", "O", "6", "7", "8", "X" }), 4, aiP));
        }

        [TestMethod]
        public void CanBlock28OnTurn8()
        {
            Assert.AreEqual(5, _computer.GetPlayerMove(new Board(new List<string> { "X", "O", "X", "4", "O", "6", "O", "X", "X" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlock45OnTurn6()
        {
            Assert.AreEqual(3, _computer.GetPlayerMove(new Board(new List<string> { "O", "X", "3", "4", "X", "X", "7", "O", "9" }), 6, aiP));
        }

        [TestMethod]
        public void CanBlock34OnTurn6WithRandom()
        {
            Assert.AreEqual(5, _computer.GetPlayerMove(new Board(new List<string> { "1", "X", "O", "X", "X", "6", "7", "O", "9" }), 6, aiP));
        }

        [TestMethod]
        public void CanWin86OnTurn8()
        {
            Assert.AreEqual(2, _computer.GetPlayerMove(new Board(new List<string> { "1", "X", "3", "X", "X", "O", "X", "O", "O" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlockTroysWin()
        {
            Assert.AreEqual(6, _computer.GetPlayerMove(new Board(new List<string> { "O", "X", "X", "X", "X", "O", "7", "O", "9" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlockTroysWinOpposite()
        {
            Assert.AreEqual(8, _computer.GetPlayerMove(new Board(new List<string> { "X", "X", "O", "O", "X", "X", "7", "O", "9" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlockTroysWinOppositeOnTop()
        {
            Assert.AreEqual(0, _computer.GetPlayerMove(new Board(new List<string> { "1", "O", "3", "X", "X", "O", "O", "X", "X" }), 8, aiP));
        }

        [TestMethod]
        public void CanBlockTroysWinOnTop()
        {
            Assert.AreEqual(2, _computer.GetPlayerMove(new Board(new List<string> { "1", "O", "3", "O", "X", "X", "X", "X", "O" }), 8, aiP));
        }
    }
}
