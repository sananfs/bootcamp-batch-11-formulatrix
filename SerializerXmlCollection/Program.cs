using System.Xml.Serialization;

public class Human
{
	public string Name {get; set;}
	public int Age {get; set;}
	public Human (string name, int age)
	{
		Name = name;
		Age = age;
	}
	public Human(){}	
}
class Program
{
	static void Main()
	{
		Human human = new("Sanan", 28);
		Human human1 = new("Ita", 30);
		Human human2 = new("Klesa", 22);
		
		List<Human> family = new();
		family.Add(human);
		family.Add(human1);
		family.Add(human2);
		
		XmlSerializer serializer = new(typeof(List<Human>));
		using(FileStream fs = new("./human.txt", FileMode.Create))
		{
			serializer.Serialize(fs, family);
		}
	}
}