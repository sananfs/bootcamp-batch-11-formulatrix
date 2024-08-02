using Chess;

class Program
{
    static void Main(string[] args)
    {
        Piece[,] initialPieces = InitializeChessBoard();

        ChessBoard chessBoard = new ChessBoard(initialPieces);

        Console.WriteLine("Masukkan nama untuk pemain putih:");
        string whitePlayerName = Console.ReadLine();

        Console.WriteLine("Masukkan nama untuk pemain hitam:");
        string blackPlayerName = Console.ReadLine();

        var players = new Dictionary<Color, IPlayer>
        {
            { Color.White, new SimplePlayer(1, whitePlayerName) },
            { Color.Black, new SimplePlayer(2, blackPlayerName) }
        };

        GameController gameController = new GameController(players, chessBoard);

        while (!gameController.EndGame())
        {
            var currentPlayer = gameController.GetCurrentPlayer();

            DisplayChessBoard(chessBoard);

            Console.WriteLine($"Giliran {currentPlayer.Name} ({gameController.GetCurrentPlayerColor()}). Pilih bidak (misal, e2): ");
            string piecePosition = Console.ReadLine();
            Console.WriteLine("Pilih tujuan (misal, e4): ");
            string destinationPosition = Console.ReadLine();

            Location pieceLocation = ParseLocation(piecePosition);
            Location destinationLocation = ParseLocation(destinationPosition);

            Piece selectedPiece = chessBoard.GetPiece(pieceLocation);

            string moveResult = gameController.MovePiece(currentPlayer, selectedPiece, destinationLocation);
            Console.WriteLine(moveResult);
        }

        Console.WriteLine("Permainan berakhir!");
    }

    private static Piece[,] InitializeChessBoard()
    {
        Piece[,] pieces = new Piece[8, 8];

        pieces[0, 0] = new Rook(0, Color.White);
        pieces[0, 1] = new Knight(1, Color.White);
        pieces[0, 2] = new Bishop(2, Color.White);
        pieces[0, 3] = new Queen(3, Color.White);
        pieces[0, 4] = new King(4, Color.White);
        pieces[0, 5] = new Bishop(5, Color.White);
        pieces[0, 6] = new Knight(6, Color.White);
        pieces[0, 7] = new Rook(7, Color.White);
        for (int i = 0; i < 8; i++)
        {
            pieces[1, i] = new Pawn(i + 8, Color.White);
        }

        pieces[7, 0] = new Rook(16, Color.Black);
        pieces[7, 1] = new Knight(17, Color.Black);
        pieces[7, 2] = new Bishop(18, Color.Black);
        pieces[7, 3] = new Queen(19, Color.Black);
        pieces[7, 4] = new King(20, Color.Black);
        pieces[7, 5] = new Bishop(21, Color.Black);
        pieces[7, 6] = new Knight(22, Color.Black);
        pieces[7, 7] = new Rook(23, Color.Black);
        for (int i = 0; i < 8; i++)
        {
            pieces[6, i] = new Pawn(i + 24, Color.Black);
        }

        return pieces;
    }

    private static void DisplayChessBoard(ChessBoard chessBoard)
    {
        Piece[,] board = chessBoard.GetChessBoard();
        Console.WriteLine("  a b c d e f g h");
        Console.WriteLine(" +----------------");

        for (int y = 7; y >= 0; y--)
        {
            Console.Write($"{y + 1}|");
            for (int x = 0; x < 8; x++)
            {
                Piece piece = board[x, y];
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
        int x = position[0] - 'a';
        int y = int.Parse(position[1].ToString()) - 1;
        return new Location(x, y);
    }
}

public class SimplePlayer : IPlayer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public SimplePlayer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}
