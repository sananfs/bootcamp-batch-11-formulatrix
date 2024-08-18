using SingletonPPT;
class Program
{
    static void Main()
    {
        // Mengakses instance singleton
        Singleton instance = Singleton.Instance;
        instance.DoSomething();
        
        // Mengakses instance singleton lagi (tetap instance yang sama)
        Singleton anotherInstance = Singleton.Instance;
        anotherInstance.DoSomething();
        
        // Memeriksa apakah kedua instance adalah objek yang sama
        Console.WriteLine(ReferenceEquals(instance, anotherInstance));
    }
}
