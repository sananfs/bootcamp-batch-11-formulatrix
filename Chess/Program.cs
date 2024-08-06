using Chess;

class Program
{
    static void Main()
    {
        Piece[,] initialPieces = InitializeChessBoard();

        ChessBoard chessBoard = new ChessBoard(initialPieces);

        Console.WriteLine("Masukkan nama untuk pemain putih:");
        string whitePlayerName = Console.ReadLine();

        Console.WriteLine("Masukkan nama untuk pemain hitam:");
        string blackPlayerName = Console.ReadLine();

        var playerNames = new Dictionary<Color, string>
        {
            { Color.White, whitePlayerName },
            { Color.Black, blackPlayerName }
        };

        GameController gameController = new GameController(playerNames, chessBoard);

        while (!gameController.EndGame())
        {
            var currentPlayerColor = gameController.CurrentTurn;
            var currentPlayerName = playerNames[currentPlayerColor];

            DisplayChessBoard(chessBoard);

            Console.WriteLine($"Giliran {currentPlayerName} ({currentPlayerColor}). Pilih bidak (misal, e2): ");
            string piecePosition = Console.ReadLine();
            Console.WriteLine("Pilih tujuan (misal, e4): ");
            string destinationPosition = Console.ReadLine();

            var pieceLocation = ParseLocation(piecePosition);
            var destinationLocation = ParseLocation(destinationPosition);

            if (pieceLocation == null || destinationLocation == null)
            {
                Console.WriteLine("Input tidak valid. Silakan coba lagi.");
                continue;
            }

            Piece selectedPiece = chessBoard.GetPiece(pieceLocation);

            if (selectedPiece == null)
            {
                Console.WriteLine("Tidak ada bidak di lokasi yang dipilih.");
                continue;
            }

            var (success, possibleMoves, message) = gameController.PossibleMove(currentPlayerColor, selectedPiece);

            if (possibleMoves != null && possibleMoves.Any())
            {
                Console.WriteLine($"Gerakan legal untuk bidak yang dipilih: {string.Join(", ", possibleMoves.Select(loc => $"{(char)('a' + loc.X)}{loc.Y + 1}"))}");
            }
            else
            {
                Console.WriteLine("Tidak ada gerakan legal yang tersedia.");
            }

            if (!success)
            {
                Console.WriteLine($"Error: {message}");
                continue;
            }

            string moveResult = gameController.MovePiece(currentPlayerColor, selectedPiece, destinationLocation);
            Console.WriteLine(moveResult);
        }

        Console.WriteLine("Permainan berakhir!");
    }

    private static Piece[,] InitializeChessBoard()
    {
        Piece[,] initialSetup = new Piece[8, 8]
        {
            { new Rook(0, Color.White), new Knight(1, Color.White), new Bishop(2, Color.White), new Queen(3, Color.White), new King(4, Color.White), new Bishop(5, Color.White), new Knight(6, Color.White), new Rook(7, Color.White) },
            { new Pawn(8, Color.White), new Pawn(9, Color.White), new Pawn(10, Color.White), new Pawn(11, Color.White), new Pawn(12, Color.White), new Pawn(13, Color.White), new Pawn(14, Color.White), new Pawn(15, Color.White) },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { new Pawn(16, Color.Black), new Pawn(17, Color.Black), new Pawn(18, Color.Black), new Pawn(19, Color.Black), new Pawn(20, Color.Black), new Pawn(21, Color.Black), new Pawn(22, Color.Black), new Pawn(23, Color.Black) },
            { new Rook(24, Color.Black), new Knight(25, Color.Black), new Bishop(26, Color.Black), new Queen(27, Color.Black), new King(28, Color.Black), new Bishop(29, Color.Black), new Knight(30, Color.Black), new Rook(31, Color.Black) }
        };

        return initialSetup;
    }

    private static void DisplayChessBoard(ChessBoard chessBoard)
    {
        Piece[,] board = chessBoard.GetChessBoard();
        Console.WriteLine("   a b c d e f g h");
        Console.WriteLine(" +----------------");

        for (int y = 7; y >= 0; y--)
        {
            Console.Write($"{y + 1}|");
            for (int x = 0; x < 8; x++)
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

    private static Location ParseLocation(string position)
    {
        if (string.IsNullOrEmpty(position) || position.Length < 2)
        {
            return null;
        }

        int x = position[0] - 'a';
        int y = int.Parse(position[1].ToString()) - 1;

        if (x < 0 || x > 7 || y < 0 || y > 7)
        {
            return null;
        }

        return new Location(y, x);
    }
}
