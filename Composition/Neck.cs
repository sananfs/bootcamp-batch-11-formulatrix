using System.Security.Cryptography.X509Certificates;

namespace Instrument;

class Neck : Component
{
	public int longNeck;
	public int fret;
	public void Grap()
	{
		Console.WriteLine("Handling nyaman");
	}
	public Neck(string brand,int price, string material, int longNeck, int fret) : base (brand, price, material)
	{
		this.longNeck = longNeck;
		this.fret = fret;
	}
}
