public delegate void MyDelegate(string message);
public class Publisher
{
	private event MyDelegate _del;
	public void AddSubscriber(MyDelegate x)
	{
		if(_del != x)
		{
		_del += x;
		Console.WriteLine("Subscriber ditambahkan");
		}
		return;
	}
	public void RemoveSubscriber(MyDelegate x)
	{
		_del -= x;
		Console.WriteLine("Subscriber dihapus");
	}
}

class Program
{
	static void Main()
	{
		Publisher publisher = new Publisher();

		publisher.AddSubscriber(Subscriber1);
		publisher.AddSubscriber(Subscriber1);
		publisher.AddSubscriber(Subscriber2);

		publisher.RemoveSubscriber(Subscriber2);
	}

	static void Subscriber1(string message)
	{
		Console.WriteLine(message);
	}

	static void Subscriber2(string message)
	{
		Console.WriteLine(message);
	}
	static void Subscriber3(string message)
	{
		Console.WriteLine(message);
	}
}
