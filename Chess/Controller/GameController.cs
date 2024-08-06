namespace Chess;
public class GameController
{
    private Dictionary<Color, string> _players;
    public Color CurrentTurn { get; private set; }
    private GameStatus _status;
    private ChessBoard _chessBoard;
    private Dictionary<Color, List<Piece>> _listPieceRemove;
    private Dictionary<Color, List<Piece>> _hasMoved;

    public Action<Piece, Location> OnPieceEaten;
    public Action<Piece, Location> OnPieceMove;
    public Action<Piece, Location> OnPieceUpgraded;

    public GameController(Dictionary<Color, string> players, ChessBoard chessBoard)
    {
        _players = players;
        _chessBoard = chessBoard;
        CurrentTurn = Color.White;
        _status = GameStatus.OnGoing;
        _listPieceRemove = new Dictionary<Color, List<Piece>>
            {
                { Color.White, new List<Piece>() },
                { Color.Black, new List<Piece>() }
            };

        _hasMoved = new Dictionary<Color, List<Piece>>
            {
                { Color.White, new List<Piece>() },
                { Color.Black, new List<Piece>() }
            };
    }

    public (bool success, List<Location> possibleMoves, string message) PossibleMove(Color playerColor, Piece selectedPiece)
    {
        if (selectedPiece == null)
        {
            return (false, null, "Tidak ada bidak.");
        }

        if (selectedPiece.Color != playerColor)
        {
            return (false, null, "Anda hanya bisa menggerakan bidak milik sendiri.");
        }

        var currentLocation = _chessBoard.GetLocation(selectedPiece);
        var possibleMoves = selectedPiece.GetLegalMoves(_chessBoard, currentLocation);

        if (possibleMoves.Count == 0)
        {
            return (false, null, "bidak tidak mungkin bergerak.");
        }

        return (true, possibleMoves, string.Empty);
    }


    public string MovePiece(Color playerColor, Piece selectedPiece, Location destination)
    {
        if (selectedPiece.Color != playerColor)
        {
            return "Error: Bukan giliran Anda.";
        }

        var currentLocation = _chessBoard.GetLocation(selectedPiece);
        var legalMoves = selectedPiece.GetLegalMoves(_chessBoard, currentLocation) ?? new List<Location>();

        if (!legalMoves.Contains(destination))
        {
            return "Error: Gerakan tidak dapat dicapai.";
        }

        _chessBoard.SetPlacePiece(selectedPiece, destination);

        if (_PieceHasCheck(CurrentTurn))
        {
            _status = GameStatus.Check;
        }
        else
        {
            _status = GameStatus.OnGoing;
        }

        CurrentTurn = CurrentTurn == Color.White ? Color.Black : Color.White;
        return "Pergerakan sukses.";
    }


    private bool _PieceHasPlayer(Color playerColor, Piece piece)
    {
        if (piece == null)
        {
            return false;
        }

        return playerColor == piece.Color;
    }

    private Piece _ChooseYourPiece(Color playerColor, Piece piece)
    {
        if (_PieceHasPlayer(playerColor, piece))
        {
            return piece;
        }
        return null;
    }

    private bool _IsUpgradePawn(Color playerColor, Piece piece, Location destination)
    {
        if (piece == null)
        {
            return false;
        }
        if (piece.PieceType != PieceType.Pawn)
        {
            return false;
        }
        if (piece.Color == Color.White && destination.X == 7)
        {
            return true;
        }
        if (piece.Color == Color.Black && destination.X == 0)
        {
            return true;
        }
        return false;
    }

    private bool _PieceHasCheck(Color kingColor)
    {
        Location kingLocation = null;

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = _chessBoard.GetPiece(new Location(x, y));
                if (piece != null && piece.Color == kingColor && piece.PieceType == PieceType.King)
                {
                    kingLocation = new Location(x, y);
                    break;
                }
            }
        }

        if (kingLocation == null) return false;

        Color opponentColor = kingColor == Color.White ? Color.Black : Color.White;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                Piece piece = _chessBoard.GetPiece(new Location(x, y));
                if (piece != null && piece.Color == opponentColor)
                {
                    var moves = piece.GetLegalMoves(_chessBoard, new Location(x, y));
                    if (moves.Contains(kingLocation))
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    public bool EndGame()
    {
        if (_status == GameStatus.Check)
        {
            return true;
        }
        return false;
    }


    private void _IsUpgradePawn(Piece piece, Location location)
    {
        if (piece == null)
        {
            return;
        }

        if (piece.PieceType == PieceType.Pawn)
        {
            var pieceRemove = _ChooseYourPiece(piece.Color, piece);
            if (pieceRemove == null)
            {
                return;
            }

            var playerColor = piece.Color;
            var idxPiece = _listPieceRemove[playerColor].Count;

            Console.WriteLine("Bidak naik pangkat! Pilih pengganti (Q/R/B/N):");
            string upgradeChoice = Console.ReadLine().ToUpper();

            Piece upgradedPiece = upgradeChoice switch
            {
                "Q" => new Queen(idxPiece, playerColor),
                "R" => new Rook(idxPiece, playerColor),
                "B" => new Bishop(idxPiece, playerColor),
                "N" => new Knight(idxPiece, playerColor),
                _ => new Queen(idxPiece, playerColor)
            };

            _listPieceRemove[playerColor].Add(pieceRemove);
            _chessBoard.SetPlacePiece(upgradedPiece, location);
            OnPieceUpgraded?.Invoke(upgradedPiece, location);
        }
    }
}