using Moq;

namespace SimpleGame.Test;

public class GameControllerTest
{
	private GameController _gameController;
	private Mock<IPlayer> playerA;
	private Mock<IPlayer> playerB;
	[SetUp]
	public void GameController()
	{
		playerA = new();
		playerA.Setup(p => p.GetName()).Returns("Sanan");
		playerB = new();
		playerB.Setup(p => p.GetName()).Returns("Ita");
		_gameController = new(playerA.Object, playerB.Object);
		
	}

	[Test]
	public void TotalPlayer_ReturnsTwo()
	{
		//Arrange
		int expected = 2;
		
		//Act
		int result = _gameController.TotalPlayer();
		
		//Assert
		Assert.That(result, Is.EqualTo(expected));
	}
	
	[Test]
	public void AddPlayer_PlayerAdded_NewPlayer()
	{
		//Arrange
		Mock<IPlayer> newPlayer = new();
		bool expected = true;
		int expectedPlayer = 3;
		//Act
		bool result = _gameController.AddPlayer(newPlayer.Object);
		int resultPlayer = _gameController.TotalPlayer();
		//Assert
		Assert.AreEqual(expected, result);
		Assert.AreEqual(expectedPlayer, resultPlayer);
	}
	[Test]
	public void AddPlayer_AddFailed_PlayerExist()
	{
		//Arrage
		bool expected = false;
		//Act
		bool result = _gameController.AddPlayer(playerA.Object);
		//Assert
		Assert.AreEqual(expected, result);
	}
	[Test]
	public void CheckPlayersName_CorrectName_PlayerExist()
	{
		//Arrange
		string expected = "Sanan";
		int index = 0;
		//Act
		string result = _gameController.CheckPlayersName(index);
		//Assert
		Assert.AreEqual(expected, result);
		Assert.AreEqual(index > 0 || index < 100, true);
	}
}