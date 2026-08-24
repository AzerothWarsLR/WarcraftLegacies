using MacroTools.GameTime;
using MacroTools.TestSupport;
using WarcraftLegacies.Source.Cheats;

namespace WarcraftLegacies.Source.Tests.Cheats;

public sealed class WorldDirectorTests
{
  [Theory]
  [InlineData(-1, 4, 1, 0)]
  [InlineData(-1, 4, -1, 3)]
  [InlineData(0, 4, 1, 1)]
  [InlineData(3, 4, 1, 0)]
  [InlineData(0, 4, -1, 3)]
  [InlineData(2, 4, -1, 1)]
  public void GetCycledIndex_MovesAndWraps(int currentIndex, int count, int direction, int expectedIndex)
  {
    Assert.Equal(expectedIndex, WorldDirector.GetCycledIndex(currentIndex, count, direction));
  }
}

public sealed class CheatNextTurnTests : GameTimeManagerTestsBase
{
  [Fact]
  public void Execute_ProcessesExactlyOneTurn()
  {
    var callbackCount = 0;
    GameTimeManager.RegisterOnTurn(1, () => callbackCount++);

    var result = new CheatNextTurn().Execute(null!);

    Assert.Equal(1, GameTimeManager.Turn);
    Assert.Equal(1, callbackCount);
    Assert.Equal("Historical Turn: 1", result);
  }
}
