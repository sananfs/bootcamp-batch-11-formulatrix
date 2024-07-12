abstract class Animal
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
	public abstract void Hunt();
}
class Eagle : Animal
{
	public override void Fly()
	{
		Console.WriteLine("Eagle Fly");
	}
	public override void Hunt()
	{
		Console.WriteLine("Eagle Amati terkam");
	}
	public void CheckAnimalEat()
	{
		base.Eat();
	}
}
class Chicken : Eagle
{
	public override void Fly()
	{
		Console.WriteLine("Chicken Cant fly!");
	}
	public override void Hunt()
	{
		Console.WriteLine("Chicken Asal patok");
	}
}

class Program
{
	static void Main()
	{
		// Animal animal = new(); dimatikan karena abstract tidak bisa di buatkan object instance
		Eagle eagle = new();
		Chicken chicken = new();
		eagle.Fly();
		chicken.Fly();
		eagle.Hunt();
		chicken.Hunt();
		eagle.CheckAnimalEat();
	}
}