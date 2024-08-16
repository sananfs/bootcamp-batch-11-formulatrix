namespace AdapterSingleton;

// Singleton untuk Dialer
public class Dialer
{
	private static readonly Lazy<Dialer> _instance = new Lazy<Dialer>(() => new Dialer());
	private Dialer() {}
	public static Dialer Instance => _instance.Value;
	public void Dial(string number) => Console.WriteLine($"Dialing {number}...");
	public void TurnOnCamera() => Console.WriteLine("Camera Control: Camera turned on.");
	public void TurnOffCamera() => Console.WriteLine("Camera Control: Camera turned off.");
}
