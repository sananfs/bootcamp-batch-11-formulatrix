class Human
{
	public string emotion = "Anger";
	public int age = 30;
	public static Human operator+(Human a, Human b)
	{
		string result = a.emotion + b.emotion;
		Human human = new Human();
		human.emotion = result;
		return human;
	}
}

class Program
{
	static void Main()
	{
		Human human = new Human();
		Human human2nd = new Human();
		Human result = human + human2nd;
		Console.WriteLine(result.emotion);
		
	}
}