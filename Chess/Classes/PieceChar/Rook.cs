namespace Chess;

public class Rook : Piece
{
	public Rook(int id, Color color) : base(id, color, PieceType.Rook) { }

	public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
	{
		var moves = new List<Location>();
		var possibleMoves = new List<Location>();
		for (int i = 1; i < 8; i++)
		{
			possibleMoves.Add(new Location(currentLocation.X, currentLocation.Y + i));
			possibleMoves.Add(new Location(currentLocation.X, currentLocation.Y - i));
			possibleMoves.Add(new Location(currentLocation.X - i, currentLocation.Y));
			possibleMoves.Add(new Location(currentLocation.X + i, currentLocation.Y));
		}

		foreach (var move in possibleMoves)
		{
			if (IsValidMove(board, move))
			{
				moves.Add(move);
			}
		}

		return moves;
	}

	private bool IsValidMove(ChessBoard board, Location location)
	{
		if (location.X < 0 || location.X >= 8 || location.Y < 0 || location.Y >= 8)
		{
			return false;
		}
		var pieceAtLocation = board.GetPiece(location);
		return pieceAtLocation == null || pieceAtLocation.Color != this.Color;
	}
}
