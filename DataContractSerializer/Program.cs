using System.Runtime.Serialization;

[DataContract]
public class Human
{
	private string _name;
	private int _age;
	public HumanType Type {get; set;}
	public Human(string name, int age, HumanType humanType)
	{
		_name = name;
		_age = age;
		Type = humanType;
	}
	public enum HumanType
	{
		Manusia,
		Dinasti
	}
	public string GetName() //bisa normal seperti ini
	{
		return _name;
	}
	public int GetAge()=> _age; //bisa menggunakan lamda expression
}
class Program
{
	static void Main()
	{
		Human human = new Human("Prabowi", 72, Human.HumanType.Dinasti);
		
		DataContractSerializer dataContract = new(typeof(Human
			));
			//Write
			using (FileStream fs = new("./myPresident.xml", FileMode.Create))
			{
				dataContract.WriteObject(fs, human);
			}

			//Read
			Human human2;
			using (FileStream fs = new("./myPresident.xml", FileMode.Open))
			{
				human2 = (Human)dataContract.ReadObject(fs);
			}
			Console.WriteLine(human.GetName());
			Console.WriteLine(human.GetAge());

		}
	}
