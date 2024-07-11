using Caculcacol;

class Program
{
	static void Main()
	{
		Calculator calculator = new();
		float fa = 7.5f;
		float fb = 4.9f;
		float fresult = calculator.Min(fa, fb);
		Console.WriteLine(fresult);
		
		int a = 5;
		int b = 1;
		int result = calculator.Multiply(a, b);
		Console.WriteLine(result);
		
		string sa = "aku";
		string sb = "kamu";
		string sresult = calculator.Add(sa, sb);
		Console.WriteLine(sresult);
	}
}
