class Program
{
	static async Task Main()
	{
		Console.WriteLine("Program Starting");
		Task t1 = Task.Run(()=>Print());
		Task t2 = Task.Run(()=>Fax());
		Task t3 = Task.Run(()=>Scan());
		
		await Task.WhenAll(t1, t2,  t3);
		Console.WriteLine("Program Finish");
	}
	static async Task Print()
	{
		Console.WriteLine("Print Start");
		await Task.Delay(10000);
		Console.WriteLine("Print Finish");
	}
	static async Task Fax()
	{
		Console.WriteLine("Fax Start");
		await Task.Delay(11000);
		Console.WriteLine("Fax Finish");
	}
	static async Task Scan()
	{
		Console.WriteLine("Scan Start");
		await Task.Delay(5000);
		Console.WriteLine("Scan Finish");
	}
}