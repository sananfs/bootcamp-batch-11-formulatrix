class Program
{
	static void Main()
	{
		int x = 4;
		double y = x;
		
		double dx = 4.0;
		int iy = (int) dx; //explicit casting atau convert
		
		int a =  3;
		float b = a;
		
		double c = 3.5;
		double d = Math.Round(c); //Math.Ceiling pembulatan ke atas, Math.Floor pembulatan ke bawah
		int result = (int)d;
		Console.WriteLine(result);
		
		double e = 3.1;
		double f = Math.Ceiling(e);
		int result2 = (int)f;
		Console.WriteLine(result2);
		
		double g = 3.99;
		double h = Math.Floor(g);
		int result3 = (int)h;
		Console.WriteLine(result3);
	}
}