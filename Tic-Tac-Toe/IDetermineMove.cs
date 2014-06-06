namespace Tic_Tac_Toe
{
    public interface IDetermineMove
    {
        int GetPlayerMove(Board board, int turnNumber, IPlayer turnPlayer);
    }
}
