namespace AdapterSingleton;

public class Adapter : ITarget
{
    private readonly Adaptee _daptee;

    // Private constructor untuk singleton
    private Adapter(){
        _adaptee = new Adaptee();
    }

    private static readonly Lazy<Adapter> _instance = new Lazy<Adapter>(() => new Adapter());

    // Properti untuk mendapatkan instance singleton dari Adapter
    public static Adapter Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}
