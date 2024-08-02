namespace Chess;

public class King : Piece
{
	public King(int id, Color color) : base(id, color, PieceType.King) { }

	public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
	{
		var moves = new List<Location>();

		var possibleMoves = new List<Location>
			{
				new Location(currentLocation.X + 1, currentLocation.Y),
				new Location(currentLocation.X - 1, currentLocation.Y),
				new Location(currentLocation.X, currentLocation.Y + 1),
				new Location(currentLocation.X, currentLocation.Y - 1),
				new Location(currentLocation.X + 1, currentLocation.Y + 1),
				new Location(currentLocation.X + 1, currentLocation.Y - 1),
				new Location(currentLocation.X - 1, currentLocation.Y + 1),
				new Location(currentLocation.X - 1, currentLocation.Y - 1)
			};

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
