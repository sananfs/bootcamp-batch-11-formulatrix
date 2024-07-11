class Engine 
{
	private void Run()
	{
		Console.WriteLine("Engine Run");
	}
}
class ElectricEngine : Engine
{
	public void Off()
	{
		Console.WriteLine("Engine Off");
	}
}
class Program
{
	static void Main()
	{
		Engine engine = new Engine();
		engine.Run(); //error tidak dpt menjalankan function Run karena function Run bersifat private
		engine.Off(); //error karena class engine tidak ada function Off
		
		ElectricEngine ee = new ElectricEngine();
		ee.Run(); //error karena tidak mendapatkan ijin akses function Run dari parent
		ee.Off();
	}
}