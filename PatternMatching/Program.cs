class Calculator
{
	public object Add(object a, object b)
	{
		if(a is int && b is int)
		{
			return (int)a + (int)b;
		}
		if(a is string x && b is string y)
		{
			return x+y; //bisa juga seperti ini
		}
		return null;
	}
}

class Program
{
	static void Main()
	{
		Calculator calc = new();
		int result = (int)calc.Add(7,9);
		Console.WriteLine(result);
		
	}
}