using AdapterSingleton;

class Program
{
	static void Main()
	{
		// Mengakses instance singleton dari Adapter
        ITarget adapter = Adapter.Instance;

        // Menggunakan metode yang disediakan oleh interface target
        adapter.Request();

        // Mengakses instance singleton dari Adapter lagi
        ITarget anotherAdapter = Adapter.Instance;

        // Memeriksa apakah kedua instance adalah objek yang sama
        Console.WriteLine(ReferenceEquals(adapter, anotherAdapter));
    }
}