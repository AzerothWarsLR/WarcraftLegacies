using MacroTools.GameTime;
using MacroTools.TestSupport;

namespace MacroTools.Tests.GameTime;

public sealed class TurnSchedulerTests : GameTimeManagerTestsBase
{
  private readonly TurnScheduler _scheduler = new();

  [Fact]
  public void Process_RemovesFinishedCallbacksWhileIterating()
  {
    // Arrange
    var callCount = 0;
    _scheduler.Register(1, () => callCount++, end: 1);
    _scheduler.Register(1, () => callCount++);
    _scheduler.Register(1, () => callCount++, end: 1);

    // Act
    _scheduler.Process(1);

    // Assert
    Assert.Equal(3, callCount);
    Assert.Single(_scheduler.Callbacks);
  }
}
