using System.Collections;

class Program
{
	static void Main()
	{
		//Array
		int[] myArray = new int[5];
		myArray [0] = 1;
		myArray [1] = 2;
		
		int[] myArray2 = {1,2,3,4,5};
		myArray[0] = 3;
		
		int[] myArray3 = [1,2,3,4,5]; //NET 8.0++
		
		Console.WriteLine(myArray2.Length); //size of array
		Console.WriteLine(myArray2.Contains(2)); //check if array contain x
		
		Console.WriteLine("###################################");
		
		//ArrayList
		ArrayList myArrayL = new();
		myArrayL.Add(true);
		myArrayL.Add(3);
		myArrayL.Add(3.9f);
		myArrayL.Add(3.0);
		myArrayL.Add("string");
		
		bool result = (bool)myArrayL[0];
		Console.WriteLine(result);
		
		Console.WriteLine("###################################");
		
		//List<T>
		List<int> myList = new();
		myList.Add(3);
		myList.Add(4);
		myList.Add(5);
		
		int result2 = myList[0];
		Console.WriteLine(result2);
		
		Console.WriteLine("###################################");
		
		//HashSet<T>
		HashSet<int> mySet = new();
		mySet.Add(3);
		mySet.Add(5);
		mySet.Add(6);
		mySet.Add(3);
		
		foreach(var i in mySet)
		{
			Console.WriteLine(i);
		}
		
		Console.WriteLine("###################################");
		
		HashSet<int> A = new() {1,2,3,4,5};
		HashSet<int> B = new() {4,5,6,7,8};
		
		// A.UnionWith(B);
		// A.IntersectWith(B);
		A.ExceptWith(B);
		foreach(var ele in A)
		{
			Console.WriteLine(ele);
		}
		
		Console.WriteLine("###################################");
		
		HashSet<int> Aa = new () {1,2,3,4,5};
		HashSet<int> Ba = new () {1,2,3};
		
		bool status = Aa.IsSupersetOf(Ba);
		Console.WriteLine(status);
		bool status2 = Ba.IsSubsetOf(Aa);
		Console.WriteLine(status2);
		
		Console.WriteLine("###################################");
		
		//Queue
		Queue<int> myQueue = new();
		myQueue.Enqueue(3);
		myQueue.Enqueue(5);
		myQueue.Enqueue(9);
		myQueue.Enqueue(4);
		
		int result4 = myQueue.Dequeue(); //3
		Console.WriteLine(result4);
		
		result4 = myQueue.Dequeue();//5
		Console.WriteLine(result4);
		
		result4 = myQueue.Peek();//9
		Console.WriteLine(result4);
		
		result4 = myQueue.Peek();//9
		Console.WriteLine(result4);
		
		result4 = myQueue.Dequeue();//9
		Console.WriteLine(result4);
		
		result4 = myQueue.Peek();//4
		Console.WriteLine(result4);

	}
}