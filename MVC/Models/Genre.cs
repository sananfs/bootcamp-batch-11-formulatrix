namespace MVC.Models;

public class Genre
{
	public int GenreId { get; set; }
	public string GenreName { get; set; }
	public string Description { get; set; }
	public IEnumerable<Game> Games { get; set; }
	public Genre()
	{
		Games = new HashSet<Game>();
	}
}
