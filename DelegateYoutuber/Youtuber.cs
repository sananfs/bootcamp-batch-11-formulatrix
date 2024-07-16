namespace DelegateYoutuber;

public delegate void Subscriber(string title);
public class Youtuber
{
	public Subscriber subscriber;
	public void UploadVideo()
	{
		Console.WriteLine("Uploading video..");
		SentNotification("Ada video baru");
	}
	public void SentNotification(string title)
	{
		subscriber(title);
	}
}
