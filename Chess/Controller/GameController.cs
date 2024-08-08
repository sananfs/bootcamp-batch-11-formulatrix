using System;
using System.Collections.Generic;

namespace Chess;

public class GameController
{
    private Dictionary<Color, string> _players;
    private ChessBoard _chessBoard;
    private Color _currentTurn;
    private GameStatus _status;

    private Dictionary<Color, List<Piece>> _piecesRemoved;
    private Dictionary<Color, List<Piece>> _hasMoved;

    public Action<Piece, Location> OnPieceEaten;
    public Action<Piece, Location> OnPieceMoved;
    public Action<Piece, Location> OnPieceUpgraded;

    public GameController(Dictionary<Color, string> players, ChessBoard chessBoard)
    {
        _players = players;
        _chessBoard = chessBoard;
        _currentTurn = Color.White;
        _status = GameStatus.OnGoing;
        _piecesRemoved = new Dictionary<Color, List<Piece>>
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

    public bool CanMovePiece(Color playerColor, Piece selectedPiece, out List<Location> possibleMoves, out string message)
    {
        possibleMoves = null;
        message = string.Empty;

        if (selectedPiece == null)
        {
            message = "Tidak ada bidak.";
            return false;
        }

        if (selectedPiece.Color != playerColor)
        {
            message = "Anda hanya bisa menggerakan bidak milik sendiri.";
            return false;
        }

        var currentLocation = _chessBoard.GetLocation(selectedPiece);
        possibleMoves = selectedPiece.GetLegalMoves(_chessBoard, currentLocation);

        if (possibleMoves.Count == 0)
        {
            message = "Bidak tidak bisa bergerak.";
            return false;
        }

        return true;
    }

    public bool MovePiece(Color playerColor, Piece selectedPiece, Location destination)
    {
        if (selectedPiece.Color != playerColor)
        {
            return false;
        }

        var currentLocation = _chessBoard.GetLocation(selectedPiece);
        var legalMoves = selectedPiece.GetLegalMoves(_chessBoard, currentLocation);

        if (!legalMoves.Contains(destination))
        {
            return false;
        }

        _chessBoard.SetPlacePiece(selectedPiece, destination);

        if (IsCheck(_currentTurn))
        {
            _status = GameStatus.Check;
        }
        else
        {
            _status = GameStatus.OnGoing;
        }

        _currentTurn = _currentTurn == Color.White ? Color.Black : Color.White;

        if (IsUpgradePawn(selectedPiece, destination))
        {
            UpgradePawn(selectedPiece, destination);
        }

        return true;
    }

    private bool IsCheck(Color kingColor)
    {
        Location kingLocation = null;

        for (int x = 0; x < ChessBoard.BoardSize; x++)
        {
            for (int y = 0; y < ChessBoard.BoardSize; y++)
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
        for (int x = 0; x < ChessBoard.BoardSize; x++)
        {
            for (int y = 0; y < ChessBoard.BoardSize; y++)
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

    private bool IsUpgradePawn(Piece piece, Location location)
    {
        if (piece == null || piece.PieceType != PieceType.Pawn)
        {
            return false;
        }

        return (piece.Color == Color.White && location.Y == ChessBoard.BoardSize - 1) ||
               (piece.Color == Color.Black && location.Y == 0);
    }

    private void UpgradePawn(Piece piece, Location location)
    {
        if (piece == null || piece.PieceType != PieceType.Pawn)
        {
            return;
        }

        var playerColor = piece.Color;
        var idxPiece = _piecesRemoved[playerColor].Count;

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

        _piecesRemoved[playerColor].Add(piece);
        _chessBoard.SetPlacePiece(upgradedPiece, location);
        OnPieceUpgraded?.Invoke(upgradedPiece, location);
    }

    public bool EndGame()
    {
        return _status == GameStatus.Check;
    }

    public Color CurrentTurn => _currentTurn;
}
