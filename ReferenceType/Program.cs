class Bag
{
	public int price;
	public Bag(int price)
	{
		this.price = price;
	}
}
class Program
{
	static void Main()
	{
		Bag bag = new(7);
		Bag bag2 = bag;
		bag2.price += 1;
		
		Console.WriteLine(bag.price); //8
		Console.WriteLine(bag2.price); //8
		
		int a = 4;
		int b = a;
		b += 1;
		Console.WriteLine(a); //4
		Console.WriteLine(b); //5
		
		string sa = "kiew"; //note: string immutable atau tidak dapat diubah
		string sb = sa;
		sb += "brongs";
		Console.WriteLine(sa); //kiew
		Console.WriteLine(sb); //kiewbrongs
	}
}