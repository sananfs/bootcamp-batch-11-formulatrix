namespace Animal;

class Cat 
{
	//camelCase => attribute/variable
	//isAlive
	
	//PascalCase => function/class
	//Eat
	//Sleep

	//variable/attribute
	public bool manja;
	public string colour;
	public bool isMale;
	
	//function/behaviour
	public void Poop() 
	{
		Console.WriteLine("Poop");
	}
	public void Eat(int jenisMakanan) 
	{
		Console.WriteLine("Cat eat " + jenisMakanan);
	}
}

// class Program 
// {
// 	static void Main() 
// 	{
// 		Cat kumi = new Cat();
// 		string inputUser = Console.ReadLine();
// 		int makanan = int.Parse(inputUser);
// 		kumi.manja = true;
// 		kumi.colour = "Brown";
// 		kumi.isMale = false;
// 		Console.WriteLine(kumi.manja);
// 		Console.WriteLine(kumi.colour);
// 		Console.WriteLine(kumi.isMale);

// 		kumi.Poop();
// 		kumi.Eat(makanan);

// 		Cat john = new Cat();
// 		john.manja = true;
// 		john.colour = "White";
// 		john.isMale = true;
// 		Console.WriteLine(kumi.manja);
// 		Console.WriteLine(kumi.colour);
// 		Console.WriteLine(kumi.isMale);

// 	}
// }