using System.Dynamic;

class KoleksiMilikKu<T>
{
	public T[] koleksiKu = new T[5]; //wadah arraynya ada 5
	public int angka = 0;
	public void Add(T input)
	{
		if(angka == koleksiKu.Length)
		{
			return;
		}
		koleksiKu[angka] = input;
		angka++;
	}
	public T Get(int index)
	{
		return koleksiKu[index];
	}
	public void Remove(int index)
	{
		koleksiKu[index] = default;
	}
}

class Program 
{
	static void Main()
	{
		KoleksiMilikKu<int> koleksiku = new KoleksiMilikKu<int>();
		koleksiku.Add(7);
		Console.WriteLine(koleksiku.Get(0));
		KoleksiMilikKu<string> koleksikuString = new KoleksiMilikKu<string>();
		koleksikuString.Add("Rusak");
		Console.WriteLine(koleksikuString.Get(0));
	}
}