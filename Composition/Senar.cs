namespace Instrument;

class Senar : Component
{
	public int amount;
	public void Petik()
	{
		Console.WriteLine("Dipetik");
	}
	public void Bend()
	{
		Console.WriteLine("Dibending");
	}
	public void Tap()
	{
		Console.WriteLine("Ditapping");
	}
	public Senar(string brand, int price, string material, int amount) : base(brand, price,  material) 
	{
		this.amount = amount;
	}
}
