using NonSingletonPPT;

class Program
{
    static void Main()
    {
        // Membuat instance baru dari NonSingleton
        NonSingleton instance = new NonSingleton();
        instance.DoSomething();
        
        // Membuat instance baru dari NonSingleton lagi (ini adalah instance yang berbeda)
        NonSingleton anotherInstance = new NonSingleton();
        anotherInstance.DoSomething();
        
        // Memeriksa apakah kedua instance adalah objek yang sama
        Console.WriteLine(ReferenceEquals(instance, anotherInstance));
    }
}
