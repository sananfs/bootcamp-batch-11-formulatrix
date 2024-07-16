using PublisherSubscriber;
class Program
{
	static void Main()
	{
		Youtuber youtuber = new();
		
		Subscriber subscriber = new();
		Notifikasi notifikasi = new();
		Email email = new();
		
		youtuber.subscriber = subscriber;
		youtuber.notifikasi = notifikasi;
		youtuber.email = email;
		
		youtuber.UploadVideo();
	}
}