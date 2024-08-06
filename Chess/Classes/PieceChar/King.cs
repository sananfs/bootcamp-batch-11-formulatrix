namespace Chess;

public class King : Piece
{
    public King(int id, Color color) : base(id, color, PieceType.King) { }

    public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
    {
        var moves = new List<Location>();
        int[] dx = { 1, 1, 1, 0, 0, -1, -1, -1 };
        int[] dy = { 1, 0, -1, 1, -1, 1, 0, -1 };

        for (int i = 0; i < dx.Length; i++)
        {
            int x = currentLocation.X + dx[i];
            int y = currentLocation.Y + dy[i];

            if (x >= 0 && x < 8 && y >= 0 && y < 8)
            {
                Piece target = board.GetPiece(new Location(x, y));
                if (target == null || target.Color != Color)
                {
                    moves.Add(new Location(x, y));
                }
            }
        }

        return moves;
    }
}
