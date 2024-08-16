namespace AdapterSingleton;

// Interface untuk kontrol bel
public interface IBellControll
{
	void StartRingingBell(int bellNumber);
	void ShutDownBell(int bellNumber);
	void StopRingingBell(int bellNumber);
}
