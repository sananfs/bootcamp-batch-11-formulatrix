namespace Chess;

public class Pawn : Piece
{
    public Pawn(int id, Color color) : base(id, color, PieceType.Pawn) { }

    public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
    {
        var moves = new List<Location>();
        int direction = Color == Color.White ? 1 : -1;

        int forwardX = currentLocation.X;
        int forwardY = currentLocation.Y + direction;
        if (forwardY >= 0 && forwardY < 8)
        {
            if (!board.IsOccupied(new Location(forwardX, forwardY)))
            {
                moves.Add(new Location(forwardX, forwardY));

                int startRow = Color == Color.White ? 1 : 6;
                int doubleForwardY = currentLocation.Y + 2 * direction;
                if (currentLocation.Y == startRow && !board.IsOccupied(new Location(forwardX, doubleForwardY)))
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
            if (captureX >= 0 && captureX < 8 && captureY >= 0 && captureY < 8)
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
