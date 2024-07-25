class MyDestructor
{
	public MyDestructor()
	{
		Console.WriteLine($"MyDestructor{GC.GetGeneration(this)} created");
	}
	~MyDestructor()
	{
		Console.WriteLine($"MyDestructor{GC.GetGeneration(this)} destructed");
	}
	
}

class Program
{
	static void Main()
	{
		InstanCreator();
		GC.Collect();
		GC.WaitForPendingFinalizers();
	}
	
	static void InstanCreator()
	{
		MyDestructor myDestructor = new();
	}
}