public enum Status
{
	NotFound,
	Redirected,
	WrongPassword,
	Larlorkidullor
}
class StatusChecker 
{
	public void Check(Status status)
	{
		if(status == Status.NotFound)
		{
			Console.WriteLine("Warning : Not Found");
		}
		else if(status == Status.Redirected)
		{
			Console.WriteLine("Warning : Redirected");
		}
		else if(status == Status.WrongPassword)
		{
			Console.WriteLine("Warning : Wrong Password");
		}
		else if(status == Status.Larlorkidullor)
		{
			Console.WriteLine("Warning : Ngalor ngidul");
		}
		else
		{
			Console.WriteLine("Status not found");
		}
		
	}
}
class Program
{
	static void Main()
	{
		StatusChecker stats = new();
		Status status = Status.WrongPassword;
		stats.Check(status);
	}
}