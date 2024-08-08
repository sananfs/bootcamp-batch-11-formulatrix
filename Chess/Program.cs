using System;
using System.Collections.Generic;

namespace Chess
{
    class Program
    {
        static void Main()
        {
            // Inisialisasi papan catur dengan setup awal
            ChessBoard chessBoard = InitializeChessBoard();

            Console.WriteLine("Masukkan nama untuk pemain putih:");
            string whitePlayerName = Console.ReadLine();
            Console.WriteLine("Masukkan nama untuk pemain hitam:");
            string blackPlayerName = Console.ReadLine();

            var playerNames = new Dictionary<Color, string>
            {
                { Color.White, whitePlayerName },
                { Color.Black, blackPlayerName }
            };

            // Inisialisasi GameController
            GameController gameController = new GameController(playerNames, chessBoard);

            while (!gameController.EndGame())
            {
                var currentPlayerColor = gameController.CurrentTurn;
                var currentPlayerName = playerNames[currentPlayerColor];

                DisplayChessBoard(chessBoard);

                Console.WriteLine($"Giliran {currentPlayerName} ({currentPlayerColor}).");

                // Input lokasi bidak
                Console.WriteLine("Masukkan lokasi bidak yang akan digerakkan (X Y): ");
                if (!TryParseLocation(out Location pieceLocation))
                {
                    Console.WriteLine("Input lokasi tidak valid. Silakan coba lagi.");
                    continue;
                }

                Console.WriteLine("Masukkan lokasi tujuan (X Y): ");
                if (!TryParseLocation(out Location destinationLocation))
                {
                    Console.WriteLine("Input lokasi tidak valid. Silakan coba lagi.");
                    continue;
                }

                Piece selectedPiece = chessBoard.GetPiece(pieceLocation);

                if (selectedPiece == null)
                {
                    Console.WriteLine("Tidak ada bidak di lokasi yang dipilih.");
                    continue;
                }

                // Cek apakah bidak dapat bergerak
                if (!gameController.CanMovePiece(currentPlayerColor, selectedPiece, out List<Location> possibleMoves, out string message))
                {
                    Console.WriteLine($"Error: {message}");
                    continue;
                }

                // Tampilkan gerakan legal
                Console.WriteLine($"Gerakan legal untuk bidak yang dipilih: {string.Join(", ", possibleMoves.Select(loc => $"{loc.X} {loc.Y}"))}");

                // Gerakkan bidak
                if (!gameController.MovePiece(currentPlayerColor, selectedPiece, destinationLocation))
                {
                    Console.WriteLine("Error: Gerakan tidak dapat dilakukan.");
                }
                else
                {
                    Console.WriteLine("Gerakan berhasil.");
                }
            }

            Console.WriteLine("Permainan berakhir!");
        }

        private static ChessBoard InitializeChessBoard()
        {
            Piece[,] initialSetup = new Piece[ChessBoard.BoardSize, ChessBoard.BoardSize]
            {
                { new Rook(0, Color.White), new Knight(1, Color.White), new Bishop(2, Color.White), new Queen(3, Color.White), new King(4, Color.White), new Bishop(5, Color.White), new Knight(6, Color.White), new Rook(7, Color.White) },
                { new Pawn(8, Color.White), new Pawn(9, Color.White), new Pawn(10, Color.White), new Pawn(11, Color.White), new Pawn(12, Color.White), new Pawn(13, Color.White), new Pawn(14, Color.White), new Pawn(15, Color.White) },
                // { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                { null, null, null, null, null, null, null, null },
                // { null, null, null, null, null, null, null, null },
                { new Pawn(16, Color.Black), new Pawn(17, Color.Black), new Pawn(18, Color.Black), new Pawn(19, Color.Black), new Pawn(20, Color.Black), new Pawn(21, Color.Black), new Pawn(22, Color.Black), new Pawn(23, Color.Black) },
                { new Rook(24, Color.Black), new Knight(25, Color.Black), new Bishop(26, Color.Black), new Queen(27, Color.Black), new King(28, Color.Black), new Bishop(29, Color.Black), new Knight(30, Color.Black), new Rook(31, Color.Black) }
            };

            return new ChessBoard(initialSetup);
        }

        private static void DisplayChessBoard(ChessBoard chessBoard)
        {
            Piece[,] board = chessBoard.GetChessBoard();
            Console.WriteLine("X  0 1 2 3 4 5 6 7");
            Console.WriteLine("Y+----------------");

            for (int y = ChessBoard.BoardSize - 1; y >= 0; y--)
            {
                Console.Write($"{y}|");
                for (int x = 0; x < ChessBoard.BoardSize; x++)
                {
                    Piece piece = board[y, x];
                    if (piece != null)
                    {
                        Console.Write($" {GetPieceSymbol(piece)}");
                    }
                    else
                    {
                        Console.Write(" .");
                    }
                }
                Console.WriteLine();
            }
        }

        private static char GetPieceSymbol(Piece piece)
        {
            return piece.PieceType switch
            {
                PieceType.King => piece.Color == Color.White ? 'K' : 'k',
                PieceType.Queen => piece.Color == Color.White ? 'Q' : 'q',
                PieceType.Rook => piece.Color == Color.White ? 'R' : 'r',
                PieceType.Bishop => piece.Color == Color.White ? 'B' : 'b',
                PieceType.Knight => piece.Color == Color.White ? 'N' : 'n',
                PieceType.Pawn => piece.Color == Color.White ? 'P' : 'p',
                _ => '.'
            };
        }

        private static bool TryParseLocation(out Location location)
        {
            location = null;
            Console.WriteLine("Masukkan koordinat (X Y) dalam format integer:");
            string input = Console.ReadLine();
            var parts = input.Split(' ');

            if (parts.Length != 2 ||
                !int.TryParse(parts[0], out int x) ||
                !int.TryParse(parts[1], out int y) ||
                x < 0 || x >= ChessBoard.BoardSize ||
                y < 0 || y >= ChessBoard.BoardSize)
            {
                return false;
            }

            location = new Location(y, x);
            return true;
        }
    }
}
