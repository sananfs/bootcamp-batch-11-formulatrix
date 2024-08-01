namespace Chess;

public class Knight : Piece
{
    public Knight(int id, Color color) : base(id, color, PieceType.Knight) { }

    public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
    {
        var moves = new List<Location>();
        var possibleMoves = new List<Location>
        {
            new Location(currentLocation.X + 2, currentLocation.Y + 1),
            new Location(currentLocation.X + 2, currentLocation.Y - 1),
            new Location(currentLocation.X - 2, currentLocation.Y + 1),
            new Location(currentLocation.X - 2, currentLocation.Y - 1),
            new Location(currentLocation.X + 1, currentLocation.Y + 2),
            new Location(currentLocation.X + 1, currentLocation.Y - 2),
            new Location(currentLocation.X - 1, currentLocation.Y + 2),
            new Location(currentLocation.X - 1, currentLocation.Y - 2),
        };

        foreach (var move in possibleMoves)
        {
            if (move.X >= 0 && move.X < 8 && move.Y >= 0 && move.Y < 8)
            {
                var pieceAtLocation = board.GetPiece(move);
                if (pieceAtLocation == null || pieceAtLocation.Color != this.Color)
                {
                    moves.Add(move);
                }
            }
        }

        return moves;
    }
}
