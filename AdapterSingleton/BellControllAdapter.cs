namespace AdapterSingleton;

// Adapter untuk kontrol bel
public class BellControllAdapter
{
	private readonly IBellControll _bellControll;
	
	public BellControllAdapter(IBellControll bellControll)
	{
		_bellControll = bellControll;
	}
	
	public void StartRingingBell() => _bellControll.StartRingingBell(1);
	public void ShutRingingBell() => _bellControll.ShutDownBell(1);
	public void StopRingingBell() => _bellControll.StopRingingBell(1);
}
