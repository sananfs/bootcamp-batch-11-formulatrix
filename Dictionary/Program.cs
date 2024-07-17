class Program
{
	static void Main()
	{
		Dictionary<int,string> myDictionary = new();
		myDictionary.Add(3,"Foo");
		myDictionary.Add(5,"Bar");
		
		string result;
		bool status = myDictionary.TryGetValue(3,out result);
		 if(status)
		 {
		 	Console.WriteLine(result);
		 }
	}
}