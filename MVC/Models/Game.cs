namespace MVC.Models;

public class Game
{
	public int GameId { get; set; }
	public string GameName { get; set; }
	public string Description { get; set; }
	public int GenreId { get; set; }
	public Genre Genre { get; set; }
}
