using System;
using System.Collections.Generic;

namespace Tic_Tac_Toe
{
    public class TestAIPlayer
    {
        private readonly IDetermineMove _moveDeterminer;
        private TestGame _game;

        public TestAIPlayer(IDetermineMove moveDeterminer, TestGame game)
        {
            _moveDeterminer = moveDeterminer;
            _game = game;

            _game.SomethingHappened += _game_SomethingHappened;
        }

        void _game_SomethingHappened(object sender, SomethingHappenedArgs args)
        {
            var turn = _moveDeterminer.GetPlayerMove(args.Board, args.TurnNumber, args.Player);
            _game.PlayTurn(turn);
        }
    }

    public class TestGame
    {
        private readonly IList<string> _messages;
        private readonly Guid _id;

        public event SomethingHappened SomethingHappened;

        protected virtual void OnSomethingHappened(SomethingHappenedArgs args)
        {
            var handler = SomethingHappened;
            if (handler != null) handler(this, args);
        }

        public TestGame(string message)
        {
            _messages = new List<string> {message};
            _id = Guid.NewGuid();
        }

        public IEnumerable<string> Messages
        {
            get { return _messages; }
        }

        public Guid Id
        {
            get { return _id; }
        }

        public void AddMessage(string message)
        {
            _messages.Add(message);
            var args = new SomethingHappenedArgs();
            OnSomethingHappened(args);
        }

        public void PlayTurn(object turn)
        {
            throw new NotImplementedException();
        }
    }

    public delegate void SomethingHappened(object sender, SomethingHappenedArgs args);

    public class SomethingHappenedArgs : EventArgs
    {
        public IPlayer Player { get; set; }
        public int TurnNumber { get; set; }
        public Board Board { get; set; }
    }
}