namespace Chess;
public class GameController
{
    private Dictionary<Color, string> _players;
    private Color _currentTurn;
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
        _currentTurn = Color.White;
        _status = GameStatus.OnGoing;
        _listPieceRemove = new Dictionary<Color, List<Piece>>();
        _hasMoved = new Dictionary<Color, List<Piece>>();
    }

    public List<Location> PossibleMove(Color playerColor, Piece piece)
    {
        if (piece == null)
        {
            return new List<Location>();
        }

        var currentLocation = _chessBoard.GetLocation(piece);
        if (currentLocation == null)
        {
            return new List<Location>();
        }

        return piece.GetLegalMoves(_chessBoard, currentLocation);
    }

    public string MovePiece(Color playerColor, Piece piece, Location destination)
    {
        if (!_MovePieceValidator(playerColor, piece))
        {
            return "Pergerakan salah: bukan giliran anda.";
        }

        var currentLocation = _chessBoard.GetLocation(piece);
        if (currentLocation == null)
        {
            return "Pergerakan salah: bidak tidak ditemukan.";
        }

        var possibleMoves = PossibleMove(playerColor, piece);
        if (possibleMoves.Contains(destination))
        {
            var targetPiece = _chessBoard.GetPiece(destination);
            bool pieceCaptured = _RemovePieceHasEaten(playerColor, piece, targetPiece, destination);
            _chessBoard.SetPlacePiece(piece, destination);

            if (pieceCaptured)
            {
                OnPieceEaten?.Invoke(piece, destination);
                return _NotifyPiece(playerColor, piece, NotifyPiece.PieceRemoved, targetPiece);
            }
            else
            {
                OnPieceMove?.Invoke(piece, destination); 
                return _NotifyPiece(playerColor, piece, NotifyPiece.PieceMoved);
            }

            _PawnHasBeenUpgrade(playerColor, piece, destination);

            if (!_hasMoved.ContainsKey(playerColor))
            {
                _hasMoved[playerColor] = new List<Piece>();
            }
            _hasMoved[playerColor].Add(piece);

            EndTurn();
            return "Gerakan komplit.";
        }
        return "Pergerakan salah: tujuan tidak dapat dicapai.";
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
        int promotionRow = (piece.Color == Color.White) ? 7 : 0;
        return destination.Y == promotionRow;
    }

    private void _PawnHasBeenUpgrade(Color playerColor, Piece piece, Location destination)
    {
        if (_IsUpgradePawn(playerColor, piece, destination))
        {
            var queen = new Queen(piece.Id, piece.Color);
            _chessBoard.SetPlacePiece(queen, destination);
            OnPieceUpgraded?.Invoke(piece, destination); 
        }
    }

    private bool _MovePieceValidator(Color playerColor, Piece piece)
    {
        if (_status != GameStatus.OnGoing)
        {
            return false;
        }

        if (!_PieceHasPlayer(playerColor, piece))
        {
            return false;
        }

        if (_currentTurn != playerColor)
        {
            return false;
        }
        return true;
    }

    private bool _RemovePieceHasEaten(Color playerColor, Piece piece, Piece targetPiece, Location destination)
    {
        if (targetPiece == null)
        {
            return false;
        }

        if (targetPiece.Color != piece.Color)
        {
            if (!_listPieceRemove.ContainsKey(targetPiece.Color))
            {
                _listPieceRemove[targetPiece.Color] = new List<Piece>();
            }
            _listPieceRemove[targetPiece.Color].Add(targetPiece);
            _chessBoard.SetPlacePiece(null, destination);
            return true;
        }
        return false;
    }

    public GameStatus GetGameStatus()
    {
        return _status;
    }

    public bool EndGame()
    {
        if (_CheckMateGameOver())
        {
            _status = GameStatus.CheckMate;
            return true;
        }
        else if (_listPieceRemove[Color.White].Exists(piece => piece.PieceType == PieceType.King) ||
                 _listPieceRemove[Color.Black].Exists(piece => piece.PieceType == PieceType.King))
        {
            _status = GameStatus.CheckMate;
            return true;
        }
        return false;
    }

    private bool _CheckMateGameOver()
    {
        if (!_listPieceRemove.ContainsKey(Color.White) || !_listPieceRemove.ContainsKey(Color.Black))
        {
            return false;
        }

        var whiteKing = _listPieceRemove[Color.White].Find(piece => piece.PieceType == PieceType.King);
        var blackKing = _listPieceRemove[Color.Black].Find(piece => piece.PieceType == PieceType.King);

        if (whiteKing != null || blackKing != null)
        {
            return true;
        }

        if (_hasMoved.ContainsKey(Color.White) && _hasMoved.ContainsKey(Color.Black))
        {
            if (_hasMoved[Color.White].Count == 0 || _hasMoved[Color.Black].Count == 0)
            {
                return false;
            }

            if (_hasMoved[Color.White].Count + _hasMoved[Color.Black].Count >= 50)
            {
                return true;
            }
        }

        return false;
    }

    private string _NotifyPiece(Color playerColor, Piece piece, NotifyPiece notifyPiece, Piece targetPiece = null)
    {
        string message;
        switch (notifyPiece)
        {
            case NotifyPiece.PieceMoved:
                message = $"Pergerakan sukses: {piece.PieceType} telah bergerak.";
                break;
            case NotifyPiece.PieceRemoved:
                message = $"Pergerakan sukses: {piece.PieceType} dimakan {targetPiece.PieceType}.";
                break;
            default:
                message = "Gerakan tidak dikenali.";
                break;
        }

        return message;
    }

    private void EndTurn()
    {
        _currentTurn = _currentTurn == Color.White ? Color.Black : Color.White;
    }

    public Color CurrentTurn => _currentTurn;
}
