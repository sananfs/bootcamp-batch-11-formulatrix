class Program
{
	static void Main()
	{
		Console.WriteLine("Program running ...");
		try
		{
			string a = "40z";
			int result = int.Parse(a);
			
			int[] myArray = null;
			Console.WriteLine(myArray[4]);
			
			int[] myArray2 = {1,2,3,4,5};
			Console.WriteLine(myArray2[5]);
		}
		// catch(NullReferenceException e)
		// {
		// 	Console.WriteLine("NullReferenceException ...");
		// 	Console.WriteLine(e.Message);
		// }
		catch(IndexOutOfRangeException e)
		{
			Console.WriteLine("IndexOutOfRangeException ...");
			Console.WriteLine(e.Message);
		}
		// catch(Exception e)
		// {
		// 	Console.WriteLine("Exception ...");
		// 	Console.WriteLine(e.Message);
		// }
		finally
		{
			Console.WriteLine("...");
		}
		Console.WriteLine("Program finish ...");
	}
}