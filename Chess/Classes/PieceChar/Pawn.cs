namespace Chess;

public class Pawn : Piece
{
	public Pawn(int id, Color color) : base(id, color, PieceType.Pawn) { }

	public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
	{
		var moves = new List<Location>();
		int[] directions;
            if (Color == Color.White)
            {
                directions = new int[] { 1, 0, 0, 1, 1, 0, 0, 1 };
            }
            else
            {
                directions = new int[] { -1, 0, 0, -1, -1, 0, 0, -1 };
            }

		for (int i = 0; i < directions.Length; i++)
		{
			int dx = currentLocation.X;
			int dy = directions[i];
			int x = currentLocation.X;
			int y = currentLocation.Y;

			while (true)
			{
				x += dx;
				y += dy;

				if (x < 0 || x >= 8 || y < 0 || y >= 8)
				{
					break;
				}

				Piece target = board.GetPiece(new Location(x, y));
				if (target == null)
				{
					moves.Add(new Location(x, y));
				}
				else
				{
					if (target.Color != Color)
					{
						moves.Add(new Location(x, y));
					}
					break;
				}
			}
		}

		return moves;
	}
	//     int direction = Color == Color.White ? 1 : -1;

	//     // Gerakan maju satu langkah
	//     int forwardX = currentLocation.X;
	//     int forwardY = currentLocation.Y + direction;
	//     if (IsWithinBounds(forwardX, forwardY) && !board.IsOccupied(new Location(forwardX, forwardY)))
	//     {
	//         moves.Add(new Location(forwardX, forwardY));

	//         // Gerakan maju dua langkah dari posisi awal
	//         int startRow = Color == Color.White ? 1 : 6;
	//         int doubleForwardY = currentLocation.Y + 2 * direction;
	//         if (currentLocation.Y == startRow && !board.IsOccupied(new Location(forwardX, doubleForwardY)))
	//         {
	//             moves.Add(new Location(forwardX, doubleForwardY));
	//         }
	//     }

	//     // Gerakan serang diagonal
	//     int[] captureOffsets = { -1, 1 };
	//     foreach (int offset in captureOffsets)
	//     {
	//         int captureX = currentLocation.X + offset;
	//         int captureY = currentLocation.Y + direction;
	//         if (IsWithinBounds(captureX, captureY))
	//         {
	//             Piece target = board.GetPiece(new Location(captureX, captureY));
	//             if (target != null && target.Color != Color)
	//             {
	//                 moves.Add(new Location(captureX, captureY));
	//             }
	//         }
	//     }

	//     return moves;
	// }

	// private bool IsWithinBounds(int x, int y)
	// {
	//     return x >= 0 && x < ChessBoard.BoardSize && y >= 0 && y < ChessBoard.BoardSize;
	// }
}
