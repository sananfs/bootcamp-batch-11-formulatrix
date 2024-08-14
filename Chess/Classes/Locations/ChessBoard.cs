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

    public void SetRokadeShort(Piece king, GameController gameController)
    {
        var currentLocation = GetLocation(king);
        if (king.PieceType != PieceType.King || currentLocation == null)
        {
            throw new InvalidOperationException("Bidak bukan raja atau lokasi raja tidak ditemukan.");
        }

        int rookX = 7;
        int rookY = currentLocation.Y;
        var rook = pieces[rookY, rookX] as Rook;

        if (rook == null || 
            gameController.HasEverMoved(king) || 
            gameController.HasEverMoved(rook))
        {
            throw new InvalidOperationException("Raja atau menara sudah pernah bergerak.");
        }

        for (int x = currentLocation.X + 1; x < rookX; x++)
        {
            if (pieces[rookY, x] != null)
            {
                throw new InvalidOperationException("Jalur rokade tidak kosong.");
            }
        }

        SetPlacePiece(king, new Location(currentLocation.X + 2, currentLocation.Y));

        SetPlacePiece(rook, new Location(currentLocation.X + 1, currentLocation.Y));

        gameController.MarkPieceAsMoved(king);
        gameController.MarkPieceAsMoved(rook);
    }

    public void SetRokadeLong(Piece king, GameController gameController)
    {
        var currentLocation = GetLocation(king);
        if (king.PieceType != PieceType.King || currentLocation == null)
        {
            throw new InvalidOperationException("Bidak bukan raja atau lokasi raja tidak ditemukan.");
        }

        int rookX = 0;
        int rookY = currentLocation.Y;
        var rook = pieces[rookY, rookX] as Rook;

        if (rook == null || 
            gameController.HasEverMoved(king) || 
            gameController.HasEverMoved(rook))
        {
            throw new InvalidOperationException("Raja atau menara sudah pernah bergerak.");
        }

        for (int x = rookX + 1; x < currentLocation.X; x++)
        {
            if (pieces[rookY, x] != null)
            {
                throw new InvalidOperationException("Jalur rokade tidak kosong.");
            }
        }

        SetPlacePiece(king, new Location(currentLocation.X - 2, currentLocation.Y));

        SetPlacePiece(rook, new Location(currentLocation.X - 1, currentLocation.Y));

        gameController.MarkPieceAsMoved(king);
        gameController.MarkPieceAsMoved(rook);
    }
}
