namespace Chess;

public class ChessBoard
{
	public const int BoardSize = 8;  // Ukuran papan 8x8

	private Piece[,] pieces = new Piece[BoardSize, BoardSize];

	public ChessBoard(Piece[,] initialPieces)
	{
		if (initialPieces.GetLength(0) != BoardSize || initialPieces.GetLength(1) != BoardSize)
		{
			throw new ArgumentException("Ukuran papan tidak sesuai.");
		}

		pieces = initialPieces;
	}

	public Piece[,] GetChessBoard() => pieces;

	public bool IsOccupied(Location location) => pieces[location.X, location.Y] != null;

	public Location GetLocation(Piece piece)
	{
		for (int x = 0; x < BoardSize; x++)
		{
			for (int y = 0; y < BoardSize; y++)
			{
				if (pieces[x, y] == piece)
					return new Location(x, y);
			}
		}
		return null;
	}

	public Piece GetPiece(Location location) => pieces[location.X, location.Y];

	public void SetPlacePiece(Piece piece, Location destination)
	{
		var currentLocation = GetLocation(piece);
		if (currentLocation != null)
		{
			pieces[currentLocation.X, currentLocation.Y] = null;
		}
		pieces[destination.X, destination.Y] = piece;
	}

	public void SetInitialSetup(Piece[,] initialPieces)
	{
		if (initialPieces.GetLength(0) != BoardSize || initialPieces.GetLength(1) != BoardSize)
		{
			throw new ArgumentException("Ukuran papan tidak sesuai.");
		}
		pieces = initialPieces;
	}
}
