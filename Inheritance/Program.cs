﻿//Proof inheritance
class Animal {
	public int age;
	public string name;
	public string gender;
	public string race;
	
	public void Eat() {
		Console.WriteLine("Eat");
	}
	public void Poop() {
		Console.WriteLine("Poop");
	}
}
class Cat : Animal {
	public string moustache;
	public void Meow() {}
}
class Dog : Animal {
	public string moustache;
	public void Bark() {}
}
class Bird : Animal {
	public string wing;
	public void Fly() {}
}
class Program {
	static void Main() {
		Bird bird = new Bird();
		bird.Eat();
		bird.Poop();
	}
}