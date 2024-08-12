using log4net;
using log4net.Config;

class Program
{
	static void Main()
	{
		ILog logger = LogManager.GetLogger(typeof(Robot));
		XmlConfigurator.Configure(new FileInfo("log4net.config"));
		Robot robot = new(logger);
		while(true)
		{
			robot.MoveRight();
			robot.MoveLeft();
			robot.TurnOff();
			robot.MoveRight();
			robot.MoveLeft();
			robot.TurnOff();
		}
	}
}

class Robot
{
	private ILog _log;
	public Robot(ILog log)
	{
		_log = log;
	}
	public void MoveLeft()
	{
		_log.Warn("Move left executed");
		Console.WriteLine("Move...");
		Console.WriteLine("Move Right Finished");
	}
	public void MoveRight()
	{
		_log.Info("Move right executed");
		Console.WriteLine("Move...");
		Console.WriteLine("Move Right Finished");
	}
	public void TurnOff()
	{
		_log.Fatal("Turn off executed");
		Console.WriteLine("TurnOff...");
		Console.WriteLine("Turn Off Finished");
	}
}