namespace Chess;

public abstract class Piece
{
	public int Id { get; }
	public Color Color { get; }
	public PieceType PieceType { get; }
	public bool IsActive { get; private set; }

	public Piece(int id, Color color, PieceType pieceType)
	{
		Id = id;
		Color = color;
		PieceType = pieceType;
		IsActive = true;
	}

	public abstract List<Location> GetLegalMoves(ChessBoard board, Location currentLocation);
	public void ChangeStatusActive() => IsActive = !IsActive;
}
