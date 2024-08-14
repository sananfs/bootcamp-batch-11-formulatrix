namespace Chess;

public class GameController
{
	private Dictionary<Color, string> _players;
	private ChessBoard _chessBoard;
	private Color _currentTurn;
																																																										 GameStatus _status;

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
	
	public bool HasEverMoved(Piece piece)
	{
		return _hasMoved[piece.Color].Contains(piece);
	}
	
	public void MarkPieceAsMoved(Piece piece)
	{
		if (!_hasMoved[piece.Color].Contains(piece))
		{
			_hasMoved[piece.Color].Add(piece);
		}
	}

	public List<Location> PossibleRokade(IPlayer player, Piece king, ChessBoard board)
	{
		List<Location> possibleMoves = new List<Location>();

		if (king.PieceType != PieceType.King || HasEverMoved(king))
		{
			return possibleMoves;
		}

		var currentLocation = board.GetLocation(king);
		if (currentLocation == null)
		{
			return possibleMoves;
		}

		int shortRookX = 7;
		var shortRook = board.GetPiece(new Location(shortRookX, currentLocation.Y)) as Rook;
		if (shortRook != null && !HasEverMoved(shortRook))
		{
			bool isPathClear = true;
			for (int x = currentLocation.X + 1; x < shortRookX; x++)
			{
				if (board.IsOccupied(new Location(x, currentLocation.Y)))
				{
					isPathClear = false;
					break;
				}
			}
			if (isPathClear)
			{
				possibleMoves.Add(new Location(currentLocation.X + 2, currentLocation.Y));
			}
		}

		int longRookX = 0;
		var longRook = board.GetPiece(new Location(longRookX, currentLocation.Y)) as Rook;
		if (longRook != null && !HasEverMoved(longRook))
		{
			bool isPathClear = true;
			for (int x = longRookX + 1; x < currentLocation.X; x++)
			{
				if (board.IsOccupied(new Location(x, currentLocation.Y)))
				{
					isPathClear = false;
					break;
				}
			}
			if (isPathClear)
			{
				possibleMoves.Add(new Location(currentLocation.X - 2, currentLocation.Y));
			}
		}

		return possibleMoves;
	}

	public bool MoveShortRokade(IPlayer player, Piece king, Location destination, ChessBoard board)
	{
		var currentLocation = board.GetLocation(king);
		if (currentLocation == null || king.PieceType != PieceType.King)
		{
			return false;
		}

		var possibleMoves = PossibleRokade(player, king, board);
		if (possibleMoves.Contains(destination))
		{
			board.SetRokadeShort(king, this);
			return true;
		}

		return false;
	}

	public bool MoveLongRokade(IPlayer player, Piece king, Location destination, ChessBoard board)
	{
		var currentLocation = board.GetLocation(king);
		if (currentLocation == null || king.PieceType != PieceType.King)
		{
			return false;
		}

		var possibleMoves = PossibleRokade(player, king, board);
		if (possibleMoves.Contains(destination))
		{
			board.SetRokadeLong(king, this);
			return true;
		}

		return false;
	}

	public bool EndGame()
	{
		return _status == GameStatus.Check;
	}

	public Color CurrentTurn => _currentTurn;
}
