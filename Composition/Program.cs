using Instrument;
class Program
{
	static void Main()
	{
		Body body = new Body("Yamaha", 1000000, "Mahony", "Brown", "Spanyol");
		Neck neck = new Neck("Yamaha", 300000, "Apple", 50, 12);
		Senar senar = new Senar("Augustin", 100000, "Nylon", 6);
		Pick pick = new Pick("Dunlop", 25000, "Plastic", 7, "Red");

		Guitar guitar = new Guitar(senar, neck, body);
		guitar.senar = senar;
		guitar.neck = neck;
		guitar.body = body;
		guitar.pick = pick;

		Console.WriteLine(guitar.body.material);
		guitar.senar.Bend();
	}
}