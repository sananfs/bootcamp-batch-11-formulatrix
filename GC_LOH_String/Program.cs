using System.Diagnostics;
class Program {
	static void Main() {
		int iteration = 1_000_000;
		string sb = new("Hello");
		for (int i = 0; i < iteration; i++)
		{
			sb += " World";
			sb += " ! ! !";
			sb.Replace('o','i');
			Thread.Sleep(2); //untuk mematikan program selama 2 detik
		}
	}
}