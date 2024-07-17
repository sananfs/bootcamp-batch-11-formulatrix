using  DelegateLvl123;

class Program
{
	static void Main()
	{
		Publisher pub = new();
		Subscriber subs = new("First sub");
		
		pub.AddSubscriber(subs.GetNotif);
		pub.AddSubscriber(subs.GetNotif);
		pub.AddSubscriber(subs.GetNotif);
		pub.SentNotification();
		
	}
}