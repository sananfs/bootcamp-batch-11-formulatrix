class Program
{
	static void Main()
	{
		var add = (int a, int b) => a+b;
		// Func<int, int, int> del = Add;
		int result = add(3,4);
		Console.WriteLine(result);
		Console.WriteLine(add(5,6));
	}

    // private static int Add(int a, int b)
    // {
    //     return a+b;
    // }
}