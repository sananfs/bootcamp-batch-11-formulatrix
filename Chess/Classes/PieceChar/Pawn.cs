namespace Chess;

public class Pawn : Piece
{
    public Pawn(int id, Color color) : base(id, color, PieceType.Pawn) { }

    public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
    {
        var moves = new List<Location>();
        int direction = (Color == Color.White) ? 1 : -1;
        int startRow = (Color == Color.White) ? 1 : 6;

        int forwardX = currentLocation.X;
        int forwardY = currentLocation.Y + direction;

        if (forwardY >= 0 && forwardY < ChessBoard.BoardSize && !board.IsOccupied(new Location(forwardX, forwardY)))
        {
            moves.Add(new Location(forwardX, forwardY));

            if (currentLocation.Y == startRow)
            {
                int doubleForwardY = currentLocation.Y + 2 * direction;
                if (!board.IsOccupied(new Location(forwardX, doubleForwardY)) && !board.IsOccupied(new Location(forwardX, forwardY)))
                {
                    moves.Add(new Location(forwardX, doubleForwardY));
                }
            }
        }

        int[] captureOffsets = { -1, 1 };
        foreach (int offset in captureOffsets)
        {
            int captureX = currentLocation.X + offset;
            int captureY = currentLocation.Y + direction;

            if (captureX >= 0 && captureX < ChessBoard.BoardSize && captureY >= 0 && captureY < ChessBoard.BoardSize)
            {
                Piece target = board.GetPiece(new Location(captureX, captureY));
                if (target != null && target.Color != Color)
                {
                    moves.Add(new Location(captureX, captureY));
                }
            }
        }

        return moves;
    }
	
}
