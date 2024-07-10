namespace Instrument;

class Body : Component
{
	public string colour;
	public string shape;
	public void Hug()
	{
		Console.WriteLine("Nyaman digunakan");
	}
	public Body(string brand,int price, string material,string colour, string shape):base(brand, price, material)
	{
		this.colour = colour;
		this.shape = shape;
	}
}
