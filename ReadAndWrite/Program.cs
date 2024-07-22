class Car
{
	public int price;	//Read & Write
	public readonly int price2;	//Read bisa diubah dengan constructor
	public const int price3 = 2;	//Read must assign before build/compile
	
	public Car (int Price2)
	{
		this.price2 = price2;
	}
}
class Program
{
	static void Main()
	{
		Car car = new(7);
		car.price = 1;
		Console.WriteLine(car.price);
		Console.WriteLine(car.price2);
		
	}
}