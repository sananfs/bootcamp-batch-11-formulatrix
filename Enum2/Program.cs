public enum DayOfWeek 
{
	Sun = 1,
	Mon,
	Tue,
	Wed,
	Thu,
	Fri,
	Sat
}

class Program
{
	static void Main()
	{
		int result = (int) DayOfWeek.Fri;
		Console.WriteLine(result);
		
		DayOfWeek result2 = (DayOfWeek)4;
		Console.WriteLine(result2);

		string x = DayOfWeek.Tue.ToString();
		Console.WriteLine(x);
 
	}
}