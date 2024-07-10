//blueprint
class Guitar
{
	//camelCase => attribute/variable
	//isAlive
	
	//PascalCase => function/class
	//Eat
	//Sleep

	//variable/attribute
	public bool electric;
	public string colour;
	public bool sixString;
	
	//function/behaviour
	public string wood;
	
	public void Playable() 
	{
		Console.WriteLine("Playable");
	}
	public void ProduceSound() 
	{
		Console.WriteLine("ProduceSound");
	}
	public void HowMuchString(int jumlahSenar) 
	{
		Console.WriteLine("We got " + jumlahSenar);
	}
}

class Program 
{
	static void Main() 
	{
		//object/instance
		//typesafety
		Guitar yamaha = new Guitar();
		string inputUser = Console.ReadLine();
		int jumlahSenar = int.Parse(inputUser);
		yamaha.electric = false;
		yamaha.colour = "Golden Brown";
		yamaha.sixString = true;
		yamaha.wood = "Mahony";
		Console.WriteLine(yamaha.electric);
		Console.WriteLine(yamaha.colour);
		Console.WriteLine(yamaha.sixString);
		Console.WriteLine(yamaha.wood);
		
		yamaha.Playable();
		yamaha.ProduceSound();
		yamaha.HowMuchString(jumlahSenar);
		
		Guitar fender = new Guitar();
		fender.electric = true;
		fender.colour = "Black";
		fender.sixString = true;
		fender.wood = "Apple";
		
		Console.WriteLine(fender.electric);
		Console.WriteLine(fender.colour);
		Console.WriteLine(fender.sixString);
		Console.WriteLine(fender.wood);
		
		fender.ProduceSound();
		fender.ProduceSound();
		
	}
}

