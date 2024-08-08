namespace Chess;

public class Location
{
	public int X { get; }
	public int Y { get; }

	public Location(int x, int y)
	{
		if (x < 0 || x >= ChessBoard.BoardSize || y < 0 || y >= ChessBoard.BoardSize)
		{
			throw new ArgumentException("Koordinat di luar batas papan.");
		}

		X = x;
		Y = y;
	}

	public override string ToString() => $"({X}, {Y})";
	
	public override bool Equals(object obj)
        {
            if (obj is Location other)
            {
                return X == other.X && Y == other.Y;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
}
