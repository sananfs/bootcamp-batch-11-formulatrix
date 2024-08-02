namespace Chess;

public class GameController
{
    private Dictionary<Color, IPlayer> _players;
    private Color _currentTurn;
    private GameStatus _status;
    private ChessBoard _chessBoard;
    private Dictionary<IPlayer, List<Piece>> _listPieceRemove;
    private Dictionary<IPlayer, List<Piece>> _hasMoved;

    public Action<Piece, Location> OnPieceEaten;
    public Action<Piece, Location> OnPieceMove;
    public Action<Piece, Location> OnPieceUpgraded;

    public GameController(Dictionary<Color, IPlayer> players, ChessBoard chessBoard)
    {
        _players = players;
        _chessBoard = chessBoard;
        _currentTurn = Color.White;
        _status = GameStatus.OnGoing;
        _listPieceRemove = new Dictionary<IPlayer, List<Piece>>();
        _hasMoved = new Dictionary<IPlayer, List<Piece>>();
    }

    public List<Location> PossibleMove(IPlayer player, Piece piece)
    {
        if (piece == null || player == null)
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

    public string MovePiece(IPlayer player, Piece piece, Location destination)
    {
        if (!_MovePieceValidator(player, piece))
        {
            return "Invalid move: not your turn.";
        }

        var currentLocation = _chessBoard.GetLocation(piece);
        if (currentLocation == null)
        {
            return "Invalid move: piece not found.";
        }

        var possibleMoves = PossibleMove(player, piece);
        if (possibleMoves.Contains(destination))
        {
            var targetPiece = _chessBoard.GetPiece(destination);
            bool pieceCaptured = _RemovePieceHasEaten(player, piece, targetPiece, destination);
            _chessBoard.SetPlacePiece(piece, destination);

            if (pieceCaptured)
            {
                OnPieceEaten?.Invoke(piece, destination);
                return _NotifyPiece(player, piece, NotifyPiece.PieceRemoved, targetPiece);
            }
            else
            {
                OnPieceMove?.Invoke(piece, destination); 
                return _NotifyPiece(player, piece, NotifyPiece.PieceMoved);
            }

            _PawnHasBeenUpgrade(player, piece, destination);

            if (!_hasMoved.ContainsKey(player))
            {
                _hasMoved[player] = new List<Piece>();
            }
            _hasMoved[player].Add(piece);

            EndTurn();
            return "Move completed.";
        }
        return "Invalid move: destination not reachable.";
    }

    private bool _PieceHasPlayer(IPlayer player, Piece piece)
    {
        if (player == null || piece == null)
        {
            return false;
        }

        Color pieceColor = piece.Color;
        var playerColor = _players.FirstOrDefault(p => p.Value == player).Key;
        return playerColor == pieceColor;
    }

    private Piece _ChooseYourPiece(IPlayer player, Piece piece)
    {
        if (player == null || piece == null)
        {
            return null;
        }
        if (_PieceHasPlayer(player, piece))
        {
            return piece;
        }
        return null;
    }

    private bool _IsUpgradePawn(IPlayer player, Piece piece, Location destination)
    {
        if (player == null || piece == null)
        {
            return false;
        }
        if (piece.PieceType != PieceType.Pawn)
        {
            return false;
        }
        Color pieceColor = piece.Color;
        int promotionRow = (pieceColor == Color.White) ? 7 : 0;
        return destination.Y == promotionRow;
    }

    private void _PawnHasBeenUpgrade(IPlayer player, Piece piece, Location destination)
    {
        if (_IsUpgradePawn(player, piece, destination))
        {
            var queen = new Queen(piece.Id, piece.Color);
            _chessBoard.SetPlacePiece(queen, destination);
            OnPieceUpgraded?.Invoke(piece, destination); 
            _NotifyPiece(player, piece, NotifyPiece.PieceUpgraded);
        }
    }

    private bool _MovePieceValidator(IPlayer player, Piece piece)
    {
        if (player == null || piece == null)
        {
            return false;
        }
        return _currentTurn == piece.Color;
    }

    private bool _PieceHasCheck(IPlayer player, Piece piece)
    {
        if (player == null || piece == null)
        {
            return false;
        }

        var opponentKingLocation = _chessBoard.GetLocation(_chessBoard.GetChessBoard()
            .Cast<Piece>()
            .FirstOrDefault(p => p != null && p.PieceType == PieceType.King && p.Color != piece.Color));

        if (opponentKingLocation != null)
        {
            var legalMoves = piece.GetLegalMoves(_chessBoard, _chessBoard.GetLocation(piece));
            return legalMoves.Contains(opponentKingLocation);
        }

        return false;
    }

    private bool _HasEverMoved(Piece piece)
    {
        if (piece == null)
        {
            return false;
        }

        return _hasMoved.Values.Any(movedPieces => movedPieces.Contains(piece));
    }

    private string _NotifyPiece(IPlayer player, Piece piece, NotifyPiece notifyPiece, Piece targetPiece = null)
    {
        string actionMessage = notifyPiece switch
        {
            NotifyPiece.PieceMoved => $"{piece.PieceType} moved to {piece.Color}",
            NotifyPiece.PieceRemoved => $"{piece.PieceType} captured {targetPiece?.PieceType}",
            NotifyPiece.PieceUpgraded => $"{piece.PieceType} promoted to Queen",
            _ => "Unknown action"
        };

        return $"Player {player}: {actionMessage}";
    }

    private bool _RemovePieceHasEaten(IPlayer player, Piece piece, Piece targetPiece, Location location)
    {
        if (targetPiece != null && targetPiece.Color != piece.Color)
        {
            var opponent = _players.FirstOrDefault(p => p.Key != piece.Color).Value;

            if (!_listPieceRemove.ContainsKey(opponent))
            {
                _listPieceRemove[opponent] = new List<Piece>();
            }

            _listPieceRemove[opponent].Add(targetPiece);

            _chessBoard.GetChessBoard()[location.X, location.Y] = null;
            return true;
        }
        return false;
    }

    public bool NextTurn()
    {
        _currentTurn = _currentTurn == Color.White ? Color.Black : Color.White;
        return true;
    }

    public string EndTurn()
    {
        if (IsCheck())
        {
            _status = GameStatus.Check;
            EndGame();
            return "Check! Game over.";
        }
        else
        {
            _status = GameStatus.OnGoing;
            NextTurn();
            return "Turn ended.";
        }
    }

    private bool IsCheck()
    {
        foreach (var player in _players.Values)
        {
            foreach (var piece in _chessBoard.GetChessBoard())
            {
                if (piece != null && piece.Color == _currentTurn && _PieceHasCheck(player, piece))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public bool EndGame()
    {
        return true;
    }
}
