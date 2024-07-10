class Phone
{
	public int jumlah;
	public int button;
	public string color;
	public Phone(int jumlah, int button, string color)
	{
		this.jumlah = jumlah;
		this.button = button;
		this.color = color;
		Console.WriteLine($"Phone Created : {jumlah} {button} {color}");
	}
}
class Program
{
	static void Main()
	{
		Phone phone = new Phone(1, 3, "blue");
	}
}
