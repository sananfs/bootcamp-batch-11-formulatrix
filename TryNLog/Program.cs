using NLog;

class Program()
{
	static void Main()
	{
		ILogger logger = LogManager.GetCurrentClassLogger();
		Robot robot = new(logger);
		while(true)
		{
			robot.MoveLeft();
			robot.MoveRight();
			robot.TurnOff();
			robot.MoveLeft();
			robot.MoveRight();
			robot.TurnOff();
			robot.MoveLeft();
			robot.MoveRight();
			robot.TurnOff();
		}
		
	}
}

class Robot
{
	private ILogger _log;
	public Robot(ILogger log)
	{
		_log = log;
	}
	public void MoveLeft()
	{
		// string email = Console.ReadLine();
		// string password = Console.ReadLine();
		_log.Info("Move Left executed");
		// if (email == "joko") {
			
		// 	return;
		// }
		
		Console.WriteLine("Move...");
		Console.WriteLine("Move Left Finished");
	}
	public void MoveRight()
	{
		_log.Info("Move right executed");
		Console.WriteLine("Move...");
		Console.WriteLine("Move right finished");
	}
	public void TurnOff()
	{
		_log.Error("TurnOff executed");
		Console.WriteLine("Turn...");
		Console.WriteLine("Turn off finished");
	}
}