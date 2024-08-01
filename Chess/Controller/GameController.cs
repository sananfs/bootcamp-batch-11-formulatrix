namespace Chess
{
	public class GameController
	{
		private Dictionary<Color, IPlayer> _players;
		private Color _currentTurn;
		private GameStatus _status;
		private ChessBoard _chessBoard;
		private Dictionary<IPlayer, List<Piece>> _listPieceRemove;
		private Dictionary<IPlayer, List<Piece>> _hasMoved;

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

		public bool MovePiece(IPlayer player, Piece piece, Location destination)
		{
			var currentLocation = _chessBoard.GetLocation(piece);
			if (currentLocation == null) 
			{
				return false;
			}

			var possibleMoves = PossibleMove(player, piece);
			if (possibleMoves.Contains(destination))
			{
				_chessBoard.SetPlacePiece(piece, destination);
				return true;
			}
			return false;
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
				return null ;
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
			int promotionRow = (pieceColor == Color.White) ? 8 : 1;
 			return destination.Y == promotionRow;			
		}
		private void _PawnHasBeenUpgrade(IPlayer player, Piece piece, Location destination)
		{
			if(_IsUpgradePawn(player, piece, destination))
			{
				
			}
		}
		private bool _MovePieceValidator
		public bool NextTurn()
		{
			_currentTurn = _currentTurn == Color.White ? Color.Black : Color.White;
			return true;
		}

		public void EndTurn()
		{
			
		}

		public bool EndGame()
		{
			return true;
		}
	}
}
