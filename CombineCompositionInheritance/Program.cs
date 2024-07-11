class Phone
{
	public Mmc mmc;
	public Lcd lcd;
	public Phone(Mmc mmc, Lcd lcd)
	{
		this.mmc = mmc;
		this.lcd = lcd;
	}
}
class Mmc
{
	public int price;
	public string version;
	public string brand;
	public string processor;
}
class Lcd
{
	public int price;
	public string version;
	public string brand;
	public int size;
}
class SamsungMmc : Mmc {}
class OppoMmc : Mmc {}
class RedmiLcd : Lcd{}

class Program {
	static void Main() {
		Mmc mmc = new Mmc();
		Lcd lcd = new Lcd();
		Phone phone = new Phone(mmc, lcd);
		
		SamsungMmc samsungMmc = new SamsungMmc();
		RedmiLcd redmiLcd = new RedmiLcd();
		Phone phone2 = new Phone(samsungMmc, redmiLcd);
	}
}