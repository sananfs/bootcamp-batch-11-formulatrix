public interface IPhone
{
	public void On();
	public void Off();
}
interface IMac
{
	public void On();
	public void Off();
	public void Fold();
}
public interface IWatch
{
	public void TellTime();
}

public class ElectricalPower : IPhone, IMac, IWatch
{
	public void On()
	{
		Console.WriteLine("Phone Turn On!");
	}
	public void Off()
	{
		Console.WriteLine("Phone Turn Off!");
	}
	public void Charge()
	{
		Console.WriteLine("Phone Charging!");
	}
	public void Fold()
	{
		Console.WriteLine("Foldable");
	}
	public void TellTime()
	{
		Console.WriteLine("15.00 WIB");
	}
}
class Program
{
	static void Main()
	{
		IPhone phone = new ElectricalPower();
		phone.On();
		// phone.Charge();
		// phone.TellTime();
		ElectricalPower phone2 = new ElectricalPower();
		phone2.Charge();
		phone2.TellTime();
	}
}