using MacroTools.GameTime;
using MacroTools.TestSupport;

namespace MacroTools.Tests.GameTime;

public sealed class GameTimeManagerTests : GameTimeManagerTestsBase
{
  [Theory]
  [InlineData(0, 0)]
  [InlineData(1, 1)]
  [InlineData(3, 3)]
  public void SkipTurns_IncreasesTurnCount(int turnsToSkip, int expectedTurn)
  {
    GameTimeManager.SkipTurns(turnsToSkip);

    Assert.Equal(expectedTurn, GameTimeManager.Turn);
  }
}
