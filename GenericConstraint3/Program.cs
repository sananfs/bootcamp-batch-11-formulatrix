using System.Numerics;

class Calculator 
{
	public T Add <T>(T a, T b) where T :IAdditionOperators<T,T,T>
	{
		return a + b;
	}
	public T Substract <T>(T a, T b) where T :ISubtractionOperators<T,T,T>
	{
		return a - b;
	}
	public T Multiply <T>(T a, T b) where T :IMultiplyOperators<T,T,T>
	{
		return a * b;
	}
	public T Divide <T>(T a, T b) where T :IDivisionOperators<T,T,T>
	{
		return a / b;
	}
}
class Program
{
	static void Main()
	{
		Calculator calc = new();
		int resultAdd = calc.Add(3,4);
		float resultSub = calc.Substract(3.0f, 2.0f);
		decimal resultMul = calc.Multiply(3.0m, 2.0M);
		double result = calc.Divide(3.0, 2.0);
		Console.WriteLine("Hasil = " + result);
	}
}