class Parent
{
	public void A()
	{
		Console.WriteLine("A");
	}
}

class Child : Parent
{
	public void A()
	{
		Console.WriteLine("a");
	}
}

class Program
{
	static void Main()
	{
		Parent parent = new Child();
		parent.A();
	}
}