﻿using System.Xml.Serialization;

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
		List<Human> family = new();
		
		XmlSerializer serializer = new(typeof(List<Human>));
		using(FileStream fs = new("./human.txt", FileMode.Open))
		{
			family= (List<Human>)serializer.Deserialize(fs);
		}
		foreach(var i in family) 
		{
			Console.WriteLine(i.Name);
			Console.WriteLine(i.Age);
		}
	}
}