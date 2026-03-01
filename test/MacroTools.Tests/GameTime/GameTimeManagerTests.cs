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

  public void Dispose()
  {
    GameTimeManagerTest.Reset();
  }
}
