namespace SingletonPPT;

public class Singleton
{
    // Langkah 1: Membuat instance static dari class Singleton
    private static Singleton _instance;

    // Langkah 2: Membuat objek untuk memastikan hanya ada satu instance
    private static readonly object _lock = new object();

    // Langkah 3: Buat private parameterless constructor supaya tidak dapat diinstansiasi dari luar
    private Singleton()
    {
    
    }

    // Langkah 4: Mendapatkan instance dari Singleton
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    // Contoh Method
    public void DoSomething()
    {
        Console.WriteLine("Singleton instance is doing something.");
    }
}
