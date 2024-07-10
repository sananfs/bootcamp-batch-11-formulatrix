namespace Instrument;
class Guitar
{
	public Senar senar;
	public Pick pick;
	public Neck neck;
	public Body body;

	public Guitar(Senar senar, Neck neck, Body body)
	{
		this.senar = senar;
		this.neck = neck;
		this.body = body;
	}
}