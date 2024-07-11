class Program
{
	static void Main()
	{
		Family family = new Family();
		family.AddNoKK(1515);
		family.FillClan("Sanan");
		Console.WriteLine(family.CheckNoKK("1234"));
		family.CheckClan();
	}
}