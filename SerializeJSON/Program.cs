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
		Human human = new();
		human.Name = "Joko W";
		human.Age = 63;
		human.Type = HumanType.Dinasti;
		
		string result = JsonSerializer.Serialize(human);
		Console.WriteLine(result);
		// using(FileStream fs = new("./human.json", FileMode.Create))
		// {
		// 	byte[] bytes = Encoding.UTF8.GetBytes(result);
		// 	fs.Write(bytes, 0, bytes.Length);
		// }
		
		using(StreamWriter sw = new("./humansw.json"))
		{
			sw.WriteLine(result);
		}
	}
}