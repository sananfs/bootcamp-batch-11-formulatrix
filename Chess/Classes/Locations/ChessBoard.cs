namespace Chess;

public class ChessBoard
{
    public const int BoardSize = 8;

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

    public bool IsOccupied(Location location) => pieces[location.Y, location.X] != null;

    public Location GetLocation(Piece piece)
    {
        for (int x = 0; x < BoardSize; x++)
        {
            for (int y = 0; y < BoardSize; y++)
            {
                if (pieces[y, x] == piece)
                    return new Location(x, y);
            }
        }
        return null;
    }

    public Piece GetPiece(Location location) => pieces[location.Y, location.X];

    public void SetPlacePiece(Piece piece, Location destination)
    {
        var currentLocation = GetLocation(piece);
        if (currentLocation != null)
        {
            pieces[currentLocation.Y, currentLocation.X] = null;
        }
        pieces[destination.Y, destination.X] = piece;
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