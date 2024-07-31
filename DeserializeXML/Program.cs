using System.Xml.Serialization;

public class Human
{
	public string Name {get; set;}
	public int Umur {get; set;}
	
}
class Program
{
	static void Main()
	{
		Human human = new();
		
		XmlSerializer serializer = new(typeof(Human));
		using (FileStream fs = new("./human.txt", FileMode.Open))
		{
			human = (Human)serializer.Deserialize (fs);
		}
		Console.WriteLine(human.Name);
		Console.WriteLine(human.Umur);
	}
}