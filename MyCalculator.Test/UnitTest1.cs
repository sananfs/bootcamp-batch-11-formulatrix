namespace MyCalculator.Test;

public class MyCalculatorTest
{
	private Calculator _calc;
	[SetUp]
	public void Setup()
	{
		_calc = new Calculator();
	}

	[Test]
	public void Add_ReturnCorrectResult()
	{
		//Arrange
		int a = 9;
		int b = 7;
		int expected = 16;
		//Act
		int result = _calc.Add(a,b);
		//Assert
		Assert.AreEqual(expected, result);
	}
	[TestCase(2,5,7)]
	[TestCase(6,3,9)]
	[TestCase(4,11,15)]
	[TestCase(30,-8,22)]
	public void Add_ReturnCorrectResult(int a, int b, int expected)
	{
		//Arrange
		//Act
		int result = _calc.Add(a,b);
		//Assert
		Assert.That(result, Is.EqualTo(expected));
	}
	[Test] // Negative Case
	public void Add_ThrowException_AddingZero()
	{
		//Arrange
		int b = 0;
		int a = 0;
		//Act
		//Assert
		Assert.Throws<Exception>(() => _calc.Add(a,b));
	}
}