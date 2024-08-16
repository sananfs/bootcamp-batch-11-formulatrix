namespace AdapterSingleton;

public class BellControll : IBellControll
{
	public void StartRingingBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Ringing started.");
	public void ShutDownBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Shut down.");
	public void StopRingingBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Ringing stopped");
}
