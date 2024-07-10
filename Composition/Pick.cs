namespace Instrument;

class Pick : Component
{
	public int size;
	public string colour;

	public void Grap()
	{
		Console.WriteLine("Nyaman dipegang");
	}
	public Pick(string brand,int price, string material, int size, string colour):base(brand, price, material)
	{
		this.size = size;
		this.colour = colour;
	}
}
