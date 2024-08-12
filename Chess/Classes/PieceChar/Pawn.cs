namespace Chess;

public class Pawn : Piece
{
	public Pawn(int id, Color color) : base(id, color, PieceType.Pawn) { }

	public override List<Location> GetLegalMoves(ChessBoard board, Location currentLocation)
	{
		var moves = new List<Location>();
		 // Tentukan array directions berdasarkan warna Pawn
            int[] directions;
            if (Color == Color.White)
            {
                // White Pawn moves up
                directions = new int[] { 1, 0, 0, 1, 1, 0, 0, 1 }; // Move up, diagonal captures
            }
            else
            {
                // Black Pawn moves down
                directions = new int[] { -1, 0, 0, -1, -1, 0, 0, -1 }; // Move down, diagonal captures
            }

            // Gerakan satu langkah ke depan
            int x = currentLocation.X;
            int y = currentLocation.Y + directions[0];

            if (y >= 0 && y < 8) // Pastikan dalam batas papan
            {
                if (board.GetPiece(new Location(x, y)) == null)
                {
                    moves.Add(new Location(x, y));

                    // Cek pergerakan dua langkah jika Pawn masih di baris awalnya
                    if (currentLocation.Y == (Color == Color.White ? 1 : 6))
                    {
                        y += directions[0];
                        if (y >= 0 && y < 8 && board.GetPiece(new Location(x, y)) == null)
                        {
                            moves.Add(new Location(x, y));
                        }
                    }
                }
            }

            // Cek serangan diagonal
            for (int i = 1; i < directions.Length; i += 2)
            {
                int dx = directions[i];
                int dy = directions[i + 1];
                int targetX = currentLocation.X + dx;
                int targetY = currentLocation.Y + dy;

                if (targetX >= 0 && targetX < 8 && targetY >= 0 && targetY < 8)
                {
                    Piece target = board.GetPiece(new Location(targetX, targetY));
                    if (target != null && target.Color != Color)
                    {
                        moves.Add(new Location(targetX, targetY));
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
