namespace DelegateLvl123;

public class Subscriber
{
	private string _name;
	public Subscriber(string name)
	{
		_name = name;
	}
	public void GetNotif(string message)
	{
		Console.WriteLine(_name + " " + message);
		// Console.WriteLine($"Subscriber {_name} : {message}");
	}
}
