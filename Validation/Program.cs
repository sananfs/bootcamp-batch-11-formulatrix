class GetData
{
	public int[] isNull()
	{
		return null;
	}
}
class Program
{
	static void Main()
	{
		GetData get = new();
		int[] myArray = get.isNull();
		if(!(myArray == null))
		{
			Console.WriteLine(myArray);
		}
	}
}