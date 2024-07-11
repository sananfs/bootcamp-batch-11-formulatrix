using System.Security.Cryptography.X509Certificates;

class Family
{
	private int _noKK;
	public string clan;
	
	public int CheckNoKK(string password)
	{
		if(password == "123")
		{
			return _noKK;
		}
		return 0;
	}
	public void AddNoKK(int add)
	{
		if(!(add < 0)) {
			_noKK = add;
	}
}
	public void FillClan(string add)
	{
		clan += add;
	}
	public void CheckClan()
	{
		Console.WriteLine(clan);
	}
}

class Program
{
	static void Main()
	{
		Family family = new Family();
		family.AddNoKK(1212);
		family.FillClan("Sanan");
		Console.WriteLine(family.CheckNoKK("123"));
		family.CheckClan();
	}
}