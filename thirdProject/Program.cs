public class AdminUI
{
    public void ShowControlPanel()
    {
        Console.WriteLine("Admin UI : Showing control panel.");
    }
}

public class BellControll : IBellControll
{
    public void StartRingingBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Ringing started.");
    public void ShutDownBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Shut down.");
    public void StopRingingBell(int bellNumber) => Console.WriteLine($"Bell {bellNumber}: Ringing stopped");
}

public class BurglarThreatHandler
{
    public void HandleBurglarThreat()
    {
        Console.WriteLine("Handling burglar threat.");
    }
}

public class CameraControl
{
    public void TurnOnCamera() => Console.WriteLine("Camera Control: Camera turn on.");
    public void TurnOffCamera() => Console.WriteLine("Camera Control: Camera turned off.");
}

// Menghapus Singleton untuk Dialer
public class Dialer
{
    public void Dial(string number) => Console.WriteLine($"Dialing {number}...");
    public void TurnOnCamera() => Console.WriteLine("Camera Control: Camera turned on.");
    public void TurnOffCamera() => Console.WriteLine("Camera Control: Camera turned off.");
}

public class FireThreatHandler
{
    public void HandleFireThreat()
    {
        Console.WriteLine("Handling fire threat.");
    }
}

// Interface untuk kontrol bel
public interface IBellControll
{
    void StartRingingBell(int bellNumber);
    void ShutDownBell(int bellNumber);
    void StopRingingBell(int bellNumber);
}

class Program
{
    static void Main()
    {
        // Instance Object
        AdminUI adminUI = new AdminUI();
        CameraControl cameraControl = new CameraControl();
        BurglarThreatHandler burglarThreatHandler = new BurglarThreatHandler();
        FireThreatHandler fireThreatHandler = new FireThreatHandler();

        // Menggunakan BellControll langsung
        IBellControll bellControll = new BellControll();

        // Menyediakan UI untuk Admin
        adminUI.ShowControlPanel();

        // Mengendalikan kamera
        cameraControl.TurnOnCamera();
        cameraControl.TurnOffCamera();

        // Menangani ancaman
        burglarThreatHandler.HandleBurglarThreat();
        fireThreatHandler.HandleFireThreat();

        // Menggunakan BellControll langsung
        bellControll.StartRingingBell(1);
        bellControll.ShutDownBell(1);
        bellControll.StopRingingBell(1);

        // Membuat instance Dialer langsung
        Dialer dialer = new Dialer();
        dialer.Dial("08-09-89999");
    }
}