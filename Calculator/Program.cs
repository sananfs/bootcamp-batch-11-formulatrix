using CalculatorLib;

class Program
{
	static void Main()
	{
		//instance
		Calculator calculator = new Calculator();
		Console.WriteLine("Kalkulator Sederhana");
		do
		{
			Console.WriteLine("1. Penjumlahan");
			Console.WriteLine("2. Pengurangan");
			Console.WriteLine("3. Perkalian");
			Console.WriteLine("4. Pembagian");
			Console.WriteLine("Pilih angka sesuai penghitungan");
			string menu = Console.ReadLine();

			//Take input user from Terminal
			Console.WriteLine("Masukkan angka : ");
			string inputUser = Console.ReadLine();
			Console.WriteLine("Masukkan angka kedua : ");
			string inputUser2 = Console.ReadLine();

			//Convert string to int using Parse
			int inputUserInt = int.Parse(inputUser);
			int inputUserInt2 = int.Parse(inputUser2);

			if (menu == "1")
			{
				//Call calculator method
				int result = calculator.Add(inputUserInt, inputUserInt2);
				Console.WriteLine("Hasil = " + result);
			}
			if (menu == "2")
			{
				//Call calculator method
				int result = calculator.Min(inputUserInt, inputUserInt2);
				Console.WriteLine("Hasil = " + result);
			}
			if (menu == "3")
			{
				int result = calculator.Multiply(inputUserInt, inputUserInt2);
				Console.WriteLine("Hasil = " + result);
			}
			if (menu == "4")
			{
				int result = calculator.Divided(inputUserInt, inputUserInt2);
				Console.WriteLine("Hasil = " + result);
			}

			//while input user
			Console.WriteLine("Apakah anda ingin menghitung lagi? y/n");
		}
		while (Console.ReadLine() == "y");
	}
}