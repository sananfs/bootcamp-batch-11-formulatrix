namespace Chess;

public class Bishop : Piece
{
    public Bishop(int id, Color color) : base(id, color, PieceType.Bishop) { }

    public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
    {
        var moves = new List<Location>();
        int[] directions = { 1, 1, -1, 1, -1, -1, 1, -1 }; // Diagonals

        for (int i = 0; i < directions.Length; i += 2)
        {
            int dx = directions[i];
            int dy = directions[i + 1];
            int x = currentLocation.X;
            int y = currentLocation.Y;

            while (true)
            {
                x += dx;
                y += dy;

                if (x < 0 || x >= 8 || y < 0 || y >= 8)
                {
                    break; // Out of bounds
                }

                Piece target = board.GetPiece(new Location(x, y));
                if (target == null)
                {
                    moves.Add(new Location(x, y));
                }
                else
                {
                    if (target.Color != Color)
                    {
                        moves.Add(new Location(x, y)); // Capture
                    }
                    break; // Blocked by a piece
                }
            }
        }

        return moves;
    }
}
