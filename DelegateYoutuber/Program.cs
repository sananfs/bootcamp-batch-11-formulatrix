using DelegateYoutuber;

class Program
{
	static void Main()
	{
		Youtuber youtuber = new();
		
		Notifikasi notifikasi = new();
		
		youtuber.subscriber += notifikasi.ShowNotification;
		youtuber.UploadVideo();
		youtuber.subscriber -= notifikasi.ShowNotification;
	}
}