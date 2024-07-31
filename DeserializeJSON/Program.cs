using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

public class Human
{
	public string Name {get; set;}
	public int Age {get; set;}
	public HumanType Type {get; set;}
	public string defaultt = "default"; //tidak akan terbaca
}
public enum HumanType
{
	Manusia,
	Dinasti
}
class Program
{
	static void Main()
	{
		string result;
		
		using(StreamReader sr = new("./humansw.json"))
		{
			result = sr.ReadLine();
		}
		Human human = JsonSerializer.Deserialize<Human>(result);
		Console.WriteLine(human.Name);
		Console.WriteLine(human.Age);
	}
}