namespace Tic_Tac_Toe
{
    public class GameController
    {
        private IWinCondition _winner;
        private IPlayer _player1;
        private IPlayer _player2;
        private ITicTacToeIO _gameIO;

        private Board _gameBoard;
        private int _turnNumber;
        private IPlayer _currentTurnPlayer;
        private string _feedback;
        private const string WinString = "Victory!!";
        private const string LoseString = "Draw!";

        public string Feedback { get { return _feedback; } }

        public GameController(IWinCondition winner, IPlayer player1, IPlayer player2, ITicTacToeIO gameIO)
        {
            _winner = winner;
            _player1 = player1;
            _player2 = player2;
            _gameIO = gameIO;
            _gameBoard = new Board();
        }

        public bool Run()
        {
            SetupGame();
            while (!EndOfGame())
            {
                PrintBoard();
                var guess = GetGuess();
                SaveGuess(guess);
                PrintBoard();
                if (CheckWin()) break;
                IncrementTurnNumber();
                SwitchPlayers();
            }
            return Rematch();
        }

        public void SetupGame()
        {
            _gameIO.PrintRules();
            _player1.Symbol = "X";
            _player2.Symbol = "O";
            _currentTurnPlayer = _player1;
            _turnNumber = 1;
        }

        private bool EndOfGame()
        {
            if (_player1.Positions.Count + _player2.Positions.Count == 9)
            {
                _feedback = LoseString;
                _gameIO.PrintLoseGame();
                return true;
            }
            return false;
        }

        private void PrintBoard()
        {
            _gameIO.PrintGameBoard(_gameBoard);
        }

        private int GetGuess()
        {
            return _currentTurnPlayer.MakeMove(_gameBoard, _turnNumber, _currentTurnPlayer);
        }

        private void SaveGuess(int guess)
        {
            _gameBoard.UpdateBoard(guess, _currentTurnPlayer.Symbol);
            _currentTurnPlayer.AddPosition(guess);
        }

        private bool CheckWin()
        {
            if(_winner.IsWin(_currentTurnPlayer.Positions))
            {
                _gameIO.PrintVictoryString(_currentTurnPlayer);
                _feedback = WinString;
                return true;
            }
            return false;
        }

        private void IncrementTurnNumber()
        {
            _turnNumber++;
        }

        private void SwitchPlayers()
        {
            _currentTurnPlayer = _currentTurnPlayer.Symbol == "X" ? _player2 : _player1;
        }

        private bool Rematch()
        {
            var response = _gameIO.GetRematchResponse();
            if (response == "Y")
                return true;
            return false;
        }
    };
}
