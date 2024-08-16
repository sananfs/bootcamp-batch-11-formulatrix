using AdapterSingleton;

class Program
{
	static void Main()
	{
		// Instance Object
		AdminUI adminUI = new AdminUI();
		CameraControl cameraControl = new CameraControl();
		BurglarThreatHandler burglarThreatHandler = new BurglarThreatHandler();
		FireThreatHandler fireThreatHandler = new FireThreatHandler();
		
		// Menggunakan BellControllAdapter
		IBellControll bellControll = new BellControll();
		BellControllAdapter bellControllAdapter = new BellControllAdapter(bellControll);
		
		// Menyediakan UI untuk Admin
		adminUI.ShowControlPanel();
		
		// Mengendalikan kamera
		cameraControl.TurnOnCamera();
		cameraControl.TurnOffCamera();
		
		// Menangani ancaman
		burglarThreatHandler.HandleBurglarThreat();
		fireThreatHandler.HandleFireThreat();
		
		// Menggunakan BellControllAdapter
		bellControllAdapter.StartRingingBell();
		bellControllAdapter.ShutRingingBell();
		bellControllAdapter.StopRingingBell();
		
		// Menggunakan Ddialer Singleton
		Dialer dialer = Dialer.Instance;
		dialer.Dial("08-09-89999");
	}
}