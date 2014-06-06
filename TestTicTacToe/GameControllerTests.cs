using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tic_Tac_Toe;

namespace TestTicTacToe
{
    [TestClass]
    public class GameControllerTests
    {
        private GameController _gameCon;
        private FakeHumanPlayer _humanPlayer;
        private FakeAiPlayer _aiPlayer;

        [TestInitialize]
        public void SetUp()
        {
            var hmm = new HumanConsoleMakeMove();
            var aimm = new AIMakeMove();
            _gameCon = new GameController(new WinCondition(), new HumanPlayer(hmm),new AIPlayer(aimm), new FakeConsoleIO());
        }

        [TestMethod]
        public void CanWin()
        {
            _humanPlayer = new FakeHumanPlayer(new List<int>{0,1,2});
            _aiPlayer = new FakeAiPlayer(new List<int> {3});
            _gameCon = new GameController(new WinCondition(), _humanPlayer, _aiPlayer, new FakeConsoleIO());
            _gameCon.Run();
            Assert.AreEqual("Victory!!", _gameCon.Feedback);
        }

        [TestMethod]
        public void CanDraw()
        {
            _humanPlayer = new FakeHumanPlayer(new List<int> { 0, 1, 5, 6, 7 });
            _aiPlayer = new FakeAiPlayer(new List<int> { 2, 3, 4, 8 });
            _gameCon = new GameController(new WinCondition(), _humanPlayer, _aiPlayer, new FakeConsoleIO());
            _gameCon.Run();
            Assert.AreEqual("Draw!", _gameCon.Feedback);
        }
    }
}
