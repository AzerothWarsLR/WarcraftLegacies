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
  [InlineData(1, 1)]
  [InlineData(3, 3)]
  public void SkipTurns_IncreasesTurnCount(int turnsToSkip, int expectedTurn)
  {
    GameTimeManager.SkipTurns(turnsToSkip);

    Assert.Equal(expectedTurn, GameTimeManager.Turn);
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
