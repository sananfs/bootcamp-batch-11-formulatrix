namespace Chess;

public class ChessBoard
{
    private Piece[,] pieces = new Piece[8, 8];

    public ChessBoard(Piece[,] piece) => this.pieces = piece;

    public Piece[,] GetChessBoard() => pieces;

    public bool IsOccupied(Location location) => pieces[location.X, location.Y] != null;

    public Location GetLocation(Piece piece)
    {
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (pieces[x, y] == piece)
                    return new Location(x, y);
            }
        }
        return null;
    }

    public Piece GetPiece(Location location) => pieces[location.X, location.Y];

    public void SetRokadeShort(Piece piece) { /* rokade */ }
    public void SetRokadeLong(Piece piece) { }
    public void SetPlacePiece(Piece piece, Location destination)
    {
        var currentLocation = GetLocation(piece);
        pieces[currentLocation.X, currentLocation.Y] = null;
        pieces[destination.X, destination.Y] = piece;
    }
}
