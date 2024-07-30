class Program
{
	private static bool _isPaused = false;
	private static readonly object _pauseLock = new object();

	static void Main()
	{
		CancellationTokenSource alarmCts = new CancellationTokenSource();
		Task t1 = Task.Run(() => Installation(alarmCts.Token));
		Task t2 = Task.Run(() => _ReadUserInput(alarmCts));
		Task.WaitAny(t1, t2);
		alarmCts.Cancel();
		t1.Wait();

		Console.WriteLine("Installation Finish");
		Console.ReadLine();
	}

	private static void _ReadUserInput(CancellationTokenSource alarmCts)
	{
		while (true)
		{
			string input = Console.ReadLine();
			Thread.Sleep(5000);

			if (input == "pause")
			{
				lock (_pauseLock)
				{
					_isPaused = true;
					Console.WriteLine("Installation Paused. Type 'resume' to continue.");
				}
			}
			else if (input == "resume")
			{
				lock (_pauseLock)
				{
					_isPaused = false;
					Console.WriteLine("Installation Resumed.");
				}
			}
			else if (input == "stop")
			{
				alarmCts.Cancel();
				break;
			}
		}
	}

	private static void Installation(CancellationToken ct)
	{
		for (int i = 0; i < 100; i++)
		{
			if (ct.IsCancellationRequested)
			{
				return;
			}
			Console.WriteLine($"Installing : {i} %");
			Thread.Sleep(100);
		}
	}
}
