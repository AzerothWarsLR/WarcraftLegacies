using MacroTools.GameTime;
using MacroTools.TestSupport;

namespace MacroTools.Tests.GameTime;

[Collection(nameof(GameTimeManagerCollection))]
public sealed class GameTimeManagerTests : IDisposable
{
  public GameTimeManagerTests()
  {
    GameTimeManagerTest.Reset();
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(60, 1)]
  [InlineData(120, 2)]
  [InlineData(59, 0)]
  [InlineData(119, 1)]
  public void ConvertGameTimeToTurn_ReturnsNumberOfCompletedTurns(int gameTime, int expectedTurn)
  {
    var result = GameTimeManager.ConvertGameTimeToTurn(gameTime);

    Assert.Equal(expectedTurn, result);
  }

  [Theory]
  [InlineData(0, 0, 0)]
  [InlineData(1, 1, 60)]
  [InlineData(3, 3, 180)]
  public void SkipTurns_IncreasesTurnCountAndGameTime(int turnsToSkip, int expectedTurn, float expectedGameTime)
  {
    GameTimeManager.SkipTurns(turnsToSkip);

    Assert.Equal(expectedTurn, GameTimeManager.GetTurn());
    Assert.Equal(expectedGameTime, GameTimeManager.GetGameTime());
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, 1)]
  [InlineData(3, 1)]
  public void GameStarted_FiresOnFirstTurn(int turnsToSkip, int expectedCalls)
  {
    // Arrange
    var callCount = 0;
    GameTimeManager.GameStarted += (_, _) => callCount++;

    // Act
    GameTimeManager.SkipTurns(turnsToSkip);

    // Assert
    Assert.Equal(expectedCalls, callCount);
  }

  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, 1)]
  [InlineData(3, 3)]
  public void TurnEnded_FiresOnEveryTurn(int turnsToSkip, int expectedCalls)
  {
    // Arrange
    var callCount = 0;
    GameTimeManager.TurnEnded += (_, _) => callCount++;

    // Act
    GameTimeManager.SkipTurns(turnsToSkip);

    // Assert
    Assert.Equal(expectedCalls, callCount);
  }

  public void Dispose()
  {
    GameTimeManagerTest.Reset();
  }
}
