class Animal
{
	public string name;
	public int age;

	public virtual void Fly()
	{
		Console.WriteLine("Flying");
	}
	public void Eat()
	{
		Console.WriteLine("Eat");

	}
}
class Eagle : Animal
{
	public override void Fly()
	{
		Console.WriteLine("Fly");
	}

}
class Chicken : Eagle
{
	public override void Fly()
	{
		Console.WriteLine("Cant fly!");
	}
}
class Program
{
	static void Main()
	{
		Animal animal = new();
		Eagle eagle = new();
		Chicken chicken = new();
		eagle.Fly();
		chicken.Fly();

	}
}