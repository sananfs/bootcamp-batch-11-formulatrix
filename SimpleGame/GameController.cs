namespace SimpleGame;

public class GameController
{
	private List<IPlayer> _players = new();
	public GameController(IPlayer a, IPlayer b)
	{
		_players.Add(a);
		_players.Add(b);
	}
	public int TotalPlayer()
	{
		return _players.Count();
	}
	public bool AddPlayer(IPlayer player)
	{
		if(_players.Contains(player))
		{
			return false;
		}
		_players.Add(player);
		return true;
	}
	public bool RemovePlayer(IPlayer player)
	{
		if(_players.Contains(player))
		{
			_players.Remove(player);
			return true;
		}
		return false;
	}
	public string CheckPlayersName(int index)
	{
		return _players[index].GetName();
	}
}
