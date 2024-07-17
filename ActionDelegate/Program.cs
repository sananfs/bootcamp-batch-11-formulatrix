class Program
{
	static void Main()
	{
		Action<string, string> del = Add;
	}
	static void Add(string a, string b)
	{
		Console.WriteLine (a+b);
	}
}