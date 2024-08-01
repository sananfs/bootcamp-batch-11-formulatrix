namespace Chess
{
    public class Queen : Piece
    {
        public Queen(int id, Color color) : base(id, color, PieceType.Queen) { }

        public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
        {
            var moves = new List<Location>();
            
            var rook = new Rook(Id, Color);
            var bishop = new Bishop(Id, Color);

            moves.AddRange(rook.GetLegalMoves(board, currentLocation));
            moves.AddRange(bishop.GetLegalMoves(board, currentLocation));

            return moves;
        }
    }
}
