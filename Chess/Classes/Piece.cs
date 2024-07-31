namespace Chess;

public abstract class Piece
{
	public int Id {get; set;}
	private Color _color { get; set; }
	private PieceType _type { get; set; }
	private bool _isAvailable = true;
}
