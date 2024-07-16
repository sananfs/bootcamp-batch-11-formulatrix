using System.Numerics;

namespace CalculatorLib;

static class Calculator<T> where T : INumber<T>
{
	public static T Add(T a, T b)
	{
		return a+b;
	}
	public static int Multiply(int a, int b)
	{
		return a*b;
	}

	public static int Divided(int a, int b)
	{
		return a/b;
	} 
	public static int Min(int a, int b)
	{
		return a-b;
	}
}
