namespace PublisherSubscriber;

public class Youtuber
{
	public Subscriber subscriber;
	public Notifikasi notifikasi;
	public Email email;
	
	public void UploadVideo()
	{
		Console.WriteLine("Uploading Video...");
		SentNotification("Ada video baru");
	}
	public void SentNotification(string title)
	{
		subscriber.ShowVideo(title);
		notifikasi.ShowDetail(title);
		email.ShowText(title);
	}
}
