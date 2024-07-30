using System.Threading.Tasks;

class Program
{
	static object lockObject = new object();
	static void Main()
	{
		CancellationTokenSource alarmCts = new CancellationTokenSource();
		Task t1 = Task.Run(() => ProgressVideo(alarmCts.Token));
		Task t2 = Task.Run(() => _ReadUserInput(alarmCts));
		Task.WaitAny(t1);
		Console.WriteLine("Video End");
		Console.ReadLine();
	}

	private static void _ReadUserInput(CancellationTokenSource alarmCts)
	{
		Console.ReadLine();
		alarmCts.Cancel();
	}

	static void ProgressVideo(CancellationToken ct)
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine($"Now Playing : {i} %");
			Thread.Sleep(100);
			if (ct.IsCancellationRequested)
			{
				lock (lockObject)
            	{
                	Thread.Sleep(1000);
                	Console.WriteLine("Speed Slowed Down");
            	};
			}
		}
	}
}