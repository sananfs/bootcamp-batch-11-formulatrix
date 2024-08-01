namespace Chess
{
    public class Pawn : Piece
    {
        public Pawn(int id, Color color) : base(id, color, PieceType.Pawn) { }

        public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
        {
            var moves = new List<Location>();
            var possibleMoves = new List<Location>();
            int direction = Color == Color.White ? 1 : -1;

            possibleMoves.Add(new Location(currentLocation.X, currentLocation.Y + direction));

            if ((Color == Color.White && currentLocation.Y == 1) || (Color == Color.Black && currentLocation.Y == 6))
            {
                possibleMoves.Add(new Location(currentLocation.X, currentLocation.Y + 2 * direction));
            }

            possibleMoves.Add(new Location(currentLocation.X - 1, currentLocation.Y + direction));
            possibleMoves.Add(new Location(currentLocation.X + 1, currentLocation.Y + direction));

            foreach (var move in possibleMoves)
            {
                if (IsValidMove(board, move, currentLocation))
                {
                    moves.Add(move);
                }
            }

            return moves;
        }

        private bool IsValidMove(ChessBoard board, Location location, Location currentLocation)
        {
            if (location.X < 0 || location.X >= 8 || location.Y < 0 || location.Y >= 8)
            {
                return false;
            }
            
            if (location.X == currentLocation.X)
            {
                if (board.IsOccupied(location))
                {
                    return false;
                }
            }
            else
            {
                if (!board.IsOccupied(location))
                {
                    return false;
                }

                var pieceAtLocation = board.GetPiece(location);
                if (pieceAtLocation.Color == this.Color)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}
